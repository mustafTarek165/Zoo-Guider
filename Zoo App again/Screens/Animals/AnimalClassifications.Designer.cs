namespace Zoo_App_again.Screens.Animals
{
    partial class AnimalClassifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalClassifications));
            buttonEllipse7 = new CustomDesign.ButtonEllipse();
            buttonEllipse3 = new CustomDesign.ButtonEllipse();
            buttonEllipse2 = new CustomDesign.ButtonEllipse();
            SuspendLayout();
            // 
            // buttonEllipse7
            // 
            buttonEllipse7.BackColor = Color.Linen;
            buttonEllipse7.BackgroundImageLayout = ImageLayout.Stretch;
            buttonEllipse7.FlatAppearance.BorderSize = 0;
            buttonEllipse7.FlatStyle = FlatStyle.Flat;
            buttonEllipse7.Font = new Font("Times New Roman", 18.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEllipse7.Location = new Point(294, 160);
            buttonEllipse7.Name = "buttonEllipse7";
            buttonEllipse7.Size = new Size(196, 119);
            buttonEllipse7.TabIndex = 10;
            buttonEllipse7.Text = "Animals";
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
            buttonEllipse3.Location = new Point(75, 129);
            buttonEllipse3.Name = "buttonEllipse3";
            buttonEllipse3.Size = new Size(196, 119);
            buttonEllipse3.TabIndex = 9;
            buttonEllipse3.Text = "Foods";
            buttonEllipse3.UseVisualStyleBackColor = false;
            buttonEllipse3.Click += buttonEllipse3_Click;
            // 
            // buttonEllipse2
            // 
            buttonEllipse2.BackColor = Color.AntiqueWhite;
            buttonEllipse2.BackgroundImageLayout = ImageLayout.Stretch;
            buttonEllipse2.FlatAppearance.BorderSize = 0;
            buttonEllipse2.FlatStyle = FlatStyle.Flat;
            buttonEllipse2.Font = new Font("Times New Roman", 18.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEllipse2.Location = new Point(510, 129);
            buttonEllipse2.Name = "buttonEllipse2";
            buttonEllipse2.Size = new Size(196, 119);
            buttonEllipse2.TabIndex = 8;
            buttonEllipse2.Text = "Animal Locations";
            buttonEllipse2.UseVisualStyleBackColor = false;
            buttonEllipse2.Click += buttonEllipse2_Click;
            // 
            // AnimalClassifications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonEllipse7);
            Controls.Add(buttonEllipse3);
            Controls.Add(buttonEllipse2);
            Name = "AnimalClassifications";
            Text = "AnimalClassifications";
            ResumeLayout(false);
        }

        #endregion

        private CustomDesign.ButtonEllipse buttonEllipse7;
        private CustomDesign.ButtonEllipse buttonEllipse3;
        private CustomDesign.ButtonEllipse buttonEllipse2;
    }
}