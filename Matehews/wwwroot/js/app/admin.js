'use strict'

// Add post
function addPost(){
    var post = {
        title: $('#Titulo').val(),
        content: $('#froala-editor').froalaEditor('html.get', true)
    }
    $.ajax({
        url: `${URL}/Admin/AddPost`, 
        type: 'POST', // add this
        data: JSON.stringify({user: getUser(), post: post}),
        contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
        success : (res)=>{
            console.log(res)
        },
        error: (err)=>{
            console.log(err)
        }
    })
    console.log(post);
}

function updatePost(){
    var post = {
        title: $('#Titulo').val(),
        content: $('#froala-editor').froalaEditor('html.get', true)
    }
    $.ajax({
        url: `${URL}/Admin/UpdatePost`, 
        type: 'POST', // add this
        data: JSON.stringify(post),
        contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
        success : (res)=>{},
        error: (err)=>{}
    })
    console.log(post);
}