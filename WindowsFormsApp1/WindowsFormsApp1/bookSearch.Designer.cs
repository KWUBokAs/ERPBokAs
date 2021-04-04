
namespace WindowsFormsApp1
{
    partial class bookSearchPage
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
            this.bookSearchBox = new System.Windows.Forms.TextBox();
            this.lvwBookInfo = new System.Windows.Forms.ListView();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookSearchBox
            // 
            this.bookSearchBox.Location = new System.Drawing.Point(110, 67);
            this.bookSearchBox.Name = "bookSearchBox";
            this.bookSearchBox.Size = new System.Drawing.Size(374, 21);
            this.bookSearchBox.TabIndex = 0;
            this.bookSearchBox.Text = "검색할책정보";
            this.bookSearchBox.TextChanged += searchBoxChanged;
            // 
            // lvwBookInfo
            // 
            this.lvwBookInfo.HideSelection = false;
            this.lvwBookInfo.Location = new System.Drawing.Point(120, 121);
            this.lvwBookInfo.Name = "lvwBookInfo";
            this.lvwBookInfo.Size = new System.Drawing.Size(377, 145);
            this.lvwBookInfo.TabIndex = 1;
            this.lvwBookInfo.UseCompatibleStateImageBehavior = false;

            this.lvwBookInfo.Columns.Add("제목");
            this.lvwBookInfo.Columns.Add("저자");
            this.lvwBookInfo.Columns.Add("출판사");
            this.lvwBookInfo.Columns.Add("출판일자");
            this.lvwBookInfo.Columns.Add("자료위치");
            this.lvwBookInfo.Columns.Add("청구번호");
            // 
            // btnMainPage
            // 
            this.btnMainPage.Location = new System.Drawing.Point(597, 109);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(106, 55);
            this.btnMainPage.TabIndex = 2;
            this.btnMainPage.Text = "메인페이지로";
            this.btnMainPage.UseVisualStyleBackColor = true;
            this.btnMainPage.Click += mainPage_Click;
            // 
            // bookSearchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMainPage);
            this.Controls.Add(this.lvwBookInfo);
            this.Controls.Add(this.bookSearchBox);
            this.Name = "bookSearchPage";
            this.Text = "책 검색";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bookSearchBox;
        private System.Windows.Forms.ListView lvwBookInfo;
        private System.Windows.Forms.Button btnMainPage;
    }
}