using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public class InputParameter
    {
        BpToolsLib.InputParameter inputParameter;

        public InputParameter(BpToolsLib.InputParameter inputParameter)
        {
            this.inputParameter = inputParameter;
        }

        public XmlClasses.Input GetInput()
        {
            XmlClasses.Input bpInput = new XmlClasses.Input();
            bpInput.Name = inputParameter.Name;
            bpInput.Type = DataTypeConverter.GetText(inputParameter.Type);
            bpInput.Narrative = inputParameter.Description;
            bpInput.Expr = inputParameter.Expression;

            return bpInput;
        }
    }
}
