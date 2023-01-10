using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cadeteria.Models;
using Cadeteria.Repositorios;
using Cadeteria.ViewModels;
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
    public IActionResult Form()
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            return View();
        }else{
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de alta un cadete"});
        }
        
    }

    [HttpPost]
    public IActionResult Alta(CadeteViewModel cadete)
    {
        if(HttpContext.Session.GetInt32("rol")==2) 
        {
            if(ModelState.IsValid)
            {
                Cadete nuevoCadete = new Cadete(cadete.Nombre,cadete.Direccion,cadete.Telefono);
                _cadeteRepositorio.Alta(nuevoCadete);
            }
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de alta un cadete"});
        }
       
    }

    public IActionResult MostrarCadetes()
    {
        if(HttpContext.Session.GetInt32("rol")==2) 
        {
            return View(_cadeteRepositorio.ObtenerCadetes());
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para ver los cadetes"});
        }
        
    }

    [HttpGet]
    public IActionResult Baja(int id)
    {
        if(HttpContext.Session.GetInt32("rol")==2) 
        {
            _cadeteRepositorio.Baja(id);
            ViewData["IDCadete"] = id;
            return View();
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para dar de baja un cadete"});
        }
        
    }

    [HttpGet]
    public IActionResult Editar(long id)
    {
        if(HttpContext.Session.GetInt32("rol")==2)
        {
            Cadete cadete = _cadeteRepositorio.ObtenerCadetePorID(id);
            return View(cadete);
        } else {
            return RedirectToAction("Error",new{error="No posee los permisos necesarios para editar un cadete"});
        }

        
    }

    [HttpPost]

    public IActionResult ConfirmarEditado(Cadete cadete)
    {
        if(HttpContext.Session.GetInt32("rol")==2) 
        {
            _cadeteRepositorio.Editar(cadete);
            ViewData["IDCadete"] = cadete.ID;
            return View();
        } else {
            return RedirectToAction("Error",new {error="No posee los permisos necesarios para editar un cadete"});
        }
        
    }

    public ActionResult Error(string error)
    {
        ViewData["error"]=error;
        return View();
    }
}