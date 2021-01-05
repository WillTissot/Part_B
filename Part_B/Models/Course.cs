using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Part_B.Models
{
    class Course
    {
        private string _title;
        private string _stream;
        private string _type;
        private DateTime _startdate;
        private DateTime _enddate;

        public string Title
        {
            get { return (this._title); }
            set
            {
                TextInfo changeStringForm = new CultureInfo("en-US", false).TextInfo;
                this._title = changeStringForm.ToTitleCase(value);
            }
        }

        public string Stream
        {
            get { return (this._stream); }
            set
            {
                TextInfo changeStringForm = new CultureInfo("en-US", false).TextInfo;
                this._stream = changeStringForm.ToTitleCase(value);
            }
        }
        public string Type
        {
            get { return (this._type); }
            set
            {
                TextInfo changeStringForm = new CultureInfo("en-US", false).TextInfo;
                this._type = changeStringForm.ToTitleCase(value);
            }
        }
        public DateTime StartDate
        {
            get { return (this._startdate); }
            set
            {
                this._startdate = Convert.ToDateTime(value);
            }
        }
        public DateTime EndDate
        {
            get { return (this._enddate); }
            set
            {
                this._enddate = Convert.ToDateTime(value);
                /* To check whether it prints the time too!!!!
                 * should I convert here or in commandpromtutils??*/
            }
        }
        public override string ToString()
        {
            return ($"\nThe {_title} is under the {_stream} stream with {_type} type. It starts on {_startdate.ToShortDateString()} and it ends on {_enddate.ToShortDateString()}");
        }
    }
}
