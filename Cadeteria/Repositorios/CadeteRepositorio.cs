using Cadeteria.Models;
using Microsoft.Data.Sqlite;
namespace Cadeteria.Repositorios;


public interface ICadeteRepositorio
{
    List<Cadete> ObtenerCadetes();
    List<long> ObtenerIDCadetes();
    void Alta(Cadete cadete);
    /*
    void Baja(long id);
    void Editar(Cadete cadete);
    */
}

public class CadeteRepositorio : ICadeteRepositorio
{
    private string rutaConexion;

    public CadeteRepositorio()
    {
        rutaConexion = "Data Source=BaseDeDatos/Cadeteria";
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
            Cadete nuevoCadete = new Cadete(datos.GetInt64(0), datos.GetString(1), datos.GetString(2), Convert.ToUInt32(datos.GetString(3)));
            listadoCadetes.Add(nuevoCadete);
        }
        conexion.Close();
        return listadoCadetes;
    }

    public List<long> ObtenerIDCadetes()
    {
        List<long> listadoIDCadete = new List<long>();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT ID FROM Cadetes",conexion);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            listadoIDCadete.Add(datos.GetInt64(0));
        }
        conexion.Close();
        return listadoIDCadete;
    }
    
    public void Alta(Cadete nuevoCadete)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("INSERT INTO Cadetes (Nombre, Direccion, Telefono, ID_Cadeteria) VALUES (@nom, @dir, @tel, 1)", conexion);
        consulta.Parameters.AddWithValue("@nom", nuevoCadete.Nombre);
        consulta.Parameters.AddWithValue("@dir", nuevoCadete.Direccion);
        consulta.Parameters.AddWithValue("@tel", nuevoCadete.Telefono);
    }

}