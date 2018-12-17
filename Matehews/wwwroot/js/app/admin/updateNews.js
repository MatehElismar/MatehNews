
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