using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Registro_de_Empleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Empleados Empleado = new Empleados();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "No ingreso el nombre"); txtNombre.Focus(); return;
            }

            errorProvider1.SetError(txtNombre, "");


            if (txtDUI.Text == "")
            {
                errorProvider1.SetError(txtDUI, "No ingreso el DUI");
                txtNombre.Focus();
                return;
            }
            errorProvider1.SetError(txtNombre, "");





            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "No ingresó el nombre");
                txtNombre.Focus();
                return;
            }

            errorProvider1.SetError(txtNombre, "");

            if (txtDUI.Text == "")
            {
                errorProvider1.SetError(txtDUI, "No ingresó el DUI");
                txtNombre.Focus();
                return;
            }

            errorProvider1.SetError(txtNombre, "");


            double Salario;

            if (!double.TryParse(txtSalario.Text, out Salario))
            {
                errorProvider1.SetError(txtSalario, "No ingresó el salario de forma correcta"); txtSalario.Focus(); return;
            }



            Empleado.Nombre = txtNombre.Text;
            Empleado.Dui = txtDUI.Text;
            Empleado.Salario = Convert.ToDouble(txtSalario.Text);
            txtAFP.Text = Empleado.AFP(Empleado.Salario).ToString();
            lbMostrar.Text = "¡Registro guardado!";

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Planilla.mdf;Integrated Security=True;Connect Timeout=30");

            conexion.Open();

             string nombre = txtNombre.Text;
             string dui = txtDUI.Text; 
             double salario =Double.Parse( txtSalario.Text); 
             double afp =Double.Parse( txtAFP.Text);

            string cadena = "insert into [Empleados] (Nombre, DUI, Salario, AFP) values ('" + nombre + "','" + dui + "','" + salario + "','" + afp + "')";

            SqlCommand comando = new SqlCommand(cadena, conexion);

            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se guardaron correctamente");
            conexion.Close();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Planilla.mdf;Integrated Security=True;Connect Timeout=30"); 
            
            conexion.Open();

            string cod = txtCod.Text; string cadena = "select Nombre, DUI from Empleados where Id=" + cod; SqlCommand comando = new SqlCommand(cadena, conexion); SqlDataReader registro = comando.ExecuteReader(); 
            if (registro.Read())
            {
                lbNombre.Text = registro["Nombre"].ToString(); lbDUI.Text = registro["DUI"].ToString();
            }
            else
            {
                MessageBox.Show("No existe un Empleado con el código ingresado"); conexion.Close();
            }
               
        }
    }
}
