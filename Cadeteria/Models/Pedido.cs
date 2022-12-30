namespace Cadeteria.Models;
    public class Pedido
    {
        public bool Estado;
        public uint Numero;
        public string Observacion;
        public Cliente cliente;

        public Pedido()
        {
            Estado = false;
            Numero = 0;
            Observacion = "";
            Cliente cliente = new Cliente();
        }

        public Pedido(uint Numero, string Observacion, bool estado)
        {
            Estado = estado;
            this.Observacion = Observacion;
            this.Numero = Numero;
        }
        public Pedido(uint Numero, string Observacion, string Nombre, uint telefono, string Direccion, string DatosDeReferencia)
        {
            Estado = false;
            this.Numero = Numero;
            this.Observacion = Observacion;
            Cliente cliente = new Cliente(DatosDeReferencia, Nombre, telefono, Direccion);
        }

        public uint getNumeroPedido(){return Numero;}
        public bool ComprobarEstadoPedido(){return Estado;}

        public void cambiarEstadoPedido(){Estado = !Estado;}

    }
