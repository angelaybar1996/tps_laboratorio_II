using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {

        }

        public Operando(string strNumero)
        {

        }



        //medio raro chequearlo
        private string Numero
        {         
            set
            {
               if( this.ValidarOperando(this.numero.ToString())!=0)
                {
                    this.Numero = value;

                }
            }
        }

        /// <summary>
        /// Convierte un número(tipo string) del sistema binario al sistema decimal(tipo string).
        /// </summary>
        /// <param name="numero">Parametro que recibe para ser convertido a Decimal</param>
        /// <returns>Retorna el número en formato decimal</returns>
        public string BinarioDecimal(string numero)
        {
            string retorno;
            int resultado;
            char[] array;

            retorno = string.Empty;
            resultado = 0;//dejarlo asi

            if (this.EsBinario(numero)==true)
            {             
                array = numero.ToCharArray();

                // Invertido  los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
                Array.Reverse(array);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        // Usamos la potencia de 2, según la posición
                        resultado += (int)Math.Pow(2, i);
                    }                 
                }
                retorno = resultado.ToString();
            } 
            else
            {
                retorno = "Valor invalido";
            }          
            return retorno;
        }

        /// <summary>
        /// Convierte un número double del sistema decimal al sistema binario
        /// </summary>
        /// <param name="numero">Parametro que recibe para ser convertido</param>
        /// <returns>Retorna el número en formato binario</returns>
        public string DecimalBinario(double numero)
        {
            string retorno;
            retorno = "";

            if (numero > 0)
            {
                String binario = "";

                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }

                    numero = (int)(numero / 2);
                }

                retorno = binario;
            }
            else
            {
                if (numero == 0)
                {
                    retorno = "0";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un número decimal(tipo string) en un numero binario(tipo string)
        /// </summary>
        /// <param name="numero">Parametro que recibe para ser convertido</param>
        /// <returns>Retorna el número en formato binario</returns>  
       public string DecimalBinario(string numero)
        {
            string retorno;
            double numeroFlotante;


            retorno = string.Empty;
            numeroFlotante = Convert.ToDouble(numero);

            if (numeroFlotante > 0)
            {
                String binario = "";

                while (numeroFlotante > 0)
                {
                    if (numeroFlotante % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }

                    numeroFlotante = (int)(numeroFlotante / 2);
                }

                retorno = binario;
            }
            else
            {
                if (numeroFlotante == 0)
                {
                    retorno = "0";
                }
            }
            return retorno;
        }

        private bool EsBinario(string binario)
        {
            bool retorno;
            char[] array;

            retorno = true;
            array = binario.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] !='0' && array[i] !='1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        public static double operator - (Operando n1,Operando n2)
        {
            double retorno;
            retorno = 0;
            return retorno;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            double retorno;
            retorno = 0;
            return retorno;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;
            retorno = 0;
            return retorno;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            double retorno;
            retorno = 0;
            return retorno;
        }

        private double ValidarOperando(string strNumero)
        {
            double retorno;
            double numero;
            retorno = 0;

            if(double.TryParse(strNumero,out numero)==true)
            {
                retorno = numero;
            }
            else
            {
               retorno=0;
            }

            return retorno;
        }



    }

}
