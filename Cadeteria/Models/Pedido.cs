namespace Cadeteria.Models;
    class Pedido
    {
    private string estado;
    private long numero;
        private string observacion;
        private long IDCliente;

        public string Observacion { get => observacion; set => observacion = value; }
        public long Numero { get => numero; set => numero = value; }
        public long IDCliente1 { get => IDCliente; set => IDCliente = value; }
        public string Estado { get => estado; set => estado = value; }

    public Pedido()
        {
            Estado = "No entregado";
            Numero = 0;
            Observacion = "";
            IDCliente = 0;
        }
        public Pedido(long Numero, string Observacion, long idCliente)
        {
            Estado = "No entregado";
            this.Numero = Numero;
            this.Observacion = Observacion;
            IDCliente = idCliente;
        }

    }
