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
    private int id;
    [Required] [StringLength(100)]
    private string direccion; 
    [Required] [StringLength(50)]
    private string nombre;
    [Required] [Range(0,9223372036854775807)]
    private long telefono;
    public int Id { get => id; set => id = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public long Telefono { get => telefono; set => telefono = value; }

    List<Pedido> Pedidos;
}