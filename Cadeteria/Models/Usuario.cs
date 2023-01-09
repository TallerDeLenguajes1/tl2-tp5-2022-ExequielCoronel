using System;
using System.Collections.Generic;
namespace Cadeteria.Models;

public class Usuario
{
    public long ID;
    public string Nombre;
    public string nombreUsuario;
    public string Password;
    public int Rol;

    public Usuario(){}
    public Usuario(long id, string nombre, string usuario, string password, int rol)
    {
        ID=id;
        nombreUsuario=usuario;
        Nombre=nombre;
        Password=password;
        Rol=rol;
    }

}