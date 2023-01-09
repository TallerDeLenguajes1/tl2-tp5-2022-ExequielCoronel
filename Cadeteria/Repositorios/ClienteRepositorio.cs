using System.Diagnostics;
using Cadeteria.Models;
using Microsoft.Data.Sqlite;
using Cadeteria.ViewModels;

namespace Cadeteria.Repositorios;

public interface IClienteRepositorio
{
    List<Cliente> ObtenerClientes();

    void Alta(Cliente cliente);
    void Baja(long ID);

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

    public void Alta(Cliente cliente)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("INSERT INTO Clientes(Nombre, Direccion, DatosRef, Telefono) VALUES (@nom, @dir, @datr, @tel)", conexion);
        consulta.Parameters.AddWithValue("@nom",cliente.Nombre);
        consulta.Parameters.AddWithValue("@dir",cliente.Direccion);
        consulta.Parameters.AddWithValue("@datr",cliente.DatosReferenciaDireccion);
        consulta.Parameters.AddWithValue("@tel",cliente.Telefono);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void Baja(long ID)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("DELETE FROM Clientes WHERE ID=@id",conexion);
        consulta.Parameters.AddWithValue("@id",ID);
        consulta.ExecuteReader();
        conexion.Close();
    }
}