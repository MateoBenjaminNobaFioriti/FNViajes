console.log(`JS separado funcionando`);

const express = require('express');
const cors = require('cors');
const mongoose = require('mongoose');
const Viajes = require('./Viajes');
const Usuarios = require('./Usuarios');
const Compras = require('./Compras');

const app = express();
app.use(cors()); //Le permite al frontend hacer peticiones
app.use(express.json());

/*mongoose.connect('mongodb://localhost:27017/fnviajes')
.then(() => {
    console.log('Conectado a MongoDB');
    encontrarViajes();
    encontrarUsuarios();
    encontrarCompras();
})  
.catch(err => console.error(err)
);*/

mongoose.connect('mongodb+srv://mateonoba:ISFT220@cluster0.ixldm1o.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0')
.then(() => {
    console.log('Conectado a MongoDB');
    encontrarViajes();
    encontrarUsuarios();
    encontrarCompras();
})  
.catch(err => console.error(err)
);

async function encontrarViajes() {
  // Busca en la base de datos con la QUERY ⤦
  const viajes = await Viajes.find();
  console.log('Todos los viajes:', viajes.length);

  // Cerrar conexión
  // mongoose.connection.close();
}

app.get('/api/viajes/:id', async (req, res) => {
  const idBuscar = parseInt(req.params.id);
  const viaje = await Viajes.findOne({id: idBuscar});

  if (!viaje) {
    return res.status(404).json({ error: 'Viaje no encontrado' });
  }

  try {
    console.log('Api cargada.');
    res.json(viaje);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/viaje/todos', async (req, res) => {
  const viajes = await Viajes.find();

  if (!viajes) {
    return res.status(404).json({ error: 'Viajes no encontrados' });
  }

  try {
    console.log('Api cargada.');
    res.json(viajes);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

async function encontrarUsuarios() {
  // Busca en la base de datos con la QUERY ⤦
  const usuarios = await Usuarios.find();
  console.log('Cantidad de Usuarios:', usuarios.length);

  // Cerrar conexión
  // mongoose.connection.close();
}

app.get('/api/usuarios/:id', async (req, res) => {
  const idBuscar = parseInt(req.params.id);
  const usuario = await Usuarios.findOne({id: idBuscar});

  if (!usuario) {
    return res.status(404).json({ error: 'Usuario no encontrados' });
  }

  try {
    console.log('Api cargada.');
    res.json(usuario);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/usuario/todos', async (req, res) => {
  const usuarios = await Usuarios.find();

  if (!usuarios) {
    return res.status(404).json({ error: 'Usuarios no encontrados' });
  }

  try {
    console.log('Api cargada.');
    res.json(usuarios);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.post('/api/registro', async (req, res) => {
  try {
    const { id, nombre, apellido, mail, contrasenia } = req.body;

    const usuario = await Usuarios.create({
      id: parseInt(id),
      nombre,
      apellido,
      mail,
      acceso: 0,
      password: contrasenia,
      carrito: [],
      compras: []
    });

    console.log('Usuario creado.');
    res.status(201).json(usuario);

  } catch (err) {
    console.error('Error al crear el usuario:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/agregarAlCarrito/:idUsuario/:idViaje', async (req, res) => {
  const idUsuario = parseInt(req.params.idUsuario);
  const idViaje = parseInt(req.params.idViaje);

  try {
    const resultado = await Usuarios.updateOne(
      { id: idUsuario },
      { $push: { carrito: idViaje} }
    );

    if (resultado.modifiedCount === 0) {
      return res.status(404).json({ error: 'Error al Agregar al Carrito' });
    }

    res.json({ mensaje: 'Agregado al carrito' });
  } catch (err) {
    console.error('Error al Agregar al Carrito:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/borrarDelCarrito/:idUsuario/:posicion', async (req, res) => {
  const idUsuario = parseInt(req.params.idUsuario);
  const posicion = parseInt(req.params.posicion);

  try {
    const usuario = await Usuarios.findOne({ id: idUsuario });

    if (!usuario) {
      return res.status(404).json({ error: 'Usuario no encontrado' });
    }

    if (posicion < 0 || posicion >= usuario.carrito.length) {
      return res.status(400).json({ error: 'Posición inválida' });
    }

    // Eliminar la posición deseada
    usuario.carrito.splice(posicion, 1);

    await usuario.save();

    res.json({ mensaje: 'Producto eliminado del carrito' });
  } catch (err) {
    console.error('Error al modificar el carrito:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

async function encontrarCompras() {
  // Busca en la base de datos con la QUERY ⤦
  const compras = await Compras.find();
  console.log('Cantidad de Compras:', compras.length);

  // Cerrar conexión
  // mongoose.connection.close();
}

app.get('/api/compra/todos', async (req, res) => {
  const compras = await Compras.find();

  if (!compras) {
    return res.status(404).json({ error: 'Compras no encontradas' });
  }

  try {
    console.log('Compras cargadas.');
    res.json(compras);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/insertarCompra/:id/:usuario/:articulos/:monto', async (req, res) => {
  const idCompra = parseInt(req.params.id);
  const idUsuario = parseInt(req.params.usuario);
  const idsArticulos = req.params.articulos?.split(',').map(a => parseInt(a)) || [];
  const monto = parseInt(req.params.monto);

  const nuevaCompra = new Compras({
    id: idCompra,
    usuario: idUsuario,
    articulos: idsArticulos,
    monto: monto
  });

  await nuevaCompra.save();

  if (!nuevaCompra) {
    return res.status(404).json({ error: 'Compras no encontradas' });
  }

  try {
    console.log('Compra insertada.');
    res.json(nuevaCompra);
  } catch (err) {
    console.error('Error al cargar la API:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.get('/api/borrarCarrito/:idUsuario/:idNuevaCompra', async (req, res) => {
  const idUsuario = parseInt(req.params.idUsuario);
  const idNuevaCompra = parseInt(req.params.idNuevaCompra);

  try {
    const resultado = await Usuarios.updateOne(
      { id: idUsuario },
      { $set: { carrito: [] },
        $push: { compras: idNuevaCompra} }
    );

    if (resultado.modifiedCount === 0) {
      return res.status(404).json({ error: 'Usuario no encontrado o carrito ya vacío' });
    }

    res.json({ mensaje: 'Carrito vaciado correctamente' });
  } catch (err) {
    console.error('Error al vaciar el carrito:', err);
    res.status(500).json({ error: 'Error del servidor' });
  }
});

app.listen(2006, () => {
  console.log('Servidor corriendo en http://localhost:2006');
});
