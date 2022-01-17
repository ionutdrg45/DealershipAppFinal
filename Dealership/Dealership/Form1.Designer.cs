namespace Dealership
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textSearch = new System.Windows.Forms.Label();
            this.textBrand = new System.Windows.Forms.Label();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textModel = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.ButtonMakeSearch = new System.Windows.Forms.Button();
            this.numericUpDownFrom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonSellcar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dealership Vehicles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(31, 57);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(872, 444);
            this.dataGridView1.TabIndex = 0;
            // 
            // textSearch
            // 
            this.textSearch.AutoSize = true;
            this.textSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Location = new System.Drawing.Point(925, 222);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(86, 25);
            this.textSearch.TabIndex = 3;
            this.textSearch.Text = "Search";
            // 
            // textBrand
            // 
            this.textBrand.AutoSize = true;
            this.textBrand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBrand.Location = new System.Drawing.Point(945, 273);
            this.textBrand.Name = "textBrand";
            this.textBrand.Size = new System.Drawing.Size(56, 20);
            this.textBrand.TabIndex = 4;
            this.textBrand.Text = "Brand:";
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBrand.Location = new System.Drawing.Point(1017, 273);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(157, 21);
            this.textBoxBrand.TabIndex = 5;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxModel.Location = new System.Drawing.Point(1017, 323);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(157, 21);
            this.textBoxModel.TabIndex = 7;
            // 
            // textModel
            // 
            this.textModel.AutoSize = true;
            this.textModel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textModel.Location = new System.Drawing.Point(945, 324);
            this.textModel.Name = "textModel";
            this.textModel.Size = new System.Drawing.Size(56, 20);
            this.textModel.TabIndex = 6;
            this.textModel.Text = "Model:";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrom.Location = new System.Drawing.Point(945, 393);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(50, 20);
            this.labelFrom.TabIndex = 8;
            this.labelFrom.Text = "From:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTo.Location = new System.Drawing.Point(945, 447);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(31, 20);
            this.labelTo.TabIndex = 11;
            this.labelTo.Text = "To:";
            // 
            // ButtonMakeSearch
            // 
            this.ButtonMakeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMakeSearch.Location = new System.Drawing.Point(991, 512);
            this.ButtonMakeSearch.Name = "ButtonMakeSearch";
            this.ButtonMakeSearch.Size = new System.Drawing.Size(137, 44);
            this.ButtonMakeSearch.TabIndex = 12;
            this.ButtonMakeSearch.Text = "Search ...";
            this.ButtonMakeSearch.UseVisualStyleBackColor = true;
            this.ButtonMakeSearch.Click += new System.EventHandler(this.ButtonMakeSearch_Click);
            // 
            // numericUpDownFrom
            // 
            this.numericUpDownFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFrom.Location = new System.Drawing.Point(1017, 391);
            this.numericUpDownFrom.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.numericUpDownFrom.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.numericUpDownFrom.Name = "numericUpDownFrom";
            this.numericUpDownFrom.Size = new System.Drawing.Size(157, 26);
            this.numericUpDownFrom.TabIndex = 13;
            this.numericUpDownFrom.Value = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            // 
            // numericUpDownTo
            // 
            this.numericUpDownTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTo.Location = new System.Drawing.Point(1017, 447);
            this.numericUpDownTo.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.numericUpDownTo.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.numericUpDownTo.Name = "numericUpDownTo";
            this.numericUpDownTo.Size = new System.Drawing.Size(157, 26);
            this.numericUpDownTo.TabIndex = 14;
            this.numericUpDownTo.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(925, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Options";
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEdit.Location = new System.Drawing.Point(930, 92);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(111, 34);
            this.ButtonEdit.TabIndex = 16;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDelete.Location = new System.Drawing.Point(1073, 92);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(111, 34);
            this.ButtonDelete.TabIndex = 17;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAdd.Location = new System.Drawing.Point(930, 159);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(254, 34);
            this.ButtonAdd.TabIndex = 18;
            this.ButtonAdd.Text = "Add new car";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(930, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // ButtonSellcar
            // 
            this.ButtonSellcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSellcar.Location = new System.Drawing.Point(412, 512);
            this.ButtonSellcar.Name = "ButtonSellcar";
            this.ButtonSellcar.Size = new System.Drawing.Size(137, 44);
            this.ButtonSellcar.TabIndex = 20;
            this.ButtonSellcar.Text = "Sell car";
            this.ButtonSellcar.UseVisualStyleBackColor = true;
            this.ButtonSellcar.Click += new System.EventHandler(this.ButtonSellcar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 568);
            this.Controls.Add(this.ButtonSellcar);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownTo);
            this.Controls.Add(this.numericUpDownFrom);
            this.Controls.Add(this.ButtonMakeSearch);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.textModel);
            this.Controls.Add(this.textBoxBrand);
            this.Controls.Add(this.textBrand);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dealership Management App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label textSearch;
        private System.Windows.Forms.Label textBrand;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label textModel;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Button ButtonMakeSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownFrom;
        private System.Windows.Forms.NumericUpDown numericUpDownTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonSellcar;
    }
}

