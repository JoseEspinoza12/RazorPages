using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int N { get; set; }

        public string Resultado { get; set; }

        public void OnPost(string accion)
        {
            if (string.IsNullOrWhiteSpace(Mensaje) || N <= 0)
            {
                Resultado = "Ingrese un mensaje y un valor de n válido.";
                return;
            }

            switch (accion)
            {
                case "codificar":
                    Resultado = Codificar(Mensaje.ToUpper(), N);
                    break;
                case "decodificar":
                    Resultado = Codificar(Mensaje.ToUpper(), 25 - (N % 25));
                    break;
            }
        }

        private string Codificar(string mensaje, int n)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in mensaje)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    resultado.Append((char)((((c - 'A') + n) % 25) + 'A'));
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}
