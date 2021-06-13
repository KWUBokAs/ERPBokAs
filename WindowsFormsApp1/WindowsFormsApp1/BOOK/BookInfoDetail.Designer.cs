
namespace WindowsFormsApp1.BOOK
{
    partial class BookInfoDetail
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
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPublicationDate = new System.Windows.Forms.Label();
            this.lblOriginnm = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblTransrator = new System.Windows.Forms.Label();
            this.lblWriter = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtIndexList = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(56, 375);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(37, 15);
            this.lblIndex.TabIndex = 24;
            this.lblIndex.Text = "목차";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(56, 284);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(37, 15);
            this.lblSummary.TabIndex = 23;
            this.lblSummary.Text = "요약";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(635, 228);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 15);
            this.lblPrice.TabIndex = 22;
            this.lblPrice.Text = "가격 : ";
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Location = new System.Drawing.Point(635, 184);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(67, 15);
            this.lblPublicationDate.TabIndex = 21;
            this.lblPublicationDate.Text = "출간일 : ";
            // 
            // lblOriginnm
            // 
            this.lblOriginnm.AutoSize = true;
            this.lblOriginnm.Location = new System.Drawing.Point(635, 141);
            this.lblOriginnm.Name = "lblOriginnm";
            this.lblOriginnm.Size = new System.Drawing.Size(52, 15);
            this.lblOriginnm.TabIndex = 20;
            this.lblOriginnm.Text = "원저 : ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(635, 96);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(82, 15);
            this.lblType.TabIndex = 19;
            this.lblType.Text = "자료형태 : ";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(357, 228);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(67, 15);
            this.lblPublisher.TabIndex = 18;
            this.lblPublisher.Text = "출판사 : ";
            // 
            // lblTransrator
            // 
            this.lblTransrator.AutoSize = true;
            this.lblTransrator.Location = new System.Drawing.Point(357, 184);
            this.lblTransrator.Name = "lblTransrator";
            this.lblTransrator.Size = new System.Drawing.Size(52, 15);
            this.lblTransrator.TabIndex = 17;
            this.lblTransrator.Text = "역자 : ";
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(357, 141);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(52, 15);
            this.lblWriter.TabIndex = 16;
            this.lblWriter.Text = "저자 : ";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(357, 96);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(54, 15);
            this.lblISBN.TabIndex = 15;
            this.lblISBN.Text = "ISBN : ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(357, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "서명 : ";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToResizeColumns = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBooks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvBooks.ColumnHeadersHeight = 29;
            this.dgvBooks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBooks.Location = new System.Drawing.Point(58, 495);
            this.dgvBooks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 23;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(811, 198);
            this.dgvBooks.TabIndex = 26;
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(58, 729);
            this.btnRent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(86, 29);
            this.btnRent.TabIndex = 27;
            this.btnRent.Text = "대출";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(173, 729);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(86, 29);
            this.btnReturn.TabIndex = 28;
            this.btnReturn.Text = "반납";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(288, 729);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 29);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(408, 729);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 29);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(58, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 218);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(770, 270);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(99, 29);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "책 정보 수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtIndexList
            // 
            this.txtIndexList.Location = new System.Drawing.Point(58, 394);
            this.txtIndexList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIndexList.Multiline = true;
            this.txtIndexList.Name = "txtIndexList";
            this.txtIndexList.ReadOnly = true;
            this.txtIndexList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIndexList.Size = new System.Drawing.Size(811, 93);
            this.txtIndexList.TabIndex = 32;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(58, 302);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSummary.Size = new System.Drawing.Size(811, 68);
            this.txtSummary.TabIndex = 33;
            // 
            // BookInfoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 808);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtIndexList);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.lblOriginnm);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.lblTransrator);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookInfoDetail";
            this.Text = "책 세부정보";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPublicationDate;
        private System.Windows.Forms.Label lblOriginnm;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblTransrator;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtIndexList;
        private System.Windows.Forms.TextBox txtSummary;
    }
}