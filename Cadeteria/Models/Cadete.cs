using System;
using System.Collections.Generic;
namespace Cadeteria.Models;
    class Cadete:Persona
    {

        List<Pedido> Pedidos;

        public Cadete(string Nombre, string Direccion, uint Telefono):base(Nombre, Direccion, Telefono)
        {
            Pedidos = new List<Pedido>();
        }

        public Cadete(long id,string Nombre, string Direccion, uint Telefono):base(id,Nombre,Direccion,Telefono){Pedidos = new List<Pedido>();}

        public Cadete():base()
        {
            Pedidos = new List<Pedido>();
        }

        public void cambiarEstadoPedido(uint NumeroPedido)
        {
            Pedido pedidoAcambiarEstado;
            foreach (var item in Pedidos)
            {
                if(item.getNumeroPedido() == NumeroPedido)
                {
                    pedidoAcambiarEstado = item;
                    Pedidos.Remove(item);
                    pedidoAcambiarEstado.cambiarEstadoPedido();
                    Pedidos.Add(pedidoAcambiarEstado);
                }
            }
        }

        public void EliminarPedidoAsignado(uint numeroPedido)
        {
            foreach (var item in Pedidos)
            {
                if(item.getNumeroPedido()==numeroPedido)
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
                if(numeroPedido == item.getNumeroPedido())
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
        public float JornalACobrar()
        {
            float total = 0;
           foreach (var item in Pedidos)
           {
                if(item.ComprobarEstadoPedido())
                {
                    total = total + 300;
                }
           }
           return total;
        }
    }
