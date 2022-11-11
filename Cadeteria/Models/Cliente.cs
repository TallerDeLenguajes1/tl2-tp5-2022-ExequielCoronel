namespace Cadeteria.Models;
    class Cliente : Persona
    {
        string DatosReferenciaDireccion;

        public Cliente():base()
        {
            DatosReferenciaDireccion = "";
        }        
        public Cliente(long id,string Nombre, long Telefono, string Direccion,string DatosReferenciaDireccion):base(id,Nombre, Direccion, Telefono)
        {
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }

        public Cliente(string Nombre, long Telefono, string Direccion,string DatosReferenciaDireccion):base(Nombre,Direccion,Telefono)
        {
            this.DatosReferenciaDireccion=DatosReferenciaDireccion;
        }

        public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }
}
