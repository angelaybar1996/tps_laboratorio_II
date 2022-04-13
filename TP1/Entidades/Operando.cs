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

        /// <summary>
        /// Constructor que asigna valor cero al atributo numero
        /// </summary>
        public Operando():this(0)
        {
           
        }

        /// <summary>
        /// Construtor que le asigna el valor recibido por parametro al atributo numero 
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que le asigna el valor recibido por parametro a la propiedad Numero
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Asigna un valor al atributo numero previa validacion
        /// </summary>
        private string Numero
        {         
            set
            {                          
             this.numero = this.ValidarOperando(value);               
            }
        }

        /// <summary>
        /// Convierte un número(tipo string) del sistema binario al sistema decimal(tipo string).
        /// </summary>
        /// <param name="binario">Parametro que recibe para ser convertido a Decimal</param>
        /// <returns>Retorna el número en formato decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno;
            int resultado;
            char[] array;

            retorno = string.Empty;
            resultado = 0;//dejarlo asi

            if (this.EsBinario(binario)==true)
            {             
                array = binario.ToCharArray();

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
       
        /// <summary>
        /// Determina si el parametro recibido es un numero binario
        /// </summary>
        /// <param name="binario">El parametro recibido</param>
        /// <returns>Retorna true si el numero es binario,caso contrario retornara false</returns>
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

        /// <summary>
        /// Realiza la resta entre n1 y n2 
        /// </summary>
        /// <param name="n1">Primer parametro de tipo Operando</param>
        /// <param name="n2">Segundo parametro de tipo Operando</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double operator - (Operando n1,Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre n1 y n2 
        /// </summary>
        /// <param name="n1">Primer parametro de tipo Operando</param>
        /// <param name="n2">Segundo parametro de tipo Operando</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre n1 y n2 
        /// </summary>
        /// <param name="n1">Primer parametro de tipo Operando</param>
        /// <param name="n2">Segundo parametro de tipo Operando</param>
        /// <returns>Retorna el resultado de la operacion, en caso que el n2 sea cero retornara double.MinValue </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;
            retorno = double.MinValue;

            if(n2.numero!=0)
            {             
                retorno = n1.numero / n2.numero;
            }           
            return retorno;
        }

        /// <summary>
        /// Realiza la suma entre n1 y n2 
        /// </summary>
        /// <param name="n1">Primer parametro de tipo Operando</param>
        /// <param name="n2">Segundo parametro de tipo Operando</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Valida si el parametro de tipo cadena es numerico y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero">El parametro recibido</param>
        /// <returns>Retorna el numero validado,en caso que no sea un numero retorna cero</returns>
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
