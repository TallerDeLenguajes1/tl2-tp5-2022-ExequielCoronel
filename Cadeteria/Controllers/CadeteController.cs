using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using Cadeteria.Repositorios;
namespace Cadeteria.Controllers;

public class CadeteController : Controller
{
    private readonly ILogger<CadeteController> _logger;

    private readonly ICadeteRepositorio _cadeteRepositorio;

    public CadeteController(ICadeteRepositorio cadeteRepo, ILogger<CadeteController> logger)
    {
        _cadeteRepositorio = cadeteRepo;
        _logger = logger;
    }

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
        return View(_cadeteRepositorio.ObtenerCadetes());
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