using SQLite;

namespace MushRoom.Models
{
    public class Producao
    {
        string _nomeproducao;
        string _infoproducao;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeProducao
        {
            get => _nomeproducao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o nome do fornecedor");
                }
                _nomeproducao = value;
            }
        }
        public string InfoProducao
        {
            get => _infoproducao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o nome do produto");
                }
                _infoproducao = value;
            }
        }
        public string Inicio { get; set; }
        public string TrocaSubstrato { get; set; }
    }
}
