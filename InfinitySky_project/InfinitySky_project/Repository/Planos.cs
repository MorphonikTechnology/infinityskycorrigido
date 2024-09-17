using InfinitySky_project.Models;
using MySql.Data.MySqlClient;

namespace InfinitySky_project.Repository
{
    public class Planos
    {
        private readonly string _connectionString;

        public Planos(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Plano> GetPlanos()
        {
            var planos = new List<Plano>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM Plano_tbl", connection))
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
                                Valor = reader.GetDecimal("valor_plano") // Supondo que você adicionou o campo valor_plano
                            });
                        }
                    }
                }
            }

            return planos;
        }

        public Plano GetPlanoById(int id)
        {
            Plano plano = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM Plano_tbl WHERE id_plano = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            plano = new Plano
                            {

                                //get de puxar 
                                IdPlano = reader.GetInt32("id_plano"),
                                HospedagemPlano = reader.GetString("hospedagem_plano"),
                                CursoPlano = reader.GetString("curso_plano"),
                                InstituicaoPlano = reader.GetString("instituicao_plano"),
                                PeriodoPlano = reader.GetString("periodo_plano"),
                                DescricaoPlano = reader.GetString("descricao_plano"),
                                ImagemPlano = reader.GetString("imagem_plano"),
                                Valor = reader.GetDecimal("valor_plano")
                            };
                        }
                    }
                }
            }

            return plano;
        }
    }
}

    