
namespace WindowsFormsApp1
{
    partial class Meet
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbRoomName = new System.Windows.Forms.Label();
            this.pbRoomImg = new System.Windows.Forms.PictureBox();
            this.lbstcMAX = new System.Windows.Forms.Label();
            this.lbMEMs = new System.Windows.Forms.Label();
            this.lbINFO = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImg)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgvList);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 363);
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
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvList.Location = new System.Drawing.Point(3, 3);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(141, 360);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbINFO);
            this.panel1.Controls.Add(this.lbMEMs);
            this.panel1.Controls.Add(this.lbstcMAX);
            this.panel1.Controls.Add(this.pbRoomImg);
            this.panel1.Controls.Add(this.lbRoomName);
            this.panel1.Location = new System.Drawing.Point(189, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 362);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(648, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 363);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
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
            // pbRoomImg
            // 
            this.pbRoomImg.Location = new System.Drawing.Point(5, 33);
            this.pbRoomImg.Name = "pbRoomImg";
            this.pbRoomImg.Size = new System.Drawing.Size(333, 238);
            this.pbRoomImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRoomImg.TabIndex = 1;
            this.pbRoomImg.TabStop = false;
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
            // lbMEMs
            // 
            this.lbMEMs.AutoSize = true;
            this.lbMEMs.Location = new System.Drawing.Point(231, 283);
            this.lbMEMs.Name = "lbMEMs";
            this.lbMEMs.Size = new System.Drawing.Size(38, 12);
            this.lbMEMs.TabIndex = 3;
            this.lbMEMs.Text = "label1";
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
            // Meet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Meet";
            this.Size = new System.Drawing.Size(881, 402);
            this.Load += new System.EventHandler(this.Meet_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImg)).EndInit();
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
    }
}
