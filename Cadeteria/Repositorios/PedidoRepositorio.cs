using System.Diagnostics;
using Cadeteria.Models;
using Microsoft.Data.Sqlite;
using Cadeteria.ViewModels;

namespace Cadeteria.Repositorios;

public interface IPedidoRepositorio
{
    List<GetPedidoViewModel> ObtenerPedidos();
    
    Pedido ObtenerPedidoPorNumero(long numero);

    
    void Alta(AltaPedidoViewModel nuevoPedido);
    
    void Baja(long numeroPedido);
    
    void Editar(Pedido pedido);

    void AsignarCliente(long idPedido, long idCliente);
    void AsignarCadete(long idPedido, long idCliente);
    
}
public class PedidoRepositorio : IPedidoRepositorio
{
    private string rutaConexion;

    public PedidoRepositorio()
    {
        rutaConexion = "Data Source=BaseDeDatos/Cadeteria.db";
    }
    public List<GetPedidoViewModel> ObtenerPedidos()
    {
        List<GetPedidoViewModel> listadoPedidos = new List<GetPedidoViewModel>();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Pedidos",conexion);
        var datos = consulta.ExecuteReader();
        while (datos.Read())
        {
            long idCliente = 0;
            long idCadete = 0;
            if(!datos.IsDBNull(2))
            {
                idCliente = datos.GetInt64(2);
            }
            if(!datos.IsDBNull(4))
            {
                idCadete=datos.GetInt64(4);
            }
            GetPedidoViewModel nuevoPedido = new GetPedidoViewModel(datos.GetInt64(0),idCliente,idCadete,datos.GetString(3),datos.GetString(1));
            listadoPedidos.Add(nuevoPedido);
        }
        conexion.Close();
        return listadoPedidos;
    }

    
    public Pedido ObtenerPedidoPorNumero(long Numero)
    {
        Pedido pedido = new Pedido();
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Pedidos WHERE ID = @id",conexion);
        consulta.Parameters.AddWithValue("@id",Numero);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            pedido.Numero = Convert.ToUInt32(datos.GetString(0));
            pedido.Observacion = datos.GetString(1);
            if(datos.GetString(3)=="Entregado")
            {
                pedido.Estado = true;
            } else if(datos.GetString(3) == "No entregado")
                {
                    pedido.Estado = false;
                }
        }
        conexion.Close();
        return pedido;
    }
    
    public void Alta(AltaPedidoViewModel nuevoPedido)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("INSERT INTO Pedidos (Observacion) VALUES (@obs)",conexion);
        consulta.Parameters.AddWithValue("obs",nuevoPedido.Observacion);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void Baja(long numeroPedido)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("DELETE FROM Pedidos WHERE ID = @id",conexion);
        consulta.Parameters.AddWithValue("@id",numeroPedido);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void Editar(Pedido pedido)
    {
        string Estado = "No entregado";
        if(pedido.Estado)
        {
            Estado = "Entregado";
        }
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("UPDATE Pedidos SET Observacion=@Obs, Estado=@Est WHERE ID=@id", conexion);
        consulta.Parameters.AddWithValue("@id",pedido.Numero);
        consulta.Parameters.AddWithValue("@Est",Estado);
        consulta.Parameters.AddWithValue("@Obs",pedido.Observacion);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void AsignarCliente(long numeroPedido, long idCliente)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("UPDATE Pedidos SET ID_Cliente=@idc WHERE ID=@id",conexion);
        consulta.Parameters.AddWithValue("@id",numeroPedido);
        consulta.Parameters.AddWithValue("@idc",idCliente);
        consulta.ExecuteReader();
        conexion.Close();
    }

    public void AsignarCadete(long numeroPedido, long idCadete)
    {
        SqliteConnection conexion = new SqliteConnection(rutaConexion);
        conexion.Open();
        SqliteCommand consulta = new SqliteCommand("UPDATE Pedidos SET ID_Cadete=@idc WHERE ID=@id",conexion);
        consulta.Parameters.AddWithValue("@id",numeroPedido);
        consulta.Parameters.AddWithValue("@idc",idCadete);
        consulta.ExecuteReader();
        conexion.Close();
    }

}