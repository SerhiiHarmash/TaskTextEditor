using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTextEditor.Models;

namespace TaskTextEditor
{
    public class FileService
    {
        private readonly SqliteDataAccess _sqliteAccess;

        public FileService()
        {
            _sqliteAccess = new SqliteDataAccess();
        }

        public async Task<FileModel> GetFile(int id)
        {
            return await _sqliteAccess.GetFileById(id);
        }

        public async Task<List<FileOpenModel>> GetAllFilesForOpening()
        {
            return await _sqliteAccess.GetAllFilesForOpening();
        }

        public string ReadFile(byte[] file)
        {
            var decompressedFile = SevenZipHelper.Decompress(file);

            var result = Encoding.Default.GetString(decompressedFile);

            return result;
        }

        public async Task FileSave(FileModel file, string text)
        {
            file.File = CompressText(text);
            if (file.Id == null)
            {
                await _sqliteAccess.AddFile(file);
            }
            else
            {
                await _sqliteAccess.UpdateFile(file);
            }
        }

        private byte[] CompressText(string text)
        {
            var bytes = Encoding.Default.GetBytes(text);

            return SevenZipHelper.Compress(bytes);
        }
    }
}
