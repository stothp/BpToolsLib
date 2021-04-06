using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageSet : HashSet<Stage>, IBaseElement, IExpressionHolder, IDataNameHolder
    {
        public MutableExpressionSet Expressions
        {
            get
            {
                MutableExpressionSet expressions = new MutableExpressionSet();
                foreach (Stage stage in this)
                {
                    if (stage is IExpressionHolder)
                    {
                        expressions.UnionWith(((IExpressionHolder)stage).Expressions);
                    }
                }
                return expressions;
            }
        }


        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dataNames = new MutableDataNameSet();
                foreach (Stage stage in this)
                {
                    if (stage is IDataNameHolder)
                    {
                        dataNames.UnionWith(((IDataNameHolder)stage).DataNames);
                    }
                }
                return dataNames;
            }
        }
    }
}
