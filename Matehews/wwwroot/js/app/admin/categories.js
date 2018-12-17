'use strict'
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