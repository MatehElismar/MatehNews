function addComment(){ 
    if(!getUser()){
        alert('Para comentar necesita registrarse')
    }
    else{
        let comment = {
            user: { id: getUser().id },
            content : $('#message').val(),
            postID : $('#postID').val()
    
        }
        console.log('Posting the comment', comment)
    
        $.ajax({
            url: `${URL}/Post/AddComment`, 
            type: 'POST', // add this
            data: JSON.stringify(comment),
            contentType: "application/json",//Recuerda siempre poner los headers correspondientes,
            dataType: 'json',
            success : (res)=>{
                console.log(res)
                if(res > 0){
                    comment.id = res
                    showComment(comment)
                }
            },
            error: (err)=>{
                console.log(err)
            } 
    
        })
    }
}

function showComment(comment){
    var container = $("#comments-container");
    let children = `
    <li class="single_comment_area">
            <!-- Comment Content -->
            <div class="comment-content d-flex">
                <!-- Comment Author -->
                <div class="comment-author">
                    <img src="~/newspaper-template/img/bg-img/31.jpg" alt="author">
                </div>
                <!-- Comment Meta -->
                <div class="comment-meta">
                    <a href="#" class="post-author">@Html.DisplayFor(modelItem =>replie.user.username)</a>
                    <a href="#" class="post-date">April 15, 2018</a>
                    <p>@Html.DisplayFor(modelItem =>replie.content)</p>
                </div>
            </div>
        </li>`

    let li =
    `
    <li class="single_comment_area">
    <!-- Comment Content -->
    <div class="comment-content d-flex">
        <!-- Comment Author -->
        <div class="comment-author">
            <img src="~/newspaper-template/img/bg-img/30.jpg" alt="author">
        </div>
        <!-- Comment Meta -->
        <div class="comment-meta">
            <a href="#" class="post-author">${getUser().fullName}</a>
            <a href="#" class="post-date">April 15, 2018</a>
            <p>${comment.content}</p>
        </div>
    </div>
    <div class="d-flex align-items-center post-like--comments">
            <a onclick="likeComment()" href="#" class="post-like"><img src="~/newspaper-template/img/core-img/like.png" alt=""> <span>Me Gusta</span></a>
            <a onclick="responseComment()" href="#poster-comment" class="post-comment"><img src="~/newspaper-template/img/core-img/chat.png" alt=""> <span>Responder</span></a>
        </div>
    <ol class="children"> 
    </ol>
    `

    $(container).append(li);
}


function likeComment(){
    $.ajax({
        url: `${URL}/Post/LikeComment`, 
        type: 'POST', // add this
        data: JSON.stringify(comment),
        contentType: "application/json",//Recuerda siempre poner los headers correspondientes,
        dataType: 'json',
        success : (res)=>{
            console.log(res) 
        },
        error: (err)=>{
            console.log(err)
        } 

    })
}

function Reply() {
    
}

function responseComment(){
    $.ajax({
            url: `${URL}/Post/ResponseComment`, 
            type: 'POST', // add this
            data: JSON.stringify(comment),
            contentType: "application/json",//Recuerda siempre poner los headers correspondientes,
            dataType: 'json',
            success : (res)=>{
                console.log(res) 
            },
            error: (err)=>{
                console.log(err)
            } 
    
        })
}