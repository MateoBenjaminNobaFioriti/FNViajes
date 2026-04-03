const mongoose = require("mongoose");

const usuariosSchema = new mongoose.Schema({
    id: Number,
    nombre: String,
    apellido: String,
    mail: String,
    acceso: Number,
    password: String,
    carrito: [Number],
    compras: [Number]
})

module.exports = mongoose.model("usuarios", usuariosSchema);