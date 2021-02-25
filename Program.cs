using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BpTools
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xdoc = new XmlDocument();
            //xdoc.Load("bp.xml");

            //foreach (XmlNode node in xdoc.ChildNodes)
            //{
            //    Console.WriteLine(node.Name);
            //}

            Page p = new Page("Page1", false);
            Start s = new Start();
            s.Narrative = "Ez itt egy leírás..";
            s.InputParameters.Add(new InputParameter("Text", "Név", "Teszt", "data1"));
            p.Stages.Add(s);

            XmlGenerator xg = new XmlGenerator();
            Console.WriteLine(xg.GenerateXml(p).OuterXml);

            Console.ReadLine();
        }
    }
}
