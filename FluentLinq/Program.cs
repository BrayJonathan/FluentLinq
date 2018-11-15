using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            /* files name list contains m */
            string pathDirectory = @"C:\Exo\DossierTest";
            DirectoryUtils directoryUtils = new DirectoryUtils(pathDirectory);
            List<string> filesNameContainsMWithQuerySyntaxe = directoryUtils.GetFilesNameContainsMWithQuerySyntaxe("m");
            List<string> filesNameContainsMWithFluentSyntaxe = directoryUtils.GetFilesNameContainsMWithFluentSyntaxe("m");
            Console.WriteLine("******************** With Query Syntaxe : ************************************");
            Console.WriteLine();
            filesNameContainsMWithQuerySyntaxe.ForEach(f => Console.WriteLine(f));
            Console.WriteLine();
            Console.WriteLine("******************** With Query Syntaxe : ************************************");
            Console.WriteLine();
            filesNameContainsMWithFluentSyntaxe.ForEach(f => Console.WriteLine(f));
            Console.WriteLine();
            Console.WriteLine("******************** XML ************************************");
            string pathXml = @"C:\Exo\DossierXml\linqxml.xml";
            XmlUtils xmlUtils = new XmlUtils(pathXml);
            xmlUtils.GetEmployeesFromXml();
            xmlUtils.DisplayInformationsOfWoman();
            xmlUtils.DisplayEmployeesByCity("Alta");
            Console.WriteLine("******************** Add ************************************");
            XElement newNode = xmlUtils.AddEmployee();
            // Console.WriteLine(newNode);
            Console.ReadKey();

        }
    }
}
