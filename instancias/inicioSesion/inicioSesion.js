document.addEventListener("DOMContentLoaded", async () => {
    const botonInicioSesion = document.getElementById("botonInicioSesion");
    
    const resUsuarios = await fetch(`https://fnviajes.onrender.com/api/usuario/todos`);
    const usuarios = await resUsuarios.json();
    console.log(usuarios);

    botonInicioSesion.addEventListener("click", async () => {

        usuarios.forEach(usuario => {
            if (document.getElementById("mail").value == usuario.mail) {
                if (document.getElementById("password").value == usuario.password) {
                    console.log(usuario);
                    window.location.href = `http://localhost:5500/index.html?usuario=${usuario.id}`;
                    return;
                }
            }
        });
    });

});
