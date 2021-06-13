namespace WindowsFormsApp1.MEMBER
{
    partial class BadMemberSearch
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
            this.label7 = new System.Windows.Forms.Label();
            this.dgvBadTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labSumLatefee = new System.Windows.Forms.Label();
            this.txtBookNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBadTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("New Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "연체 도서 반납";
            // 
            // dgvBadTable
            // 
            this.dgvBadTable.AllowUserToAddRows = false;
            this.dgvBadTable.AllowUserToDeleteRows = false;
            this.dgvBadTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBadTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBadTable.Location = new System.Drawing.Point(8, 53);
            this.dgvBadTable.Name = "dgvBadTable";
            this.dgvBadTable.ReadOnly = true;
            this.dgvBadTable.RowHeadersWidth = 51;
            this.dgvBadTable.RowTemplate.Height = 27;
            this.dgvBadTable.Size = new System.Drawing.Size(622, 435);
            this.dgvBadTable.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(681, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "회원 ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(637, 53);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(157, 25);
            this.txtId.TabIndex = 11;
            this.txtId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtId_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(636, 135);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 51);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturn.Location = new System.Drawing.Point(637, 192);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(157, 51);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "반납";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(636, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "총 지불금액";
            // 
            // labSumLatefee
            // 
            this.labSumLatefee.AutoSize = true;
            this.labSumLatefee.Location = new System.Drawing.Point(637, 408);
            this.labSumLatefee.Name = "labSumLatefee";
            this.labSumLatefee.Size = new System.Drawing.Size(30, 15);
            this.labSumLatefee.TabIndex = 14;
            this.labSumLatefee.Text = "0원";
            // 
            // txtBookNum
            // 
            this.txtBookNum.Location = new System.Drawing.Point(636, 104);
            this.txtBookNum.Name = "txtBookNum";
            this.txtBookNum.Size = new System.Drawing.Size(157, 25);
            this.txtBookNum.TabIndex = 11;
            this.txtBookNum.TextChanged += new System.EventHandler(this.txtBookNum_TextChanged);
            this.txtBookNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookNum_KeyPress);
            this.txtBookNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBookNum_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(643, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "도서 등록번호";
            // 
            // BadMemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labSumLatefee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBookNum);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBadTable);
            this.Controls.Add(this.label7);
            this.Name = "BadMemberSearch";
            this.Size = new System.Drawing.Size(797, 500);
            this.Load += new System.EventHandler(this.BadMemberSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBadTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvBadTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labSumLatefee;
        private System.Windows.Forms.TextBox txtBookNum;
        private System.Windows.Forms.Label label3;
    }
}
