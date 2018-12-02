const socket = io('https://menudochat.herokuapp.com');
var user = {}

// Cuando el se conecte al servidor socker.io
socket.on('connect', ()=>{   
    // emitimos este evento para notificarle a los demas usuarios que nos conectamos a la sala
    socket.emit('chat:connect',user)
    })  

    // recibimos los usuarios conectados
    socket.on('chat:connected', (user)=>{
      // Si el usuario conectado soy yo
      console.log("user", user);
      if(socket.id == user.socket ){ 

          // otenemos desde el servidor losusuario que hasta el momento estan conectados 
          
          // http.GetUsers()
          // .subscribe((users:any)=>{
          //   users = users 
          //   console.log('conversation', users)
          // })

          http.GetConversation(user.name)
          .subscribe((conv)=>{
            users = conv.users
            messages = conv.messages
            messages.reverse() 

            if(users.length > 0)
              userTypping.msg = ' '

            // removemos nuestro usuario de la lista de usuarios local
            users.splice( users.findIndex(u => u._id == user._id), 1 )
            if( localStorage.getItem('first') == 'true' ){  
        // Mostramos en una notificacion la cantidad de usuarios conectados
              M.toast({html: `<bold>${users.length}<bold> usuarios le dan la bienvenida...`})
            }
          })
      }
      else{ 
        playNotificationSound()
        // Si el usuario que se conecta no esta en la lista, lo agregamos
        if(users.findIndex(x => x._id == user._id) == -1){
          users.push(user)
        }
        M.toast({html: `<strong>${user.name}</strong>  Se ha unido a la conversacion!!`})
        
      }
    })

    // recibimos al usuario desconectado
    socket.on('chat:disconnected', (socketID)=>{
      playNotificationSound()
      var user = users.find(u => u.socket == socketID)
       users.splice( users.findIndex(u => u.socket == socketID), 1 )
       M.toast({html: `~~ <strong>${user.name}</strong>  ha abandonado a la conversacion`})
     
    })

    socket.on('chat:message', (data)=>{
      playMsgSound()
      userTypping.msg =' '
      msgObject.output = true
      messages.unshift(data) 
    })

    socket.on('chat:typing', (username)=>{  
      // playTyppingSound()
      userTypping.sujeto = username
      console.log('userTypen', userTypping.sujeto)
      userTypping.msg = userTypping.sujeto + userTypping.predicado
      setInterval(()=>{
        userTypping.msg = ' '
      
      }, 5000)
    }) 
