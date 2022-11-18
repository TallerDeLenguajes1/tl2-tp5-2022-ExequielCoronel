namespace Cadeteria.Models;
    class Pedido
    {
        private string estado;

        private bool cadeteAsignado;
        private long numero;
        private string observacion;
        private long IDCliente;

        public string Observacion { get => observacion; set => observacion = value; }
        public long Numero { get => numero; set => numero = value; }
        public long IDCliente1 { get => IDCliente; set => IDCliente = value; }
        public string Estado { get => estado; set => estado = value; }
        public bool CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

    public Pedido()
        {
            Estado = "No entregado";
            cadeteAsignado = false;
            Numero = 0;
            Observacion = "";
            IDCliente = 0;
        }
        public Pedido(long Numero, string Observacion, long idCliente)
        {
            Estado = "No entregado";
            cadeteAsignado = false;
            this.Numero = Numero;
            this.Observacion = Observacion;
            IDCliente = idCliente;
        }

    }
