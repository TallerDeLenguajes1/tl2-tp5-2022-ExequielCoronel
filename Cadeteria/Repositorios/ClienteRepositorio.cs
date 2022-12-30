using System.Diagnostics;
using Cadeteria.Models;
using Microsoft.Data.Sqlite;
using Cadeteria.ViewModels;

namespace Cadeteria.Repositorios;

public interface IClienteRepositorio
{
    List<Cliente> ObtenerClientes();
}

public class ClienteRepositorio:IClienteRepositorio
{
    private string rutaConexion;

    public ClienteRepositorio()
    {
        rutaConexion="Data Source = BaseDeDatos/Cadeteria.db";
    }
    public List<Cliente> ObtenerClientes()
    {
        List<Cliente> ListadoClientes = new List<Cliente>();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Clientes",conexion);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            Cliente cliente = new Cliente(datos.GetInt64(0), datos.GetString(3),datos.GetString(1),datos.GetInt64(4),datos.GetString(2));
            ListadoClientes.Add(cliente);
        }
        conexion.Close();
        return ListadoClientes;
    }
}