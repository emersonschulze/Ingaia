const mongoose = require("mongoose");

const CalculoSchema = new mongoose.Schema(
  {
    internalId: String,
    area: Number,
    unidadeMedida: String,
    valorTotal: Number
  },
);

module.exports = mongoose.model("CalculoArea", CalculoSchema);