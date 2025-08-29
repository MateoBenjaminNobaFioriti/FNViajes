document.addEventListener('DOMContentLoaded', async () => {

    //Consigue la lista de paquetes
    const listaPaquetes = document.getElementById("listaPaquetes");

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
        const resUser = await fetch(`http://localhost:2006/api/usuarios/${idUsuario}`);
        usuario = await resUser.json();
        console.log(usuario);
        botonesUsuario(idUsuario);

        if (usuario) {
            saludarUsuario(usuario);
        }

        //Boton ingresar
        const aCuenta = document.getElementById("a-boton-cuenta");
        aCuenta.href = "./carritoDeCompras.html";
        const imgLogin = document.getElementById("boton-cuenta");
        imgLogin.src = "../../imagenes-principal/imagen-logout.png";

    } else {
        console.log(`No se encontro usuario`);

        //Borra el frontend del carrito y muestra "No hay elementos"
        const columnaDer = document.getElementById("columnaDer");
        columnaDer.style.display = "none";

        const listaItems = document.getElementById("listaItems");
        listaItems.style.width = "100%";

        const divPaquete = document.createElement("div");
        divPaquete.classList.add("paquete");
        divPaquete.style.width = "100%";
        divPaquete.style.display = "flex";
        divPaquete.style.alignItems = "center";
        divPaquete.style.justifyContent = "center";


        const divTextoPaquete = document.createElement("div");
        divTextoPaquete.classList.add("textoPaquete");
        divTextoPaquete.style.width = "auto";
        divTextoPaquete.style.justifyContent = "center";

        const aTextoPaquete = document.createElement("a");
        aTextoPaquete.href = "../inicioSesion/inicioSesion.html";
        aTextoPaquete.textContent = "Iniciar sesion";
        aTextoPaquete.id = "a-boton-cuenta";
        aTextoPaquete.style.width = "100%";
        aTextoPaquete.style.border = "1px solid black";
        aTextoPaquete.style.marginTop = "2vh";
        aTextoPaquete.style.color = "black";

        const h2TextoPaquete = document.createElement("h2");
        h2TextoPaquete.textContent = `No hay usuario activo.`;
        h2TextoPaquete.style.textAlign = "center";
        h2TextoPaquete.style.width = "100%";

        listaPaquetes.appendChild(divPaquete);
        divPaquete.appendChild(divTextoPaquete);
        divTextoPaquete.appendChild(h2TextoPaquete);
        divTextoPaquete.appendChild(document.createElement("br"));
        h2TextoPaquete.appendChild(aTextoPaquete);

        return;
    }

    // Carrito ----------------------------------------------------------------------------

    

    let carritoUsuario = new Array();
    let montoTotal = 0;

    if (usuario.carrito.length > 0) {
        for (let i = 0; i < usuario.carrito.length; i++) {
            console.log(`Intentando conectar a: http://localhost:2006/api/viajes/${usuario.carrito[i]}`);
            const res = await fetch(`http://localhost:2006/api/viajes/${usuario.carrito[i]}`);
            const viaje = await res.json();
            carritoUsuario.push(viaje);
        }

        console.log(carritoUsuario);

        // Agrega un paquete por elemento en el carrito
        carritoUsuario.forEach((paquete, index) => {
            const divPaquete = document.createElement("div");
            divPaquete.classList.add("paquete");

            const divBorrarPaquete = document.createElement("div");
            divBorrarPaquete.classList.add("divBorrarPaquete");

            const aBorrarPaquete = document.createElement("a");
            aBorrarPaquete.id = "aBorrarPaquete";

            aBorrarPaquete.addEventListener("click", () => borrarElemento(index, idUsuario))
            
            const imgBorrarPaquete = document.createElement("img");
            imgBorrarPaquete.classList.add("imgBorrarPaquete");
            imgBorrarPaquete.src = "./imgs/cerrar.png";

            const divImgPaquete = document.createElement("div");
            divImgPaquete.classList.add("imgPaquete");

            const aImgPaquete = document.createElement("a");
            aImgPaquete.href = `http://localhost:5500/instancias/viaje/viaje.html?id=${paquete.id}&usuario=${usuario.id}`

            const imgPaquete = document.createElement("img");
            imgPaquete.src = `../../${paquete.img}`;

            const divTextoPaquete = document.createElement("div");
            divTextoPaquete.classList.add("textoPaquete");

            const h2TextoPaquete = document.createElement("h2");
            h2TextoPaquete.textContent = "x1";

            const h3TextoPaquete = document.createElement("h3");
            h3TextoPaquete.textContent = paquete.nombre;

            const divPrecioPaquete = document.createElement("div");
            divPrecioPaquete.classList.add("precioPaquete");

            const h3PrecioPaquete = document.createElement("h3");
            h3PrecioPaquete.textContent = "$ ";

            const h3PrecioPaquetePrecio = document.createElement("h3");
            h3PrecioPaquetePrecio.textContent = paquete.precio;
            montoTotal += paquete.precio;

            listaPaquetes.appendChild(divPaquete);
            
            divPaquete.appendChild(divBorrarPaquete);
            divBorrarPaquete.appendChild(aBorrarPaquete);
            aBorrarPaquete.appendChild(imgBorrarPaquete);

            divPaquete.appendChild(divImgPaquete);
            divImgPaquete.appendChild(aImgPaquete);
            aImgPaquete.appendChild(imgPaquete);

            divPaquete.appendChild(divTextoPaquete);
            divTextoPaquete.appendChild(h2TextoPaquete);
            divTextoPaquete.appendChild(h3TextoPaquete);
            
            divPaquete.appendChild(divPrecioPaquete);
            divPrecioPaquete.appendChild(h3PrecioPaquete);
            divPrecioPaquete.appendChild(h3PrecioPaquetePrecio);
        });

        console.log(`Monto total: ${montoTotal}`);

        const totalMonto = document.getElementById('totalMonto');
        totalMonto.textContent = `$ ${montoTotal}`;

    } else {

        //Borra el frontend del carrito y muestra "No hay elementos"
        const columnaDer = document.getElementById("columnaDer");
        columnaDer.style.display = "none";

        const listaItems = document.getElementById("listaItems");
        listaItems.style.width = "100%";

        const divPaquete = document.createElement("div");
        divPaquete.classList.add("paquete");
        divPaquete.style.width = "100%";

        const divTextoPaquete = document.createElement("div");
        divTextoPaquete.classList.add("textoPaquete");
        divTextoPaquete.style.width = "100%";

        const h2TextoPaquete = document.createElement("h2");
        h2TextoPaquete.textContent = "No hay elementos en el carrito";
        h2TextoPaquete.style.textAlign = "center";
        h2TextoPaquete.style.width = "100%";

        listaPaquetes.appendChild(divPaquete);
        divPaquete.appendChild(divTextoPaquete);
        divTextoPaquete.appendChild(h2TextoPaquete);
    }

    // Boton Comprar --------------------------------------------------------------------------------

    const botonComprar = document.getElementById("botonComprar");
    botonComprar.addEventListener("click", async (e) => {
        e.preventDefault(); // Cancela el comportamiento
        // Encontrar el ultimo id de compras para generar el siguiente
        const resCompra = await fetch(`http://localhost:2006/api/compra/todos`);
        const compras = await resCompra.json();
        console.log(compras);
        const idNuevaCompra = compras.length + 1; 
        console.log(idNuevaCompra);
        
        // Agarrar el usuario, los viajes y el monto total
        const idUsuarioCompra = idUsuario;
        const arrayArticulosCompra = usuario.carrito.join(',');
        const montoCompra = montoTotal;

        // Crear el objeto en compras
        const resNuevaCompra = await fetch(`http://localhost:2006/api/insertarCompra/${idNuevaCompra}/${idUsuarioCompra}/${arrayArticulosCompra}/${montoCompra}`);
        const nuevaCompra = await resNuevaCompra.json();
        console.log(`Compra ingresada: ${nuevaCompra}`);

        // Borrar los viajes de "usuario.carrito"
        const resBorrarCarrito = await fetch(`http://localhost:2006/api/borrarCarrito/${idUsuarioCompra}/${idNuevaCompra}`);
        const borrarCarrito = await resBorrarCarrito.json();
        console.log(borrarCarrito);

        alert("Compra realizada con exito.");
        location.reload();
    });
})

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

async function borrarElemento(posicion, idUsuario) {
    console.log(`index: ${posicion}, usuario: ${idUsuario}`);

    const resBorrarDelCarrito = await fetch(`http://localhost:2006/api/borrarDelCarrito/${idUsuario}/${posicion}`);
    const resultado = await resBorrarDelCarrito.json();
    console.log(`La posición ${posicion} del carrito fue eliminada`);
    console.log(resultado);

    location.reload();
}