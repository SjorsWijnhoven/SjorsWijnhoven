using TelloSharp;
using System.IO;


namespace DroneController
{
    public partial class ControllerForm : Form {

        private Tello tello = new Tello();
        private int _distance;
        private int _distanceUpDown;
        private int _rotationDegrees;


        public ControllerForm() {
            InitializeComponent();
            tello.Connect();

            _distance = 60;
            _distanceUpDown = 30;
            _rotationDegrees = 90;

            KeyPreview = true;
        }



        private void ControllerForm_KeyDown(object sender, KeyEventArgs e) {
            Keys pressedKey = e.KeyCode;

            switch (pressedKey) {

                //Takeoff / Land
                case Keys.N:
                    buttonTakeOff.PerformClick();
                    break;

                case Keys.M:
                    buttonLand.PerformClick();
                    break;


                //Move Directions
                case Keys.W:
                    buttonMoveForward.PerformClick();
                    break;

                case Keys.S:
                    buttonMoveBack.PerformClick();
                    break;

                case Keys.A:
                    buttonMoveLeft.PerformClick();
                    break;

                case Keys.D:
                    buttonMoveRight.PerformClick();
                    break;

                case Keys.I:
                    buttonMoveUp.PerformClick();
                    break;

                case Keys.K:
                    buttonMoveDown.PerformClick();
                    break;



                //Rotate
                case Keys.J:
                    buttonRotateLeft.PerformClick();
                    break;

                case Keys.L:
                    buttonRotateRight.PerformClick();
                    break;

            }
        }




        //-----PRE-SET PATH-----
        private List<string> readFlightPlan() {
            List<string> commands = [];
            string commandLine;
            //StreamReader sr = new("..\\..\\..\\FlightPlan.txt");
            StreamReader sr = new("..\\..\\..\\FlightPlan_V2.txt");

            commandLine = sr.ReadLine();
            while (commandLine != null) {
                commands.Add(commandLine);
                commandLine = sr.ReadLine();
            }

            sr.Close();
            return commands;
        }

        private void performFlightPlan(List<string> commands) {
            foreach (string commandLine in commands) {
                switch (commandLine) {

                    case "takeoff":
                        buttonTakeOff.PerformClick();
                        break;
                    case "land":
                        buttonLand.PerformClick();
                        break;

                    case "mf":
                        buttonMoveForward.PerformClick();
                        break;
                    case "mb":
                        buttonMoveBack.PerformClick();
                        break;
                    case "ml":
                        buttonMoveLeft.PerformClick();
                        break;
                    case "mr":
                        buttonMoveRight.PerformClick();
                        break;
                    case "mu":
                        buttonMoveUp.PerformClick();
                        break;
                    case "md":
                        buttonMoveDown.PerformClick();
                        break;

                    case "rl":
                        buttonRotateLeft.PerformClick();
                        break;
                    case "rr":
                        buttonRotateRight.PerformClick();
                        break;

                    default:
                        break;
                }
            }
        }


        
        private void performFlightPlan_V2(List<string> commands) {
            List<string> actions = [];
            List<int> parameters = [];
            foreach (string commandLine in commands) {

                try {
                    string[] commandSegements = (commandLine.Trim()).Split(":");
                    actions.Add(commandSegements[0]);
                    parameters.Add(int.Parse(commandSegements[1]));
                } catch(Exception) {
                    //Do nothing, just ignore any faulty lines
                }
            }

            for(int i = 0; i < actions.Count; i++) {
                switch (actions[i]) {
                    case "takeoff":
                        tello.Takeoff();
                        break;
                    case "land":
                        tello.Land();
                        break;

                    case "mf":
                        tello.Forward(parameters[i]);
                        break;
                    case "mb":
                        tello.Back(parameters[i]);
                        break;
                    case "ml":
                        tello.Left(parameters[i]);
                        break;
                    case "mr":
                        tello.Right(parameters[i]);
                        break;
                    case "mu":
                        tello.Up(parameters[i]);
                        break;
                    case "md":
                        tello.Down(parameters[i]);
                        break;

                    case "rl":
                        tello.CounterClockwise(parameters[i]);
                        break;
                    case "rr":
                        tello.Clockwise(parameters[i]);
                        break;

                    default:
                        break;
                }
            }
        }
        

        private void buttonFlightPlan_Click(object sender, EventArgs e) {
            performFlightPlan_V2(readFlightPlan());
        }



        //-----DRONE CONTROLS-----
        //Takeoff / Land
        private void buttonTakeOff_Click(object sender, EventArgs e) {
            tello.Takeoff();

        }

        private void buttonLand_Click(object sender, EventArgs e) {
            tello.Land();
        }


        //Move Directions
        private void buttonMoveForward_Click(object sender, EventArgs e) {
            tello.Forward(_distance);
        }

        private void buttonMoveBack_Click(object sender, EventArgs e) {
            tello.Back(_distance);
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e) {
            tello.Left(_distance);
        }

        private void buttonMoveRight_Click(object sender, EventArgs e) {
            tello.Right(_distance);
        }

        private void buttonMoveUp_Click(object sender, EventArgs e) {
            tello.Up(_distanceUpDown);
        }

        private void buttonMoveDown_Click(object sender, EventArgs e) {
            tello.Down(_distanceUpDown);
        }


        //Rotate
        private void buttonRotateLeft_Click(object sender, EventArgs e) {
            tello.CounterClockwise(_rotationDegrees);
        }

        private void buttonRotateRight_Click(object sender, EventArgs e) {
            tello.Clockwise(_rotationDegrees);
        }

    }
}
