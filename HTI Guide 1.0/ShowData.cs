using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTI_Guide_1._0
{
    class ShowData
    {
        string courses, courseName, gr1, gr2, gr3, gr4, gr5;
        public ShowData()
        {
        }

        public ShowData(string courses, string courseName, string gr1, string gr2, string gr3, string gr4, string gr5)
        {
            this.courses = courses;
            this.courseName = courseName;
            this.gr1 = gr1;
            this.gr2 = gr2;
            this.gr3 = gr3;
            this.gr4 = gr4;
            this.gr5 = gr5;
        }

        public string showScreen(ShowData data)
        {
            {
                data.courses = data.courseName + ": ";
                if (data.gr1 != "")
                {
                    data.courses += data.gr1;
                }
                if (data.gr2 != "")
                {
                    data.courses += ", " + data.gr2;
                }
                if (data.gr3 != "")
                {
                    data.courses += ", " + data.gr3;
                }
                if (data.gr4 != "")
                {
                    data.courses += ", " + data.gr4;
                }
                if (data.gr5 != "")
                {
                    data.courses += ", " + data.gr5;
                }
                data.courses += "\n";
                return data.courses;
            }
        }
    }
}