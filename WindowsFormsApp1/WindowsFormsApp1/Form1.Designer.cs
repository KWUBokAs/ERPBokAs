﻿namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBookSearchPage = new System.Windows.Forms.Button();
            this.btnSuperUserPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 113);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hello, World!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = " ";
            // 
            // btnBookSearchPage
            // 
            this.btnBookSearchPage.Location = new System.Drawing.Point(137, 98);
            this.btnBookSearchPage.Name = "btnBookSearchPage";
            this.btnBookSearchPage.Size = new System.Drawing.Size(115, 23);
            this.btnBookSearchPage.TabIndex = 2;
            this.btnBookSearchPage.Text = "검색페이지로";
            this.btnBookSearchPage.UseVisualStyleBackColor = true;
            this.btnBookSearchPage.Click += new System.EventHandler(this.bookSearchPage_Click);
            // 
            // btnSuperUserPage
            // 
            this.btnSuperUserPage.Location = new System.Drawing.Point(138, 155);
            this.btnSuperUserPage.Name = "btnSuperUserPage";
            this.btnSuperUserPage.Size = new System.Drawing.Size(113, 19);
            this.btnSuperUserPage.TabIndex = 3;
            this.btnSuperUserPage.Text = "사서페이지로";
            this.btnSuperUserPage.UseVisualStyleBackColor = true;
            this.btnSuperUserPage.Click += superUserPage_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSuperUserPage);
            this.Controls.Add(this.btnBookSearchPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBookSearchPage;
        private System.Windows.Forms.Button btnSuperUserPage;
    }
}

