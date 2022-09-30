/*
*Validador de placas feito por Rodolfo Dias na medium.com,
*Alterado em alguns pontos para melhor adequação ao codigo do desafio
*Fonte: https://medium.com/signainfo/validando-placa-de-ve%C3%ADculos-com-regular-expressions-em-c-62260c81137e
*/
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models;
class ValidadorDePlacas
{        
    public static bool ValidarPlaca(string placa)
    {
        //Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
        Regex padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
        //Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
        Regex padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");

        if (string.IsNullOrWhiteSpace(placa)) 
        {
            return false; 
        }

        if (placa.Length > 8 || placa.Length < 7) 
        {
            return false; 
        }

        /*
        *Verifica se o caractere da posição 4 é uma letra, se sim,
        *aplica a validação para o formato de placa do Mercosul,
        *senão, aplica a validação do formato de placa padrão.
        */
        if (char.IsLetter(placa, 4))
        {   
            return padraoMercosul.IsMatch(placa);
        }
        else
        {
            return padraoNormal.IsMatch(placa);
        }
    }    
}