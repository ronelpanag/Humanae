using System;

namespace Humanae.DomainGlobal
{
    public static class ValidationHelper
    {
        public static bool ValidateIdentification(string identification)
        {
            int sumaPar = 0;
            int sumaImpar = 0;
            int longitud = Convert.ToInt32(identification.Length);
            /*Control de errores en el código*/
            try
            {
                //verificamos que la longitud del parametro sea igual a 11
                if (longitud == 11)
                {
                    int digitoVerificador = Convert.ToInt32(identification.Substring(10, 1));
                    //recorremos en un ciclo for cada dígito de la cédula
                    for (int i = 9; i >= 0; i--)
                      {
                        //si el digito no es par multiplicamos por 2
                        int digito = Convert.ToInt32(identification.Substring(i, 1));
                        if ((i % 2) != 0)
                        {
                            int digitoImpar = digito * 2;
                            //si el digito obtenido es mayor a 10, restamos 9
                            if (digitoImpar >= 10)
                              {
                                digitoImpar = digitoImpar - 9;
                            }
                            sumaImpar = sumaImpar + digitoImpar;
                        }
                        /*En los demás casos sumamos el dígito y lo aculamos 
                         en la variable */
                        else
                        {
                            sumaPar = sumaPar + digito;
                        }
                    }
                    //Declaración de variables a nivel de método o función.
                    /*Obtenemos el verificador restandole a 10 el modulo 10 
        de la suma total de los dígitos*/
                    int verificador = 10 - ((sumaPar + sumaImpar) % 10);
                    /*si el verificador es igual a 10 y el dígito verificador
                      es igual a cero o el verificador y el dígito verificador 
                      son iguales retorna verdadero*/
                    if (((verificador == 10) && 
                        (digitoVerificador == 0)) || 
                        (verificador == digitoVerificador))
                      {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
