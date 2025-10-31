namespace DroneController
{
    partial class ControllerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            buttonTakeOff = new Button();
            buttonLand = new Button();
            buttonMoveForward = new Button();
            buttonMoveLeft = new Button();
            buttonMoveRight = new Button();
            buttonMoveBack = new Button();
            buttonMoveDown = new Button();
            buttonRotateRight = new Button();
            buttonRotateLeft = new Button();
            buttonMoveUp = new Button();
            buttonFlightPlan = new Button();
            SuspendLayout();
            // 
            // buttonTakeOff
            // 
            buttonTakeOff.Location = new Point(243, 226);
            buttonTakeOff.Name = "buttonTakeOff";
            buttonTakeOff.Size = new Size(75, 42);
            buttonTakeOff.TabIndex = 1;
            buttonTakeOff.Text = "N\r\n[Take Off]";
            buttonTakeOff.UseVisualStyleBackColor = true;
            buttonTakeOff.Click += buttonTakeOff_Click;
            // 
            // buttonLand
            // 
            buttonLand.Location = new Point(324, 226);
            buttonLand.Name = "buttonLand";
            buttonLand.Size = new Size(75, 42);
            buttonLand.TabIndex = 2;
            buttonLand.Text = "M\r\n[Land]";
            buttonLand.UseVisualStyleBackColor = true;
            buttonLand.Click += buttonLand_Click;
            // 
            // buttonMoveForward
            // 
            buttonMoveForward.Location = new Point(125, 55);
            buttonMoveForward.Name = "buttonMoveForward";
            buttonMoveForward.Size = new Size(75, 44);
            buttonMoveForward.TabIndex = 5;
            buttonMoveForward.Text = "W\r\n[Forward]";
            buttonMoveForward.UseVisualStyleBackColor = true;
            buttonMoveForward.Click += buttonMoveForward_Click;
            // 
            // buttonMoveLeft
            // 
            buttonMoveLeft.Location = new Point(44, 105);
            buttonMoveLeft.Name = "buttonMoveLeft";
            buttonMoveLeft.Size = new Size(75, 47);
            buttonMoveLeft.TabIndex = 6;
            buttonMoveLeft.Text = "A\r\n[Left]";
            buttonMoveLeft.UseVisualStyleBackColor = true;
            buttonMoveLeft.Click += buttonMoveLeft_Click;
            // 
            // buttonMoveRight
            // 
            buttonMoveRight.Location = new Point(206, 105);
            buttonMoveRight.Name = "buttonMoveRight";
            buttonMoveRight.Size = new Size(75, 47);
            buttonMoveRight.TabIndex = 7;
            buttonMoveRight.Text = "D\r\n[Right]";
            buttonMoveRight.UseVisualStyleBackColor = true;
            buttonMoveRight.Click += buttonMoveRight_Click;
            // 
            // buttonMoveBack
            // 
            buttonMoveBack.Location = new Point(125, 105);
            buttonMoveBack.Name = "buttonMoveBack";
            buttonMoveBack.Size = new Size(75, 47);
            buttonMoveBack.TabIndex = 8;
            buttonMoveBack.Text = "S\r\n[Back]";
            buttonMoveBack.UseVisualStyleBackColor = true;
            buttonMoveBack.Click += buttonMoveBack_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Location = new Point(435, 105);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(75, 47);
            buttonMoveDown.TabIndex = 12;
            buttonMoveDown.Text = "K\r\n[Down]";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonRotateRight
            // 
            buttonRotateRight.Location = new Point(516, 105);
            buttonRotateRight.Name = "buttonRotateRight";
            buttonRotateRight.Size = new Size(75, 47);
            buttonRotateRight.TabIndex = 11;
            buttonRotateRight.Text = "L\r\n[Rotate R]";
            buttonRotateRight.UseVisualStyleBackColor = true;
            buttonRotateRight.Click += buttonRotateRight_Click;
            // 
            // buttonRotateLeft
            // 
            buttonRotateLeft.Location = new Point(354, 105);
            buttonRotateLeft.Name = "buttonRotateLeft";
            buttonRotateLeft.Size = new Size(75, 47);
            buttonRotateLeft.TabIndex = 10;
            buttonRotateLeft.Text = "J\r\n[Rotate L]";
            buttonRotateLeft.UseVisualStyleBackColor = true;
            buttonRotateLeft.Click += buttonRotateLeft_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Location = new Point(435, 55);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(75, 44);
            buttonMoveUp.TabIndex = 9;
            buttonMoveUp.Text = "I\r\n[Up]";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // buttonFlightPlan
            // 
            buttonFlightPlan.Location = new Point(514, 275);
            buttonFlightPlan.Name = "buttonFlightPlan";
            buttonFlightPlan.Size = new Size(109, 48);
            buttonFlightPlan.TabIndex = 13;
            buttonFlightPlan.Text = "Perform\r\nFlight Plan";
            buttonFlightPlan.UseVisualStyleBackColor = true;
            buttonFlightPlan.Click += buttonFlightPlan_Click;
            // 
            // ControllerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 335);
            Controls.Add(buttonFlightPlan);
            Controls.Add(buttonMoveDown);
            Controls.Add(buttonRotateRight);
            Controls.Add(buttonRotateLeft);
            Controls.Add(buttonMoveUp);
            Controls.Add(buttonMoveBack);
            Controls.Add(buttonMoveRight);
            Controls.Add(buttonMoveLeft);
            Controls.Add(buttonMoveForward);
            Controls.Add(buttonLand);
            Controls.Add(buttonTakeOff);
            Name = "ControllerForm";
            Text = "Drone Controller";
            KeyDown += ControllerForm_KeyDown;
            ResumeLayout(false);
        }

        #endregion
        private Button buttonTakeOff;
        private Button buttonLand;
        private Button buttonMoveForward;
        private Button buttonMoveLeft;
        private Button buttonMoveRight;
        private Button buttonMoveBack;
        private Button buttonMoveDown;
        private Button buttonRotateRight;
        private Button buttonRotateLeft;
        private Button buttonMoveUp;
        private Button buttonFlightPlan;
    }
}
