using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTI_Guide_1._0
{
    class Verification
    {
        // the verification will check with the order
        //   1- if the course was entered before
        //   2- if there is no entered group  Number
        //   3- if the group number is resonable range
        //   4- if the group number is repeated
    //TODO:  5- if the groups added have al data Entered
    // TODO: delayed - change all methods to static - check all won't have a proplem before checking
        private string[] addedCoursesName = new string[20];
        int coursesCount;
        private int gr1, gr2, gr3, gr4, gr5;

        public Verification()
        {
        }

        public Verification(string[] addedCoursesName, int coursesCount, string gr1, string gr2, string gr3, string gr4, string gr5)
        {
            this.coursesCount = coursesCount;
            this.addedCoursesName = addedCoursesName;
            if (gr1 != "")
            {
                this.gr1 = int.Parse(gr1);
            }
            if (gr2 != "")
            {
                this.gr2 = int.Parse(gr2);
            }
            if (gr3 != "")
            {
                this.gr3 = int.Parse(gr3);
            }
            if (gr4 != "")
            {
                this.gr4 = int.Parse(gr4);
            }
            if (gr5 != "")
            {
                this.gr5 = int.Parse(gr5);
            }
        }

        public bool VerifyCourseName(Verification data)
        //TODO: delayed - make course not case sensitive
        {
            bool errorDetermineGroupName = true; //courses wasn't added before
            if (data.coursesCount > 1)
            {
                for (int i = 1; i < data.coursesCount; i++)
                {
                    if (data.addedCoursesName[data.coursesCount] == data.addedCoursesName[i])
                    {
                        errorDetermineGroupName = false; //courses was added before
                        break;
                    }
                }
            }
            return errorDetermineGroupName;
        }

        public bool VerifyAGroupIsEntered(Verification data)
        {
            bool errorAGroupISEntered = true;
            if ((data.gr5.ToString() == "0") && (data.gr4.ToString() == "0") && (data.gr3.ToString() == "0")
                 && (data.gr2.ToString() == "0") && (data.gr1.ToString() == "0"))
            {
                errorAGroupISEntered = false;
            }
            return errorAGroupISEntered;
        }

        public bool VerifyGroupRange(Verification data)
        {
            bool errorDetetrmineGroupRange = true;
            if (   (data.gr1 < 0) || (data.gr1 >= 25) || (data.gr2 < 0) || (data.gr2 >= 25)
                || (data.gr3 < 0) || (data.gr3 >= 25) || (data.gr4 < 0) || (data.gr4 >= 25)
                || (data.gr5 < 0) || (data.gr5 >= 25)                                       )
            // assuming the biggest group number is 25
            // zero is added due to the empty text boxes values is "" but changing to int and back to string made it to the value "0"
            {
                errorDetetrmineGroupRange = false;
            }
            return errorDetetrmineGroupRange;
        }
        public bool VerifyGroupRepetition(Verification data)
        {
            bool errorDetetrmineRepetition = true;
            if ( ( ((data.gr1 == data.gr2)||(data.gr1 == data.gr3)||(data.gr1 == data.gr4)||(data.gr1 == data.gr5)) && (data.gr1.ToString() != "0"))
              || ( (                        (data.gr2 == data.gr3)||(data.gr2 == data.gr4)||(data.gr2 == data.gr5)) && (data.gr2.ToString() != "0"))
              || ( (                                                (data.gr3 == data.gr4)||(data.gr3 == data.gr5)) && (data.gr3.ToString() != "0"))
              || ( (                                                                        (data.gr4 == data.gr5)) && (data.gr4.ToString() != "0")) )
            // zero is used due to the empty text boxes values is "" but changing to int and back to string made it to the value "0"
            {
                errorDetetrmineRepetition = false;
            }
            return errorDetetrmineRepetition;
        }
    }
}
