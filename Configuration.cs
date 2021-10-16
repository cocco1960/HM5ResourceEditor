using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HM5ResourceEditor
{
    class Configuration
    {
        public bool CheckIfGamePathEntryAdded()
        {
            try
            {
                List<string> lines = File.ReadAllLines("HM5ResourceEditor.ini").ToList();
                string line = lines.Where(l => l.StartsWith("GamePath")).FirstOrDefault();

                return line != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hitman Absolution Resource Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public string GetGamePath()
        {
            try
            {
                List<string> lines = File.ReadAllLines("HM5ResourceEditor.ini").ToList();
                string line = lines.Where(l => l.StartsWith("GamePath")).FirstOrDefault();

                if (line != null)
                {
                    string path = line.Substring(line.IndexOf('=') + 1);

                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void WriteGamePath(string path)
        {
            try
            {
                List<string> lines = File.ReadAllLines("HM5ResourceEditor.ini").ToList();
                string line = lines.Where(l => l.StartsWith("GamePath")).FirstOrDefault();

                if (line != null)
                {
                    string currentPath = line.Substring(line.IndexOf('=') + 1);
                    string newPath;

                    if (currentPath.Equals(""))
                    {
                        newPath = line + path;
                    }
                    else
                    {
                        newPath = line.Replace(line.Substring(line.IndexOf('=') + 1), path);
                    }

                    int index = lines.FindIndex(l => l.StartsWith("GamePath"));
                    lines[index] = newPath;
                }
                else
                {
                    lines.Add("GamePath=" + path);
                }

                File.WriteAllLines("HM5ResourceEditor.ini", lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hitman Absolution Resource Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
