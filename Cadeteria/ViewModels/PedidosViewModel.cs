using System;
using System.Collections.Generic;
using System.Linq;
namespace Cadeteria.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

public class AltaPedidoViewModel
{
    [Required, Range(0,9999999999)]
    public long Numero{get; set;}

    [Required, MaxLength(100), MinLength(10)]
    public string Observacion{get; set;}

    [Required, MaxLength(100), MinLength(5)]
    public string NombreCliente{get; set;}

    [Required, Range(0,9999999999)]
    public long TelefonoCliente{get; set;}

    [Required, MaxLength(100), MinLength(10)]
    public string DireccionCliente{get; set;}

    [MaxLength(100), DefaultValue("Sin referencia")]
    public string ReferenciaDireccionCliente {get; set;}

    
    public AltaPedidoViewModel(long Numero,string Observacion, string NombreCliente, long TelefonoCliente, string DireccionCliente, string? ReferenciaDireccionCliente)
    {
        this.Numero = Numero;
        this.Observacion = Observacion;
        this.NombreCliente = NombreCliente;
        this.TelefonoCliente = TelefonoCliente;
        this.DireccionCliente = DireccionCliente;
        this.ReferenciaDireccionCliente = ReferenciaDireccionCliente;
    }
    public AltaPedidoViewModel(){}
}

public class ModificarPedidoViewModel
{
    [Required]
    public long Numero {get; set;}
    [Required, MaxLength(100), MinLength(10)]
    public string Observacion{get; set;} 

    public ModificarPedidoViewModel(){}
    public ModificarPedidoViewModel(long numero,string Observacion)
    {
        Numero = numero;
        this.Observacion = Observacion;
    }
}