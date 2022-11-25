using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Cadeteria.Models;
namespace Cadeteria.ViewModels;


public class CadeteViewModel
{
    [Required]
    private int id {get; set;}
    [Required] [StringLength(100)]
    private string direccion {get; set;}
    [Required] [StringLength(50)]
    private string nombre {get; set;}
    [Required] [Range(0,9223372036854775807)]
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