using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Model
{
    public class Contact
    {
        public Contact(string FirstName,string LastName,string Company)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Company = Company;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
        public string Company { get; set; }
        public override string ToString()
        {
            return String.Format("{0} ---{1}", FullName, Company);
        }
    }
}
