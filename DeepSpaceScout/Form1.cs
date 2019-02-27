using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepSpaceScout
{
    public partial class DeepSpaceScout : Form
    {
        public DeepSpaceScout()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This creates or opens the .csv file where the data is written
            //It sets the names of the columns in the data file into CSV format.
            //CSV format can be opened in Google Sheets or Excel among others.
            //The name of the file comes 1st, then each column heading.
            //you can put all of the headings on one line or continue to the 
            //next line with the + sign.

            //******************* CSV FILE HEADER **************************
            //First line of the Header
            System.IO.File.AppendAllText("DeepSpaceScoutData.csv",
                "," +       //advance space for Team #
                "," +       //advance space for Match #
                "Starting Position," +
                "," +       //space for 2nd start positin
                "," + 
                "Sandstorm Score Placement," +
                "," +       //space for 2nd Sandstorm cell
                "," +       //space for hatch from ground
                "Scoring Element Count," +
                "," +       //space for 2nd scoring element
                "Cargo in Rocket," +
                "," +       //space for 2nd cargo placemnt
                "," +       //space for 3nd cargo placemnt
                "," +       //space for 4th cargo placemnt
                "Hatch Panel in Rocket," +
                "," +       //space for 2nd hatch placemnt
                "," +       //space for 3nd hatch placemnt
                "," +       //space for 4th hatch placemnt
                "End Game," +
                "\n");

            //Second line of the Header
            System.IO.File.AppendAllText("DeepSpaceScoutData.csv", 
                "Team Number," +
                "Match Number," +
                "HAB Level Start," +
                "Starting Side," +
                "HAB Line Crossed," +
                "Cargo Placement," +
                "Hatch Panel Placemet," +
                "Hatch from Ground," +
                "Cargo Count," +
                "Hatch Count," +
                "Rocket Bottom," +
                "Rocket Middle," +
                "Rocket Top," +
                "Cargo Ship," +
                "Rocket Bottom," +
                "Rocket Middle," +
                "Rocket Top," +
                "Cargo Ship," +
                "HAB Level," +
                "Defense," +
                "Stalled," +
                "Tipped," +
                "Fouls," +
                "\n");
            // the \n tells the program to go to the next line.
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            // This stuff happens when you click the ENTER button

            // ***************** TEAM NUMBER *******************
            //check to see if Team Number box is empty or has a 0
            string TeamNumber = "error";
            if (TeamNumberTextBox.Text == "" || TeamNumberTextBox.Text == "0")
            {
                MessageBox.Show("Please Enter A Team Number.", "Team Number Message");
                TeamNumberTextBox.Text = "";
                TeamNumber = "error";
                return;         //jump out of here so the user can enter the team number
            }
            else TeamNumber = TeamNumberTextBox.Text;
            TeamNumber = TeamNumberTextBox.Text;
            //MessageBox.Show(TeamNumber, "Team Number Message");  *this was only included for development; not intended for final program

            //***************** MATCH NUMBER *******************
            //check to see if Match Number box is empty or has a 0
            string MatchNumber = "error";
            if (MatchNumberTextBox.Text == "" || TeamNumberTextBox.Text == "0")
            {
                MessageBox.Show("Please Enter A Match Number.", "Match Number Message");
                MatchNumberTextBox.Text = "";
                MatchNumber = "error";
                return;         //jump out of here so the user can enter the match number
            }
            else MatchNumber = MatchNumberTextBox.Text;
            MatchNumber = MatchNumberTextBox.Text;
            

            //******************** START POSITION *************************
            // find out if HAB Start Level is 1 or 2
            // find out what side the robot starts on
            int HABStartLevel = 0;
            string HABStartSide = "none";
            if (LeftStartHAB2CheckBox.Checked == true)
            {
                HABStartLevel = 2;
                HABStartSide = "Left";
            }
            if (RightStartHAB2CheckBox.Checked == true) 
            {
                HABStartLevel = 2;
                HABStartSide = "Right";
            }
            if (LeftStartHAB1CheckBox.Checked == true) 
            {
                HABStartLevel = 1;
                HABStartSide = "Left";
            }
            if (MiddleStartHAB1CheckBox.Checked == true) 
            {
                HABStartLevel = 1;
                HABStartSide = "Middle";
            }
            if (RightStartHAB1CheckBox.Checked == true) 
            {
                HABStartLevel = 1;
                HABStartSide = "Right";
            }

            //***************** SANDSTORM SCORING ELEMENT **********************************
            string SandstormCargoPlacement = "none";
            string SandstormHatchPlacement = "none";
            if (SandCargoInCargoShipCheckBox.Checked) SandstormCargoPlacement = "Cargo Ship";
            if (SandCargoInRocketCheckBox.Checked) SandstormCargoPlacement = "Rocket";
            if (SandHatchInCargoShipCheckBox.Checked) SandstormHatchPlacement = "Cargo Ship";
            if (SandHatchInRocketCheckBox.Checked) SandstormHatchPlacement = "Rocket";

                                 
            // ************** CAN A ROBOT PICK A HATCH PANEL FROM THE GROUND? **************
            Boolean GroundPickUp = false;
            if (PickHatchGroundCheckBox.Checked) GroundPickUp = true;

            // ************** SCORING ELEMENT COUNT ********************************
            // We only want the count value that is in the text box so we don't need 
            // to do any modifications.

            // **************** CARGO - ROCKET PLACEMENT **************************
            // We only want the value of the check box (true/false) so no modifications are needed 

            // ****************** HAB LEVEL - END GAME ******************************
            int EndHAB = 0;
            if (EndHABLevel1CheckBox.Checked) EndHAB = 1;
            else if (EndHABLevel2CheckBox.Checked) EndHAB = 2;
            else if (EndHABLevel3TextBox.Checked) EndHAB = 3;
            else EndHAB = 0;

            // **************** FOUL TYPE ***********************
            string FoulType = "none";
            if (TechFoulsCheckBox.Checked) FoulType = "Tech";
            else if (RankingPointFoulsCheckBox.Checked) FoulType = "Ranking";
            else FoulType = "none";
            
            // ******* ENTER DATA IN CSV FILE ******************************
            //Push the results of the checkboxes and text boxes back out to the .csv file.
            System.IO.File.AppendAllText("DeepSpaceScoutData.csv",
                 TeamNumber + "," +
                 MatchNumber + "," +
                 HABStartLevel + "," +
                 HABStartSide + "," + 
                 CrossHABLineCheckBox.Checked + "," +
                 SandstormCargoPlacement + "," + //sandstorm cargo placement
                 SandstormHatchPlacement + "," + //sandstorm hatch placement
                 GroundPickUp + "," +
                 CargoCountTextBox.Text + "," +
                 HatchPanelCountTextBox.Text + "," +
                 CargoRocketBottomCheckBox.Checked + "," +
                 CargoRocketMiddleCheckBox.Checked + "," +
                 CargoRocketTopCheckBox.Checked + "," +
                 CargoCargoShipCheckBox.Checked + "," +
                 HatchRocketBottomkBox.Checked + "," +
                 HatchRocketMiddleCheckBox.Checked + "," +
                 HatchRocktTopCheckBox.Checked + "," +
                 HatchCargoShipCheckBox.Checked + "," +
                 EndHAB + "," +
                 DefenseCheckBox.Checked + "," +
                 StalledCheckBox.Checked + "," +
                 TippedCheckBox.Checked + "," +
                 FoulType + "," +

                 "\n");  //move to the next line for the next set of data

            //Clear all the variable to be ready for the next entry.
            MatchNumberTextBox.Clear();
            TeamNumberTextBox.Clear();
            CargoCountTextBox.Clear();
            HatchPanelCountTextBox.Clear();
            LeftStartHAB2CheckBox.Checked = false;
            RightStartHAB2CheckBox.Checked = false;
            LeftStartHAB1CheckBox.Checked = false;
            MiddleStartHAB1CheckBox.Checked = false;
            RightStartHAB1CheckBox.Checked = false;
            SandCargoInCargoShipCheckBox.Checked = false;
            SandCargoInRocketCheckBox.Checked = false;
            SandHatchInCargoShipCheckBox.Checked = false;
            SandHatchInRocketCheckBox.Checked = false;
            PickHatchGroundCheckBox.Checked = false;
            CargoRocketBottomCheckBox.Checked = false;
            CargoRocketTopCheckBox.Checked = false;
            HatchCargoShipCheckBox.Checked = false;
            HatchRocketMiddleCheckBox.Checked = false;
            CargoRocketMiddleCheckBox.Checked = false;
            CargoCargoShipCheckBox.Checked = false;
            HatchRocketBottomkBox.Checked = false;
            HatchRocktTopCheckBox.Checked = false;
            EndHABLevel1CheckBox.Checked = false;
            EndHABLevel2CheckBox.Checked = false;
            EndHABLevel3TextBox.Checked = false;
            EndNoHABCheckBox.Checked = false;
            DefenseCheckBox.Checked = false;
            TippedCheckBox.Checked = false;
            StalledCheckBox.Checked = false;
            RankingPointFoulsCheckBox.Checked = false;
            TechFoulsCheckBox.Checked = false;
            CrossHABLineCheckBox.Checked = false;



        }

        private void HABLevel2StartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /*  THIS SECTION CAN BE USED TO MAKE SURE ONLY ONE STARTING POSITION IS SELECTED
             if (HAB2LeftStartCheckBox.Checked != true & HAB2RightStartCheckBox.Checked != true)
                 {
                 HABStartLevel = 1;
                 //MessageBox.Show("HAB Level 1.", "Start Position");
                 //return;
                 }
             else if (LeftStartHAB1CheckBox.Checked != true & MiddleStartHAB1CheckBox.Checked != true & RightStartHAB1CheckBox.Checked != true)
             {
                 HABStartLevel = 2;
                 //MessageBox.Show("HAB Level 2.", "Start Position");
                 //return;
             }
             */
            //check to make sure only 1 starting position is selected
            //if another one is selected, deselect the previous selection
            //and select the new position

        }

        private void RocketLocationLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RankingPointFoulsCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
