using Microsoft.AspNetCore.Mvc;
using OrchardCore.Media;
using System.Text;

namespace OrchardModule.Controllers
{
    public class FileManagementController : Controller
    {
        private readonly IMediaFileStore _mediaFileStore;

        public FileManagementController(IMediaFileStore media)
        {
            _mediaFileStore = media;
        }

        public async Task<string> CreateFile()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("hello world"));
            await _mediaFileStore.CreateFileFromStreamAsync("Demo.txt", stream);
            return "OK";
        }

        public async Task<string> ReadFile()
        {
            var fileInfo = await _mediaFileStore.GetFileInfoAsync("Demo.txt");

            using var stream = await _mediaFileStore.GetFileStreamAsync("Demo.txt");
            using var streamReader = new StreamReader(stream);
            var content = await streamReader.ReadToEndAsync();

            return $"file info: size{fileInfo.Length}, content: {content}";
        }
    }
}
