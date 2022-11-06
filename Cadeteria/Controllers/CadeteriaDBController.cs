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
    public IActionResult Alta(AltaCadeteViewModel cadete)
    {
        if(ModelState.IsValid)
        {
            Cadete nuevocadete = new Cadete(cadete.nombre, cadete.direccion, cadete.telefono);
            String strCadete = nuevocadete.ID + ";" + nuevocadete.Nombre + ";" + nuevocadete.Direccion + ";" + nuevocadete.Telefono;
            ControlCSV controlCSV = new ControlCSV(path);
            controlCSV.EscribirEnCSV(strCadete);
            return View();
        } else {
            return RedirectToAction("Error");
        }
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

    [HttpGet]
    public IActionResult Modificar(int id)
    {
        ControlCSV controlCSV = new ControlCSV(path);
        List<Cadete> listado = controlCSV.ObtenerLista();
        Cadete cadeteAModificar = new Cadete();
        foreach (var item in listado)
        {
            if(id == item.ID)
            {
                cadeteAModificar = item;
            }
        }
        ModificarCadeteViewModel cadeteView = new ModificarCadeteViewModel(cadeteAModificar.ID,cadeteAModificar.Nombre,cadeteAModificar.Direccion,cadeteAModificar.Telefono); 
        return View(cadeteView);
    }

    [HttpPost]
    public IActionResult ConfirmarModificado(ModificarCadeteViewModel cadete)
    {
        if(ModelState.IsValid)
        {
            ControlCSV controlCSV = new ControlCSV(path);
            controlCSV.ElminarLinea(cadete.id);
            String strEdit = cadete.id + ";" + cadete.nombre + ";" + cadete.direccion + ";" + cadete.telefono;
            controlCSV.EscribirEnCSV(strEdit);
            ViewData["IDCadete"] = cadete.id;
            return View();
        } else {
            return RedirectToAction("Error");
        }
    }
}