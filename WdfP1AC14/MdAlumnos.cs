namespace WdfP1AC14
{
    internal class MdAlumnos
    {
        internal int Parcial1;

        public int idAlumno { get; set; }
        public string? carnet { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? clase { get; set; }
        public string? seccion { get; set; }
        public int parcial1 { get; set; }
        public int parcial2 { get; set; }
        public int Parcial2 { get; internal set; }
        public int parcial3 { get; set; }
        public int Parcial3 { get; internal set; }

        public override string ToString()
        {
            return $"id:{idAlumno} Nombre:{nombre} seccion {seccion} Clase:{clase} Parcial 1 {parcial1} Parcial 2 {parcial2} Parcial 3 {parcial3} ";
        }
    }
}