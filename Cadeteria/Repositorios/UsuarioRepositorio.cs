using Cadeteria.ViewModels;
using Cadeteria.Models;
using Microsoft.Data.Sqlite;

namespace Cadeteria.Repositorios;

public interface IUsuarioRepositorio
{
    Usuario Loggear(string usuario, string password);
}

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private string rutaConexionDB;
    public UsuarioRepositorio()
    {
        rutaConexionDB = "Data Source=BaseDeDatos/Cadeteria.db";
    }
    public Usuario Loggear(string usuario, string password)
    {
        string PassWord = Encrypt.GetSHA1(password);
        Usuario usuario1 = null;
        SqliteConnection conexion = new SqliteConnection(rutaConexionDB);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Usuarios WHERE Usuario = @usu AND Contraseña = @pass", conexion);
        consulta.Parameters.AddWithValue("@usu",usuario);
        consulta.Parameters.AddWithValue("@pass",PassWord);
        var resultado = consulta.ExecuteReader();
        if(resultado.Read())
        {
            usuario1.ID = Convert.ToInt64(resultado.GetString(4));
            usuario1.Nombre = resultado.GetString(0);
            usuario1.nombreUsuario = resultado.GetString(1);
            usuario1.Password = resultado.GetString(2);
            if(resultado.GetString(3)=="Administrador")
            {
                usuario1.Rol=0;
            } else{
                if(resultado.GetString(3)=="Cadete")
                {
                    usuario1.Rol=1;
                }
            }
        }
        conexion.Close();
        return usuario1;
    }
}