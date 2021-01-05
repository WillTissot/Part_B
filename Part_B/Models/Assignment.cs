using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Part_B.Models
{
    class Assignment
    {
        private string _title;
        private string _description;
        private DateTime _subdatetime;
        private float _oralmark;
        private float _totalmark;

        public string Title
        {
            get { return (_title); }
            set
            {
                TextInfo changeStringForm = new CultureInfo("en-US", false).TextInfo;
                this._title = changeStringForm.ToTitleCase(value);
            }
        }
        public string Description
        {
            get { return (_description); }
            set { this._description = value; }
        }
        public DateTime SubDateTime
        {
            get { return (_subdatetime); }
            set { this._subdatetime = Convert.ToDateTime(value); }
        }
        public float OralMark
        {
            get { return (_oralmark); }
            set { this._oralmark = Convert.ToInt32(value); }
        }
        public float TotalMark
        {
            get { return (_totalmark); }
            set { this._totalmark = Convert.ToInt32(value); }
        }

        public override string ToString()
        {
            return ($"The {_title} assignment with description: {_description}, had submission date {_subdatetime.ToShortDateString()}. " +
                    $"Oral's exam weight factor is: {OralMark} and the weight factor for the total exam is {TotalMark} ");

        }
    }
}
