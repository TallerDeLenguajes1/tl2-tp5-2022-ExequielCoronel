using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Cadeteria.Models;
using Cadeteria.Repositorios;
namespace Cadeteria.ViewModels;

public class GetPedidoViewModel
{
    long numero;
    public long Numero { get => numero; set => numero = value; }

    long? idCliente;
    public long? IdCliente { get => idCliente; set => idCliente = value; }

    string estado;
    public string Estado { get => estado; set => estado = value; }

    string observacion;
    public string Observacion { get => observacion; set => observacion = value; }

    public GetPedidoViewModel(long Numero, long? IDCliente, string Estado, string Observacion)
    {
        numero=Numero;
        idCliente=IDCliente;
        estado=Estado;
        observacion=Observacion;
    }
}

public class AltaPedidoViewModel
{
    [Required] [StringLength(2000)]
    string observacion;
    public string Observacion { get => observacion; set => observacion = value; }
    
}