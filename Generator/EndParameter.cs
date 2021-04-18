using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public class EndParameter
    {
        BpToolsLib.EndParameter endParameter;

        public EndParameter(BpToolsLib.EndParameter endParameter)
        {
            this.endParameter = endParameter;
        }

        public XmlClasses.Output GetOutput()
        {
            XmlClasses.Output bpOutput = new XmlClasses.Output();
            bpOutput.Name = endParameter.Name;
            bpOutput.Type = DataTypeConverter.GetText(endParameter.Type);
            bpOutput.Narrative = endParameter.Description;
            bpOutput.Stage = endParameter.DataName;

            return bpOutput;
        }
    }
}
