using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLL
{
    public class JsonManager
    {
        public static string Read(string fileName, string location)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists($@"{desktopPath}\{location}"))
            {
                DirectoryInfo di = Directory.CreateDirectory($@"{desktopPath}\{location}");
            }

            var direccion = Path.Combine(
            $@"{desktopPath}",
            location,
            fileName);

            string jsonResult = string.Empty;

            using (StreamReader streamReader = new StreamReader(direccion))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public static void Write(string fileName, string location, string jSONString)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists($@"{desktopPath}\{location}"))
            {
                DirectoryInfo di = Directory.CreateDirectory($@"{desktopPath}\{location}");
            }

            var direccion = Path.Combine(
            $@"{desktopPath}",
            location,
            fileName);

            using (var streamWriter = File.CreateText(direccion))
            {
                streamWriter.Write(jSONString);
            }
        }
    }
}
