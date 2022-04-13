using System;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando num1,Operando num2,char operador)
        {
            char auxOp;

            auxOp = Calculadora.ValidarOperador(operador);


            return 
        }

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
