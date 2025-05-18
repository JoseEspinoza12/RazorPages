using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class NumerosRandomModel : PageModel
    {

        public int[] Numeros { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public int[] Ordenados { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }

        public void OnGet()
        {
            GenerarDatos();
        }

        public void OnPost()
        {
            GenerarDatos();
        }

        private void GenerarDatos()
        {
            Random rnd = new Random();
            Numeros = new int[20];

            for (int i = 0; i < Numeros.Length; i++)
            {
                Numeros[i] = rnd.Next(0, 101);
            }

            Suma = Numeros.Sum();
            Promedio = Suma / (double)Numeros.Length;

            Ordenados = Numeros.OrderBy(n => n).ToArray();

            // Moda
            var frecuencias = Numeros.GroupBy(n => n)
                                    .Select(g => new { Numero = g.Key, Frecuencia = g.Count() })
                                    .Where(g => g.Frecuencia > 1)
                                    .OrderByDescending(g => g.Frecuencia);

            int maxFrecuencia = frecuencias.FirstOrDefault()?.Frecuencia ?? 0;
            Moda = frecuencias.Where(g => g.Frecuencia == maxFrecuencia)
                            .Select(g => g.Numero).ToList();

            // Mediana
            if (Ordenados.Length % 2 == 0)
            {
                int mid1 = Ordenados[Ordenados.Length / 2 - 1];
                int mid2 = Ordenados[Ordenados.Length / 2];
                Mediana = (mid1 + mid2) / 2.0;
            }
            else
            {
                Mediana = Ordenados[Ordenados.Length / 2];
            }
        }
    }
}
