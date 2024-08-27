namespace Zoo_App_again.Screens.Animals
{
    partial class AnimalPlaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalPlaces));
            panel3 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            panel24 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            button8 = new Button();
            button6 = new Button();
            button7 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            animalPlaceBindingSource = new BindingSource(components);
            label3 = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animalPlaceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Location = new Point(147, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1194, 54);
            panel3.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.BurlyWood;
            label1.Location = new Point(407, 4);
            label1.Name = "label1";
            label1.Size = new Size(372, 39);
            label1.TabIndex = 19;
            label1.Text = "Manage Animal Locations";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel24);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button7);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(148, 811);
            panel1.TabIndex = 36;
            // 
            // panel24
            // 
            panel24.BackColor = Color.RosyBrown;
            panel24.Location = new Point(3, 307);
            panel24.Name = "panel24";
            panel24.Size = new Size(10, 64);
            panel24.TabIndex = 35;
            // 
            // panel6
            // 
            panel6.BackColor = Color.RosyBrown;
            panel6.Location = new Point(3, 205);
            panel6.Name = "panel6";
            panel6.Size = new Size(10, 64);
            panel6.TabIndex = 34;
            // 
            // panel5
            // 
            panel5.BackColor = Color.RosyBrown;
            panel5.Location = new Point(3, 109);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 64);
            panel5.TabIndex = 33;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button8.ForeColor = Color.BurlyWood;
            button8.ImageAlign = ContentAlignment.TopLeft;
            button8.Location = new Point(15, 113);
            button8.Name = "button8";
            button8.Size = new Size(127, 44);
            button8.TabIndex = 27;
            button8.Text = "Home";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.BurlyWood;
            button6.Location = new Point(15, 310);
            button6.Name = "button6";
            button6.Size = new Size(127, 50);
            button6.TabIndex = 31;
            button6.Text = "Log Out";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button7.ForeColor = Color.BurlyWood;
            button7.Location = new Point(15, 209);
            button7.Name = "button7";
            button7.Size = new Size(127, 50);
            button7.TabIndex = 28;
            button7.Text = "Animals";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(625, 299);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 35;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumSeaGreen;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(333, 329);
            button2.Name = "button2";
            button2.Size = new Size(225, 35);
            button2.TabIndex = 34;
            button2.Text = "Get Animals in that place";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(688, 176);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 33;
            button1.Text = "SEARCH";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Number, name });
            dataGridView1.DataSource = animalPlaceBindingSource;
            dataGridView1.Location = new Point(932, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(302, 376);
            dataGridView1.TabIndex = 32;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
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
            // animalPlaceBindingSource
            // 
            animalPlaceBindingSource.DataSource = typeof(Entities.AnimalPlace);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.MediumSeaGreen;
            label3.Location = new Point(258, 96);
            label3.Name = "label3";
            label3.Size = new Size(244, 39);
            label3.TabIndex = 31;
            label3.Text = "Animal Location";
            // 
            // button5
            // 
            button5.BackColor = Color.MediumSeaGreen;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(423, 176);
            button5.Name = "button5";
            button5.Size = new Size(82, 35);
            button5.TabIndex = 30;
            button5.Text = "EDIT";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.MediumSeaGreen;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(554, 176);
            button4.Name = "button4";
            button4.Size = new Size(89, 35);
            button4.TabIndex = 29;
            button4.Text = "DELETE";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.MediumSeaGreen;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(275, 176);
            button3.Name = "button3";
            button3.Size = new Size(94, 35);
            button3.TabIndex = 28;
            button3.Text = "ADD";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(554, 109);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 20);
            textBox1.TabIndex = 27;
            // 
            // AnimalPlaces
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1334, 500);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Name = "AnimalPlaces";
            Text = "AnimalPlaces";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)animalPlaceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label label1;
        private Panel panel1;
        private Panel panel24;
        private Panel panel6;
        private Panel panel5;
        private Button button8;
        private Button button6;
        private Button button7;
        private ListBox listBox1;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label3;
        private Button button5;
        private Button button4;
        private Button button3;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn name;
        private BindingSource animalPlaceBindingSource;
    }
}