using System.Collections.Generic;

namespace IDECaseStudy
{
    internal class Program //: IDE // is-a
    {
        //IDE ide = new IDE(); // has-a
        static void Main(string[] args)
        {
            IDE ide = new IDE(); // uses
            ide.languages.Add(new LangCSharp());
            ide.languages.Add(new LangJava());
            ide.languages.Add(new LangC());
            ide.DoWork();
        }
    }

    class IDE
    {
        public List<ILanguage> languages = new List<ILanguage>();

        public void DoWork()
        {
            foreach (ILanguage lang in languages)
            {
                System.Console.WriteLine($"Working with {lang.GetName()}");
                System.Console.WriteLine(lang.GetUnit());
                System.Console.WriteLine(lang.GetParadigm());
                System.Console.WriteLine("--------------");
            }
        }
    }

    interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }


    abstract class OOLanguage : ILanguage
    {
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object Oriented";
        }

        abstract public string GetName();

    }

    class LangCSharp : OOLanguage
    {
        public override string GetName()
        {
            return "CSharp";
        }

    }
    class LangJava : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }

    }
    class LangC : ILanguage
    {
        public string GetName()
        {
            return "C";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedure Oriented";
        }
    }
}
