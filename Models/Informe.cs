using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Cadeterias;
using Cadetes;

namespace AccesoADato{
    public abstract class AccesoADatos{
        public abstract Cadeteria CargarDatosCadeteria(string? rutaArchivoCadeteria);
        public abstract List<Cadete> CargarDatosCadete(string? rutaArchivoCadete);

    }
    public class AccesoCSV : AccesoADatos{
        public override List<Cadete> CargarDatosCadete(string? rutaArchivoCadete){
            Cadete cadete = null;
            List<Cadete> listadoCadetes = new List<Cadete> ();
            using (var reader = new StreamReader(rutaArchivoCadete)){
                while (!reader.EndOfStream){
                    var linea = reader.ReadLine();
                    var valores = linea.Split(',');
                    if (valores.Length >= 4){
                        int id = int.Parse(valores[0]);
                        string nombre = valores[1];
                        string direccion = valores[2];
                        string telefono = valores[3];
                        cadete = new Cadete(id, nombre, direccion, telefono);
                        listadoCadetes.Add(cadete);
                    }
                }
            }
            return listadoCadetes;
        }
        public override Cadeteria CargarDatosCadeteria(string? rutaArchivoCadeteria){
        string nombre = "";
        string telefono = "";
        List<Cadete> cadetes = new List<Cadete>();
        using (var reader = new StreamReader(rutaArchivoCadeteria)){
            while (!reader.EndOfStream){
                var linea = reader.ReadLine();
                var valores = linea.Split(',');
                if (valores.Length >= 2){
                    nombre = valores[0];
                    telefono = valores[1];
                }
            }
        }
        Cadeteria cadeteria = new Cadeteria(nombre, telefono);
        return cadeteria;
    }
    }
    public class AccesoJSON : AccesoADatos{
        public override Cadeteria CargarDatosCadeteria(string? rutaArchivoCadeteria){
            Cadeteria NuevaCadeteria;
            string StringADeserealizar;
            using(var ArchivoOpen = new FileStream(rutaArchivoCadeteria, FileMode.Open)){
                using(var strReader = new StreamReader(ArchivoOpen)){
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                NuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(StringADeserealizar); 
            }
            return NuevaCadeteria;
        }
        public override List<Cadete> CargarDatosCadete(string? rutaArchivosCadete){
            List<Cadete> ListaDeserealizada;
            string StringADeserealizar;
            using (var ArchivoOpen = new FileStream(rutaArchivosCadete, FileMode.Open)){
                using (var strReader = new StreamReader(ArchivoOpen)){
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                ListaDeserealizada = JsonSerializer.Deserialize<List<Cadete>>(StringADeserealizar);
            }
            return ListaDeserealizada;
        }
    }
}