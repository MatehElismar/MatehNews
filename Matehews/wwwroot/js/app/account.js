'use strict'
//La url debe estar en otro archivo
var url = `${URL}/Account`


function getUser(){
  return JSON.pase(localStorage.getItem("user"));
}

function setUser(user){
  return localStorage.setItem("user", JSON.stringify(user));
}

function removeUser(){
  return localStorage.removeItem("user");
}

function postRequest(url, data, callback, error){
   //Option of request  
   let opts = {
      method: "POST",
      body: (data == null || data == undefined) ? {} : data,
      header: { 'content-type' : 'application/json' }
    };

    //Do the request
    return fetch(url, opts) 
      .then((res)=>{  
        setUser(res)
        console.log(res.text());  
        // console.log("Response as JSON", res.body.getReader())
        // if(callback != null || undefined){
        //   callback();
        // }
        
        // return res;
        return res;
      })
      .then((data)=>{console.log("data: ", data)})
      .catch((err)=>{ 
        console.log("Error 2323: ", err); 
        if(error != null || error != undefined)
          { error(); }
        return error;
      })
}

function register(){
  //get data
  let form = document.querySelector("#register-form"); 
  postRequest(`${url}/Register`, new FormData(form));
}

function login(e){ 
  //get data
  let form = document.querySelector("#login-form");
  postRequest(`${url}/Login`, new FormData("Hola malola")) 
}

function logout(){
  let user = getUser();
  postRequest(`${url}/Logout`, user.ID, (res)=>{
     if(res == true){
        window.location = "https://localhost:5001/"
     }
     else{
        alert("Hubo problemas con el logout, revise la consola");
     }
  })
}

function isLogged(){
  let user = getUser();
  postRequest(`${url}/IsLogged`, user.ID, (response)=>{
    if(response){
      removeUser();
    }
    else{
     alert("Hubo problemas con el logout, revise la consola");
    }
  })
}
