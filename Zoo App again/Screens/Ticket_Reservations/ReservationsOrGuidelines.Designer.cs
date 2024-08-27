namespace Zoo_App_again.Screens.Ticket_Reservations
{
    partial class ReservationsOrGuidelines
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationsOrGuidelines));
            buttonEllipse7 = new CustomDesign.ButtonEllipse();
            buttonEllipse3 = new CustomDesign.ButtonEllipse();
            SuspendLayout();
            // 
            // buttonEllipse7
            // 
            buttonEllipse7.BackColor = Color.Linen;
            buttonEllipse7.BackgroundImageLayout = ImageLayout.Stretch;
            buttonEllipse7.FlatAppearance.BorderSize = 0;
            buttonEllipse7.FlatStyle = FlatStyle.Flat;
            buttonEllipse7.Font = new Font("Times New Roman", 18.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEllipse7.Location = new Point(457, 143);
            buttonEllipse7.Name = "buttonEllipse7";
            buttonEllipse7.Size = new Size(196, 119);
            buttonEllipse7.TabIndex = 12;
            buttonEllipse7.Text = "Guidelines";
            buttonEllipse7.UseVisualStyleBackColor = false;
            buttonEllipse7.Click += buttonEllipse7_Click;
            // 
            // buttonEllipse3
            // 
            buttonEllipse3.BackColor = Color.BurlyWood;
            buttonEllipse3.BackgroundImageLayout = ImageLayout.Stretch;
            buttonEllipse3.FlatAppearance.BorderSize = 0;
            buttonEllipse3.FlatStyle = FlatStyle.Flat;
            buttonEllipse3.Font = new Font("Times New Roman", 18.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEllipse3.Location = new Point(225, 143);
            buttonEllipse3.Name = "buttonEllipse3";
            buttonEllipse3.Size = new Size(196, 119);
            buttonEllipse3.TabIndex = 11;
            buttonEllipse3.Text = "Ticket Reservations";
            buttonEllipse3.UseVisualStyleBackColor = false;
            buttonEllipse3.Click += buttonEllipse3_Click;
            // 
            // ReservationsOrGuidelines
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonEllipse7);
            Controls.Add(buttonEllipse3);
            Name = "ReservationsOrGuidelines";
            Text = "ReservationsOrGuidelines";
            ResumeLayout(false);
        }

        #endregion

        private CustomDesign.ButtonEllipse buttonEllipse7;
        private CustomDesign.ButtonEllipse buttonEllipse3;
    }
}