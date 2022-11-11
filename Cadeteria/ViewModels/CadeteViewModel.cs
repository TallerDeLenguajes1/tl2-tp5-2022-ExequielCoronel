using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadeteria.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

public class AltaCadeteViewModel
{
    [Required]
    
    public int id {get; set;}
    [Required, MaxLength(100), MinLength(5)]
    [DisplayName("Direccion: ")]
    public string direccion {get; set;}
    [Required, MaxLength(50), MinLength(5),DisplayName("Nombre: ")]
    
    public string nombre {get; set;}
    [Required, Range(0,9999999999, ErrorMessage ="El {0} debe estar entre {1} y {2}"), DisplayName("Telefono: ")]
    public long telefono {get; set;}
    List<Pedido> Pedidos = new List<Pedido>();

    public AltaCadeteViewModel(){}
    public AltaCadeteViewModel(int Id, String Nombre, String Direccion, long Telefono)
    {
        id = Id;
        nombre = Nombre;
        direccion = Direccion;
        telefono = Telefono;
    }
}

public class ModificarCadeteViewModel
{
    [Required]
    public long id {get; set;}
    [Required, MaxLength(100), MinLength(5)]
    [DisplayName("Direccion: ")]
    public string direccion {get; set;}
    [Required, MaxLength(50), MinLength(5),DisplayName("Nombre: ")]
    
    public string nombre {get; set;}
    [Required, Range(0,9999999999, ErrorMessage ="El {0} debe estar entre {1} y {2}"), DisplayName("Telefono: ")]
    public long telefono {get; set;}
    List<Pedido> Pedidos = new List<Pedido>();

    public ModificarCadeteViewModel(){}
    public ModificarCadeteViewModel(long Id, String Nombre, String Direccion, long Telefono)
    {
        id = Id;
        nombre = Nombre;
        direccion = Direccion;
        telefono = Telefono;
    }
}