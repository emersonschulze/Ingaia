var request = require('request');
var calculo = require('../model/Calculo');
var regraCalculo = require('../business/RegraCalculo');
const fetch = require('node-fetch');

class UnidadeMedidaController {
  
  async listarUnidadeMedida(req, res){
    var listaUnidades = [];
    let response = await fetch('https://ingaiaapi1.herokuapp.com/api/v1/ValorUnidadeMedida')
    let data = await response.json()

    data.forEach(element => {
      listaUnidades.push(element);
    });

    return res.send(listaUnidades);
  }
  

  async calcularValorImovel(req, res){
    var unidade = req.body.unidade;
    var area = req.body.area;
    
    console.log("post", area +" " + unidade);

    var resultadoCalc;

    let response = await fetch('https://ingaiaapi1.herokuapp.com/api/v1/ValorUnidadeMedida')
    let data = await response.json()

    var item = data.filter(x => x.unidadeMedida == unidade);
  
    if(item !== "" ){
      resultadoCalc = regraCalculo.calcular(JSON.stringify(item[0].valor), area)
    }
      if(resultadoCalc.toString().includes("Erro no parametro")){
        return res.send("Atenção houve erro no calculo, error: "+ resultadoCalc.toString());
      }
      return res.send("O valor da unidade: "+ unidade + ", para o imovél é: " + resultadoCalc.toString());
  }

}
    
module.exports = new UnidadeMedidaController();