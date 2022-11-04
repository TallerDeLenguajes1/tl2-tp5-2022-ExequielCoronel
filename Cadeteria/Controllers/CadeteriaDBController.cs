using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using System.IO;
using System.Text;
namespace Cadeteria.Controllers;

public class CadeteriaDBController : Controller
{

    private string path = @"C:\Users\execo\Escritorio\Universidad\3ero\2doCuatrimestre\TallerDeLenguajesII\Practica\TPN4\tl2-tp4-2022-ExequielCoronel\Cadeteria\wwwroot\Cadetes.csv";
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Alta(IFormCollection cadete)
    {
        ControlCSV controlCSV = new ControlCSV(path);
        controlCSV.EscribirEnCSV(cadete);
        return View();
    }

    public IActionResult MostrarCadetes()
    {
        ControlCSV controlCSV = new ControlCSV(path);
        List<Cadete> listado = controlCSV.ObtenerLista();
        return View(listado);
    }

    [HttpGet]
    public IActionResult Baja(int id)
    {
        ControlCSV controlCSV = new ControlCSV(path);
        controlCSV.ElminarLinea(id);
        ViewData["IDCadete"] = id;
        return View();
    }
}