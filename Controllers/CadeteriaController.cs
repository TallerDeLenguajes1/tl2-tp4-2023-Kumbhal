using Cadeterias;
using Cadetes;
using Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace Cadeterias.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;
    public CadeteriaController(ILogger<CadeteriaController> logger){
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteria();
    }
    [HttpGet("GetNombreCadeteria")]
    public ActionResult<string> GetNombreCadeteria(){
        return Ok(cadeteria.Nombre);
    }
    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        List<Cadete>? listCadetes = cadeteria.GetCadetes();
        return Ok(listCadetes);
    }
    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos(){
        List<Pedido> pedidos = cadeteria.GetPedidos();
        return Ok(pedidos);
    }
    /* [HttpGet]
    [Route("Informe")]
    public ActionResult<Informe>GetInforme()
    {
        var informe = cadeteria.GetInforme();
        return Ok(informe);
    }  */

    [HttpPost("AddPedido")]
    public ActionResult<Pedido>AddPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.AddPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var asigPedido = cadeteria.AsignarCadeteAPedido(idPedido, idCadete);
        return Ok(asigPedido);
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido)
    {
        var camEstadoPedido = cadeteria.CambiarEstadoPedido(idPedido);
        return Ok(camEstadoPedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> ReasignarPedido(int idPedido, int idNuevoCadete)
    {
        var camCadetePedido = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(camCadetePedido);
    }
}