'use strict' 
const controller = 'Account'

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
  fetch(`${URL}/${controller}/Register`, {method: 'POST', body: form})
    .then(res=>res.json())
    .then(res=>{
      if(res.logged == true){
        setUser(res)
          // window.location = URL;
      }
      console.log(res)
    })
}

function login(e){ 
  var form = new FormData(document.querySelector('#login-form'));
  console.log('form: ', form);
  // Do the request
  fetch(`${URL}/${controller}/Login`, {method: 'POST', body: form })
  .then(res => res.json())
  .then(res=>{
    if(res.logged == true){
      setUser(res)
        // window.location = URL;
    }
    console.log(res)
  })
}

function logout(){
  //Get the user form the localStorage
  let user = getUser();  

  //Do the request
  $.ajax({
    url: `${URL}/${controller}/Logout`,
    type: 'POST', // add this
    data: JSON.stringify(user),
    contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
    success: function (res) {
      console.log(res);
        if(res){
          removeUser();
          // window.location = URL;
        }
        else{
          console.log('el proceso ha sido exitosamente fallido')
        }
    }
  });
}

function isLogged(next, error){
  let user = getUser();
   fetch(`${URL}/${controller}/IsLogged`, { method: 'POST', body: JSON.stringify(user) })
    .then(res=> res.text())
    .then((res)=>{
       if(res == 'logged'){
          return next();//si esta loggeado ejecutamoss un callback 
        }
        else{
         console.log("No esta usted loggeado; El Proceso fallo Exitosamente");
          if(error!= null)
            error();
        } 
   }) 
}

function redirectIfNoLogged(){
  for(let i = 0; i < ONLY_USER_PATHS.length(); i++){
    if(window.location.pathname == ONLY_USER_PATHS[i]){
       isLogged(
         ()=>{ console.log("this user is logged");},
         ()=>{
          window.location = 'https://localhost:5001/Home/NotFound'
         })
        return null;
      }
   }
} 

function isAdmin(){
  return getUser().accesKey == true;
}
