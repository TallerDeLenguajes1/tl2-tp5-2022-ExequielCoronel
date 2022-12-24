namespace Cadeteria.Models;
    public class Pedido
    {
        bool Estado;
        uint Numero;
        string Observacion;
        Cliente cliente;

        public bool Estado1 { get => Estado; set => Estado = value; }
        public uint Numero1 { get => Numero; set => Numero = value; }
        public string Observacion1 { get => Observacion; set => Observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido()
        {
            Estado1 = false;
            Numero1 = 0;
            Observacion1 = "";
            Cliente = new Cliente();
        }

        public Pedido(uint Numero, string Observacion, bool estado)
        {
            Estado = estado;
            this.Observacion = Observacion;
            this.Numero = Numero;
        }
        public Pedido(uint Numero, string Observacion, string Nombre, uint telefono, string Direccion, string DatosDeReferencia)
        {
            Estado1 = false;
            this.Numero1 = Numero;
            this.Observacion1 = Observacion;
            Cliente cliente = new Cliente(DatosDeReferencia, Nombre, telefono, Direccion);
        }

        public uint getNumeroPedido(){return Numero1;}
        public bool ComprobarEstadoPedido(){return Estado1;}

        public void cambiarEstadoPedido(){Estado1 = !Estado1;}

    }
