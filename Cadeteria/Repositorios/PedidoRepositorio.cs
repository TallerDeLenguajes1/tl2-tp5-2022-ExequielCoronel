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
    /*
    void Editar(Pedido pedido);
    */
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
            if(!datos.IsDBNull(2))
            {
                idCliente = datos.GetInt64(2);
            } 
            GetPedidoViewModel nuevoPedido = new GetPedidoViewModel(datos.GetInt64(0),idCliente,datos.GetString(3),datos.GetString(1));
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
        SqliteCommand consulta = new SqliteCommand("SELECT * FROM Pedidos WHERE ID=@id",conexion);
        consulta.Parameters.AddWithValue("id",Numero);
        var datos = consulta.ExecuteReader();
        while(datos.Read())
        {
            bool estado = false;
            if(datos.GetString(3) == "Entregado")
            {
                estado = true;
            }
            pedido.Numero1 = Convert.ToUInt32(datos.GetString(0));
            pedido.Observacion1 = datos.GetString(1);
            pedido.Estado1 = estado;
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

}