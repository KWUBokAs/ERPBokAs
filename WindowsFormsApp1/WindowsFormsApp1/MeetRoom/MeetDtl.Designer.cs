
namespace WindowsFormsApp1.MeetRoom {
    partial class MeetDtl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeetDtl));
            this.lbLoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvIDs = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.btnReservNCan = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnEditNDel = new System.Windows.Forms.Button();
            this.lbWarn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDs)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLoc
            // 
            this.lbLoc.AutoSize = true;
            this.lbLoc.Location = new System.Drawing.Point(12, 9);
            this.lbLoc.Name = "lbLoc";
            this.lbLoc.Size = new System.Drawing.Size(41, 12);
            this.lbLoc.TabIndex = 0;
            this.lbLoc.Text = "ㅁㅁ실";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "메인 대여자 ID";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(131, 34);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(146, 21);
            this.tbID.TabIndex = 2;
            this.tbID.Leave += new System.EventHandler(this.tbID_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "대여자";
            // 
            // dgvIDs
            // 
            this.dgvIDs.AllowUserToAddRows = false;
            this.dgvIDs.AllowUserToDeleteRows = false;
            this.dgvIDs.AllowUserToResizeColumns = false;
            this.dgvIDs.AllowUserToResizeRows = false;
            this.dgvIDs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIDs.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvIDs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIDs.Location = new System.Drawing.Point(14, 84);
            this.dgvIDs.MultiSelect = false;
            this.dgvIDs.Name = "dgvIDs";
            this.dgvIDs.RowTemplate.Height = 23;
            this.dgvIDs.Size = new System.Drawing.Size(221, 162);
            this.dgvIDs.TabIndex = 4;
            this.dgvIDs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIDs_CellValueChanged);
            this.dgvIDs.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIDs_RowLeave);
            this.dgvIDs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvIDs_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(260, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 51);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDel.FlatAppearance.BorderSize = 0;
            this.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDel.Image = ((System.Drawing.Image)(resources.GetObject("BtnDel.Image")));
            this.BtnDel.Location = new System.Drawing.Point(260, 171);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(65, 51);
            this.BtnDel.TabIndex = 6;
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // btnReservNCan
            // 
            this.btnReservNCan.Location = new System.Drawing.Point(12, 272);
            this.btnReservNCan.Name = "btnReservNCan";
            this.btnReservNCan.Size = new System.Drawing.Size(75, 23);
            this.btnReservNCan.TabIndex = 7;
            this.btnReservNCan.Text = "예약/취소";
            this.btnReservNCan.UseVisualStyleBackColor = true;
            this.btnReservNCan.Click += new System.EventHandler(this.btnReservNCan_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.Location = new System.Drawing.Point(131, 272);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(75, 23);
            this.btnExtend.TabIndex = 8;
            this.btnExtend.Text = "연장";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // btnEditNDel
            // 
            this.btnEditNDel.Location = new System.Drawing.Point(250, 272);
            this.btnEditNDel.Name = "btnEditNDel";
            this.btnEditNDel.Size = new System.Drawing.Size(75, 23);
            this.btnEditNDel.TabIndex = 9;
            this.btnEditNDel.Text = "수정";
            this.btnEditNDel.UseVisualStyleBackColor = true;
            this.btnEditNDel.Click += new System.EventHandler(this.btnEditNDel_Click);
            // 
            // lbWarn
            // 
            this.lbWarn.AutoSize = true;
            this.lbWarn.ForeColor = System.Drawing.Color.Red;
            this.lbWarn.Location = new System.Drawing.Point(209, 62);
            this.lbWarn.Name = "lbWarn";
            this.lbWarn.Size = new System.Drawing.Size(133, 12);
            this.lbWarn.TabIndex = 10;
            this.lbWarn.Text = "해당하는 ID가 없어요 :(";
            this.lbWarn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MeetDtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 307);
            this.Controls.Add(this.lbWarn);
            this.Controls.Add(this.btnEditNDel);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnReservNCan);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvIDs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbLoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeetDtl";
            this.Text = "MeetDtl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetDtl_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvIDs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button btnReservNCan;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnEditNDel;
        private System.Windows.Forms.Label lbWarn;
    }
}