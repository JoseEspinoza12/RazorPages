using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class DeterminarIMCModel : PageModel
    {
        
        [BindProperty]
        public int Peso { get; set; }
        [BindProperty]
        public int Altura { get; set; }
        public float? IMC { get; set; }
        public string Resultado { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Recomendacion { get; set; } = "";
        
        public void OnGet()
        {
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
            double alturaMetros = Altura / 100.0; 
            double imc = Peso / Math.Pow(alturaMetros, 2);
            IMC = (float)imc;

            switch (imc)
            {
                case < 18.5:
                    Resultado = "Bajo peso";
                    Imagen = "https://st2.depositphotos.com/1062793/5303/i/450/depositphotos_53038743-stock-illustration-doodle-hungry-dog.jpg";
                    Recomendacion = "Aumentar el consumo de calorías y proteínas.";
                    break;
                case >= 18.5 and < 25:
                    Resultado = "Peso normal";
                    Imagen = "https://img.freepik.com/fotos-premium/retrato-hombre-negocios-sonriente-dando-pulgares_53419-3804.jpg";
                    Recomendacion = "Mantener hábitos saludables.";
                    break;
                case >= 25 and < 27:
                    Resultado = "Sobrepeso";
                    Imagen = "https://static7.depositphotos.com/1001911/681/v/450/depositphotos_6815136-stock-illustration-dislike-emoticon.jpg";
                    Recomendacion = "Considerar una dieta equilibrada y ejercicio.";
                    break;
                case >= 27 and < 30:
                    Resultado = "Obesidad Grado 1";
                    Imagen = "https://refaccionariamario.info/147204-large_default/calcomania-externa-de-vinyl-con-imagen-no-se-admiten-gordas.jpg";
                    Recomendacion = "Consultar a un profesional de la salud.";
                    break;
                case >= 30 and < 40:
                    Resultado = "Obesidad Grado 2";
                    Imagen = "https://i.ytimg.com/vi/v25QfyWmQ_o/mqdefault.jpg";
                    Recomendacion = "Consultar a un profesional de la salud.";
                    break;
                case >= 40:
                    Resultado = "Obesidad Grado 3";
                    Imagen = "https://heraldodemexico.com.mx/u/fotografias/m/2025/1/22/f850x638-1075006_1152495_7338.png";
                    Recomendacion = "Consultar a un profesional de la salud.";
                    break;
                default:
                    Resultado = "Error en el cálculo del IMC.";
                    Imagen = "https://www.healthywa.wa.gov.au/~/media/HealthyWA/Images/Articles/2015/06/23/IMC-Error.jpg";
                    Recomendacion = "Verificar los datos ingresados.";
                    break;
            }
        }
    }
}
