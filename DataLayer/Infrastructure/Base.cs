using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace DataLayer.Infrastructure
{
    
    public abstract class Base
    {
        private readonly string path;
        protected Base(string path)
        {
            this.path = path;
        }

        protected void WriteErrorMessageToLog(Dictionary<string, string> errorMessage)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                string error= "";
                try
                {
                    foreach (var line in errorMessage)
                    {
                        writer.WriteLine(line.Key + ": " + line.Value);
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
        }

        protected string ReadErrorMessageFromLog()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string errors = "";
                try
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        errors += reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    errors = "The file could not be read: " +
                        ex.Message;
                }
                return errors;
            }
            
        }

    }
}
