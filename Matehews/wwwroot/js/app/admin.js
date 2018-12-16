'use strict' 
//#region Add post
function setEditorHtml(content){
    $('#froala-editor').froalaEditor('html.set', content)
}

function addPost(event){
    var user = getUser();
    var post = {
        title: $('#title').val(),
        review: $('#review').val(),
        content: $('#froala-editor').froalaEditor('html.get', true),
        categorieName: $('#selectedCat').html(),
    } 
    if(event.target.innerText == 'Publicar'){
        post.author = user.id;
        $.ajax({
            url: `${URL}/Admin/AddPost`, 
            type: 'POST', // add this 
            body: JSON.stringify({post: post, user: getUser()}),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success : (res)=>{
                console.log(res)
                if(res){
                    alert("Proceso Exitoso")
    
                }
                else{
                    alert("Process Failed. Please check the debug console")
                }
            },
            error: (err)=>{
                console.log(err)
            }
        })
    }
    else{
        post.id = parseInt($('#postID').html());
        $.ajax({
            url: `${URL}/Admin/UpdatePost`, 
            type: 'POST', // add this
            body: JSON.stringify({user: getUser(), post: post}),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success : (res)=>{
                console.log(res)
                if(res){
                    alert("Proceso Exitoso") 
                }
                else{
                    alert("Process Failed. Please check the debug console")
                }
            },
            error: (err)=>{
                console.log(err)
            }
        })
    }
} 

function changeCategorie(event){  
    $('.selectedCategorie').removeClass('selectedCategorie')
    $('#'+ event.target.id).addClass('selectedCategorie');
    $('#selectedCat').html(event.target.innerHTML) 
}

//#endregion

//#region UpdatePosts
function searchPosts(){
    var user = getUser();
    let authorName = $('#selectedUser').html()
     var n = authorName.indexOf("(") + 1; 
    var m = authorName.indexOf(")");
    let idAuthor = authorName.substring( n, m);
    console.log(idAuthor)

    var post = {
        id: parseInt($('#elid').val()),
        title: $('#eltitle').val(),
        review: $('#elreview').val(), 
        author: idAuthor
    }
    console.log('authorName', authorName)
    console.log('user ', getUser())
    console.log('post ', post)
    $.ajax({
        url: `${URL}/Admin/SearchPosts`, 
        type: 'POST', // add this
        data: JSON.stringify({user: getUser(), post:post}),
        contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
        success : (res)=>{
            console.log(res)
            if(res){
                fillTable(res)
                // alert("Proceso Exitoso")
            }
            else{
                alert("Process Failed. Please check the debug console")
            }
        },
        error: (err)=>{
            console.log(err)
        }
    })
}

function fillTable(results){
    if(results.length <= 0){
        alert('no se encontraron resultados')
    }
    else{ 
        $('#results-table-body').html("loading");
        results.forEach((post, index)=>{
            var row = 
            `
                <tr id="row${index}" onclick="selectPost(event)">
                <th class="id" scope="row">${post.id}</th>
                <td class="title">${post.title}</td>
                <td class="review">${post.review}</td>
                <td class="author">${post.author}</td>
                <td class="datetimePosted">${post.datetimePosted}</td>
                </tr>
            `;
            $('#results-table-body').append(row);
       })
           
    }
}


function selectPost(e){ 
    let selectedPost = {
        id: $(`#${e.target.parentNode.id} .id`).html(),
        title: $(`#${e.target.parentNode.id} .title`).html(),
        review: $(`#${e.target.parentNode.id} .review`).html(),
        author: $(`#${e.target.parentNode.id} .author`).html(),
        datetimePosted: $(`#${e.target.parentNode.id} .datetimePosted`).html(), 
    }
    let url = selectedPost.title.replace(' ', '-')
    window.location = `${URL}/Admin/UpdatePost?title=${url}`
}
    
    function changeUser(event){  
        $('.selectedUser').removeClass('selectedUser')
        $('#'+ event.target.id).addClass('selectedUser');
        $('#selectedUser').html(event.target.innerHTML) 
    }
//#endregion
//#region  Categories

var operation = ''
var selectedTarget = {}

function cancel(){
    $('#saveBtn').attr('disabled', true) 
    $('#cancelBtn').attr('disabled', true)
     $('#name').attr('readonly', 'readonly')
     $('#description').attr('readonly', 'readonly')
     operation = ''
}

function active(){
     $('#saveBtn').attr('disabled', false) 
    $('#cancelBtn').attr('disabled', false) 
     $('#name').removeAttr('readonly') 
     $('#description').removeAttr('readonly') 
}

function update(){
    if(operation != ''){
        alert('Cancele o Guarde la operacion actual')
    }
    else{
        operation = 'update'
        active(); 
    }
}

function save(){
    var categorie ={name: $('#name').val(), description: $('#description').val()} 
     if(operation == "update"){ 
        //update
        $.ajax({
            url: `${URL}/Admin/UpdateSection`,
            type: 'POST', // add this
            data: JSON.stringify({user: getUser(), categorie: categorie, lastname : selectedTarget.innerText}),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success: function (res) {
               if(res){
                   console.log('selectedTarget', selectedTarget)
                    $(selectedTarget).html(categorie.name)
                    alert('Categoria Actualizada')
                    cancel();
               }  
               else{
                   alert('Proceso fallido, revise la consola del servidor')
               }
            }
        });
    }
    else{
        
        //add
        $.ajax({
            url: `${URL}/Admin/AddSection`,
            type: 'POST', // add this
            data: JSON.stringify({user: getUser(), categorie: categorie, lastname : selectedTarget.innerText}),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success: function (res) {
                if(res){
                    var button = `
                        <button onclick="showInfo(event)" type="button" class="btn btn-danger">${categorie.name}</button>
                    `;
                    $('#categories-container').append(button) 
                    alert('Categoria Agregada')
                    cancel();
               }  
               else{
                   alert('Proceso fallido, revise la consola del servidor')
               }
            }
        }); 
    }
}

function add(){ 
   if(operation != ''){
       alert('Cancele o Guarde la operacion actual')
   }
   else{
       active();
       $('#name').val('')
       $('#count').val('')
       $('#description').val('')
   }
}

function showInfo(e){
    console.log(e)
    $('#updateBtn').attr('disabled', false)
    $('#name').val(e.target.innerText); 
    selectedTarget = e.target;
     $.ajax({
            url: `${URL}/Admin/GetSection`,
            type: 'POST', // add this
            data: JSON.stringify(e.target.innerText),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success: function (categorie) {
                console.log(categorie);  
                $('#description').val(categorie.description)
                $('#cantPosts').val(categorie.cantPosts)
            }
        }); 
};
//#endregion