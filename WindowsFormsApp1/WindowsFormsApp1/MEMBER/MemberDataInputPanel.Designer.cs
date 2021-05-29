namespace WindowsFormsApp1.MEMBER
{
    partial class MemberDataInputPanel
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
            this.testTextBox = new System.Windows.Forms.RichTextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtSummery = new System.Windows.Forms.ListBox();
            this.chklistManage = new System.Windows.Forms.CheckedListBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassward = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSerchUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testTextBox
            // 
            this.testTextBox.Location = new System.Drawing.Point(331, 245);
            this.testTextBox.Name = "testTextBox";
            this.testTextBox.Size = new System.Drawing.Size(388, 84);
            this.testTextBox.TabIndex = 33;
            this.testTextBox.Text = "";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(552, 171);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(167, 61);
            this.btnDeleteUser.TabIndex = 32;
            this.btnDeleteUser.Text = "회원삭제";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(552, 94);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(167, 61);
            this.btnChangeUser.TabIndex = 31;
            this.btnChangeUser.Text = "정보수정";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(552, 15);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(76, 61);
            this.btnAddUser.TabIndex = 30;
            this.btnAddUser.Text = "회원추가";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtSummery
            // 
            this.txtSummery.FormattingEnabled = true;
            this.txtSummery.ItemHeight = 15;
            this.txtSummery.Location = new System.Drawing.Point(167, 343);
            this.txtSummery.Name = "txtSummery";
            this.txtSummery.Size = new System.Drawing.Size(552, 139);
            this.txtSummery.TabIndex = 29;
            // 
            // chklistManage
            // 
            this.chklistManage.FormattingEnabled = true;
            this.chklistManage.Items.AddRange(new object[] {
            "사서사용자",
            "열람실관리자",
            "회의실관리자",
            "회원관리자"});
            this.chklistManage.Location = new System.Drawing.Point(167, 245);
            this.chklistManage.Name = "chklistManage";
            this.chklistManage.Size = new System.Drawing.Size(133, 84);
            this.chklistManage.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(167, 207);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(334, 25);
            this.txtEmail.TabIndex = 27;
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyUp);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(167, 156);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(334, 25);
            this.txtPhoneNumber.TabIndex = 26;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            this.txtPhoneNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhoneNumber_KeyUp);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(167, 105);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(334, 25);
            this.txtName.TabIndex = 25;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // txtPassward
            // 
            this.txtPassward.Location = new System.Drawing.Point(167, 61);
            this.txtPassward.Name = "txtPassward";
            this.txtPassward.Size = new System.Drawing.Size(334, 25);
            this.txtPassward.TabIndex = 24;
            this.txtPassward.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassward_KeyUp);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(166, 15);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(334, 25);
            this.txtId.TabIndex = 23;
            this.txtId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtId_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "소개";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "관리자권한";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "E-Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "전화번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Passward";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID";
            // 
            // btnSerchUser
            // 
            this.btnSerchUser.Location = new System.Drawing.Point(643, 15);
            this.btnSerchUser.Name = "btnSerchUser";
            this.btnSerchUser.Size = new System.Drawing.Size(76, 61);
            this.btnSerchUser.TabIndex = 30;
            this.btnSerchUser.Text = "회원검색";
            this.btnSerchUser.UseVisualStyleBackColor = true;
            // 
            // MemberDataInputPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testTextBox);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.btnSerchUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtSummery);
            this.Controls.Add(this.chklistManage);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPassward);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MemberDataInputPanel";
            this.Size = new System.Drawing.Size(797, 501);
            this.Load += new System.EventHandler(this.MemberDataInputPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox testTextBox;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ListBox txtSummery;
        private System.Windows.Forms.CheckedListBox chklistManage;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassward;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSerchUser;
    }
}
