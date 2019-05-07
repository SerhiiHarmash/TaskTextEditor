using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using TaskTextEditor.Models;

namespace TaskTextEditor
{
    class SqliteDataAccess
    {
        private readonly string _connectionString;

        public SqliteDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public async Task AddFile(FileModel file)
        {
            using (IDbConnection conection = new SQLiteConnection(_connectionString))
            {
                await conection.ExecuteAsync("insert into Files (Title, File) values (@Title, @File)", file);
            }
        }

        public async Task UpdateFile(FileModel file)
        {
            using (IDbConnection conection = new SQLiteConnection(_connectionString))
            {
               await conection.ExecuteAsync("update Files set File = @File where Id = @id", file);
            }
        }

        public async Task<List<FileOpenModel>> GetAllFilesForOpening()
        {
            using (IDbConnection conection = new SQLiteConnection(_connectionString))
            {
                var output = await conection.QueryAsync<FileOpenModel>("select Id, Title from Files", new DynamicParameters());
                return output.ToList();
            }
        }

        public async Task<FileModel> GetFileById(int id)
        {
            using (IDbConnection conection = new SQLiteConnection(_connectionString))
            {
                var file = await conection.QueryFirstAsync<FileModel>($"select * from Files where Id=@id", new { id });
                return file;
            }
        }
    }
}
