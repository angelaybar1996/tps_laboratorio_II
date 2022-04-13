using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion entre ambos numeros
        /// </summary>
        /// <param name="num1">Parametro operador uno </param>
        /// <param name="num2">Parametro operador dos</param>
        /// <param name="operador">Parametro operador</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double Operar(Operando num1,Operando num2,char operador)
        {
            char auxOp;
            double retorno;

            auxOp = Calculadora.ValidarOperador(operador);
            retorno = -1;

            switch (auxOp)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '/':
                    if(num2 !=0)
                    {
                        retorno = num1 / num2;
                    }
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el operador sea correspondiente con +,-,*,/.
        /// </summary>
        /// <param name="operador">Paramatro recibido a validar</param>
        /// <returns>Retorna el operador correspondiente,en caso contrario retorna +</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno;
            retorno = '+';

            if(operador!='+' && operador != '-' && operador != '/' && operador != '*')
            {
                return retorno;
            }
            else if(operador=='+')
            {
                retorno= '+';
            }
            else if(operador == '-')
            {
                retorno = '-';
            }
            else if (operador == '*')
            {
                retorno = '*';
            }
            else if (operador == '/')
            {
                retorno = '/';
            }

            return retorno;

        }
    }
}
