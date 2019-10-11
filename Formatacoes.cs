using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Helper
{
    public static class Formatacoes
    {
        /// <summary>
        /// Retira Tudo que não for letra ou numero da string
        /// </summary>
        /// <param name="input">string com apenas letras ou numeros</param>
        /// <returns>string sem a mascara</returns>
        public static string TiraMascara(this string input)
        {
            if (input.Length > 0 )
            {
                return Regex.Replace(input, "[^a-zA-z0-9]", "");
            }
            return input;
        }

        /// <summary>
        /// Coloca uma mascara em uma string, sopõe que todas elas tenham numeros, caso contrario joga uma exception
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ColocaMascara(this string input, string mascara)
        {
            try
            {
                return Convert.ToUInt64(input).ToString(mascara);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// tira os espacoes excedentes entre as palavras, exemplo: "uma       coisa" vira "uma coisa"
        /// </summary>
        /// <param name="input">string a ser formatada</param>
        /// <returns>string com um espaco entre as palavras</returns>
        public static string TiraEspacoExcedente(this string input)
        {
            return Regex.Replace(input, @"\s{2,}", " ");
        }

       

        /// <summary>
        /// remove o tudo que não for uma letra
        /// </summary>
        /// <param name="input">string a ser formatada</param>
        /// <returns>apenas as letras da string</returns>
        public static string RemoveNaoLetras(this string input)
        {
            return Regex.Replace(input, "[^a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]", "");
        }

        /// <summary>
        /// remove tudo o que não for numeros
        /// </summary>
        /// <param name="input">string a ser alterada</param>
        /// <returns>string sem caracteres que não for numero</returns>
        public static string RemoveNaoNumeros(this string input)
        {
            return Regex.Replace(input, @"[^\d]", "");
        }
        
        public static string NumeroDecimal(this string input)
        {
            return Regex.Replace(input, @"[^\d-,]", "");
        }

    }
}
