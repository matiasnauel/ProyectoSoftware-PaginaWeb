window.onload = function() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/TraerProductosPublicaciones?CANTIDAD=" + localStorage.getItem("offset"),




        dataType: "json",
        success: function(data) {




            $.each(data, function(i, item) {
                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "A�adir Al Carrito";
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);

                $('#contenedor').append(div);






            });



        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }

    });


}



function VerMas() {
    var offset = parseInt(localStorage.getItem("offset"));
    offset = offset + 6;
    localStorage.setItem("offset", `${offset}`);
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/TraerProductosPublicaciones?CANTIDAD=" + localStorage.getItem("offset"),




        dataType: "json",
        success: function(data) {
            $.each(data, function(i, item) {
                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "A�adir Al Carrito";
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                $('#contenedor').append(div);






            });



        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }




    });



}




var buscador = document.getElementById('formulario');
buscador.addEventListener('submit', function(e) {
    e.preventDefault();
    var filtro = document.getElementById("search").value;
    var maestro = document.getElementById("maestro");
    var contenedor = document.getElementById("contenedor");
    var paginacion = document.getElementById("paginacion");
    maestro.remove(contenedor);
    maestro.remove(paginacion);
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltro?filtro=" + filtro,




        dataType: "json",




        success: function(data) {
            var maestro2 = document.createElement('div');
            maestro2.className = "col-md-12";
            maestro2.id = "maestro";
            var divcontenedor = document.createElement('div');
            divcontenedor.className = "w3-row-padding";
            divcontenedor.id = "contenedor";
            $.each(data, function(i, item) {







                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "A�adir Al Carrito";
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                divcontenedor.append(div);
                $('#panel').append(maestro2);
                maestro2.append(divcontenedor);





            });
        }



    });
});

function llenarLocalStorage(publicacionID) {
    localStorage.setItem("publicacionID", parseInt(publicacionID));

}



function BuscarDescripcion(descripcion) {
    var maestro = document.getElementById("maestro");
    var contenedor = document.getElementById("contenedor");
    var paginacion = document.getElementById("paginacion");
    maestro.remove(contenedor);
    maestro.remove(paginacion);
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltroDescripcion?filtro=" + descripcion,




        dataType: "json",
        success: function(data) {
            var maestro2 = document.createElement('div');
            maestro2.className = "col-md-12";
            maestro2.id = "maestro";
            var divcontenedor = document.createElement('div');
            divcontenedor.className = "w3-row-padding";
            divcontenedor.id = "contenedor";
            $.each(data, function(i, item) {

                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "A�adir Al Carrito";
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                divcontenedor.append(div);
                $('#panel').append(maestro2);
                maestro2.append(divcontenedor);




            });

        }

    });
}



function BuscarCategoria(categoria) {
    var maestro = document.getElementById("maestro");
    var contenedor = document.getElementById("contenedor");
    var paginacion = document.getElementById("paginacion");
    maestro.remove(contenedor);
    maestro.remove(paginacion);
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltroCategoria?filtro=" + categoria,




        dataType: "json",
        success: function(data) {
            var maestro2 = document.createElement('div');
            maestro2.className = "col-md-12";
            maestro2.id = "maestro";
            var divcontenedor = document.createElement('div');
            divcontenedor.className = "w3-row-padding";
            divcontenedor.id = "contenedor";
            $.each(data, function(i, item) {

                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "A�adir Al Carrito";
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                divcontenedor.append(div);
                $('#panel').append(maestro2);
                maestro2.append(divcontenedor);




            });

        }

    });
}


//----------------------------------------------------- FIREBASE ------------------------------------------------------------------//v
var dropDownContenido = document.getElementById('dropdow-contentId');



//--Boton cerrar---/
function Cerrar() {
    firebase.auth().signOut().then(function() {
        console.log("Finalizo sesion");
        location.href = "/Proyectoactualizado2.2/LoginTP/login.html";
    }).catch(function(error) {
        console.log(error);
    });
}

function IniciarSesion() {
    location.href = "/ProyectoActualizado/Proyectoactualizado2.2/LoginTP/login.html";
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
//-- aparese si el usuario se registra --//
function Aparece(user) {
    //Si se verifico el usuario que rediriga la pagina
    if (user.uid != null) {
        dropDownContenido.innerHTML = `<a href="#" onclick="Cerrar();">Cerrar Sesion</a>`;
    }
    console.log("hola");
}
Aparece();