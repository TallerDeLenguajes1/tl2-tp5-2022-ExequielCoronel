namespace Cadeteria.Models;

class ControlCSV
{
    private string RutaArchivoCSV;

    public ControlCSV(string path){RutaArchivoCSV=path;}
    public void EscribirEnCSV(String cadena)
    {
        StreamWriter archivo = new System.IO.StreamWriter(RutaArchivoCSV,true);
        archivo.WriteLine(cadena);
        archivo.Close();
    }

    public List<Cadete> ObtenerLista()
    {
        StreamReader archivo = new StreamReader(RutaArchivoCSV);
        List<Cadete> listadoCadetes = new List<Cadete>();
        while(!archivo.EndOfStream)
        {
            string lineas = archivo.ReadLine();
            string [] datos = lineas.Split(";");
            Cadete cadete = new Cadete(Convert.ToInt64(datos[0]),datos[1],datos[2],Convert.ToUInt32(datos[3]));
            listadoCadetes.Add(cadete);
        }
        archivo.Close();
        return listadoCadetes;
    }

    public void ElminarLinea(long ID)
    {
        List<Cadete> ListadoCadetes = new List<Cadete>();
        ListadoCadetes = ObtenerLista();
        File.Delete(RutaArchivoCSV);
        StreamWriter sw = new StreamWriter(RutaArchivoCSV);
        foreach (var cadete in ListadoCadetes)
        {
            if(cadete.ID!=ID)
            {
                sw.WriteLine(cadete.ID + ";" + cadete.Nombre + ";" + cadete.Direccion + ";" + cadete.Telefono);
            }
        }
        sw.Close();
    }
}