namespace Zoo_App_again.Screens.Cafes
{
    partial class Cafes
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cafes));
            panel3 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            panel24 = new Panel();
            panel5 = new Panel();
            button2 = new Button();
            button7 = new Button();
            button1 = new Button();
            label6 = new Label();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            monthlyRent = new DataGridViewTextBoxColumn();
            rentDuration = new DataGridViewTextBoxColumn();
            cafeBindingSource = new BindingSource(components);
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cafeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.PapayaWhip;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(115, -8);
            panel3.Name = "panel3";
            panel3.Size = new Size(1348, 59);
            panel3.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(557, 11);
            label1.Name = "label1";
            label1.Size = new Size(211, 39);
            label1.TabIndex = 18;
            label1.Text = "Manage Cafes";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PapayaWhip;
            panel1.Controls.Add(panel24);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button7);
            panel1.Location = new Point(-7, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(125, 737);
            panel1.TabIndex = 41;
            // 
            // panel24
            // 
            panel24.BackColor = Color.RosyBrown;
            panel24.Location = new Point(3, 218);
            panel24.Name = "panel24";
            panel24.Size = new Size(10, 64);
            panel24.TabIndex = 33;
            // 
            // panel5
            // 
            panel5.BackColor = Color.RosyBrown;
            panel5.Location = new Point(3, 118);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 64);
            panel5.TabIndex = 30;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.BurlyWood;
            button2.Location = new Point(14, 234);
            button2.Name = "button2";
            button2.Size = new Size(108, 41);
            button2.TabIndex = 32;
            button2.Text = "Log Out";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button7.ForeColor = Color.BurlyWood;
            button7.ImageAlign = ContentAlignment.TopLeft;
            button7.Location = new Point(14, 128);
            button7.Name = "button7";
            button7.Size = new Size(111, 42);
            button7.TabIndex = 28;
            button7.Text = "Home";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(458, 241);
            button1.Name = "button1";
            button1.Size = new Size(111, 35);
            button1.TabIndex = 40;
            button1.Text = "UPDATE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(143, 301);
            label6.Name = "label6";
            label6.Size = new Size(252, 39);
            label6.TabIndex = 39;
            label6.Text = "Enter Cafe Name";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(401, 311);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 38;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Number, name, monthlyRent, rentDuration });
            dataGridView1.DataSource = cafeBindingSource;
            dataGridView1.Location = new Point(849, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(553, 463);
            dataGridView1.TabIndex = 37;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint_1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // Number
            // 
            Number.DataPropertyName = "int";
            Number.HeaderText = "Number";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 125;
            // 
            // name
            // 
            name.DataPropertyName = "Name";
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 125;
            // 
            // monthlyRent
            // 
            monthlyRent.DataPropertyName = "Monthly_Rent";
            monthlyRent.HeaderText = "Monthly Rent";
            monthlyRent.MinimumWidth = 6;
            monthlyRent.Name = "monthlyRent";
            monthlyRent.ReadOnly = true;
            monthlyRent.Width = 125;
            // 
            // rentDuration
            // 
            rentDuration.DataPropertyName = "Rent_Duration";
            rentDuration.HeaderText = "Rent Duration";
            rentDuration.MinimumWidth = 6;
            rentDuration.Name = "rentDuration";
            rentDuration.ReadOnly = true;
            rentDuration.Width = 125;
            // 
            // cafeBindingSource
            // 
            cafeBindingSource.DataSource = typeof(Entities.Cafe);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(143, 187);
            label5.Name = "label5";
            label5.Size = new Size(208, 39);
            label5.TabIndex = 36;
            label5.Text = "Rent Duration";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(145, 122);
            label3.Name = "label3";
            label3.Size = new Size(203, 39);
            label3.TabIndex = 35;
            label3.Text = "Monthly Rent";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(145, 71);
            label2.Name = "label2";
            label2.Size = new Size(171, 39);
            label2.TabIndex = 34;
            label2.Text = "Cafe Name";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 192, 192);
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(329, 362);
            button5.Name = "button5";
            button5.Size = new Size(122, 35);
            button5.TabIndex = 33;
            button5.Text = "SEARCH";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 192, 192);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(503, 362);
            button4.Name = "button4";
            button4.Size = new Size(111, 35);
            button4.TabIndex = 32;
            button4.Text = "DELETE";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 192);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(296, 241);
            button3.Name = "button3";
            button3.Size = new Size(111, 35);
            button3.TabIndex = 31;
            button3.Text = "ADD";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(355, 200);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 20);
            textBox3.TabIndex = 30;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(354, 135);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 20);
            textBox2.TabIndex = 29;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(355, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 20);
            textBox1.TabIndex = 28;
            // 
            // Cafes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1448, 622);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Cafes";
            Text = "Cafes";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cafeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label label1;
        private Panel panel1;
        private Panel panel24;
        private Panel panel5;
        private Button button2;
        private Button button7;
        private Button button1;
        private Label label6;
        private TextBox textBox4;
        private DataGridView dataGridView1;
        private BindingSource cafeBindingSource;
        private Label label5;
        private Label label3;
        private Label label2;
        private Button button5;
        private Button button4;
        private Button button3;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn monthlyRent;
        private DataGridViewTextBoxColumn rentDuration;
    }
}