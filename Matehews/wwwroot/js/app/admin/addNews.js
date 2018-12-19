'use strict'

//#region Add post
function setEditorHtml(content){
    $('#froala-editor').froalaEditor('html.set', content)
}

function addPost(){ 
    let user = getUser();
    let post = {};
    post.title = $('#title').val();
    post.review = $('#review').val();
    post.categorieName = $('#selectedCat').html();
    post.content = $('#froala-editor').froalaEditor('html.get', true);
    post.author = user.id;

    //Do the requestd
    let opts = {}
    opts.url = `${URL}/Admin/AddPost`;
    opts.type = 'POST';
    opts.contentType = 'application/json'; 
    opts.data = JSON.stringify({user: getUser(), post: post});
    opts.success = (res)=>{
        alert('Proceso Exitoso')  
    };
    opts.error = (err)=>{
        alert(err);
    };

    $.ajax(opts)
} 

function updatePost(){
    var user = getUser();
    var post = {
        title: $('#title').val(),
        title: $('#title').val(),
        review: $('#review').val(),
        content: $('#froala-editor').froalaEditor('html.get', true),
        categorieName: $('#selectedCat').html(),
        status: $('#selectedSta').html(),
    }  
    post.id = parseInt($('#postID').html());
    post.author = user.id; 
    console.log(user)

    console.log('Post need update: ',post)

        // console.log("I am here")
       $.ajax({
           url: `${URL}/Admin/UpdatePost`,
           type: 'post',
           data: JSON.stringify({user: getUser(), post: post}),
           contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
            success: (res)=>{
                console.log(res);
                alert('Proceso Exitoso')
            },
            error: (error)=>{
                console.error(error);
                alert('Se ha encontrado un erro; revise la consola de depuracion')
            }
       })
}

function changeCategorie(event){  
    $('.selectedCategorie').removeClass('selectedCategorie')
    $('#'+ event.target.id).addClass('selectedCategorie');
    $('#selectedSta').html(event.target.innerHTML) 
} 

function changeStatus(event){  
    $('.selectedStatus').removeClass('selectedStatus');
    $('#'+ event.target.id).addClass('selectedStatus');
    $('#selectedSta').html(event.target.innerHTML) 
} 
//#endregion
