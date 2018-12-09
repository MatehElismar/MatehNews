'use strict'

// Add post
function addPost(){
    var user = getUser();
    var post = {
        title: $('#title').val(),
        review: $('#review').val(),
        content: $('#froala-editor').froalaEditor('html.get', true),
        author: user.first +' '+ user.last,
        categorieName: $('.selectedCategorie').html() 
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
        success : (res)=>{},
        error: (err)=>{}
    })
    console.log(post);
}

function changeCategorie(event){
    console.log('categorie Selected', $('.selectedCategorie').html());
    $('.selectedCategorie').removeClass('selectedCategorie')
    $('#'+ event.target.id).addClass('selectedCategorie');
    $('#selectedCat').html(event.target.innerHTML)
    console.log('categorie Selected', $('.selectedCategorie').html());
}