namespace InfinitySky_project.Models
{
    public class Pais
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Clima { get; set; }
            public string ComidasTip { get; set; }
            public string Moeda { get; set; }
            public string Descricao { get; set; }
            public ICollection<Plano> Planos { get; set; }
        }

    }

