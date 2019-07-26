using System;

namespace FormularioCadastroCliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataAberturaEmpresa { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public enum Status
        {
            DataInvalida,
            TodosCamposNaoPreenchidos,
            CnpjInvalido,
            Ok
        }

        public static Status Validar(Cliente cliente)
        {
            if (Preenchido(cliente.RazaoSocial) || Preenchido(cliente.NomeFantasia) || Preenchido(cliente.Cnpj) || Preenchido(Convert.ToString(cliente.DataAberturaEmpresa)) || Preenchido(cliente.Endereco) || Preenchido(cliente.Bairro) || Preenchido(cliente.Cidade) || Preenchido(cliente.Uf))
            {
                return Status.TodosCamposNaoPreenchidos;
            }
            if (!CnpjValido(cliente.Cnpj))
            {
                return Status.CnpjInvalido;
            }
            if (!DataValida(cliente.DataAberturaEmpresa))
            {
                return Status.DataInvalida;
            }
            return Status.Ok;
        }

        public static bool Preenchido(string valor)
        {
            return !string.IsNullOrEmpty(valor.Trim());
        }

        public static bool CnpjValido(string cnpj)
        {
            //cnpj = cnpj.Replace(/[^\d] +/ g, "");

            if (Preenchido(cnpj))
            {
                return false;
            }

            if (cnpj.Length != 14)
            {
                return false;
            }

            var tamanho = cnpj.Length - 2;
            var numeros = cnpj.Substring(0, tamanho);
            var digitos = cnpj.Substring(tamanho);
            var soma = 0;
            var pos = tamanho - 7;

            for (var x = tamanho; x >= 1; x--)
            {
                soma += numeros[tamanho - x] * pos--;
                if (pos < 2)
                    pos = 9;
            }

            var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (Convert.ToString(resultado) != Convert.ToString(digitos[0]))
            {
                return false;
            }

            tamanho = tamanho + 1;
            numeros = cnpj.Substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;

            for (var i = tamanho; i >= 1; i--)
            {
                soma += numeros[tamanho - i] * pos--;
                if (pos < 2)
                    pos = 9;
            }

            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;

            return Convert.ToString(resultado) == Convert.ToString(digitos[1]);
        }

        public static bool DataValida(DateTime? data)
        {
            //var reg = / (0[1 - 9] |[12][0 - 9] | 3[01])[- /.](0[1 - 9] | 1[012])[- /.](19 | 20)\d\d /;
            //if (!Convert.ToString(data).match(reg))
            //{
            //    return false;
            //}
            //var partesData = data.Split("/");
            //var dataFormatada = new Date(partesData[2], partesData[1] - 1, partesData[0]);

            //return new Date() > dataFormatada;
            return true;
        }
    }
}
