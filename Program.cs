using BpTools.XmlClasses;
using BpTools.Interpreter;
using BpTools.Generator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace BpTools
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Page page = new Page("Teszt", true);
            //page.PageInformation = new StagePageInfo("Teszt");

            //StageStart start = new StageStart();
            //start.InputParameters.Add(new StartParameter(DataType.Text, "Input1", "Teszt", "Data1"));
            ////page.Start = start;

            //StageNote note1 = new StageNote("Megjegyzés", "Ez a hosszú szöveg");
            //note1.Y = 45;
            //start.NextStage = note1;

            //StageNote note2 = new StageNote("Megjegyzés", "Ez a hosszú szöveg");
            //note2.Y = 90;
            //note1.NextStage = note2;

            //StageMultipleCalculation multiCalc = new StageMultipleCalculation()
            //{
            //    Y = 135,
            //    Calculations = new Collection<Calculation>()
            //    {
            //        new Calculation("1+1", "Data1"),
            //        new Calculation("1+2", "Data2")
            //    }
            //};
            //note2.NextStage = multiCalc;

            //StageChoice choice = new StageChoice("Choice1")
            //{
            //    Y = 180,
            //    Choices = new Collection<Choice>()
            //    {
            //        new Choice("choice1", "[data1] = \"data1\"", 45, new StageNote () { Y = 225, X = 90 }),
            //        new Choice("choice2", "[data2] = \"data1\"", 90, new StageNote () { Y = 270, X = 90 })
            //    }
            //};
            //choice.Otherwise.Y = 315;
            //multiCalc.NextStage = choice;

            //StageSet coll = TraverseStages.GetTraversedStages(note1);

            ////StageNote note = new StageNote("Note1", "Helló");
            ////start.NextStage = note;

            //string xml = BpClasses.Test.TestOut(new ToBp.Generator(coll).Process);
            //Console.WriteLine(xml);
            //Clipboard.SetText(xml);

            Interpreter.Interpreter interpret = new Interpreter.Interpreter(Clipboard.GetText());

            IBaseElement elem = interpret.GetElement();

            if (elem is StageSet)
            {
                foreach (Stage stage in (StageSet)elem)
                {
                    if (stage is StageData && stage.Name.Equals("Data6"))
                    {
                        stage.Name = "Modified";
                    }
                }

                foreach (MutableDataName dataName in ((StageSet)elem).DataNames)
                {
                    if (dataName.Value.Equals("Data6"))
                    {
                        dataName.Value = "Modified";
                    }
                }

                foreach (MutableExpression expression in ((StageSet)elem).Expressions)
                {
                    expression.Value = expression.Value.Replace("[Data6]", "[Modified]");
                }
            }

            //StageDecision d = new StageDecision()
            //{
            //    Name = "Decision1",
            //    Expression = "[Modified] = \"AAA\""
            //};

            //StageSet ss = new StageSet() { d };



            string xml = new Generator.Generator(elem).GetXml();

            Console.WriteLine(xml);

            Clipboard.SetText(xml);

            Console.ReadLine();
        }
    }
}

