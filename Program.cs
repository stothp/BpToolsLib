using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BpTools
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Page page = new Page("Page 1");
            //page.PageInformation.Description = "Leírás\r\nMert szeretem";
            //page.Start.NextStage = new End();
            //page.Start.NextStage.Y = 45;
            //page.Start.InputParameters.Add(new Parameter(DataType.Text, "Próba", "Leírás, ne higyj nekem!", "Data1"));

            //page.OtherStages.Add(new Data("Data1", DataType.Text, "Próbaképpen"));

            //ToBp.XmlBuilder.BuildXmlProcess(page);


            BpClasses.Process proc = BpClasses.Test.TestIn(Clipboard.GetText());

            ////Console.WriteLine(proc.Stages[0].CollectionInfo.Fields[0].Name);
            string xml = BpClasses.Test.TestOut(proc);
            Console.WriteLine(xml);
            Clipboard.SetText(xml);

            Console.ReadLine();
        }
    }
}
