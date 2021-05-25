using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteIngaia.Entity;

namespace TesteIngaia.Business
{
    public class RegrasBusiness
    {
        private ValorUnidadeMedida _dto;

        public RegrasBusiness(ValorUnidadeMedida vlunidadeMedida)
        {
            _dto = vlunidadeMedida;
        }

        public bool regraValorPermitido()
        {
            return validarRangeValorPermitido();
        }

        private bool validarRangeValorPermitido()
        {
            var valor = _dto.valor;
            if (valor < 10 || valor > 10000)
            {
                return false;

            }

            return true;

        }

    }
}
