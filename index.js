console.log('hos');

document.addEventListener('DOMContentLoaded', async () => {

    //Usuario -----------------------------------------------------------------------------------

    //Busca la ID en la URL y la guarda
    console.log(`Consiguiendo Usuario...`);
    const params = new URLSearchParams(window.location.search); //id=1&usuario=1
    const idUsuario = params.get('usuario') //1

    let usuario = null;
    
    //Si hay id, se conecta a mongo y llena la variable 'usuario'
    if (idUsuario) {
        console.log(`Usuario Conseguido: ${idUsuario}`);
        console.log(`Intentando conectar a: http://localhost:2006/api/usuarios/${idUsuario}`);
        const resUser = await fetch(`https://fnviajes.onrender.com/api/usuarios/${idUsuario}`);
        usuario = await resUser.json();
        console.log(usuario);

        botonesUsuario(idUsuario);
        if (usuario) {
            saludarUsuario(usuario);
        }

        //Boton ingresar
        const aCuenta = document.getElementById("a-boton-cuenta");
        aCuenta.href = "./index.html";
        const imgLogin = document.getElementById("boton-cuenta");
        imgLogin.src = "../../imagenes-principal/imagen-logout.png";
        
    } else {
        console.log(`No se encontro usuario`);
    }

    //Viajes -----------------------------------------------------------------------------------

    console.log(`Consiguiendo Viajes:`);
    console.log(`Intentando conectar a: http://localhost:2006/api/viaje/todos`);
    const res = await fetch(`https://fnviajes.onrender.com/api/viaje/todos`);
    const viajes = await res.json();
    console.log(viajes);

    viajes.forEach(viaje => {

        const contenidoViajes = document.getElementById("contenido-viajes");

        const divViaje = document.createElement("div");
        divViaje.classList.add('viaje'); 

        const aDivViaje = document.createElement('a');
        aDivViaje.href = `./instancias/viaje/viaje.html?id=${viaje.id}`;

        const imgViaje = document.createElement("img");
        imgViaje.src = `./${viaje.img}`;

        const pViaje = document.createElement('p');
        // Traslasierra Salvaje: Caminata entre Ríos de Montaña - Córdoba / San Luis
        pViaje.textContent = `${viaje.nombre}: ${viaje.desc} - ${viaje.lugar}`

        const divBotonViaje = document.createElement('div');
        divBotonViaje.classList.add('div-boton');

        const aViaje = document.createElement('a');
        aViaje.classList.add('boton');
        aViaje.href = `./instancias/viaje/viaje.html?id=${viaje.id}`;
        
        aViaje.textContent = `Ver`;
        
        if (usuario) {
            aDivViaje.href += `&usuario=${usuario.id}`;
            aViaje.href += `&usuario=${usuario.id}`;
        }

        contenidoViajes.appendChild(divViaje);
        divViaje.appendChild(aDivViaje);
        aDivViaje.appendChild(imgViaje);
        divViaje.appendChild(pViaje);
        divViaje.appendChild(divBotonViaje);
        divBotonViaje.appendChild(aViaje);
    });

    
});

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
