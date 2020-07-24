// //----------------------------------------------------------------->
// var singupForm = document.querySelector('#SingUpForm');
// //Sing Up
// singupForm.addEventListener('submit', (e) => {
//     e.preventDefault();
//     var email = document.querySelector('#email').value;
//     var contraseña = document.querySelector('#contraseña').value;

//     auth.signInWithEmailAndPassword(email, contraseña)
//         .then(userCredential => {
//             location.href = "PantallaPrincipal.html";
//         })


// });

//Boton para acceder con google ----------------------------------->
const googleBoton = document.querySelector('#GoogleBoton');
var token = "";

googleBoton.addEventListener('click', e => {
    const provider = new firebase.auth.GoogleAuthProvider();
    auth.signInWithPopup(provider)
        .then(function(result) {
            token = result.credential.accessToken;
            var user = result.user;
            var Uids = user.uid;

            user.getIdToken().then(function(data) {
                //  loginAPIGoogle(data, Uids);


            });
        })
        .catch(erro => {
            console.log(erro);
        })
});

//----------------------------------------------------------------->
function loginAPIGoogle(data, Uids) {
    $.ajax({
        url: `https://localhost:44368/api/Autenticacion/getUser?uids=${Uids}`,
        dataType: 'json',
        type: 'GET',
        beforeSend: function(xhr) {
            xhr.setRequestHeader("Accept", "application/json");
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.setRequestHeader("Authorization", "Bearer " + data);
        },
        error: function(ex) {
            console.log(ex.status + " - " + ex.statusText);
        },
        success: function() {
            location.href = "";
        }
    });
}


//------------------------------------------------------------------>
//Restablecer contraseña
function RestablecerContraseña() {
    var email = document.querySelector('#email').value;
    var comentario = document.getElementById('comentario1');
    if (email == "") {

        comentario.innerHTML = `
                    <!-- Modal -->
                    <
                    div class = "modal fade"
                id = "myModal"
                role = "dialog" >
                <
                div class = "modal-dialog" >

                <!-- Modal content-->
                <
                div class = "modal-content" >
                <
                div class = "modal-header" >
                <
                button type = "button"
                class = "close"
                data - dismiss = "modal" > & times; < /button>

                <
                /div> <
                div class = "modal-body" >
                <
                p > Ingrese su correo electronico. < /p> <
                /div> <
                div class = "modal-footer" >
                <
                button type = "button"
                class = "btn btn-default"
                data - dismiss = "modal" > Cerrar < /button> <
                /div> <
                /div>

                <
                /div> <
                /div>
                `;

    } else {
        var auth = firebase.auth();
        var emailAddress = email;

        auth.sendPasswordResetEmail(emailAddress).then(function() {
            alert("Se ha enviado un correo a su cuenta, siga los pasos indicados");
        }).catch(function(error) {
            console.log(error);
        });
    }

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
        location.href = "../PantallasPrincipales/PaginaPrincipal.html";
    }
}