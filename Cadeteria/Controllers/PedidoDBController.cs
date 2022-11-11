using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using System.IO;
using System.Text;
namespace Cadeteria.Controllers;

public class PedidoDBController : Controller
{
    private string pathP = @"CSV/Pedidos.csv";
    public IActionResult FormAlta()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult AltaPedido(AltaPedidoViewModel pedidoView)
    {
        if(ModelState.IsValid)
        {
            String path = @"CSV/Clientes.csv";
            ControlCSV controlCSVCliente = new ControlCSV(path);
            long IDCliente = controlCSVCliente.IDAltaCliente();
            String strCliente = IDCliente + ";" + pedidoView.NombreCliente + ";" + pedidoView.TelefonoCliente + ";" + pedidoView.DireccionCliente + ";" + pedidoView.ReferenciaDireccionCliente;
            controlCSVCliente.EscribirEnCSV(strCliente);
            ControlCSV controlCSVPedido = new ControlCSV(pathP);
            long NumPedido = controlCSVPedido.NumeroAltaPedido();
            String strPedido = NumPedido + ";" + pedidoView.Observacion + ";" + pedidoView.Estado + ";" + IDCliente;
            controlCSVPedido.EscribirEnCSV(strPedido);
            return View();
        } else {
            return RedirectToAction("ErrorViewModel");
        }
    }

    public IActionResult MostrarPedidos()
    {
        ControlCSV controlCSVPedidos = new ControlCSV(pathP);
        List<Pedido> Listado = controlCSVPedidos.ObtenerPedidos();
        return View(Listado);
    }

    [HttpGet]
    public IActionResult EliminarPedido(long Numero)
    {
        ControlCSV controlCSVPedido = new ControlCSV(pathP);
        controlCSVPedido.ElminarLineaPedido(Numero);
        ViewData["NumeroPedido"] = Numero;
        return View();
    }

    
}
