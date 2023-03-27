using Exercicios.Interfaces;
using Exercicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers;

[Route("transacao")]
public class TransacaoController : Controller
{
    private IClienteServices _clienteService;

    public TransacaoController(IClienteServices clienteServices)
    {
        _clienteService = clienteServices;
    }

    [HttpPost]
    [Route("{idCliente}")]
    public ActionResult AdicionarTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
    {
        _clienteService.AdicionarTransacao(transacao, idCliente);
        return Created(Request.Path, transacao);
    }

    [HttpGet]
    [Route("{idCliente}")]
    public ActionResult ListarTransacao([FromRoute] int idCliente)
    {
        return Ok(_clienteService.ListarTransacao(idCliente));
    }
}