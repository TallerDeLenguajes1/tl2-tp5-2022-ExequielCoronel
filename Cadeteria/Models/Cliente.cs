namespace Cadeteria.Models;
    public class Cliente : Persona
    {
        public string DatosReferenciaDireccion;

        public Cliente():base()
        {
            DatosReferenciaDireccion = "";
        }

    public Cliente(string Nombre, string Direccion, long Telefono, string direccion) : base(Nombre, Direccion, Telefono)
    {
    }

    public Cliente(long ID,string DatosReferenciaDireccion, string Nombre, long Telefono, string Direccion):base(ID,Nombre, Direccion, Telefono)
        {
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }
    }
 