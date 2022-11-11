namespace Cadeteria.Models;

class ControlCSV
{
    private string RutaArchivoCSV;

    public ControlCSV(string path){RutaArchivoCSV=path;}

    public void EscribirEnCSV(String cadena)
    {
        StreamWriter archivo = new System.IO.StreamWriter(RutaArchivoCSV,true);
        archivo.WriteLine(cadena);
        archivo.Close();
    }

    public List<Cadete> ObtenerLista()
    {
        StreamReader archivo = new StreamReader(RutaArchivoCSV);
        List<Cadete> listadoCadetes = new List<Cadete>();
        while(!archivo.EndOfStream)
        {
            string lineas = archivo.ReadLine();
            string [] datos = lineas.Split(";");
            Cadete cadete = new Cadete(Convert.ToInt64(datos[0]),datos[1],datos[2],Convert.ToInt64(datos[3]));
            listadoCadetes.Add(cadete);
        }
        archivo.Close();
        return listadoCadetes;
    }

    public void ElminarLinea(long ID)
    {
        List<Cadete> ListadoCadetes = new List<Cadete>();
        ListadoCadetes = ObtenerLista();
        File.Delete(RutaArchivoCSV);
        StreamWriter sw = new StreamWriter(RutaArchivoCSV);
        foreach (var cadete in ListadoCadetes)
        {
            if(cadete.ID!=ID)
            {
                sw.WriteLine(cadete.ID + ";" + cadete.Nombre + ";" + cadete.Direccion + ";" + cadete.Telefono);
            }
        }
        sw.Close();
    }

    public void EditarLinea(long ID, String contenido)
    {
        List<Cadete> ListadoCadetes = new List<Cadete>();
        ListadoCadetes = ObtenerLista();
        File.Delete(RutaArchivoCSV);
        StreamWriter sw = new StreamWriter(RutaArchivoCSV);
        foreach (var item in ListadoCadetes)
        {
           if(item.ID == ID)
           {
                sw.WriteLine(contenido);
           } else {
                sw.WriteLine(item.ID + ";" + item.Nombre + ";" + item.Direccion + ";" + item.Telefono);
           }
        }
        sw.Close();
    }

    public long IDAlta()
    {
        long ID = 1;
        List<Cadete> Listado = new List<Cadete>();
        Listado = ObtenerLista();
        int posUltimo = Listado.Count-1;
        if(posUltimo>=0)
        {
            ID = Listado[posUltimo].ID+1;
        }
        return ID;
    }

    //Metodos para Pedidos
    public List<Pedido> ObtenerPedidos()
    {
        StreamReader archivo = new StreamReader(RutaArchivoCSV);
        List<Pedido> listadoPedidos = new List<Pedido>();
        while(!archivo.EndOfStream)
        {
            string lineas = archivo.ReadLine();
            string [] datos = lineas.Split(";");
            Pedido pedido = new Pedido(Convert.ToInt64(datos[0]), datos[1], Convert.ToInt64(datos[3]));
            listadoPedidos.Add(pedido);
        }
        archivo.Close();
        return listadoPedidos;
    }
    public long NumeroAltaPedido()
    {
        long Numero=1;
        List<Pedido> Listado = new List<Pedido>();
        Listado = ObtenerPedidos();
        int posUltimo = Listado.Count-1;
        if(posUltimo>=0)
        {
            Numero = Listado[posUltimo].Numero + 1;
        }
        return Numero;
    }

    public void ElminarLineaPedido(long ID)
    {
        List<Pedido> ListadoPedidos = new List<Pedido>();
        ListadoPedidos = ObtenerPedidos();
        File.Delete(RutaArchivoCSV);
        StreamWriter sw = new StreamWriter(RutaArchivoCSV);
        foreach (var pedido in ListadoPedidos)
        {
            if(pedido.Numero!=ID)
            {
                sw.WriteLine(pedido.Numero + ";" + pedido.Observacion + ";" + pedido.Estado + ";" + pedido.IDCliente1);
            }
        }
        sw.Close();
    }

    //Metodos para cliente
    public List<Cliente> ObtenerClientes()
    {
        StreamReader archivo = new StreamReader(RutaArchivoCSV);
        List<Cliente> ListadoClientes = new List<Cliente>();
        while(!archivo.EndOfStream)
        {
            string lineas = archivo.ReadLine();
            string [] datos = lineas.Split(";");
            Cliente cliente = new Cliente(Convert.ToInt32(datos[0]),datos[1],Convert.ToInt64(datos[2]),datos[3],datos[4]);
            ListadoClientes.Add(cliente);  
        }
        archivo.Close();
        
        return ListadoClientes;
    }

    public long IDAltaCliente()
    {
        long ID=1;
        List<Cliente> Clientes = new List<Cliente>();
        Clientes = ObtenerClientes();
        int posUltimo = Clientes.Count-1;
        if(posUltimo>=0)
        {
            ID = Clientes[posUltimo].ID + 1;
        }
        return ID;
    }

}