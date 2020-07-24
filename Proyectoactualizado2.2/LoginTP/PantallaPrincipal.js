var contenido = document.getElementById('contenido');


function Cerrar() {
    firebase.auth().signOut().then(function() {
        console.log("Finalizo sesion");
        location.href = "Login.html";
    }).catch(function(error) {
        console.log(error);
    });
}
//Agregar un Obsevador para obtener información del usuario ingresado a la pagina
function Observador() {
    firebase.auth().onAuthStateChanged(function(user) {
        if (user) {
            Aparece(user);
            // User is signed in.
            console.log("existe usuario activo");
            var displayName = user.displayName;
            var email = user.email;
            var emailVerified = user.emailVerified;
            var photoURL = user.photoURL;
            var isAnonymous = user.isAnonymous;
            var uid = user.uid;
            var providerData = user.providerData;
            // ...
            //devuelve el token del usuario
            user.getIdToken().then(function(data) {
                console.log(data)
            });
            console.log("hola");

        } else {
            // User is signed out.
            // ...
            console.log("no existe el usuario");
        }
    });
}
Observador();

function Aparece(user) {
    //Si se verifico el usuario que rediriga la pagina
    if (user.emailVerified == true) {
        contenido.innerHTML = `<button onclick="Cerrar();">Cerrar Sesion</button>`;
    }
}
Aparece();

//Obtener información del perfil de un usuario

function ObtenerDtosUser() {
    var user = firebase.auth().currentUser;
    if (user != null) {
        user.providerData.forEach(function(profile) {
            console.log("Sign-in provider: " + profile.providerId);
            console.log("  Provider-specific UID: " + profile.uid);
            console.log("  Name: " + profile.displayName);
            console.log("  Email: " + profile.email);
            console.log("  Photo URL: " + profile.photoURL);
        });
    }
}