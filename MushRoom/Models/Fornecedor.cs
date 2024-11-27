using SQLite;

namespace MushRoom.Models
{
    public class Fornecedor
    {
        string _nomefornecedor;
        string _nomeproduto; 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeFornecedor
        {
            get => _nomefornecedor;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o nome do fornecedor");
                }
                _nomefornecedor = value;
            }
        }
        public string NomeProduto
        {
            get => _nomeproduto;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o nome do produto");
                }
                _nomeproduto = value;
            }
        }
        public string CNPJ {  get; set; }
        public string Telefone { get; set; }

    }
}
