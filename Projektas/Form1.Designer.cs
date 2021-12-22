
namespace Projektas
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pavadinimas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kaina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.priceMax = new System.Windows.Forms.NumericUpDown();
            this.priceMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Basket_Button = new System.Windows.Forms.Button();
            this.Support_Button = new System.Windows.Forms.Button();
            this.support_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceMin)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Pavadinimas,
            this.Kaina,
            this.Tipas});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(750, 366);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Id
            // 
            this.Id.Text = "Prekes ID";
            this.Id.Width = 80;
            // 
            // Pavadinimas
            // 
            this.Pavadinimas.Text = "Pavadinimas";
            this.Pavadinimas.Width = 285;
            // 
            // Kaina
            // 
            this.Kaina.Text = "Kaina";
            this.Kaina.Width = 86;
            // 
            // Tipas
            // 
            this.Tipas.Text = "Kategorija";
            this.Tipas.Width = 208;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Visos prekės";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(12, 12);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(432, 22);
            this.SearchBar.TabIndex = 3;
            this.SearchBar.Text = "Paieška";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(451, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(145, 24);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Ieškoti";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // priceMax
            // 
            this.priceMax.Location = new System.Drawing.Point(464, 45);
            this.priceMax.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.priceMax.Name = "priceMax";
            this.priceMax.Size = new System.Drawing.Size(71, 22);
            this.priceMax.TabIndex = 5;
            this.priceMax.ValueChanged += new System.EventHandler(this.priceMax_ValueChanged_1);
            // 
            // priceMin
            // 
            this.priceMin.Location = new System.Drawing.Point(351, 44);
            this.priceMin.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.priceMin.Name = "priceMin";
            this.priceMin.Size = new System.Drawing.Size(71, 22);
            this.priceMin.TabIndex = 6;
            this.priceMin.ValueChanged += new System.EventHandler(this.priceMin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pasirinkta kaina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "nuo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "iki";
            // 
            // Basket_Button
            // 
            this.Basket_Button.BackColor = System.Drawing.Color.Coral;
            this.Basket_Button.Location = new System.Drawing.Point(777, 12);
            this.Basket_Button.Name = "Basket_Button";
            this.Basket_Button.Size = new System.Drawing.Size(129, 46);
            this.Basket_Button.TabIndex = 10;
            this.Basket_Button.Text = "Pirkinių krepšelis";
            this.Basket_Button.UseVisualStyleBackColor = false;
            this.Basket_Button.Click += new System.EventHandler(this.Basket_Button_Click);
            // 
            // Support_Button
            // 
            this.Support_Button.BackColor = System.Drawing.Color.Coral;
            this.Support_Button.Location = new System.Drawing.Point(777, 72);
            this.Support_Button.Name = "Support_Button";
            this.Support_Button.Size = new System.Drawing.Size(129, 46);
            this.Support_Button.TabIndex = 11;
            this.Support_Button.Text = "Pagalba";
            this.Support_Button.UseVisualStyleBackColor = false;
            this.Support_Button.Click += new System.EventHandler(this.Support_Button_Click);
            // 
            // support_label
            // 
            this.support_label.AutoSize = true;
            this.support_label.Location = new System.Drawing.Point(777, 166);
            this.support_label.Name = "support_label";
            this.support_label.Size = new System.Drawing.Size(0, 17);
            this.support_label.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.support_label);
            this.Controls.Add(this.Support_Button);
            this.Controls.Add(this.Basket_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceMin);
            this.Controls.Add(this.priceMax);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Kompiuterių dalių parduotuvė";
            ((System.ComponentModel.ISupportInitialize)(this.priceMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Pavadinimas;
        private System.Windows.Forms.ColumnHeader Kaina;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Tipas;
        private System.Windows.Forms.NumericUpDown priceMax;
        private System.Windows.Forms.NumericUpDown priceMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Basket_Button;
        private System.Windows.Forms.Button Support_Button;
        private System.Windows.Forms.Label support_label;
    }
}

