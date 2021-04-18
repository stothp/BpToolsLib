using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public abstract class Stage
    {
        protected XmlClasses.Stage XmlStage { get; set; }
        public BpToolsLib.Stage BpStage { get; set; }

        public Stage(XmlClasses.Stage xmlStage)
        {
            this.XmlStage = xmlStage;
        }

        public virtual void Initialize()
        {
            BpStage.Id = XmlStage.StageId;
            BpStage.Name = XmlStage.Name;
            if (XmlStage.Narrative != null)
            {
                BpStage.Description = XmlStage.Narrative;
            }
            if (XmlStage.Display != null)
            {
                BpStage.X = XmlStage.Display.X;
                BpStage.Y = XmlStage.Display.Y;
                if (XmlStage.Display.H > 0)
                {
                    BpStage.Height = XmlStage.Display.H;
                }
                if (XmlStage.Display.W > 0)
                {
                    BpStage.Width = XmlStage.Display.W;
                }
            }
            else
            {
                //BpStage.X = XmlStage.DisplayX;
                //BpStage.Y = XmlStage.DisplayY;
                //BpStage.Width = XmlStage.DisplayWidth;
                //BpStage.Height = XmlStage.DisplayHeight;
            }
            if (XmlStage.Font != null)
            {
                BpStage.Font.Family = XmlStage.Font.Family;
                BpStage.Font.Size = XmlStage.Font.Size;
                BpStage.Font.Style = XmlStage.Font.Style;
                BpStage.Font.Color = XmlStage.Font.Color;
            }
        }

        public abstract BpToolsLib.Stage GetStage ();

    }
}
