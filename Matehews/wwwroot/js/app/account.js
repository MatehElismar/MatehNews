'use strict'
//La url debe estar en otro archivo
var url = `${URL}/Account`


function getUser(){
  return JSON.parse(localStorage.getItem("user"));
}

function setUser(user){
  return localStorage.setItem("user", JSON.stringify(user));
}

function removeUser(){
  return localStorage.removeItem("user");
} 

function register(){
  //get data
  let form = new FormData(document.querySelector("#register-form")); 
 
  // Do the request
  fetch('https://localhost:5001/Account/Register', {method: 'POST', body: form})
    .then(res=>res.json())
    .then(res=>{
      if(res.logged == true){
        setUser(res)
          window.location = 'https://localhost:5001/'
      }
      console.log(res)
    })
}

function login(e){ 
  var form = new FormData(document.querySelector('#login-form'));
  console.log('form: ', form);
  // Do the request
  fetch('https://localhost:5001/Account/Login', {method: 'POST', body: form }).then(res => res.json()).then(res=>{
    if(res.logged == true){
      setUser(res)
        window.location = 'https://localhost:5001/'
    }
    console.log(res)
  })
}

function logout(){
  let user = getUser();
  fetch('https://localhost:5001/Account/Logout', {method: 'POST', body: JSON.stringify(user)})
    .then(res=>res.text())
    .then((res)=>{
      console.log(res)
     if(res == 'isLogout'){
       removeUser()
        window.location = "https://localhost:5001/"
     }
     else{
        alert("Hubo problemas con el logout, revise la consola");
     }
  })
  .catch(err=>{console.log('eror: ', err)})
}

function isLogged(next, error?){
  let user = getUser();
   fetch('https://localhost:5001/Account/IsLogged', { method: 'POST', body: JSON.stringify(user) })
    .then(res=> res.text())
    .then((res)=>{
       if(res == 'logged'){
          return next();//si esta loggeado ejecutamoss un callback 
        }
        else{
         alert("No esta usted loggeado; El Proceso fallo Exitosamente");
          if(error!= null)
            error();
        } 
   })
    
}
