using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Part_B.Models
{
    class Trainer : Human
    {
        private string _subject;

        public string Subject
        {
            get { return (this._subject); }
            set { this._subject = value.ToUpper(); }
        }

        public override string ToString()
        {
            return ($"{FirstName} {LastName} is a trainer of the {_subject}.");
        }
    }
}
