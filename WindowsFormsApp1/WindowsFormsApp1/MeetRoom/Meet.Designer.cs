
namespace WindowsFormsApp1.MeetRoom {
    partial class Meet {
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbINFO = new System.Windows.Forms.Label();
            this.lbMEMs = new System.Windows.Forms.Label();
            this.lbstcMAX = new System.Windows.Forms.Label();
            this.pbRoomImg = new System.Windows.Forms.PictureBox();
            this.lbRoomName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReserv = new System.Windows.Forms.DataGridView();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImg)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserv)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.dgvList);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(107, 363);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Location = new System.Drawing.Point(3, 3);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(104, 360);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lbINFO);
            this.panel1.Controls.Add(this.lbMEMs);
            this.panel1.Controls.Add(this.lbstcMAX);
            this.panel1.Controls.Add(this.pbRoomImg);
            this.panel1.Controls.Add(this.lbRoomName);
            this.panel1.Location = new System.Drawing.Point(128, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 362);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // lbINFO
            // 
            this.lbINFO.AutoSize = true;
            this.lbINFO.Location = new System.Drawing.Point(3, 309);
            this.lbINFO.Name = "lbINFO";
            this.lbINFO.Size = new System.Drawing.Size(38, 12);
            this.lbINFO.TabIndex = 4;
            this.lbINFO.Text = "label1";
            // 
            // lbMEMs
            // 
            this.lbMEMs.AutoSize = true;
            this.lbMEMs.Location = new System.Drawing.Point(231, 283);
            this.lbMEMs.Name = "lbMEMs";
            this.lbMEMs.Size = new System.Drawing.Size(38, 12);
            this.lbMEMs.TabIndex = 3;
            this.lbMEMs.Text = "label1";
            // 
            // lbstcMAX
            // 
            this.lbstcMAX.AutoSize = true;
            this.lbstcMAX.Location = new System.Drawing.Point(3, 283);
            this.lbstcMAX.Name = "lbstcMAX";
            this.lbstcMAX.Size = new System.Drawing.Size(38, 12);
            this.lbstcMAX.TabIndex = 2;
            this.lbstcMAX.Text = "label1";
            // 
            // pbRoomImg
            // 
            this.pbRoomImg.Location = new System.Drawing.Point(5, 33);
            this.pbRoomImg.Name = "pbRoomImg";
            this.pbRoomImg.Size = new System.Drawing.Size(333, 238);
            this.pbRoomImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRoomImg.TabIndex = 1;
            this.pbRoomImg.TabStop = false;
            // 
            // lbRoomName
            // 
            this.lbRoomName.AutoSize = true;
            this.lbRoomName.Location = new System.Drawing.Point(3, 2);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(38, 12);
            this.lbRoomName.TabIndex = 0;
            this.lbRoomName.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgvReserv);
            this.panel2.Controls.Add(this.dtp);
            this.panel2.Location = new System.Drawing.Point(477, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 363);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Check;
            this.pictureBox1.Location = new System.Drawing.Point(144, 332);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "사용 중 :";
            // 
            // dgvReserv
            // 
            this.dgvReserv.AllowUserToAddRows = false;
            this.dgvReserv.AllowUserToDeleteRows = false;
            this.dgvReserv.AllowUserToResizeColumns = false;
            this.dgvReserv.AllowUserToResizeRows = false;
            this.dgvReserv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReserv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReserv.ColumnHeadersVisible = false;
            this.dgvReserv.Location = new System.Drawing.Point(5, 30);
            this.dgvReserv.MultiSelect = false;
            this.dgvReserv.Name = "dgvReserv";
            this.dgvReserv.RowHeadersVisible = false;
            this.dgvReserv.RowTemplate.Height = 23;
            this.dgvReserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReserv.Size = new System.Drawing.Size(175, 299);
            this.dgvReserv.TabIndex = 1;
            this.dgvReserv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReserv_CellClick);
            // 
            // dtp
            // 
            this.dtp.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtp.Location = new System.Drawing.Point(0, 0);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(186, 21);
            this.dtp.TabIndex = 0;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // Meet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Meet";
            this.Size = new System.Drawing.Size(736, 402);
            this.Load += new System.EventHandler(this.Meet_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbRoomImg;
        private System.Windows.Forms.Label lbRoomName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbINFO;
        private System.Windows.Forms.Label lbMEMs;
        private System.Windows.Forms.Label lbstcMAX;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DataGridView dgvReserv;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
