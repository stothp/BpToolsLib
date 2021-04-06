using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public class InputParameter
    {
        BpTools.InputParameter inputParameter;

        public InputParameter(BpTools.InputParameter inputParameter)
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
