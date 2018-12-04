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

function postRequest(url, data?, callback?, error?){
   //Option of request
   let opts = {
      method: "post",
      body: (data == null || data = undefined) ? {} : data,
      header: { 'content-type' : 'application/json' }
    };

    //Do the request
    fetch(url, opts)
      .then(res)=>{  
        setUser(res.json())
        console.log(res);  
        console.log("Response as JSON", res.json());
        callback();
        return res;
      }
      .catch(error)=>{ 
        console.log(error);
        error();
        return error;
      };
};

function register(){
  //get data
  let form = querySelector("#register-form"); 
  postRequest(`${url}/Login`, FormData(form));
}

function login(){
  //get data
  let form = querySelector("#login-form");
  postRequest(`${URL}/Login`, FormData(form))
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
