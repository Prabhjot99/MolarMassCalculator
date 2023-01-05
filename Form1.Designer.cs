namespace MMC_NoName01
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
            this.UI_DataGridView = new System.Windows.Forms.DataGridView();
            this.UI_BtnSortName = new System.Windows.Forms.Button();
            this.UI_SortSymbols = new System.Windows.Forms.Button();
            this.UI_BtnSortAtomicNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_TbxChemicalFormula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UI_lblMolarMass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DataGridView
            // 
            this.UI_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGridView.Location = new System.Drawing.Point(13, 23);
            this.UI_DataGridView.Name = "UI_DataGridView";
            this.UI_DataGridView.RowHeadersWidth = 51;
            this.UI_DataGridView.Size = new System.Drawing.Size(556, 269);
            this.UI_DataGridView.TabIndex = 0;
            // 
            // UI_BtnSortName
            // 
            this.UI_BtnSortName.Location = new System.Drawing.Point(606, 23);
            this.UI_BtnSortName.Name = "UI_BtnSortName";
            this.UI_BtnSortName.Size = new System.Drawing.Size(141, 23);
            this.UI_BtnSortName.TabIndex = 1;
            this.UI_BtnSortName.Text = "Sort By Name";
            this.UI_BtnSortName.UseVisualStyleBackColor = true;
            this.UI_BtnSortName.Click += new System.EventHandler(this.UI_BtnSortName_Click);
            // 
            // UI_SortSymbols
            // 
            this.UI_SortSymbols.Location = new System.Drawing.Point(607, 52);
            this.UI_SortSymbols.Name = "UI_SortSymbols";
            this.UI_SortSymbols.Size = new System.Drawing.Size(140, 23);
            this.UI_SortSymbols.TabIndex = 2;
            this.UI_SortSymbols.Text = "Single Character Symbols";
            this.UI_SortSymbols.UseVisualStyleBackColor = true;
            this.UI_SortSymbols.Click += new System.EventHandler(this.UI_SortSymbols_Click);
            // 
            // UI_BtnSortAtomicNumber
            // 
            this.UI_BtnSortAtomicNumber.Location = new System.Drawing.Point(606, 81);
            this.UI_BtnSortAtomicNumber.Name = "UI_BtnSortAtomicNumber";
            this.UI_BtnSortAtomicNumber.Size = new System.Drawing.Size(140, 23);
            this.UI_BtnSortAtomicNumber.TabIndex = 3;
            this.UI_BtnSortAtomicNumber.Text = "Sort By Atomic #";
            this.UI_BtnSortAtomicNumber.UseVisualStyleBackColor = true;
            this.UI_BtnSortAtomicNumber.Click += new System.EventHandler(this.UI_BtnSortAtomicNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chemical Formula:";
            // 
            // UI_TbxChemicalFormula
            // 
            this.UI_TbxChemicalFormula.Location = new System.Drawing.Point(109, 334);
            this.UI_TbxChemicalFormula.Name = "UI_TbxChemicalFormula";
            this.UI_TbxChemicalFormula.Size = new System.Drawing.Size(134, 20);
            this.UI_TbxChemicalFormula.TabIndex = 5;
            this.UI_TbxChemicalFormula.TextChanged += new System.EventHandler(this.UI_TbxChemicalFormula_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Approx. Molar Mass:";
            // 
            // UI_lblMolarMass
            // 
            this.UI_lblMolarMass.AutoSize = true;
            this.UI_lblMolarMass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UI_lblMolarMass.Location = new System.Drawing.Point(372, 336);
            this.UI_lblMolarMass.Name = "UI_lblMolarMass";
            this.UI_lblMolarMass.Size = new System.Drawing.Size(15, 15);
            this.UI_lblMolarMass.TabIndex = 7;
            this.UI_lblMolarMass.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 394);
            this.Controls.Add(this.UI_lblMolarMass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UI_TbxChemicalFormula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_BtnSortAtomicNumber);
            this.Controls.Add(this.UI_SortSymbols);
            this.Controls.Add(this.UI_BtnSortName);
            this.Controls.Add(this.UI_DataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DataGridView;
        private System.Windows.Forms.Button UI_BtnSortName;
        private System.Windows.Forms.Button UI_SortSymbols;
        private System.Windows.Forms.Button UI_BtnSortAtomicNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UI_TbxChemicalFormula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UI_lblMolarMass;
    }
}

