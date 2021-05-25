var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');

var controller = require('../controller/UnidadeMedidaController')

router.get('/unidadeMedida', controller.listarUnidadeMedida); 

router.post('/unidadeMedida', controller.calcularValorImovel); 
  

module.exports = router;