using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BpTools
{
    class XmlGenerator
    {
        XmlDocument xml = new XmlDocument();

        public XmlNode GenerateXml(BpElement element)
        {
            Console.WriteLine(element.GetType().ToString());
            switch (element.GetType().ToString())
            {
                case "BpTools.Page":
                    XmlNode node = CreateProcessNode();
                    node.AppendChild(CreatePageNode((Page)element));
                    return node;
                default:
                    throw new Exception("Unknown element type: " + element.GetType().ToString());
            }
             
        }

        public XmlNode CreateProcessNode()
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "process", "");
            node.Attributes.Append(xml.CreateAttribute("name")).Value = "__selection__Test";
            
            return node;
        }

        public XmlNode CreateView(View view)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "view", "");
            node.AppendChild(xml.CreateElement("camerax")).InnerText = view.CameraX.ToString();
            node.AppendChild(xml.CreateElement("cameray")).InnerText = view.CameraY.ToString();
            XmlNode zoom = xml.CreateElement("zoom");
            zoom.InnerText = view.CameraY.ToString();
            zoom.Attributes.Append(xml.CreateAttribute("version")).Value = view.Version;
            node.AppendChild(zoom);

            return node;
        }

        public XmlNode CreateInputParameters(View view)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "view", "");
            node.AppendChild(xml.CreateElement("camerax", view.CameraX.ToString()));
            node.AppendChild(xml.CreateElement("cameray", view.CameraY.ToString()));
            node.AppendChild(xml.CreateElement("zoom", view.CameraY.ToString()))
                .Attributes.Append(xml.CreateAttribute("version")).Value = view.Version;

            return node;
        }

        public XmlNode CreateInputParameter(InputParameter input)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "input", "");
            node.Attributes.Append(xml.CreateAttribute("type")).Value = input.Type;
            node.Attributes.Append(xml.CreateAttribute("name")).Value = input.Name;
            node.Attributes.Append(xml.CreateAttribute("narrative")).Value = input.Narrative;
            node.Attributes.Append(xml.CreateAttribute("stage")).Value = input.Stage;

            return node;
        }

        public XmlNode CreateInputParameterCollection(InputParameterCollection inputParameters)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "inputs", "");
            foreach (InputParameter input in inputParameters)
            {
                node.AppendChild(CreateInputParameter(input));
            }

            return node;
        }

        public XmlNode CreatePageNode(Page page)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "subsheet", "");
            node.Attributes.Append(xml.CreateAttribute("subsheetid")).Value = page.StageId;
            node.Attributes.Append(xml.CreateAttribute("type")).Value = page.Type;
            node.Attributes.Append(xml.CreateAttribute("published")).Value = page.Published.ToString();
            node.Attributes.Append(xml.CreateAttribute("name")).Value = page.Name;
            node.AppendChild(CreateView(page.View));

            foreach (Stage stage in page.Stages)
            {
                node.AppendChild(CreateStageFactory(stage));
            }

            return node;
        }

        public XmlNode CreateStageFactory (Stage stage)
        {
            switch (stage.GetType().ToString())
            {
                case "BpTools.Start":
                    return CreateStartNode((Start)stage);
                default:
                    throw new Exception("Unknown stage type: " + stage.GetType().ToString());
            }
        }

        public XmlNode CreateStageNode (Stage stage)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "stage", "");
            
            node.Attributes.Append(xml.CreateAttribute("stageid")).Value = stage.StageId;
            node.Attributes.Append(xml.CreateAttribute("name")).Value = stage.Name;
            node.Attributes.Append(xml.CreateAttribute("type")).Value = stage.Type;

            node.AppendChild(xml.CreateElement("narrative")).InnerText = stage.Narrative;

            return node;
        }

        public XmlNode CreateStartNode(Start start)
        {
            XmlNode node = CreateStageNode(start);

            node.AppendChild(CreateInputParameterCollection(start.InputParameters));

            return node;
        }
    }
}
