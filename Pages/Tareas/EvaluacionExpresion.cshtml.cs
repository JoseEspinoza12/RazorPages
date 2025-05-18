using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MyApp.Namespace
{
    public class EvaluacionExpresionModel : PageModel
    {
        // Definir los atributos
        [BindProperty]
        public int A { get; set; }
        [BindProperty]
        public int B { get; set; }
        [BindProperty]
        public int X { get; set; }
        [BindProperty]
        public int Y { get; set; }
        [BindProperty]
        public int N { get; set; }
        
        public double ResultadoDirecto { get; set; }
        public List<TerminoExpansion> Terminos { get; set; } = new();
        public double ResultadoExpansion { get; set; }

        public void OnGet()
        {
            // Valores por defecto para demostración
            A = 2;
            B = 1;
            X = 3;
            Y = 2;
            N = 2;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Calcular();
            }
            return Page();
        }

        public void Calcular()
        {
            // Cálculo directo
            ResultadoDirecto = Math.Pow((A * X) + (B * Y), N);
            
            // Cálculo por expansión binomial
            ResultadoExpansion = 0;
            Terminos.Clear();
            
            for (int k = 0; k <= N; k++)
            {
                double coeficiente = CalcularCoeficienteBinomial(N, k);
                double termino = coeficiente * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                
                Terminos.Add(new TerminoExpansion
                {
                    K = k,
                    CoeficienteBinomial = coeficiente,
                    ValorTermino = termino,
                    ExpresionTermino = $"{coeficiente} * ({A*X})^{N-k} * ({B*Y})^{k}"
                });
                
                ResultadoExpansion += termino;
            }
        }
        
        private double CalcularCoeficienteBinomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
        
        private double Factorial(int number)
        {
            if (number <= 1)
                return 1;
            return number * Factorial(number - 1);
        }

        public class TerminoExpansion
        {
            public int K { get; set; }
            public double CoeficienteBinomial { get; set; }
            public double ValorTermino { get; set; }
            public string ExpresionTermino { get; set; } = string.Empty;
        }
    }
}