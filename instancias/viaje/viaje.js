document.addEventListener('DOMContentLoaded', async () => {

    //Usuario -----------------------------------------------------------------------------------

    //Busca la ID en la URL y la guarda
    console.log(`Consiguiendo Usuario...`);
    const params = new URLSearchParams(window.location.search); //id=1&usuario=1
    const idUsuario = params.get('usuario'); //1
    const idViaje = params.get('id');

    let usuario = null;
    
    //Si hay id, se conecta a mongo y llena la variable 'usuario'
    if (idUsuario) {

        console.log(`Usuario Conseguido: ${idUsuario}`);
        console.log(`Intentando conectar a: http://localhost:2006/api/usuarios/${idUsuario}`);
        const resUser = await fetch(`http://localhost:2006/api/usuarios/${idUsuario}`);
        usuario = await resUser.json();
        console.log(usuario);

        botonesUsuario(idUsuario);

        if (usuario) {
            saludarUsuario(usuario);
        }

        //Boton ingresar
        const aCuenta = document.getElementById("a-boton-cuenta");
        aCuenta.href = `./viaje.html?id=${idViaje}`;
        const imgLogin = document.getElementById("boton-cuenta");
        imgLogin.src = "../../imagenes-principal/imagen-logout.png";

    } else {
        console.log(`No se encontro usuario`);
    }

    // Viaje ----------------------------------------------------------------------

    //Consigo la id del viaje
    const id = params.get('id');

    console.log(`Script funcionando con id: ${id}`);

    console.log(`Intentando conectar a: http://localhost:2006/api/viajes/${id}`);
    const res = await fetch(`http://localhost:2006/api/viajes/${id}`);
    const viajes = await res.json();
    console.log(viajes);
    
    await reemplazarCont(viajes);

    if (usuario != null) {
        const botonComprarYA = document.getElementById("comprarYA");
        botonComprarYA.addEventListener("click", async () => {
            const resAgregarAlCarrito = await fetch(`http://localhost:2006/api/agregarAlCarrito/${idUsuario}/${id}`);
            window.location.href = `http://localhost:5500/instancias/carritoDeCompras/carritoDeCompras.html?usuario=${idUsuario}`;
        });

        const botonAgregarCarrito = document.getElementById("botonAgregarCarrito");
        botonAgregarCarrito.addEventListener("click", async () => {
            const resAgregarAlCarrito = await fetch(`http://localhost:2006/api/agregarAlCarrito/${idUsuario}/${id}`);
            console.log(`Viaje ${id} agregado al carrito de ${usuario.nombre}`);
            alert("Elemento añadido al carrito");
        });
    }
});



async function reemplazarCont(viajes) {
    console.log('Reemplazando contenido...');

    const tituloViaje = document.getElementById("tituloViaje");
    console.log(viajes.nombre);
    tituloViaje.textContent = viajes.nombre;

    const localidadViaje = document.getElementById('localidadViaje');
    console.log(viajes.lugar);
    localidadViaje.textContent = `${viajes.lugar} - ${viajes.duracion} Dias`;

    const imgViaje = document.getElementById('imgViaje');
    console.log(viajes.img);
    imgViaje.src = `../../${viajes.img}`;
    
    const parrafoViaje1 = document.getElementById('parrafoViaje1');
    console.log(viajes.desc);
    parrafoViaje1.textContent = viajes.desc;
    
    const parrafoViaje2 = document.getElementById('parrafoViaje2');
    parrafoViaje2.textContent = "";

    const precioViaje = document.getElementById('precioViaje');
    console.log(viajes.precio);
    precioViaje.textContent = `$${viajes.precio}`;
}

function botonesUsuario(idUsuario) {
    //Establecer boton carrito de compras
    if (idUsuario) {
        const botonCarrito = document.getElementById("a-boton-carrito-compras");
        botonCarrito.href += `?usuario=${idUsuario}`;

        const botonFNViajes = document.getElementById("a-boton-logo");
        botonFNViajes.href += `?usuario=${idUsuario}`;
    }
}

function saludarUsuario(usuario) {
    const saludo = document.getElementById("saludoUsuario");
    saludo.textContent = `Hola, ${usuario.nombre} ${usuario.apellido}!`;
}