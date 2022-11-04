namespace Cadeteria.Models;
    class Cliente : Persona
    {
        string DatosReferenciaDireccion;

        public Cliente():base()
        {
            DatosReferenciaDireccion = "";
        }        
        public Cliente(string DatosReferenciaDireccion, string Nombre, uint Telefono, string Direccion):base(Nombre, Direccion, Telefono)
        {
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }
    }
