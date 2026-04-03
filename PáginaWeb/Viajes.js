const mongoose = require("mongoose");

const viajesSchema = new mongoose.Schema({
    id: Number,
    nombre: String,
    lugar: String,
    desc: String,
    duracion: Number,
    img: String,
    precio: Number
})

module.exports = mongoose.model("viajes", viajesSchema);