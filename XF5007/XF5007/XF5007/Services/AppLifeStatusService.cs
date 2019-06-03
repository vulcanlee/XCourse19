using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XF5007.Services
{
    public class AppLifeStatusService
    {
        string filename = "User.txt";
        public async Task<string> ReadAsync()
        {
            string content = "";
            string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
            if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, $"{filename}");
            if (File.Exists(filePath))
            {
                using (var fileStream = File.Open(filePath, FileMode.Open))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        content = await streamReader.ReadToEndAsync();
                    }
                }
            }
            return content;
        }

        public async Task WriteAsync(string writeContent, bool reset = false)
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
            if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, $"{filename}");

            try
            {
                Console.WriteLine($"   --> {writeContent}");
                string content = await ReadAsync();
                using (var fileStream = File.Create(filePath))
                {
                    using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        if (reset == false)
                        {
                            await streamWriter.WriteAsync($"{writeContent}{Environment.NewLine}{content}");
                        }
                        else
                        {
                            await streamWriter.WriteAsync("");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
            }
        }

    }
}
