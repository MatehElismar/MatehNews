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
      else{
        alert("error: "+ res)
      }
      console.log(res)
    })
}

function login(){ 
  var form = new FormData(document.querySelector('#login-form'));
  console.log('form: ', form);
  // Do the request
  fetch(`${URL}/${controller}/Login`, {method: 'POST', body: form })
  .then(res => res.json())
  .then(res=>{
    if(res.logged == true){
      setUser(res)
        if(res.accessKey == 100)
        window.location = `${URL}/Admin/CPanel`;
    }
    else{
      alert('error: '+ res.first)
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
          window.location = URL;
        }
        else{
          console.log('el proceso ha sido exitosamente fallido')
        }
    }
  });
}

function isLogged(next, error){
  let user = getUser(); 

   $.ajax({
    url: `${URL}/${controller}/IsLogged`,
    type: 'POST', // add this
    data: JSON.stringify(user), 
    contentType: "application/json; charset=utf-8",//Recuerda siempre poner los headers correspondientes
    success: function (res) {
      console.log("Is Logged?", res);
      if(res == true){  
        return next(user);//si esta loggeado ejecutamoss un callback 
      }
      else{
       console.log("No esta usted loggeado; El Proceso fallo Exitosamente");
        if(error!= null)
          error();
      } 
    },
    error: ()=>{
      console.log("No esta usted loggeado; El Proceso fallo Exitosamente");
        if(error!= null)
          error();
    }
  });
}

function redirectIfNoLogged(){
  for(let i = 0; i < ONLY_USER_PATHS.length(); i++){
    if(window.location.pathname == ONLY_USER_PATHS[i]){
       isLogged(
         (user)=>{ console.log("this user is logged");},
         (err)=>{
          window.location = 'https://localhost:5001/Home/NotFound'
         })
        return null;
      }
   }
} 

function isOnlyAdminPage(){
  isLogged(
    (user)=>{
      console.log(isAdmin())
        if(isAdmin()){  console.log('Este usuario tiene acceso')   } 
      else{
        window.location = 'https://localhost:5001/Home/NotFound'
      }
    },
    ()=>{ window.location = 'https://localhost:5001/Home/NotFound'}  
  )
}

function isAdmin(){
  let user = getUser()
  console.log(user);
  if(user == null){ return false; }
  return (user.accessKey == 100) 
}
