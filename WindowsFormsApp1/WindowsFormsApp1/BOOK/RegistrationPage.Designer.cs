
namespace WindowsFormsApp1.BOOK
{
    partial class RegistrationPage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegist = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.dtpPublishcationDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtOriginnm = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtTransrator = new System.Windows.Forms.TextBox();
            this.txtWriter = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(495, 48);
            this.btnRegist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(100, 21);
            this.btnRegist.TabIndex = 5;
            this.btnRegist.Text = "등록";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtISBN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(46, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(435, 54);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "필수항목";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 19);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(107, 21);
            this.txtName.TabIndex = 11;
            // 
            // txtISBN
            // 
            this.txtISBN.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtISBN.Location = new System.Drawing.Point(285, 19);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtISBN.MaxLength = 13;
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(107, 21);
            this.txtISBN.TabIndex = 10;
            this.txtISBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtISBN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "서명";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudPrice);
            this.groupBox2.Controls.Add(this.dtpPublishcationDate);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmbTypes);
            this.groupBox2.Controls.Add(this.txtIndex);
            this.groupBox2.Controls.Add(this.txtSummary);
            this.groupBox2.Controls.Add(this.txtOriginnm);
            this.groupBox2.Controls.Add(this.txtPublisher);
            this.groupBox2.Controls.Add(this.txtTransrator);
            this.groupBox2.Controls.Add(this.txtWriter);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(46, 130);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(435, 370);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "선택항목";
            // 
            // nudPrice
            // 
            this.nudPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPrice.Location = new System.Drawing.Point(285, 69);
            this.nudPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(107, 21);
            this.nudPrice.TabIndex = 25;
            // 
            // dtpPublishcationDate
            // 
            this.dtpPublishcationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPublishcationDate.Location = new System.Drawing.Point(285, 44);
            this.dtpPublishcationDate.Name = "dtpPublishcationDate";
            this.dtpPublishcationDate.Size = new System.Drawing.Size(107, 21);
            this.dtpPublishcationDate.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(221, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "출간일";
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(285, 94);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(107, 20);
            this.cmbTypes.TabIndex = 8;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(26, 259);
            this.txtIndex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIndex.MaxLength = 65535;
            this.txtIndex.Multiline = true;
            this.txtIndex.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(366, 98);
            this.txtIndex.TabIndex = 22;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(26, 139);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSummary.MaxLength = 65535;
            this.txtSummary.Multiline = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(366, 98);
            this.txtSummary.TabIndex = 20;
            // 
            // txtOriginnm
            // 
            this.txtOriginnm.Location = new System.Drawing.Point(285, 19);
            this.txtOriginnm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginnm.MaxLength = 255;
            this.txtOriginnm.Name = "txtOriginnm";
            this.txtOriginnm.Size = new System.Drawing.Size(107, 21);
            this.txtOriginnm.TabIndex = 19;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(88, 69);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPublisher.MaxLength = 255;
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(107, 21);
            this.txtPublisher.TabIndex = 16;
            // 
            // txtTransrator
            // 
            this.txtTransrator.Location = new System.Drawing.Point(88, 44);
            this.txtTransrator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTransrator.MaxLength = 255;
            this.txtTransrator.Name = "txtTransrator";
            this.txtTransrator.Size = new System.Drawing.Size(107, 21);
            this.txtTransrator.TabIndex = 15;
            // 
            // txtWriter
            // 
            this.txtWriter.Location = new System.Drawing.Point(88, 19);
            this.txtWriter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWriter.MaxLength = 255;
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.Size = new System.Drawing.Size(107, 21);
            this.txtWriter.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "목차";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(221, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "가격";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "요약";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(221, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "원저";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "자료유형";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "출판사";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "번역가";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "저자";
            // 
            // RegistrationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegist);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegistrationPage";
            this.Size = new System.Drawing.Size(628, 502);
            this.Load += new System.EventHandler(this.RegistrationPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TextBox txtOriginnm;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtTransrator;
        private System.Windows.Forms.TextBox txtWriter;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.DateTimePicker dtpPublishcationDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudPrice;
    }
}
