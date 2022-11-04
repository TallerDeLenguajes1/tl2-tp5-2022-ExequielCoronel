namespace Cadeteria.Models;
    class Pedido
    {
        const uint INDEFINIDO = 9999999;
        bool Estado;
        uint Numero;
        string Observacion;
        Cliente cliente;

        public Pedido()
        {
            Estado = false;
            Numero = 0;
            Observacion = "";
            cliente = new Cliente();
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
