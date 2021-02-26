using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Security.Permissions;

namespace BpTools
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Page page = new Page("Robinak teszt");
            page.SubSheetInfo.Narrative = "Ide írtam egy szöveget.";

            Start start = new Start();
            start.InputParameters.Add(new Parameter("text", "param1", "Első paraméter", "Data1"));
            start.InputParameters.Add(new Parameter("text", "param2", "MÁsodik paraméter", "Data2"));

            page.Stages.Add(start);

            End end = new End();
            end.OutputParameters.Add(new Parameter("text", "param1", "Első paraméter", "Data1"));
            end.OutputParameters.Add(new Parameter("text", "param2", "MÁsodik paraméter", "Data2"));

            end.DisplayY = 45;

            page.Stages.Add(end);

            start.OnSuccess = end.StageId;

            XmlGenerator xg = new XmlGenerator(page);
            string xml = xg.GetFormattedString();
            Console.WriteLine(xml);
            Clipboard.SetText(xml);

            Console.ReadLine();
        }
    }
}
