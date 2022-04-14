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
            double auxResultado;
            string operador;

            if (String.IsNullOrWhiteSpace(txtNumero1.Text) && String.IsNullOrWhiteSpace(txtNumero2.Text) && cmbOperador.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Double.TryParse(txtNumero1.Text, out double garbageNumber) || !Double.TryParse(txtNumero2.Text, out garbageNumber))
            {
                MessageBox.Show("Error,debe ingresar numeros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (cmbOperador.SelectedItem == null)
            {
                cmbOperador.Text = "+";
                operador = "+";
            }
            else
            {
                operador = cmbOperador.SelectedItem.ToString();
            }

            auxResultado = FrmCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = auxResultado.ToString();
            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {txtNumero2.Text} = {lblResultado.Text}");                      
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

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char auxOp = char.Parse(operador);
            double resultado;

            resultado = Calculadora.Operar(n1, n2, auxOp);
            return resultado;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }           
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
           
            if(lblResultado.Text.StartsWith("-"))
            {
                MessageBox.Show("No disponible para convertir numeros negativos a binarios", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
            }                                      
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();

            lblResultado.Text=resultado.BinarioDecimal(lblResultado.Text);
            
            if (lblResultado.Text.StartsWith("Valor"))
            {
                MessageBox.Show("No es un numero binario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblResultado.Text = lblResultado.Text;
            }          
        }
    }
}
