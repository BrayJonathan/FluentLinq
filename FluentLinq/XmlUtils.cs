using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentLinq
{
    class XmlUtils
    {
        #region Properties
        private string _Path;
        private IEnumerable<XElement> _Employees;
        #endregion

        #region Constructors
        public XmlUtils(string Path)
        {
            _Path = Path;
        }
        #endregion

        #region Accessors
        public string Path { get => _Path; set => _Path = value; }
        public IEnumerable<XElement> Employees { get => _Employees; set => _Employees = value; }
        #endregion

        #region Methods
        #region public
        public  void GetEmployeesFromXml()
        {
            _Employees = XElement.Load(_Path).Elements("Employee");
        }

        public void DisplayInformationsOfWoman()
        {
            List<XElement> womans = GetWomanList();
            Console.WriteLine();
            Console.WriteLine("******** Informations of woman ********");
            Console.WriteLine("woman count = {0}", womans.Count());
            womans.ForEach(w => Console.WriteLine("\t{0}", w.Element("Name").Value));
        }

        public void DisplayEmployeesByCity(string city)
        {
            List<XElement> employeesInCity = GetEmployeesByCity(city);
            Console.WriteLine();
            Console.WriteLine("************ Employees of {0} ************************", city);
            Console.WriteLine("City : {0}", city);
            employeesInCity.ForEach(e => Console.WriteLine("\t{0}", e.Element("Name").Value));
        }

        public XElement AddEmployee()
        {
            XElement nodeEmployees = XElement.Load(_Path);
            nodeEmployees.Add(
                new XElement("Employee",
                new XElement("EmpId", 5),
                new XElement("Name", "Bray"),
                new XElement("Sex", "Male"),
                new XElement("Phone", "06.49.70.24.91", new XAttribute("Type", "CellPhone")),
                new XElement("Address",
                    new XElement("Street", "Paris"),
                    new XElement("City", "Sottevilles-les-Rouens"),
                    new XElement("State", "Haute-Normandie"),
                    new XElement("Zip", "76300"),
                    new XElement("Country", "France"))));
            nodeEmployees.Save(_Path);
            return nodeEmployees;
        }
        #endregion

        #region Private
        private List<XElement> GetWomanList()
        {
            return _Employees.Where(e => e.Element("Sex").Value == "Female").ToList();
        }

        private List<XElement> GetEmployeesByCity(string city)
        {
            return _Employees.Where(e => e.Element("Address").Element("City").Value == city).ToList();
        }
        #endregion
        #endregion
    }
}
