const mongoose = require("mongoose");

const comprasSchema = new mongoose.Schema({
    id: Number,
    usuario: Number,
    articulos: [Number],
    monto: Number
})

module.exports = mongoose.model("compras", comprasSchema);