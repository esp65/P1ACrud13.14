using P1ACrud13._14.Clases.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1ACrud13._14.Clases.Servicios
{
    internal class ClsImportExport
    {
        private ClsConexion cone;

        public ClsImportExport()
        {
            cone = new();
        }


        public string importar(string archivo)
        {
            string texto = "";
            try
            {
                texto = File.ReadAllText(archivo);
                return $"Procesados:{cone.EjecutarSQLDirecto(texto)}";
            }
            catch (Exception ex)
            {
                return $"Hubo un error al importar {ex.Message}";
            }
        }


        public string exportar(string instruccion, string archivoDestino)
        {
            string textoSalida = "";
            DataTable respuesta = cone.consultaTablaDirecta(instruccion);


            foreach (DataRow dr in respuesta.Rows)
            {
                textoSalida += $"{dr["carnet"]};{dr["nombre"]};{dr["seccion"]};{dr["parcial1"]};{dr["parcial2"]};{dr["parcial3"]}\n";
            }


            if (!string.IsNullOrEmpty(textoSalida))
            {
                try
                {
                    File.WriteAllText(archivoDestino, textoSalida);
                    return $"Procesado o creado archivo {archivoDestino}";
                }
                catch (Exception ex)
                {
                    return $"hay clavo en el arhcivo {ex.Message}";
                }
            }

            return "no se encontraron registros";

        }
    }
}
