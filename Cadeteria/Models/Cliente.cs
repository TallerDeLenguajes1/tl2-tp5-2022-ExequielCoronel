namespace Cadeteria.Models;
    class Cliente : Persona
    {
        string DatosReferenciaDireccion;

        public Cliente():base()
        {
            DatosReferenciaDireccion = "";
        }        
        public Cliente(string DatosReferenciaDireccion, string Nombre, long Telefono, string Direccion):base(Nombre, Direccion, Telefono)
        {
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }
    }
