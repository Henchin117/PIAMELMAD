using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PIAMEL2._0
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        SqlConnection coneccion = new SqlConnection("server= DESKTOP-C08OI78\\SQLEXPRESS ; database = SITEMA ; INTEGRATED SECURITY = true");

        private void btn_login_Click(object sender, EventArgs e)
        {
            coneccion.Open();
            SqlCommand comando = new SqlCommand("SELECT [USER], PASWORD FROM LOGIN WHERE [USER] = @vUser AND PASWORD = @vPassword", coneccion);
            comando.Parameters.AddWithValue("@vUser", txt_user.Text);
            comando.Parameters.AddWithValue("@vPassword", txt_pass.Text);

            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                coneccion.Close();
                Form11 pantalla = new Form11();
                pantalla.Show();
            }

        }
    }
}
