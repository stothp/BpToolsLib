using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    public class Test
    {
        public static string TestOut(Process process)
        {
            //Process process = new Process();
            //process.Name = "__selection__TEst";

            //Subsheet subsheet = new Subsheet();
            //subsheet.SubsheetId = System.Guid.NewGuid().ToString();
            //subsheet.Type = "Normal";
            //subsheet.Published = "True";
            //subsheet.Name = "Test1";
            //subsheet.View = new View();
            //subsheet.View.CameraX = 0;
            //subsheet.View.CameraY = 0;
            //subsheet.View.Zoom = new Zoom();
            //subsheet.View.Zoom.Value = 1.25;

            //process.Subsheets = new List<Subsheet>();
            //process.Subsheets.Add(subsheet);

            //Stage stage = new Stage();
            //stage.SubsheetId = subsheet.SubsheetId;
            //stage.StageId = System.Guid.NewGuid().ToString();
            //stage.Name = "Start";
            //stage.Type = "Start";
            //stage.DisplayX = 0;
            //stage.DisplayY = 0;
            //stage.DisplayHeight = 30;
            //stage.DisplayWidth = 60;
            //stage.Font = new Font();
            //stage.Font.Family = "Segoe UI";
            //stage.Font.Size = 10;
            //stage.Font.Style = "Regular";
            //stage.Font.Color = "000000";

            //process.Stages = new List<Stage>();
            //process.Stages.Add(stage);

            var EmptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer ser = new XmlSerializer(typeof(Process));
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            StringBuilder builder = new StringBuilder();
            ser.Serialize(XmlWriter.Create(new StringWriter(builder), settings), process, EmptyNamespaces);
            return builder.ToString();
        }

        public static Process TestIn(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Process));

            Process proc;

            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);

            using (Stream reader = stream)
            {
                proc = (Process)ser.Deserialize(reader);
            }

            return proc;
        }
    }
}
