using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public class StartParameter
    {
        BpTools.StartParameter startParameter;

        public StartParameter(BpTools.StartParameter startParameter)
        {
            this.startParameter = startParameter;
        }

        public XmlClasses.Input GetInput()
        {
            XmlClasses.Input bpInput = new XmlClasses.Input();
            bpInput.Name = startParameter.Name;
            bpInput.Type = DataTypeConverter.GetText(startParameter.Type);
            bpInput.Narrative = startParameter.Description;
            bpInput.Stage = startParameter.DataName;

            return bpInput;
        }
    }
}
