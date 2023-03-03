namespace BTL
{
    partial class fProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLoad1 = new System.Windows.Forms.Button();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.btnEdit1 = new System.Windows.Forms.Button();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIDDM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtNameSP = new System.Windows.Forms.TextBox();
            this.txtIDSP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 637);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 8);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(527, 617);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.btnLoad1);
            this.panel4.Controls.Add(this.btnAdd1);
            this.panel4.Controls.Add(this.btnEdit1);
            this.panel4.Controls.Add(this.btnDelete1);
            this.panel4.Location = new System.Drawing.Point(570, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 183);
            this.panel4.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(115, 120);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(283, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // btnLoad1
            // 
            this.btnLoad1.Image = global::BTL.Properties.Resources.Button_Reload_icon;
            this.btnLoad1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad1.Location = new System.Drawing.Point(321, 27);
            this.btnLoad1.Name = "btnLoad1";
            this.btnLoad1.Size = new System.Drawing.Size(75, 60);
            this.btnLoad1.TabIndex = 5;
            this.btnLoad1.Text = "Load";
            this.btnLoad1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoad1.UseVisualStyleBackColor = true;
            this.btnLoad1.Click += new System.EventHandler(this.btnLoad1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::BTL.Properties.Resources.add_icon;
            this.btnAdd1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd1.Location = new System.Drawing.Point(18, 27);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(75, 60);
            this.btnAdd1.TabIndex = 2;
            this.btnAdd1.Text = "Thêm";
            this.btnAdd1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnEdit1
            // 
            this.btnEdit1.Image = global::BTL.Properties.Resources.Pencil_1_icon;
            this.btnEdit1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit1.Location = new System.Drawing.Point(220, 27);
            this.btnEdit1.Name = "btnEdit1";
            this.btnEdit1.Size = new System.Drawing.Size(75, 60);
            this.btnEdit1.TabIndex = 4;
            this.btnEdit1.Text = "Sửa";
            this.btnEdit1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit1.UseVisualStyleBackColor = true;
            this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::BTL.Properties.Resources.Symbols_Delete_icon;
            this.btnDelete1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete1.Location = new System.Drawing.Point(120, 27);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(75, 60);
            this.btnDelete1.TabIndex = 3;
            this.btnDelete1.Text = "Xóa";
            this.btnDelete1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtIDDM);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtAmount);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtprice);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.txtNameSP);
            this.panel3.Controls.Add(this.txtIDSP);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(570, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 282);
            this.panel3.TabIndex = 4;
            // 
            // txtIDDM
            // 
            this.txtIDDM.Location = new System.Drawing.Point(115, 250);
            this.txtIDDM.Name = "txtIDDM";
            this.txtIDDM.Size = new System.Drawing.Size(283, 20);
            this.txtIDDM.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "ID Danh mục:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(115, 213);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(283, 20);
            this.txtAmount.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Số lượng:";
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(115, 169);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(283, 20);
            this.txtprice.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // txtNameSP
            // 
            this.txtNameSP.Location = new System.Drawing.Point(115, 66);
            this.txtNameSP.Name = "txtNameSP";
            this.txtNameSP.Size = new System.Drawing.Size(283, 20);
            this.txtNameSP.TabIndex = 9;
            // 
            // txtIDSP
            // 
            this.txtIDSP.Location = new System.Drawing.Point(115, 22);
            this.txtIDSP.Name = "txtIDSP";
            this.txtIDSP.Size = new System.Drawing.Size(283, 20);
            this.txtIDSP.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Giá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Danh Mục:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên Sản Phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID SP:";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::BTL.Properties.Resources.search_icon__3_;
            this.btnSearch.Location = new System.Drawing.Point(34, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 60);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1058, 644);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "fProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản Phẩm";
            this.Load += new System.EventHandler(this.fProduct_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnEdit1;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtNameSP;
        private System.Windows.Forms.TextBox txtIDSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDDM;
        private System.Windows.Forms.Label label2;
    }
}