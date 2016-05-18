using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTI_Guide_1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //counting courses and adding them to an array
        int coursesCount = 0;
        string[] addedCoursesName = new string[20];

        public MainWindow()
        {
            InitializeComponent();
            InizializeDaysPeriods();
        }

        private void InizializeDaysPeriods()
        {
            for (Days fillData = Days.Sat; fillData <= Days.Fri; fillData++)
            {
                gr1D1.Items.Add(fillData);
                gr1D2.Items.Add(fillData);
                gr2D1.Items.Add(fillData);
                gr2D2.Items.Add(fillData);
                gr3D1.Items.Add(fillData);
                gr3D2.Items.Add(fillData);
                gr4D1.Items.Add(fillData);
                gr4D2.Items.Add(fillData);
                gr5D1.Items.Add(fillData);
                gr5D2.Items.Add(fillData);
            }
            for (Periods fillData = Periods.P1; fillData <= Periods.P8; fillData++)
            {
                gr1D1StartPeriod.Items.Add(fillData);
                gr1D2StartPeriod.Items.Add(fillData);
                gr2D1StartPeriod.Items.Add(fillData);
                gr2D2StartPeriod.Items.Add(fillData);
                gr3D1StartPeriod.Items.Add(fillData);
                gr3D2StartPeriod.Items.Add(fillData);
                gr4D1StartPeriod.Items.Add(fillData);
                gr4D2StartPeriod.Items.Add(fillData);
                gr5D1StartPeriod.Items.Add(fillData);
                gr5D2StartPeriod.Items.Add(fillData);
                gr1D1EndPeriod.Items.Add(fillData);
                gr1D2EndPeriod.Items.Add(fillData);
                gr2D1EndPeriod.Items.Add(fillData);
                gr2D2EndPeriod.Items.Add(fillData);
                gr3D1EndPeriod.Items.Add(fillData);
                gr3D2EndPeriod.Items.Add(fillData);
                gr4D1EndPeriod.Items.Add(fillData);
                gr4D2EndPeriod.Items.Add(fillData);
                gr5D1EndPeriod.Items.Add(fillData);
                gr5D2EndPeriod.Items.Add(fillData);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //adding courses to array
                coursesCount++;
                addedCoursesName[coursesCount] = courseName.Text;

                // Make sure no Course ot group is repeated
                Verification verify = new Verification();
                Verification verificationData = new Verification(addedCoursesName, coursesCount, gr1.Text, gr2.Text, gr3.Text, gr4.Text, gr5.Text);
                bool errorDetermineGroupName = verify.VerifyCourseName(verificationData);
                bool errorDetetrmineGroupRange = verify.VerifyGroupRange(verificationData);
                bool errorDetetrmineGroupRepetition = verify.VerifyGroupRepetition(verificationData);
                bool errorAGroupISEntered = verify.VerifyAGroupIsEntered(verificationData);
                if ((errorDetermineGroupName == true) && (errorDetetrmineGroupRange == true)
                    && (errorDetetrmineGroupRepetition == true) && (errorAGroupISEntered == true))
                {
                    // adding course to the screen
                    ShowData addedcourses = new ShowData();
                    ShowData addcourse = new ShowData(courses.Text, courseName.Text, gr1.Text, gr2.Text, gr3.Text, gr4.Text, gr5.Text);
                    courses.Text += addedcourses.showScreen(addcourse);
                    MessageBox.Show("تم اضافه الماده");
                }
                else if (errorDetermineGroupName == false)
                {
                    MessageBox.Show("تم اضافه الماده سابقا");
                    coursesCount--; //removing courses from the array that wasn't really used
                    /*TODO: delayed - add a message(panel) with yes or no to allow user 
                            modify added Courses - the code modifies the data
                            of the course and modify it in the show courses screen*/
                }
                else if (errorDetetrmineGroupRange == false)
                {
                    MessageBox.Show("رقم المجموعه غير مناسب");
                    coursesCount--; //removing courses from the array that wasn't really used
                }
                else if (errorDetetrmineGroupRepetition == false)
                {
                    MessageBox.Show("يوجد مجموعتين بنفس الرقم");
                    coursesCount--; //removing courses from the array that wasn't really used
                }
                else if (errorAGroupISEntered == false)
                {
                    MessageBox.Show("لا يوجد مجموعات");
                    coursesCount--; //removing courses from the array that wasn't really used
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please, Enter a Number not a string");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void schedule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
