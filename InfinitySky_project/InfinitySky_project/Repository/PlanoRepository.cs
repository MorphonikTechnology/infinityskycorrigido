using InfinitySky_project.Models;
using MySql.Data.MySqlClient;

namespace InfinitySky_project.Repository
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly string _connectionString;

        public PlanoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Plano> GetPlano()
        {
            var planos = new List<Plano>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Plano_tbl LIMIT 3", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            planos.Add(new Plano
                            {
                                IdPlano = reader.GetInt32("id_plano"),
                                HospedagemPlano = reader.GetString("hospedagem_plano"),
                                CursoPlano = reader.GetString("curso_plano"),
                                InstituicaoPlano = reader.GetString("instituicao_plano"),
                                PeriodoPlano = reader.GetString("periodo_plano"),
                                DescricaoPlano = reader.GetString("descricao_plano"),
                                ImagemPlano = reader.GetString("imagem_plano"),
                                Valor = reader.GetDecimal("valor_plano")
                            });
                        }
                    }
                }
            }

            return planos;
        }
    }
}

