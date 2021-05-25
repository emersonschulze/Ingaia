class regraCalculo {

    calcular(item, area){
        var areaD = parseFloat(area);
        var itemD = parseFloat(item);

        if(isNaN(areaD)){
            return "Erro no parametro area"
        } 
        if(isNaN(itemD)){
            return "Erro no parametro item"
        } 
        var conta = (areaD * itemD)
       
        return conta;
    }

}
    
module.exports = new regraCalculo();