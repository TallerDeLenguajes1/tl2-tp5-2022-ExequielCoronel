using System;
using System.Collections.Generic;
namespace Cadeteria.Models;
class CadeteViewModel
{
    [require]
    private int id {get; set;}
    [require] [StringLength(100)]
    private string direccion {get; set;}
    [require] [StringLength(50)]
    private string nombre {get; set;}
    [require] [Range(0,9223372036854775807)]
    private long telefono {get; set;}
    List<Pedido> Pedidos;

    public CadeteViewModel()
    {
        
    }

    public CadeteViewModel(int Id, String Nombre, String Direccion, long Telefono)
    {
        id = Id;
        nombre = Nombre;
        direccion = Direccion;
        telefono = Telefono;
        Pedidos = new List<Pedido>();
    }
}