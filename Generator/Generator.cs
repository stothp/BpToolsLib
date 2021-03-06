using BpToolsLib.XmlClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace BpToolsLib.Generator
{
    public class Generator
    {
        public XmlClasses.Process Process { get; }

        public Generator (BpToolsLib.IBaseElement element)
        {
            if (element is BpToolsLib.Process)
            {
                Process = new Process((BpToolsLib.Process)element).GetBpProcess();
            }
            else if (element is BpToolsLib.Page)
            {
                BpToolsLib.Process baseProcess = new BpToolsLib.Process("__selection__copy");
                baseProcess.Pages.Add((BpToolsLib.Page)element);
                Process = new Process(baseProcess).GetBpProcess();
            }
            else if (element is BpToolsLib.StageSet)
            {
                BpToolsLib.Process baseProcess = new BpToolsLib.Process("__selection__copy");
                Process = new Process(baseProcess).GetBpProcess();
                Process.Stages = new StageSet((BpToolsLib.StageSet)element).GetBpStage();
            }
            else
            {
                throw new System.Exception("Invalid element to generate XML from");
            }
        }

        public string GetXml()
        {
            var EmptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer ser = new XmlSerializer(typeof(XmlClasses.Process));
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            StringBuilder builder = new StringBuilder();
            ser.Serialize(XmlWriter.Create(new StringWriter(builder), settings), Process, EmptyNamespaces);
            return builder.ToString();
        }
    }
}