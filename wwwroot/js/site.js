jQuery(document).ready(function () {
    particlesJS.load('particles-js', '/assets/particles.json', function () {
        console.log('callback - particles.js config loaded');
    });
});

// connect to signalr
//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/chatHub")
//    .build();

////receive the message
//connection.on("ReceiveMessage", (user, message) => {
//    const rec_msg = user + ": " + message;
//    const li = documnet.createElement("li");
//    li.textContent = rec_msg;
//    document.getElementById("messagesList").appendChild(li);
//})

//connection.start().catch(err => console.error(err.toString()));

//// send the message
//document.getElementById("sendMessage").addEventListener("click", event => {
//    const user = document.getElementById("userName").value;
//    const message = document.getElementById("userMessage").value;
//    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
//    event.preventDefault();
//}); 