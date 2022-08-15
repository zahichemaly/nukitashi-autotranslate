using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TextTranslator.Translators;

namespace TextTranslator
{
    public class FileHelper
    {
        private string sourcePath = ConfigurationManager.AppSettings["SourcePath"];
        private string desPath = ConfigurationManager.AppSettings["DesPath"];

        public void ReadFile()
        {
            var txtFiles = Directory.GetFiles(sourcePath, "*.txt");
            var paths = new List<string>(txtFiles);

            ITranslator translator = new GoogleTranslator();

            // Create dest folder if not exists
            Directory.CreateDirectory(desPath);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            foreach (var path in paths)
            {
                var fileName = Path.GetFileName(path);
                var tmpPath = Path.Combine(desPath, fileName);
                ProcessFile(translator, path, tmpPath);
            }
        }

        private void ProcessFile(ITranslator translator, string inputPath, string outputPath)
        {
            string line;
            var japaneseEncoding = Encoding.GetEncoding(932);
            using (StreamReader reader = new StreamReader(inputPath, japaneseEncoding))
            using (StreamWriter writer = new StreamWriter(outputPath, false, japaneseEncoding))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line) &&
                        !line.StartsWith("$") &&
                        !line.StartsWith(";"))
                    {
                        //ja-JP -> en-US
                        string translatedText = translator.Translate("en-US", line).Result;
                        writer.WriteLine(translatedText);
                        Console.WriteLine(line + " ~> " + translatedText);
                        //break;
                    }
                    else
                    {
                        //writer.WriteLine(line);
                    }
                }
                writer.Close();
                reader.Close();
            }
        }
    }
}
