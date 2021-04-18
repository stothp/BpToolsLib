using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "stage")]
    public class Stage
    {
        [XmlAttribute("stageid")]
        public string StageId { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("narrative")]
        public string Narrative { get; set; }

        [XmlElement("display")]
        public Display Display { get; set; }

        //[XmlElement("displayx")]
        //public int DisplayX { get; set; }
        //[XmlElement("displayy")]
        //public int DisplayY { get; set; }
        //[XmlElement("displaywidth")]
        //public int DisplayWidth { get; set; }
        //[XmlElement("displayheight")]
        //public int DisplayHeight { get; set; }
        [XmlElement("font")]
        public Font Font { get; set; }

        [XmlElement("subsheetid")]
        public string SubsheetId { get; set; }
        [XmlElement("onsuccess")]
        public string OnSuccess { get; set; }
        [XmlArray("preconditions")]
        public List<Condition> Preconditions { get; set; }
        [XmlArray("postconditions")]
        public List<Condition> Postconditions { get; set; } 
        [XmlArray("inputs")]
        public List<Input> Inputs { get; set; } 
        [XmlArray("outputs")]
        public List<Output> Outputs { get; set; }
        [XmlElement("processid")]
        public string ProcessId { get; set; }
        [XmlElement("datatype")]
        public string DataType { get; set; }
        [XmlElement("private")]
        public string Private { get; set; }
        [XmlElement("alwaysinit")]
        public string AlwaysInit { get; set; }
        [XmlElement("decision")]
        public Decision Decision { get; set; }
        [XmlElement("ontrue")]
        public string OnTrue { get; set; }
        [XmlElement("onfalse")]
        public string OnFalse { get; set; }
        [XmlElement("groupid")]
        public string GroupId { get; set; }
        [XmlElement("calculation")]
        public Calculation Calculation { get; set; }
        [XmlArray("steps")]
        public List<Calculation> Steps { get; set; }
        [XmlElement("collectioninfo")]
        public CollectionInfo CollectionInfo { get; set; }
        [XmlElement("resource")]
        public Resource Resource { get; set; }
        [XmlElement("initialvalue")]
        public InitialValue InitialValue { get; set; }
        [XmlElement("looptype")]
        public string LoopType { get; set; }
        [XmlElement("loopdata")]
        public string LoopData { get; set; }
        [XmlElement("alert")]
        public Alert Alert { get; set; }
        [XmlElement("exception")]
        public Exception Exception { get; set; }
        [XmlElement("exposure")]
        public string Exposure { get; set; }
        [XmlElement("expression")]
        public string Expression { get; set; }
        [XmlArray("choices")]
        public List<Choice> Choices { get; set; }

        [XmlIgnore]
        public string Code { get; set; }
        [XmlElement("code")]
        public System.Xml.XmlCDataSection CodeCDATA
        {
            get
            {
                if (Code == null)
                {
                    return null;
                }
                else
                {
                    return new System.Xml.XmlDocument().CreateCDataSection(Code);
                }
            }
            set
            {
                Code = value.Value;
            }
        }        

        [XmlIgnore]
        public bool PreconditionsSpecified
        {
            get { return (this.Preconditions != null && this.Preconditions.Count > 0); }
        }
        [XmlIgnore]
        public bool PostconditionsSpecified
        {
            get { return (this.Postconditions != null && this.Postconditions.Count > 0); }
        }
        [XmlIgnore]
        public bool InputsSpecified
        {
            get { return (this.Inputs != null && this.Inputs.Count > 0); }
        }
        [XmlIgnore]
        public bool OutputsSpecified
        {
            get { return (this.Outputs != null && this.Outputs.Count > 0); }
        }
        [XmlIgnore]
        public bool StepsSpecified
        {
            get { return (this.Steps != null && this.Steps.Count > 0); }
        }
        [XmlIgnore]
        public bool ChoicesSpecified
        {
            get { return (this.Choices != null && this.Choices.Count > 0); }
        }

    }
}
