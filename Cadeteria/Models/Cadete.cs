using System;
using System.Collections.Generic;
namespace Cadeteria.Models;
    class Cadete:Persona
    {

        List<Pedido> Pedidos;

        public Cadete(string Nombre, string Direccion, long Telefono):base(Nombre, Direccion, Telefono)
        {
            Pedidos = new List<Pedido>();
        }

        public Cadete(long id,string Nombre, string Direccion, long Telefono):base(id,Nombre,Direccion,Telefono){Pedidos = new List<Pedido>();}

        public Cadete():base()
        {
            Pedidos = new List<Pedido>();
        }

        public void EliminarPedidoAsignado(uint numeroPedido)
        {
            foreach (var item in Pedidos)
            {
                if(item.Numero==numeroPedido)
                {
                    Pedidos.Remove(item);
                }
            }
        }

        public Pedido obtenerPedido(uint numeroPedido)
        {
            Pedido p = new Pedido();
            foreach (var item in Pedidos)
            {
                if(numeroPedido == item.Numero)
                {
                    p = item;
                }
            }
            return p;
        }

        public void AgregarPedido(Pedido p)
        {
            Pedidos.Add(p);
        }
    }
