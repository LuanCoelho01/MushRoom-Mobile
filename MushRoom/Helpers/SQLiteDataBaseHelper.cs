using MushRoom.Models;
using SQLite;

namespace MushRoom.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Fornecedor>().Wait();
            _conn.CreateTableAsync<Producao>().Wait();
        }

        public Task <int> Insert (Fornecedor f)
        {
            return _conn.InsertAsync(f);
        }

        public Task <List<Fornecedor>> Update(Fornecedor f)
        {
            string sql = "UPDATE Fornecedor SET NomeFornecedor = ?, NomeProduto = ?, CNPJ = ?, Telefone = ? WHERE Id = ?";

            return _conn.QueryAsync<Fornecedor>(sql, f.NomeFornecedor,f.NomeProduto, f.CNPJ, f.Telefone, f.Id);
        }

        public Task <int> Delete(int id)
        {
            return _conn.Table<Fornecedor>().DeleteAsync(i => i.Id == id);
        }

        public Task <List<Fornecedor>> GetAll()
        {
            return _conn.Table<Fornecedor>().ToListAsync();
        }

        public Task <List<Fornecedor>> Search(string q)
        {
            string sql = "SELECT * FROM Fornecedor WHERE NomeFornecedor LIKE '%" + q + "%'";

            return _conn.QueryAsync<Fornecedor>(sql);
        }





    }
}
