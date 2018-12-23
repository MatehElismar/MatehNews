'use strict'

//#region Add post
function setEditorHtml(content){
    $('#froala-editor').froalaEditor('html.set', content)
}

async function addPost(){ 
    let formData = new  FormData();
    let files = document.querySelector('#portrait').files;
    for (var i = 0; i != files.length; i++) {
        console.log(files[i]);
        formData.append("portrait", files[i]);
    }
    
    
    let user = getUser();
    let post = {};
    post.title = $('#title').val();
    post.review = $('#review').val();
    post.categorieName = $('#selectedCat').html();
    post.content = $('#froala-editor').froalaEditor('html.get', true);
    post.author = user.id;
    post.userID = user.id;
    post.userAccessKey = user.accessKey;
 
    await Object.keys(post)
    .forEach(key=>{
        formData.append(key, post[key]);
    }) 

    fetch(`${URL}/Admin/AddPost`, {method: 'POST', body: formData })
    .then(res => res.json())
    .then(res=>{ 
            alert('Proceso Exitoso')   
            alert(err); 
        console.log(res) 
    })
    .catch(err=>console.log(err)) 
} 

async function updatePost(){

    let formData = new  FormData();
    let files = document.querySelector('#portrait').files;
    for (var i = 0; i != files.length; i++) {
        console.log(files[i]);
        formData.append("portrait", files[i]);
    }

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

    await Object.keys(post)
    .forEach(key=>{
        formData.append(key, post[key]);
    }) 

    fetch(`${URL}/Admin/UpdatePost`, {method: 'POST', body: formData })
    .then(res => res.json())
    .then(res=>{ 
            alert('Proceso Exitoso')   
            alert(err); 
        console.log(res) 
    })
    .catch(err=>{alert('Se ha encontrado un erro; revise la consola de depuracion'); console.log(err)}) 
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
