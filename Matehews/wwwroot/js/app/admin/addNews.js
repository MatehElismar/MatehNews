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
            type: 'POST', // add this 
            url: `${URL}/Admin/AddPost`, 
            body: JSON.stringify({post: post, user: getUser()}),
            contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            dataType: 'json',
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
        // console.log("I am here")
       $.ajax({
           url: `${URL}/Admin/Actualizar`,
           type: 'post',
           body: JSON.stringify({user: getUser(), post: {id: 2323}}),
           contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success: (res)=>{
                console.log(res);
            },
            error: (error)=>{
                console.error(error);
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
