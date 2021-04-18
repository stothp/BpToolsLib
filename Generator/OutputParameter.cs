using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public class OutputParameter
    {
        BpToolsLib.OutputParameter outputParameter;

        public OutputParameter(BpToolsLib.OutputParameter outputParameter)
        {
            this.outputParameter = outputParameter;
        }

        public XmlClasses.Output GetOutput()
        {
            XmlClasses.Output bpOutput = new XmlClasses.Output();
            bpOutput.Name = outputParameter.Name;
            bpOutput.Type = DataTypeConverter.GetText(outputParameter.Type);
            bpOutput.Narrative = outputParameter.Description;
            bpOutput.Stage = outputParameter.DataName;

            return bpOutput;
        }
    }
}
