namespace BLL
{
    using System.IO;

    public class FileLogger : ILogger
    {
        private string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        private void WriteToFile(string formattedString)
        {
            File.AppendAllText(this.filePath, formattedString + "\n");
        }

        public void Info(string message)
        {
            this.WriteToFile("[INFO]: " + message);
        }

        public void Warn(string message)
        {
            this.WriteToFile("[WARNING]: " + message);
        }

        public void Error(string message)
        {
            this.WriteToFile("[ERROR]: " + message);
        }

        public void Critical(string message)
        {
            this.WriteToFile("[CRITICAL]: " + message);
        }

        public void Debug(string message)
        {
            this.WriteToFile("[Debug]: " + message);
        }
    }
}
