
namespace WindowsFormsApp1
{
    partial class BookInfoDetail
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelISBN = new System.Windows.Forms.Label();
            this.labelWriter = new System.Windows.Forms.Label();
            this.labelTransrator = new System.Windows.Forms.Label();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelOriginnm = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Callnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RentYN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservYN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(328, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 15);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "서명 : ";
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(328, 70);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(54, 15);
            this.labelISBN.TabIndex = 2;
            this.labelISBN.Text = "ISBN : ";
            // 
            // labelWriter
            // 
            this.labelWriter.AutoSize = true;
            this.labelWriter.Location = new System.Drawing.Point(328, 115);
            this.labelWriter.Name = "labelWriter";
            this.labelWriter.Size = new System.Drawing.Size(52, 15);
            this.labelWriter.TabIndex = 3;
            this.labelWriter.Text = "저자 : ";
            // 
            // labelTransrator
            // 
            this.labelTransrator.AutoSize = true;
            this.labelTransrator.Location = new System.Drawing.Point(328, 158);
            this.labelTransrator.Name = "labelTransrator";
            this.labelTransrator.Size = new System.Drawing.Size(52, 15);
            this.labelTransrator.TabIndex = 4;
            this.labelTransrator.Text = "역자 : ";
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(328, 201);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(67, 15);
            this.labelPublisher.TabIndex = 5;
            this.labelPublisher.Text = "출판사 : ";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(529, 29);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(82, 15);
            this.labelType.TabIndex = 6;
            this.labelType.Text = "자료형태 : ";
            // 
            // labelOriginnm
            // 
            this.labelOriginnm.AutoSize = true;
            this.labelOriginnm.Location = new System.Drawing.Point(529, 70);
            this.labelOriginnm.Name = "labelOriginnm";
            this.labelOriginnm.Size = new System.Drawing.Size(52, 15);
            this.labelOriginnm.TabIndex = 7;
            this.labelOriginnm.Text = "원저 : ";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Location = new System.Drawing.Point(529, 115);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 15);
            this.labelPublicationDate.TabIndex = 8;
            this.labelPublicationDate.Text = "출간일 : ";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(529, 158);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(52, 15);
            this.labelPrice.TabIndex = 9;
            this.labelPrice.Text = "가격 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "요약";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "목차";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Callnum,
            this.RentYN,
            this.ReservYN,
            this.RegDate,
            this.Location});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(30, 429);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(794, 213);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Callnum
            // 
            this.Callnum.Text = "청구번호";
            // 
            // RentYN
            // 
            this.RentYN.Text = "대여가능여부";
            // 
            // ReservYN
            // 
            this.ReservYN.Text = "예약가능여부";
            // 
            // RegDate
            // 
            this.RegDate.Text = "예약일";
            // 
            // Location
            // 
            this.Location.Text = "책 위치";
            // 
            // BookInfoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelPublicationDate);
            this.Controls.Add(this.labelOriginnm);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelPublisher);
            this.Controls.Add(this.labelTransrator);
            this.Controls.Add(this.labelWriter);
            this.Controls.Add(this.labelISBN);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BookInfoDetail";
            this.Size = new System.Drawing.Size(873, 677);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.Label labelWriter;
        private System.Windows.Forms.Label labelTransrator;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelOriginnm;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Callnum;
        private System.Windows.Forms.ColumnHeader RentYN;
        private System.Windows.Forms.ColumnHeader ReservYN;
        private System.Windows.Forms.ColumnHeader RegDate;
        private System.Windows.Forms.ColumnHeader Location;
    }
}
