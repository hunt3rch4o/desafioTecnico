
using datosDesafioTecnico;
using entidadesDesafioTecnico;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace desafioTecnico.Controllers
{
    public class _TipoCambio_cb : ControllerBase
    {

        d_conexion odConexion = new d_conexion();

        [HttpPost]
        [Route("obtenerTC")]
        public dynamic fn_ObtenerTC([FromBody] e_TipoCambio oeTipoCambio)
        {
            oeTipoCambio.TipoCambio = odConexion.consulta();

            oeTipoCambio.montoTipoCambio = oeTipoCambio.TipoCambio * oeTipoCambio.montoOrigen;

            return new
            {
                succes = true,
                message = "Operacion Realizada con Éxito",
                result = oeTipoCambio
            };
        }

        [HttpPut]
        [Route("ActualizaTC")]
        public dynamic fn_ActualizarTC(double numTipoCambio)
        {
            odConexion.actualiza(numTipoCambio);

            return new
            {
                succes = true,
                message = "Operacion Realizada con Éxito",
                result = numTipoCambio
            };
        }



        [HttpGet]
        [Route("listarTC")]
        public dynamic fn_ListarTC()
        {
            e_TipoCambio oeTipoCambio = new e_TipoCambio();

            
            oeTipoCambio.monedaOrigen = "DOLARES";
            oeTipoCambio.monedaDestino = "SOLES";
            oeTipoCambio.montoOrigen = 50;
            oeTipoCambio.TipoCambio = 3.85;
            oeTipoCambio.montoTipoCambio = oeTipoCambio.montoOrigen * oeTipoCambio.TipoCambio;

            return new
            {
                succes = true,
                message = "Operacion Realizada con Éxito",
                result = oeTipoCambio
            };
        }
    }
}
