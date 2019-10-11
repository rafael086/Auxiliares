using System;
using System.Text.RegularExpressions;

namespace Helper
{
    public static class Validacoes
    {


        /// <summary>
        /// Metodo que verifica letras sem espaço
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool Verificanome(this string input)
        {
            return Regex.IsMatch(input.TiraEspacoExcedente().Trim(), "^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
        }

        public static bool ValidaRG(this string input)
        {

            return Regex.IsMatch(input, @"[a-zA-Z0-9]{9}");
        }



        /// <summary>
        /// Verifica se todos os número digitados são válidos
        /// </summary>
        /// <param name="nValor01"></param>
        /// <returns></returns>
        public static bool SoNumeros(this string nValor01)
        {
            nValor01 = nValor01.TiraEspacoExcedente();
            return Regex.IsMatch(nValor01, "^[0-9]+$");

        }

        /// <summary>
        /// verifica se o NCM tem 8 digitos
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidaNCM(this string input)
        {
            return Regex.IsMatch(input, @"^\d{8}$");
        }

        /// <summary>
        /// Verifica se a entrada é um email valido
        /// </summary>
        /// <param name="input">string a ser verificada</param>
        /// <returns>true se for um email valido, false se não for</returns>
        public static bool Email(this string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z][0-9a-zA-Z\._-]+@([a-zA-Z0-9\\.]+\.)[a-zA-A-09]+$");
        }

        /// <summary>
        /// verifica se a entrada é um telefone valido(dez caracteres numericos, não verifica se é um telefone existente)
        /// </summary>
        /// <param name="input">string a ser verificada</param>
        /// <returns>true se o telefone for valido, false se for invalido</returns>
        public static bool Telefone(this string input)
        {
            return Regex.IsMatch(input, @"^\d{10,11}$");
        }

        /// <summary>
        /// verifica se a entrada é um CEP valido(oito caracteres numericos, não verifica se é um CEP existente)
        /// </summary>
        /// <param name="input">string a ser validada</param>
        /// <returns>true se for um cep valido, false se nao for</returns>
        public static bool CEP(this string input)
        {
            return Regex.IsMatch(input, @"^\d{8}$");
        }

        /// <summary>
        /// retorna true se a string for uma data valida
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool Data(this string input)
        {
            try
            {
                Convert.ToDateTime(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Valida um cnpj, referencia: http://www.geradorcnpj.com/javascript-validar-cnpj.htm
        /// </summary>
        /// <param name="input">CNPJ a ser validado</param>
        /// <returns>false se o CNPJ for invalido. true se for valido</returns>
        public static bool validaCNPJ(this string cnpj)
        {
            //retira tudo o que não for digito
            cnpj = Regex.Replace(cnpj, "[^\\d]+", "");

            //elimina cnpjs invalidos
            if (cnpj.Length != 14 || cnpj == "00000000000000" || cnpj == "11111111111111" || cnpj == "22222222222222" || cnpj == "33333333333333" || cnpj == "44444444444444" || cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777" || cnpj == "88888888888888" || cnpj == "99999999999999")
                return false;

            //valida DVs
            int tamanho = cnpj.Length - 2;
            string numeros = cnpj.Substring(0, tamanho);
            string digitos = cnpj.Substring(tamanho);
            int soma = 0;
            int pos = tamanho - 7;
            for (int i = tamanho; i >= 1; i--)
            {
                soma += Convert.ToInt32(numeros[tamanho - i].ToString()) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            int resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != Convert.ToInt32(digitos[0].ToString()))
                return false;
            tamanho++;
            numeros = cnpj.Substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (int i = tamanho; i >= 1; i--)
            {
                soma += Convert.ToInt32(numeros[tamanho - i].ToString()) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != Convert.ToInt32(digitos[1].ToString()))
                return false;
            return true;
        }

        /// <summary>
        /// Valida um cpf, referencia: http://www.geradorcpf.com/javascript-validar-cpf.htm
        /// </summary>
        /// <param name="cpf">CPF a ser validado</param>
        /// <returns>true se for valido, false se for invalido</returns>
        public static bool ValidaCPF(this string cpf)
        {
            cpf = Regex.Replace(cpf, "[^\\d]+", "");
            // Elimina CPFs invalidos conhecidos    
            if (cpf.Length != 11 || cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
                return false;
            //valida o 1 digito
            int add = 0;
            for (int i = 0; i < 9; i++)
                add += Convert.ToInt32(cpf[i].ToString()) * (10 - i);
            int rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != Convert.ToInt32(cpf[9].ToString()))
                return false;
            //valida o segundo digito
            add = 0;
            for (int i = 0; i < 10; i++)
                add += Convert.ToInt32(cpf[i].ToString()) * (11 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != Convert.ToInt32(cpf[10].ToString()))
                return false;
            return true;
        }

    }
}
