using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {           
            this.Limpiar();          
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Operando n1 = new Operando(txtNumero1.Text);
            Operando n2 = new Operando(txtNumero2.Text);
            char auxOp = char.Parse(cmbOperador.SelectedItem.ToString());

            lblResultado.Text=Calculadora.Operar(n1, n2, auxOp).ToString();
            lstOperaciones.Items.Add($"{txtNumero1.Text} {auxOp.ToString()} {txtNumero2.Text} = {lblResultado.Text}");

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            lblResultado.Text = "0";        
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            cmbOperador.SelectedIndex = 0;

        }

        //private static double Operar(string numero1,string numero2,string operador)
        //{

        //}
    }
}
