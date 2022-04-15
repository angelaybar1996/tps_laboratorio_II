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
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga del FormCalculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalculadora_Load(object sender, EventArgs e)
        {           
            this.Limpiar();          
        }

        /// <summary>
        /// Llama al metodo limpiar que reestablece valores de inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Limpia el lblResultado,txtNumero1,txtNumero2 y en el cmbOperator le asigna la primera seleccion
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "0";        
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            cmbOperador.SelectedIndex = 0;

        }

        /// <summary>
        /// Realiza la operacion entre los operandos
        /// </summary>
        /// <param name="numero1">primer operando</param>
        /// <param name="numero2">segundo operando</param>
        /// <param name="operador">operador</param>
        /// <returns>Retorna el resultado de la operacion tipo double</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {


            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char auxOp = char.Parse(operador);
            double resultado;

            resultado = Calculadora.Operar(n1, n2, auxOp);
            return resultado;
        }

        /// <summary>
        /// Cierra el formulario y luego lo destruye
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }           
        }

        /// <summary>
        /// COnvierte el numero decimal double en una representacion entera en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Convierte el resultado binario en decimal double y lo muestra en el lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();

            lblResultado.Text=resultado.BinarioDecimal(lblResultado.Text);
            
            if (lblResultado.Text.StartsWith("Valor"))
            {
                MessageBox.Show("No es un numero binario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblResultado.Text = lblResultado.Text;
                this.Limpiar();
            }          
        }

        /// <summary>
        /// Realiza la operacion entre operandos, antes verifica que los campos esten completos
        /// tengan formato de numeros y retorna el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click_1(object sender, EventArgs e)
        {
            double auxResultado;
            string operador;

            if (String.IsNullOrWhiteSpace(txtNumero1.Text) || String.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                MessageBox.Show("Olvidaste completar los campos operandos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!Double.TryParse(txtNumero1.Text, out double auxNumero) || !Double.TryParse(txtNumero2.Text, out auxNumero) || Double.IsNaN(auxNumero))
                {
                    MessageBox.Show("Operandos no validos!Deben ser números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cmbOperador.SelectedItem.ToString() == "")
                    {
                        cmbOperador.Text = "+";
                        operador = "+";
                    }
                    else
                    {
                        operador = cmbOperador.SelectedItem.ToString();
                    }
                    auxResultado = FrmCalculadora.Operar(txtNumero1.Text.Replace(".", ","), txtNumero2.Text.Replace(".", ","), operador);
                    lblResultado.Text = auxResultado.ToString();
                    lstOperaciones.Items.Add($"{txtNumero1.Text.Replace(".", ",")} {operador} {txtNumero2.Text.Replace(".", ",")} = {lblResultado.Text}");
                }
            }
        }
    }
}
