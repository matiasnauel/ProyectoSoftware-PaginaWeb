//Registrar el usuario
var formulario = document.getElementById('formulario');

//Crear un usuario en  firebase
formulario.addEventListener('click', function(e) {
    e.preventDefault();
    console.log("me diste un click");
    var datos = new FormData(formulario);

    firebase.auth().createUserWithEmailAndPassword(datos.get("email"), datos.get("contraseña"))
        .then(function() {
            Verificar();
        })
        .catch(function(error) {
            // Handle Errors here.
            var errorCode = error.code;
            var errorMessage = error.message;
            console.log(errorCode);
            console.log(errorMessage);



        });

});

// //Validar usuario por gmail para que le llegue por su correo 
// function Verificar() {
//     var user = firebase.auth().currentUser;

//     user.sendEmailVerification().then(function() {
//         console.log("enviando correo");
//     }).catch(function(error) {
//         console.log(error);
//     });
// }
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
            console.log(uid);
            var providerData = user.providerData;
            // ...
            //devuelve el token del usuario
            user.getIdToken().then(function(data) {
                console.log(data)
            });

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
        location.href = "PantallaPrincipal.html";
    }
}