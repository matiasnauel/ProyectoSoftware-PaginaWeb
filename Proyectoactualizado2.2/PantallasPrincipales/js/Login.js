var singupForm = document.querySelector('#SingUpForm');
singupForm.addEventListener('submit', (e) => {
    e.preventDefault();
    var email = document.querySelector('#email').value;
    var contraseña = document.querySelector('#contraseña').value;

    auth.createUserWithEmailAndPassword(email, contraseña)
        .then(userCredential => {
            console.log("sing up");
        })


});
//Google login