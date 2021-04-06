using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public abstract class Stage
    {
        protected XmlClasses.Stage XmlStage { get; set; }
        public BpTools.Stage BpStage { get; set; }

        public Stage(XmlClasses.Stage xmlStage)
        {
            this.XmlStage = xmlStage;
        }

        public virtual void Initialize()
        {
            BpStage.Id = XmlStage.StageId;
            BpStage.Name = XmlStage.Name;
            BpStage.Description = XmlStage.Narrative;
            BpStage.X = XmlStage.DisplayX;
            BpStage.Y = XmlStage.DisplayY;
            BpStage.Width = XmlStage.DisplayWidth;
            BpStage.Height = XmlStage.DisplayHeight;
            BpStage.Font.Family = XmlStage.Font.Family;
            BpStage.Font.Size = XmlStage.Font.Size;
            BpStage.Font.Style = XmlStage.Font.Style;
            BpStage.Font.Color = XmlStage.Font.Color;
        }

        public abstract BpTools.Stage GetStage ();

    }
}
