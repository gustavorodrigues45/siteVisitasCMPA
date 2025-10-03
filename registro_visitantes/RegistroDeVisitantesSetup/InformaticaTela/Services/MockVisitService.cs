using InformaticaTela.Models;
using InformaticaTela.Services;

namespace InformaticaTela.Services
{
    public class MockVisitService : IVisitService
    {
        private List<Visit> todasVisitas = new List<Visit>
        {
            new Visit { Nome = "Jo�o da Silva", HoraChegada = DateTime.Today.AddHours(9).AddMinutes(15) },
            new Visit { Nome = "Maria Oliveira", HoraChegada = DateTime.Today.AddHours(10).AddMinutes(5) },
            new Visit { Nome = "Carlos Souza", HoraChegada = DateTime.Today.AddHours(11).AddMinutes(40) },

            // Exemplo de visita em outro dia (n�o deve aparecer no site)
            new Visit { Nome = "Ant�nio Pereira", HoraChegada = DateTime.Today.AddDays(-1).AddHours(14) }
        };

        public List<Visit> GetVisitasDiarias()
        {
            // Filtra apenas as visitas do dia atual
            return todasVisitas
                .Where(v => v.HoraChegada.Date == DateTime.Today)
                .OrderBy(v => v.HoraChegada) // organiza por hor�rio
                .ToList();
        }
    }
}
