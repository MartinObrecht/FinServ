using System.Text.RegularExpressions;

namespace FinServ.Domain.Entities.Helpers
{
    public static class CpfHelper
    {
        private static readonly Regex CpfRegex = new Regex(@"^\s*?(\d{3}\.?\d{3}\.?\d{3}-?\d{2})\s*?$", RegexOptions.Compiled);

        public static bool CpfValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            var cpfLimpo = ExtrairNumerosCpf(cpf);
            if (cpfLimpo == null || cpfLimpo.Length != 11 || new string(cpfLimpo[0], 11) == cpfLimpo) return false;

            var numeros = cpfLimpo.Select(c => c - '0').ToArray();
            return VerificarDigitos(numeros);
        }

        public static string ExtrairNumerosCpf(string cpf)
        {
            var match = CpfRegex.Match(cpf);
            return match.Success ? match.Groups[1].Value.Replace(".", "").Replace("-", "") : null;
        }

        private static bool VerificarDigitos(int[] numeros)
        {
            int calcularDigito(int[] baseNumeros, int[] multiplicadores)
            {
                var soma = baseNumeros.Zip(multiplicadores, (n, m) => n * m).Sum();
                var resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            var multiplicadores1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicadores2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var digito1 = calcularDigito(numeros.Take(9).ToArray(), multiplicadores1);
            var digito2 = calcularDigito(numeros.Take(10).ToArray(), multiplicadores2);

            return digito1 == numeros[9] && digito2 == numeros[10];
        }
    }
}
