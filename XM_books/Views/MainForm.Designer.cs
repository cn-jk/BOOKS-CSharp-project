namespace XM_books.Views
{
    partial class MainForm
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbJunrs = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_VsegoStrokTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_VsegoStrokNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_NomerTekuscheyStrokiTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_NomerTekuscheyStrokiNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 120);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.OliveDrab;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Controls.Add(this.cmbJunrs);
            this.panel5.Location = new System.Drawing.Point(78, 34);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(986, 48);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkKhaki;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(14, 8, 0, 8);
            this.label1.Size = new System.Drawing.Size(96, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Жанр:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Khaki;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(826, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 48);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Искать";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(480, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(376, 44);
            this.txtSearch.TabIndex = 1;
            // 
            // cmbJunrs
            // 
            this.cmbJunrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbJunrs.FormattingEnabled = true;
            this.cmbJunrs.ItemHeight = 32;
            this.cmbJunrs.Location = new System.Drawing.Point(96, 0);
            this.cmbJunrs.Margin = new System.Windows.Forms.Padding(0);
            this.cmbJunrs.MinimumSize = new System.Drawing.Size(258, 0);
            this.cmbJunrs.Name = "cmbJunrs";
            this.cmbJunrs.Size = new System.Drawing.Size(258, 40);
            this.cmbJunrs.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OliveDrab;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvBooks);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Margin = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.panel2.Size = new System.Drawing.Size(1144, 502);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.OliveDrab;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Location = new System.Drawing.Point(0, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1144, 125);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.btnDel);
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnAddNew);
            this.panel4.Location = new System.Drawing.Point(78, 35);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(986, 48);
            this.panel4.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Khaki;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(825, 0);
            this.btnExit.MinimumSize = new System.Drawing.Size(22, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 48);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Выйти";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Khaki;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(592, 0);
            this.btnDel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDel.MaximumSize = new System.Drawing.Size(220, 48);
            this.btnDel.MinimumSize = new System.Drawing.Size(22, 48);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(180, 48);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "&Удалить";
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Khaki;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(254, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.MinimumSize = new System.Drawing.Size(22, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(280, 48);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Редактировать";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Khaki;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(0, 0);
            this.btnAddNew.MaximumSize = new System.Drawing.Size(220, 48);
            this.btnAddNew.MinimumSize = new System.Drawing.Size(22, 48);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(200, 48);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "&Добавить";
            this.btnAddNew.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_VsegoStrokTxt,
            this.status_VsegoStrokNum,
            this.status_NomerTekuscheyStrokiTxt,
            this.status_NomerTekuscheyStrokiNum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 86);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1144, 39);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_VsegoStrokTxt
            // 
            this.status_VsegoStrokTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_VsegoStrokTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.status_VsegoStrokTxt.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.status_VsegoStrokTxt.Name = "status_VsegoStrokTxt";
            this.status_VsegoStrokTxt.Size = new System.Drawing.Size(169, 39);
            this.status_VsegoStrokTxt.Text = "ВСЕГО СТРОК:";
            this.status_VsegoStrokTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // status_VsegoStrokNum
            // 
            this.status_VsegoStrokNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_VsegoStrokNum.Name = "status_VsegoStrokNum";
            this.status_VsegoStrokNum.Size = new System.Drawing.Size(27, 32);
            this.status_VsegoStrokNum.Text = "0";
            this.status_VsegoStrokNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // status_NomerTekuscheyStrokiTxt
            // 
            this.status_NomerTekuscheyStrokiTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_NomerTekuscheyStrokiTxt.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.status_NomerTekuscheyStrokiTxt.Name = "status_NomerTekuscheyStrokiTxt";
            this.status_NomerTekuscheyStrokiTxt.Size = new System.Drawing.Size(313, 39);
            this.status_NomerTekuscheyStrokiTxt.Text = "НОМЕР ТЕКУЩЕЙ СТРОКИ:";
            this.status_NomerTekuscheyStrokiTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // status_NomerTekuscheyStrokiNum
            // 
            this.status_NomerTekuscheyStrokiNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_NomerTekuscheyStrokiNum.Margin = new System.Windows.Forms.Padding(0);
            this.status_NomerTekuscheyStrokiNum.Name = "status_NomerTekuscheyStrokiNum";
            this.status_NomerTekuscheyStrokiNum.Size = new System.Drawing.Size(27, 39);
            this.status_NomerTekuscheyStrokiNum.Text = "1";
            this.status_NomerTekuscheyStrokiNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(80, 0);
            this.dgvBooks.Margin = new System.Windows.Forms.Padding(0);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 62;
            this.dgvBooks.RowTemplate.Height = 28;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(984, 380);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.SelectionChanged += new System.EventHandler(this.dgvBooks_SelectionChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1144, 622);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1158, 651);
            this.Name = "MainForm";
            this.Text = "КНИГИ/BOOKS";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbJunrs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel status_VsegoStrokTxt;
        private System.Windows.Forms.ToolStripStatusLabel status_VsegoStrokNum;
        private System.Windows.Forms.ToolStripStatusLabel status_NomerTekuscheyStrokiTxt;
        private System.Windows.Forms.ToolStripStatusLabel status_NomerTekuscheyStrokiNum;
    }
}