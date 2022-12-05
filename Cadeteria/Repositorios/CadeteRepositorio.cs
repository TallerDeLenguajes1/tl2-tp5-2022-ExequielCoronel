using Cadeteria.Models;
using Microsoft.Data.Sqlite;
namespace Cadeteria.Repositorios;


public interface ICadeteRepositorio
{
    List<Cadete> ObtenerCadetes();
    Cadete ObtenerCadetePorID(long id);
    void Alta(Cadete cadete);
    void Baja(long id);
    void Editar(Cadete cadete);
    
}

public class CadeteRepositorio : ICadeteRepositorio
{
    private string rutaConexion;

    public CadeteRepositorio()
    {
        rutaConexion = "Data Source=BaseDeDatos/Cadeteria.db";
    }

    public List<Cadete> ObtenerCadetes()
    {
        List<Cadete> listadoCadetes = new List<Cadete>();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Cadetes",conexion);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            Cadete nuevoCadete = new Cadete(datos.GetInt64(0), datos.GetString(1), datos.GetString(2), datos.GetInt64(3));
            listadoCadetes.Add(nuevoCadete);
        }
        conexion.Close();
        return listadoCadetes;
    }

    public Cadete ObtenerCadetePorID(long id)
    {
        Cadete cadete = new Cadete();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Cadetes WHERE ID=@id",conexion);
        consulta.Parameters.AddWithValue("@id",id);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            cadete.ID = datos.GetInt64(0);
            cadete.Nombre = datos.GetString(1);
            cadete.Direccion = datos.GetString(2);
            cadete.Telefono = datos.GetInt64(3);
        }
        conexion.Close();
        return cadete;
    }

    public void Alta(Cadete nuevoCadete)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("INSERT INTO Cadetes (Nombre, Direccion, Telefono, ID_Cadeteria) VALUES (@nom, @dir, @tel, 1)", conexion);
        consulta.Parameters.AddWithValue("@nom", nuevoCadete.Nombre);
        consulta.Parameters.AddWithValue("@dir", nuevoCadete.Direccion);
        consulta.Parameters.AddWithValue("@tel", nuevoCadete.Telefono);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void Baja(long id)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("DELETE FROM Cadetes WHERE ID = @id",conexion);
        consulta.Parameters.AddWithValue("@id",id);
        consulta.ExecuteReader();
        conexion.Close();
    }
    public void Editar(Cadete cadete)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("UPDATE Cadetes SET Nombre=@nom, Direccion=@dir, Telefono=@tel WHERE ID = @id", conexion);
        consulta.Parameters.AddWithValue("@nom", cadete.Nombre);
        consulta.Parameters.AddWithValue("@dir", cadete.Direccion);
        consulta.Parameters.AddWithValue("@tel", cadete.Telefono);
        consulta.Parameters.AddWithValue("@id", cadete.ID);
        consulta.ExecuteReader();
        conexion.Close();
    }
}