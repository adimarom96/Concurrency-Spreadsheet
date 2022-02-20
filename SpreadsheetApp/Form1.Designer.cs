namespace SpreadsheetApp
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
            this.bCreateSpread = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.textStringSearch = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textStringSet = new System.Windows.Forms.TextBox();
            this.bSetString = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.textRowSize = new System.Windows.Forms.TextBox();
            this.textColSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textROW2 = new System.Windows.Forms.TextBox();
            this.textCOL1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bCreateSpread
            // 
            this.bCreateSpread.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bCreateSpread.BackgroundImage")));
            this.bCreateSpread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bCreateSpread.Location = new System.Drawing.Point(239, 42);
            this.bCreateSpread.Margin = new System.Windows.Forms.Padding(4);
            this.bCreateSpread.Name = "bCreateSpread";
            this.bCreateSpread.Size = new System.Drawing.Size(134, 140);
            this.bCreateSpread.TabIndex = 2;
            this.bCreateSpread.UseVisualStyleBackColor = true;
            this.bCreateSpread.Click += new System.EventHandler(this.bCreateSpread_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(43, 285);
            this.Result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(66, 25);
            this.Result.TabIndex = 3;
            this.Result.Text = "Result";
            this.Result.Click += new System.EventHandler(this.Result_Click);
            // 
            // textStringSearch
            // 
            this.textStringSearch.Location = new System.Drawing.Point(48, 153);
            this.textStringSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textStringSearch.Name = "textStringSearch";
            this.textStringSearch.Size = new System.Drawing.Size(107, 22);
            this.textStringSearch.TabIndex = 4;
            this.textStringSearch.TextChanged += new System.EventHandler(this.textStringSearch_TextChanged);
            // 
            // bSearch
            // 
            this.bSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearch.BackgroundImage")));
            this.bSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearch.Location = new System.Drawing.Point(48, 42);
            this.bSearch.Margin = new System.Windows.Forms.Padding(4);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(107, 103);
            this.bSearch.TabIndex = 5;
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Text ";
            // 
            // textStringSet
            // 
            this.textStringSet.Location = new System.Drawing.Point(456, 153);
            this.textStringSet.Margin = new System.Windows.Forms.Padding(4);
            this.textStringSet.Name = "textStringSet";
            this.textStringSet.Size = new System.Drawing.Size(119, 22);
            this.textStringSet.TabIndex = 6;
            this.textStringSet.TextChanged += new System.EventHandler(this.textStringSet_TextChanged);
            // 
            // bSetString
            // 
            this.bSetString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSetString.BackgroundImage")));
            this.bSetString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSetString.Location = new System.Drawing.Point(456, 42);
            this.bSetString.Margin = new System.Windows.Forms.Padding(4);
            this.bSetString.Name = "bSetString";
            this.bSetString.Size = new System.Drawing.Size(117, 103);
            this.bSetString.TabIndex = 9;
            this.bSetString.UseVisualStyleBackColor = true;
            this.bSetString.Click += new System.EventHandler(this.bSetString_Click);
            // 
            // bPrint
            // 
            this.bPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPrint.BackgroundImage")));
            this.bPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPrint.Location = new System.Drawing.Point(611, 42);
            this.bPrint.Margin = new System.Windows.Forms.Padding(4);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(133, 123);
            this.bPrint.TabIndex = 11;
            this.bPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 358);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(734, 369);
            this.dataGridView1.TabIndex = 12;
            // 
            // bSave
            // 
            this.bSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSave.BackgroundImage")));
            this.bSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSave.Location = new System.Drawing.Point(686, 193);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(62, 60);
            this.bSave.TabIndex = 13;
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bLoad.BackgroundImage")));
            this.bLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bLoad.Location = new System.Drawing.Point(611, 196);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(70, 57);
            this.bLoad.TabIndex = 14;
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // textRowSize
            // 
            this.textRowSize.Location = new System.Drawing.Point(239, 190);
            this.textRowSize.Name = "textRowSize";
            this.textRowSize.Size = new System.Drawing.Size(56, 22);
            this.textRowSize.TabIndex = 15;
            // 
            // textColSize
            // 
            this.textColSize.Location = new System.Drawing.Point(308, 190);
            this.textColSize.Name = "textColSize";
            this.textColSize.Size = new System.Drawing.Size(65, 22);
            this.textColSize.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "row            col";
            // 
            // textROW2
            // 
            this.textROW2.Location = new System.Drawing.Point(455, 200);
            this.textROW2.Name = "textROW2";
            this.textROW2.Size = new System.Drawing.Size(54, 22);
            this.textROW2.TabIndex = 18;
            // 
            // textCOL1
            // 
            this.textCOL1.Location = new System.Drawing.Point(521, 200);
            this.textCOL1.Name = "textCOL1";
            this.textCOL1.Size = new System.Drawing.Size(59, 22);
            this.textCOL1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(194, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Create New SpreadSheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(694, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Save";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(620, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Load";
            this.label8.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Search For String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "row                col";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Insert String";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(649, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Print ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 176);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Text ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 796);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCOL1);
            this.Controls.Add(this.textROW2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textColSize);
            this.Controls.Add(this.textRowSize);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.bSetString);
            this.Controls.Add(this.textStringSet);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.textStringSearch);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.bCreateSpread);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bCreateSpread;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TextBox textStringSearch;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textStringSet;
        private System.Windows.Forms.Button bSetString;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.TextBox textRowSize;
        private System.Windows.Forms.TextBox textColSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textROW2;
        private System.Windows.Forms.TextBox textCOL1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}

