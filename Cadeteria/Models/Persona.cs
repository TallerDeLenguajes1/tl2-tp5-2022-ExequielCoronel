
namespace Cadeteria.Models;
    class Persona
    {
        private static long AI = 0;
        private long iD;
        private string nombre;
        private string direccion;
        private uint telefono;

        public long ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }

    public Persona()
        {
            ID = 0;
            Nombre = "";
            Direccion = "";
            Telefono = 0;
        }

        public Persona(string Nombre, string Direccion, uint Telefono)
        {
            
            this.ID = AI;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            AI++;
        }

        public Persona(long ID,string Nombre, string Direccion, uint Telefono)
        {
            this.ID=ID;
            this.Nombre = Nombre;
            this.Direccion=Direccion;
            this.Telefono=Telefono;
        }
    }
