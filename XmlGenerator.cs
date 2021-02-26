using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BpTools
{
    class XmlGenerator
    {
        CultureInfo cultureInfo = new CultureInfo("en-us");
        XmlDocument xml = new XmlDocument();

        public XmlGenerator(BpElement element)
        {
            Console.WriteLine(element.GetType().ToString());
            XmlNode baseNode;
            switch (element.GetType().ToString())
            {
                case "BpTools.Page":
                    baseNode = CreateProcessNode();
                    baseNode.AppendChild(CreatePageNode((Page)element));
                    ((Page)element).SubSheetInfo.SubsheetId = ((Page)element).StageId;
                    baseNode.AppendChild(CreateSubsheetInfoNode(((Page)element).SubSheetInfo));
                    foreach (Stage stage in ((Page)element).Stages)
                    {
                        stage.SubsheetId = ((Page)element).StageId;
                        baseNode.AppendChild(CreateStageFactory(stage));
                    }
                    break;
                case "BpTools.Start":
                    baseNode = CreateProcessNode();
                    baseNode.AppendChild(CreateStartNode((Start)element));
                    break;
                default:
                    throw new Exception("Unknown element type: " + element.GetType().ToString());
            }
            xml.AppendChild(baseNode);
        }

        public string GetFormattedString()
        {
            StringBuilder builder = new StringBuilder();
            using (XmlFragmentWriter writer = new XmlFragmentWriter(new StringWriter(builder)))
            {
                writer.Formatting = Formatting.Indented;
                xml.Save(writer);
            }
            return builder.ToString();
        }

        public XmlNode CreateProcessNode()
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "process", "");
            node.Attributes.Append(xml.CreateAttribute("name")).Value = "__selection__XmlInvestigations";
            
            return node;
        }

        public XmlNode CreateView(View view)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "view", "");
            node.AppendChild(xml.CreateElement("camerax")).InnerText = view.CameraX.ToString();
            node.AppendChild(xml.CreateElement("cameray")).InnerText = view.CameraY.ToString();
            XmlNode zoom = xml.CreateElement("zoom");
            zoom.InnerText = view.Zoom.ToString(cultureInfo);
            zoom.Attributes.Append(xml.CreateAttribute("version")).Value = view.Version;
            node.AppendChild(zoom);

            return node;
        }

        public XmlNode CreateFontNode(Font font)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "font", "");
            node.Attributes.Append(xml.CreateAttribute("family")).Value = font.Family;
            node.Attributes.Append(xml.CreateAttribute("size")).Value = font.Size.ToString();
            node.Attributes.Append(xml.CreateAttribute("style")).Value = font.Style;
            node.Attributes.Append(xml.CreateAttribute("color")).Value = font.Color;

            return node;
        }

        public XmlNode CreateParameter(Parameter parameter, string type)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, type, "");
            node.Attributes.Append(xml.CreateAttribute("type")).Value = parameter.Type;
            node.Attributes.Append(xml.CreateAttribute("name")).Value = parameter.Name;
            node.Attributes.Append(xml.CreateAttribute("narrative")).Value = parameter.Narrative;
            node.Attributes.Append(xml.CreateAttribute("stage")).Value = parameter.Stage;

            return node;
        }

        public XmlNode CreateInputParameter(Parameter parameter)
        {
            return CreateParameter(parameter, "input");
        }

        public XmlNode CreateOutputParameter(Parameter parameter)
        {
            return CreateParameter(parameter, "output");
        }

        public XmlNode CreateInputParameterCollection(InputParameterCollection inputParameters)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "inputs", "");
            foreach (Parameter input in inputParameters)
            {
                node.AppendChild(CreateInputParameter(input));
            }

            return node;
        }

        public XmlNode CreateOutputParameterCollection(OutputParameterCollection outputParameters)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "outputs", "");
            foreach (Parameter output in outputParameters)
            {
                node.AppendChild(CreateOutputParameter(output));
            }

            return node;
        }

        public XmlNode CreatePageNode(Page page)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "subsheet", "");
            node.Attributes.Append(xml.CreateAttribute("subsheetid")).Value = page.StageId;
            node.Attributes.Append(xml.CreateAttribute("type")).Value = page.Type;
            node.Attributes.Append(xml.CreateAttribute("published")).Value = page.Published.ToString();
            node.AppendChild(xml.CreateElement("name")).InnerText = page.Name;
            node.AppendChild(CreateView(page.View));

            return node;
        }

        public XmlNode CreateStageFactory (Stage stage)
        {
            switch (stage.GetType().ToString())
            {
                case "BpTools.Start":
                    return CreateStartNode((Start)stage);
                case "BpTools.SubSheetInfo":
                    return CreateSubsheetInfoNode((SubSheetInfo)stage);
                case "BpTools.End":
                    return CreateEndNode((End)stage);
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

            node.AppendChild(xml.CreateElement("subsheetid")).InnerText = stage.SubsheetId;
            node.AppendChild(xml.CreateElement("narrative")).InnerText = stage.Narrative;
            node.AppendChild(xml.CreateElement("displayx")).InnerText = stage.DisplayX.ToString();
            node.AppendChild(xml.CreateElement("displayy")).InnerText = stage.DisplayY.ToString();
            node.AppendChild(xml.CreateElement("displaywidth")).InnerText = stage.DisplayWidth.ToString();
            node.AppendChild(xml.CreateElement("displayheight")).InnerText = stage.DisplayHeight.ToString();
            node.AppendChild(CreateFontNode(stage.Font));

            return node;
        }

        public XmlNode CreateStartNode(Start start)
        {
            XmlNode node = CreateStageNode(start);
            node.AppendChild(CreateInputParameterCollection(start.InputParameters));
            node.AppendChild(xml.CreateElement("onsuccess")).InnerText = start.OnSuccess;
            return node;
        }

        public XmlNode CreateSubsheetInfoNode(SubSheetInfo subsheetInfo)
        {
            return CreateStageNode(subsheetInfo);
        }

        public XmlNode CreateEndNode(End end)
        {
            XmlNode node = CreateStageNode(end);
            node.AppendChild(CreateOutputParameterCollection(end.OutputParameters));
            return node;
        }
    }
}
