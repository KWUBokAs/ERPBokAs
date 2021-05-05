namespace WindowsFormsApp1.MEMBER
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPassward = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lab_LoginStatus = new System.Windows.Forms.Label();
            this.lvwMember = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Passward";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(181, 104);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(254, 25);
            this.txtId.TabIndex = 1;
            // 
            // txtPassward
            // 
            this.txtPassward.Location = new System.Drawing.Point(180, 156);
            this.txtPassward.Name = "txtPassward";
            this.txtPassward.Size = new System.Drawing.Size(254, 25);
            this.txtPassward.TabIndex = 1;
            this.txtPassward.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassward_KeyUp);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(459, 103);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 78);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lab_LoginStatus
            // 
            this.lab_LoginStatus.AutoSize = true;
            this.lab_LoginStatus.Location = new System.Drawing.Point(181, 66);
            this.lab_LoginStatus.Name = "lab_LoginStatus";
            this.lab_LoginStatus.Size = new System.Drawing.Size(0, 15);
            this.lab_LoginStatus.TabIndex = 4;
            // 
            // lvwMember
            // 
            this.lvwMember.HideSelection = false;
            this.lvwMember.Location = new System.Drawing.Point(27, 222);
            this.lvwMember.Name = "lvwMember";
            this.lvwMember.Size = new System.Drawing.Size(749, 203);
            this.lvwMember.TabIndex = 5;
            this.lvwMember.UseCompatibleStateImageBehavior = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwMember);
            this.Controls.Add(this.lab_LoginStatus);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassward);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassward;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lab_LoginStatus;
        private System.Windows.Forms.ListView lvwMember;
    }
}