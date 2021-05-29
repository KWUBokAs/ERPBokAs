namespace WindowsFormsApp1.MEMBER
{
    partial class StatusOfUsePanenl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labRentNum = new System.Windows.Forms.Label();
            this.labOverDueNum = new System.Windows.Forms.Label();
            this.labLatefee = new System.Windows.Forms.Label();
            this.dgvRentData = new System.Windows.Forms.DataGridView();
            this.btnExtend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentData)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(185, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "대출";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(332, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "연체";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(459, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "미납연체료";
            // 
            // labRentNum
            // 
            this.labRentNum.AutoSize = true;
            this.labRentNum.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labRentNum.Location = new System.Drawing.Point(240, 37);
            this.labRentNum.Name = "labRentNum";
            this.labRentNum.Size = new System.Drawing.Size(20, 20);
            this.labRentNum.TabIndex = 1;
            this.labRentNum.Text = "0";
            // 
            // labOverDueNum
            // 
            this.labOverDueNum.AutoSize = true;
            this.labOverDueNum.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labOverDueNum.Location = new System.Drawing.Point(387, 37);
            this.labOverDueNum.Name = "labOverDueNum";
            this.labOverDueNum.Size = new System.Drawing.Size(20, 20);
            this.labOverDueNum.TabIndex = 1;
            this.labOverDueNum.Text = "0";
            // 
            // labLatefee
            // 
            this.labLatefee.AutoSize = true;
            this.labLatefee.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labLatefee.Location = new System.Drawing.Point(574, 37);
            this.labLatefee.Name = "labLatefee";
            this.labLatefee.Size = new System.Drawing.Size(40, 20);
            this.labLatefee.TabIndex = 1;
            this.labLatefee.Text = "0원";
            // 
            // dgvRentData
            // 
            this.dgvRentData.AllowUserToAddRows = false;
            this.dgvRentData.AllowUserToDeleteRows = false;
            this.dgvRentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentData.Location = new System.Drawing.Point(17, 81);
            this.dgvRentData.Name = "dgvRentData";
            this.dgvRentData.ReadOnly = true;
            this.dgvRentData.RowHeadersWidth = 51;
            this.dgvRentData.RowTemplate.Height = 27;
            this.dgvRentData.Size = new System.Drawing.Size(763, 291);
            this.dgvRentData.TabIndex = 2;
            // 
            // btnExtend
            // 
            this.btnExtend.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExtend.Location = new System.Drawing.Point(315, 409);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(156, 50);
            this.btnExtend.TabIndex = 3;
            this.btnExtend.Text = "대출연장";
            this.btnExtend.UseVisualStyleBackColor = true;
            // 
            // StatusOfUsePanenl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.dgvRentData);
            this.Controls.Add(this.labLatefee);
            this.Controls.Add(this.labOverDueNum);
            this.Controls.Add(this.labRentNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "StatusOfUsePanenl";
            this.Size = new System.Drawing.Size(797, 501);
            this.Load += new System.EventHandler(this.StatusOfUsePanenl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labRentNum;
        private System.Windows.Forms.Label labOverDueNum;
        private System.Windows.Forms.Label labLatefee;
        private System.Windows.Forms.DataGridView dgvRentData;
        private System.Windows.Forms.Button btnExtend;
    }
}
