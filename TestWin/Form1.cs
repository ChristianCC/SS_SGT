using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
 

namespace TestWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {

            string res = Encriptacion.Desencriptar(Convert.FromBase64String(tbDesEncripta.Text));
            tbDesEncriptaResultado.Text = res;
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            byte[] res =  Encriptacion.Encriptar(tbEncripta.Text);
            tbEncriptaResultado.Text = Convert.ToBase64String(res);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Encriptacion.EncriptarContraseña(
                tbPwd.Text,
                tbUsuario.Text
                );
            tbResultado.Text = res;
        }
    }
}
