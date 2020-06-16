using Microsoft.Extensions.Logging;

namespace WebLabs_Klempach.Services
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string _filePath;
        public FileLoggerProvider(string path)
        {
            _filePath = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filePath);
        }

        public void Dispose()
        {
            return;
        }
    }
}
