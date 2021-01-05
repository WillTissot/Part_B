using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_B
{
    class Human
    {
        private string _firstname;
        private string _lastname;

        public string FirstName
        {
            get { return (this._firstname); }
            set { this._firstname = value; }
        }
        public string LastName
        {
            get { return (this._lastname); }
            set { this._lastname = value; }
        }

    }
}

