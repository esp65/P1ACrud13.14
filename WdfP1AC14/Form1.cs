namespace WdfP1AC14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServicioAlumno srvAlumno = new();
        MdAlumnos oAlumnos = new();
        
        private void DesplegarGrid()
        {
            var respuesta = srvAlumno.ConsultaSQL("select * from tb_alumnos");
            dataGridViewAlumnos.DataSource = respuesta;
        }


        private void buttonObtenerDatos_Click(object sender, EventArgs e)
        {
            DesplegarGrid();

        }

        private void MapaoDatosFormulario(MdAlumnos _alumnos)
        {
            textBoxCarnet.Text = _alumnos.carnet;
            textBoxNombre.Text = _alumnos.nombre;
            textBoxCorreo.Text = _alumnos.correo;
            comboBoxClase.Text = _alumnos.clase;
            comboBoxSeccion.Text = _alumnos.seccion;
            textBoxParcial1.Text = Convert.ToString(_alumnos.parcial1);
            textBoxParcial2.Text = Convert.ToString(_alumnos.parcial2);
            textBoxParcial3.Text = Convert.ToString(_alumnos.parcial3);


        }

        private void LimpiarDatos()
        {
            oAlumnos = new();
            MapaoDatosFormulario(oAlumnos);
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            string archivo = @"C:\Users\alumno";
            ClsImportExport im = new();
            MessageBox.Show(im.exportar("Select * from tb_alumnos where seccion = 'A'", archivo));
            
        }

       private MdAlumnos DatosFormulario()
       {
            MdAlumnos _alumnos = new MdAlumnos();
            _alumnos.carnet = textBoxCarnet.Text.Trim();
            _alumnos.nombre = textBoxNombre.Text.Trim();
            _alumnos.correo = textBoxCorreo.Text.Trim();
            _alumnos.clase = comboBoxClase.Text.Trim();
            _alumnos.seccion = comboBoxSeccion.Text.Trim();
            _alumnos.parcial1 = Convert.ToInt32(textBoxParcial1.Text);
            _alumnos.parcial2 = Convert.ToInt32(textBoxParcial2.Text);
            _alumnos.parcial3 = Convert.ToInt32(textBoxParcial3.Text);
            return _alumnos;

        }

        public void Validacion()
        {
            MessageBox.Show("La nota ingresada no es valida");
            LimpiarDatos();
            oAlumnos = DatosFormulario();
        }

        private void buttonCrearAlumno_Click(object sender, EventArgs e)
        {
            oAlumnos = DatosFormulario();

            if (oAlumnos.Parcial1 > 20)
            {
                Validacion();

            }
            else if (oAlumnos.Parcial2 >20)
            {
                Validacion();
            }
            else if (oAlumnos.Parcial3 < 35)
            {
                Validacion();

            }
            else
            {
                int respuesta = srvAlumno.CrearAlumno(oAlumnos);
                if (respuesta > 0 )
                {
                    MessageBox.Show("Disculpa hay un problema en la grabacion");
                }
            }



        }

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            BuscarAlumno(carnet);
        }

        private void BuscarAlumno(string carnet)
        {
            throw new NotImplementedException();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            oAlumnos = DatosFormulario();
            if (textBoxNombre.Text == "")
            {
                MessageBox.Show("Lo siento, 'Nombre' no puede quedar vacio");
                LimpiarDatos();
            }
            else
            {
                int respuesta = srvAlumno.ActualizarAlumno(oAlumnos);

                if (respuesta > 0) 
                {
                    MessageBox.Show("Se actualizo el Alumno");
                    LimpiarDatos();
                    DesplegarGrid();
                }
                else
                {
                    MessageBox.Show("Hay un problema con la grabacion");
                }
               
            }
            


        }
        
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            oAlumnos = DatosFormulario();
            DialogResult ev = MessageBox.Show("¿Estas seguro de borrar al Alumno?","Advertencia",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ev== DialogResult.Yes)
            {
                int respuesta = srvAlumno.EliminarAlumno(oAlumnos);
                
                if(respuesta > 0)
                {
                    MessageBox.Show("El alumno ha sido borrado");
                    LimpiarDatos();
                    DesplegarGrid();
                }else
                {
                    MessageBox.Show("Perdon, hay un pronlema en la Eliminacion");
                }
            }else if (ev==DialogResult.No)
            {
                DesplegarGrid();

            }

        }

        
        
    }
}