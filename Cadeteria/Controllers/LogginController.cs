using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Cadeteria.ViewModels;
using Cadeteria.Models;
using Cadeteria.Repositorios;

namespace Cadeteria.Controllers;

public class LogginController : Controller
{
    private readonly IUsuarioRepositorio usuarioRepositorio;

    public LogginController(IUsuarioRepositorio usuarioRepo)
    {
        usuarioRepositorio = usuarioRepo;
    }

    public ActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Loggear(string usuario, string password)
    {
        Usuario usuarioLoggin = usuarioRepositorio.Loggear(usuario,password);
        if(usuarioLoggin is not null)
        {
            HttpContext.Session.SetString("usuario", usuarioLoggin.nombreUsuario);
            if(usuarioLoggin.Rol==1)
            {
                HttpContext.Session.SetString("id_cadete",Convert.ToString(usuarioLoggin.ID));
            }
            HttpContext.Session.SetInt32("rol",usuarioLoggin.Rol);
            return RedirectToAction("MostrarCadetes","Cadete");
        } else {
            return RedirectToAction("Error", new {error = "Usuario y/o Contraseña incorrectos"});
        }
    }

    public ActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Form");
    }

    public ActionResult Error(string error)
    {
        ViewData["error"]=error;
        return View();
    }
}