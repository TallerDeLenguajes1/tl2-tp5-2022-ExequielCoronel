using System.Collections.Generic;
namespace Cadeteria.Models;
    class CadeteriaDB
    {
        string Nombre;
        uint Telefono;
        List<Cadete> Cadetes = new List<Cadete>();

        public List<Cadete> Cadetes1 { get => Cadetes; set => Cadetes = value; }

    public CadeteriaDB(string Nombre, uint Telefono)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }

        public bool ExisteCadete(long ID)
        {
            foreach (var Cadete in this.Cadetes)
            {
                if(Cadete.ID==ID)
                {
                    return true;
                }
            }
            return false;
        }

        public Cadete buscarCadete(long ID)
        {
            Cadete c = new Cadete();
            foreach (var Cadete in Cadetes)
            {
                if(Cadete.ID == ID)
                {
                    c=Cadete;
                }
            }
            return c;
        }

        public bool EliminarCadete(long ID)
        {
            foreach (var Cadete in Cadetes)
            {
                if(Cadete.ID==ID)
                {
                    Cadetes.Remove(Cadete);
                    return true;
                }
            }
            return false;
        }
        public void AgregarCadete(Cadete c)
        {
            this.Cadetes.Add(c);
        }

    }
