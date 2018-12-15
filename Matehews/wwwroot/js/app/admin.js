'use strict' 
//#region Add post
function addPost(){
    var user = getUser();
    var post = {
        title: $('#title').val(),
        review: $('#review').val(),
        content: $('#froala-editor').froalaEditor('html.get', true),
        author: user.id,
        categorieName: $('.selectedCategorie').html() 
    }
    $.ajax({
        url: `${URL}/Admin/AddPost`, 
        type: 'POST', // add this
        data: JSON.stringify({user: getUser(), post: post}),
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
    console.log('categorie Selected', $('.selectedCategorie').html());
}

function updatePost(){
    var user = getUser();
    var post = {
        title: $('#title').val(),
        review: $('#review').val(),
        content: $('#froala-editor').froalaEditor('html.get', true),
        author: user.first +' '+ user.last,
        categorieName: $('.selectedCategorie').html() 
    }
    $.ajax({
        url: `${URL}/Admin/UpdatePost`, 
        type: 'POST', // add this
        data: JSON.stringify(post),
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
            console.error(err)
        }
    })
    console.log(post);
}

function changeCategorie(event){  
    $('.selectedCategorie').removeClass('selectedCategorie')
    $('#'+ event.target.id).addClass('selectedCategorie');
    $('#selectedCat').html(event.target.innerHTML) 
}

//#endregion

//#region UpdatePosts
function searchPosts(){
    let authorName = $('#selectedUser').html()
     var n = authorName.indexOf("(") + 1; 
    var m = authorName.indexOf(")");
    let idAuthor = authorName.substring( n, m);
    console.log(idAuthor)

    var post = {
        id: $('#id').val(),
        title:$('#title').val(),
        review: $('#review').val(), 
        author: idAuthor 
    } 
    console.log('authorName', authorName)
    console.log('user ', getUser())
    console.log('post ', post)
    $.ajax({
        url: `${URL}/Admin/SearchPostsa`, 
        type: 'POST', // add this
        data: { user: getUser(), post: post},
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

function fillTable(results){
    if(results.length <= 0){
        alert('no se encontraron resultados')
    }
    else{ 
       results.forEach((post, index)=>{
            var row = 
            `
                <tr>
                <th scope="row">${post.id}</th>
                <td>${post.title}</td>
                <td>${post.review}</td>
                <td>${post.author}</td>
                <td>${post.datetimePosted}</td>
                </tr>
            `;
            $('#results-table-body').append(row);
       })
           
    }
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