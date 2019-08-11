using DALUdeO.DataClass;
using DALUdeO.Reader;
using Modelos.Persona;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DALUdeO.Conexion;
using Modelos.Personal;

namespace DALUdeO
{
    public partial class Form1 : Form
    {
       conexion2 con = new conexion2();
        
        //se declara una variable de tipo boleana que sirve para indicar si el usuario presiono el boton editar
        bool editar;
        int Id;

        //metodo de actulizar
        public void ActualizarGrid()
        {
            // Aca se hace una funcion (select) para mostrar los datos

            con.ActualizarGrid(this.dataGridView1, "SELECT * FROM odeodal.persona");
        }

        public void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {


            //guardar
            if (editar)
            {
                
                //Se realiza un update
                con.Conectar();
                string consulta = "update persona set Nombre  = '" + textBox1.Text + "', Apellido  ='" + textBox2.Text + "', Direccion  ='" + textBox3.Text + "' where idpersona = " + Id + " ;";
                con.EjecutarSql(consulta);
                this.ActualizarGrid();
                con.Desconectar();

                editar = false;

            }
            else
            {
            
                con.Conectar();

                //Se crea una consulta para insertar los datos (Guardar)
                string consulta = "insert into persona (Nombre, Apellido, Direccion) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' );";
                //con esta funcion ejecuto la consulta de arriba en codigo sql
                con.EjecutarSql(consulta);
                this.ActualizarGrid();
                con.Desconectar();
          
            }

            limpiar();


            ////Query de consultas
            //PersonaModel personaModel = new PersonaModel();
            //personaModel.IdPersona = 2;
            //personaModel.Nombre = "Lorena ";
            //personaModel.Apellido = "Gregorio";
            //personaModel.Direccion = "Zona 21";



            //PersonaReader reader = new PersonaReader(QuerysRepo.TipoQuery.PorId, personaModel);
            //Collection<PersonaModel> persona = reader.Execute();

            //foreach (PersonaModel p2 in persona)
            //    MessageBox.Show(string.Format("{0}, {1}, {2}", p2.Nombre, p2.Apellido, p2.Direccion));
            // finaliza query de consultas




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //La variable editar se agrega para que sea true
            editar = true;

            // se agregan las campos de los datos por columna como un vector
            Id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                PersonalModel personalModel = new PersonalModel();
                personalModel.IdPersonal = 9;
                personalModel.Nombres = "Sonia";
                personalModel.Apellidos = "Banana";
                personalModel.Direccion = "Zona 4";
                personalModel.Area = "Administracion";
                personalModel.Puesto = "Secretaria";

                //Clase.Enum
                //Recibe el TipoQuery como la PersonaModel
                PersonalReader reader = new PersonalReader(QuerysRepo.TipoQuery2.Todos, personalModel);
                Collection<PersonalModel> personales = reader.Execute();

                foreach (PersonalModel p in personales)
                {
                    MessageBox.Show(string.Format("{0},{1},{2},{3},{4}", p.Nombres, p.Apellidos, p.Direccion, p.Area, p.Puesto));
                }
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
