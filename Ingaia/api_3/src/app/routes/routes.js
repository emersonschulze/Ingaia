var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');

var controller = require('../controller/UnidadeMedidaController')

router.get('/calculoImovel', controller.listarUnidadeMedida); 

router.post('/calculoImovel', controller.calcularValorImovel); 
  

module.exports = router;