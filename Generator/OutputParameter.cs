using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public class OutputParameter
    {
        BpTools.OutputParameter outputParameter;

        public OutputParameter(BpTools.OutputParameter outputParameter)
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
