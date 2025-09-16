document.addEventListener("DOMContentLoaded", async () => {

    const botonRegistro = document.getElementById("botonRegistro");
    botonRegistro.addEventListener("click", async (e) => {
        e.preventDefault(); //Para que no recargue la pagina

        // Recupero los datos
        const mail = document.getElementById("mail");
        const nombre = document.getElementById("nombre");
        const apellido = document.getElementById("apellido");
        const contrasenia1 = document.getElementById("contrasenia1");
        const contrasenia2 = document.getElementById("contrasenia2");
        let contraseniaFinal;

        // Verifico que haya valores en todos y ejecuto
        if (mail.value && nombre.value && apellido.value && contrasenia1.value && contrasenia2.value) {
            // Corroboro que las contrasenias sean iguales
            if (contrasenia1.value === contrasenia2.value) {
                contraseniaFinal = contrasenia1.value;

                // Corroboro que las contrasenias tengan al menos 4 caracteres
                if (contraseniaFinal.length < 4) {
                    alert("La contraseña debe tener al menos 4 caracteres");
                    return;
                }
            } else {
                alert("Las contraseñas no coinciden");
                return;
            }

            // Corroboro que el mail tenga buen formato
            const regexMail = /^[^@]+@[^@]+\.[^@]+$/;
            if (!regexMail.test(mail.value)) {
                alert("El mail no tiene un formato válido (Debe ser algo@algo.algo)");
                return;
            }

            // Encontrar el ultimo id de usuarios para generar el siguiente
            const resUsuarios = await fetch(`https://fnviajes.onrender.com/api/usuario/todos`);
            const usuarios = await resUsuarios.json();
            console.log(usuarios);
            const idNuevoUsuario = usuarios.length + 1; 
            console.log(idNuevoUsuario);

            // Ingreso del nuevo usuario a la base de datos
            await fetch('https://fnviajes.onrender.com/api/registro', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    id: idNuevoUsuario,
                    nombre: nombre.value,
                    apellido: apellido.value,
                    mail: mail.value,
                    contrasenia: contraseniaFinal
                })
            });

            alert("¡Usuario registrado exitosamente!");
            location.href = `../../index.html?usuario=${idNuevoUsuario}`;
        } else {
            alert("Por favor completá todos los campos.");
            return;
        }

    });
});
