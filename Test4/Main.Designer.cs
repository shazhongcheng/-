namespace Test4
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_OpenS = new System.Windows.Forms.Button();
            this.btn_OpenC = new System.Windows.Forms.Button();
            this.btn_Produce = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SNote = new System.Windows.Forms.TextBox();
            this.txt_SAllNum = new System.Windows.Forms.TextBox();
            this.txt_SAllPrice = new System.Windows.Forms.TextBox();
            this.txt_Sstand = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Cadd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SAllMoney = new System.Windows.Forms.TextBox();
            this.txt_SPriOne = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Sunit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Ctel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SSellNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Shop = new System.Windows.Forms.ComboBox();
            this.cb_Client = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_OpenS);
            this.splitContainer1.Panel1.Controls.Add(this.btn_OpenC);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Produce);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Update);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Del);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Add);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SNote);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SAllNum);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SAllPrice);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Sstand);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Cadd);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SAllMoney);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SPriOne);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Sunit);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Ctel);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SSellNum);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SName);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txt_CName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cb_Shop);
            this.splitContainer1.Panel1.Controls.Add(this.cb_Client);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 695);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_OpenS
            // 
            this.btn_OpenS.Location = new System.Drawing.Point(297, 430);
            this.btn_OpenS.Name = "btn_OpenS";
            this.btn_OpenS.Size = new System.Drawing.Size(104, 23);
            this.btn_OpenS.TabIndex = 9;
            this.btn_OpenS.Text = "打开调味品信息";
            this.btn_OpenS.UseVisualStyleBackColor = true;
            // 
            // btn_OpenC
            // 
            this.btn_OpenC.Location = new System.Drawing.Point(297, 378);
            this.btn_OpenC.Name = "btn_OpenC";
            this.btn_OpenC.Size = new System.Drawing.Size(89, 23);
            this.btn_OpenC.TabIndex = 8;
            this.btn_OpenC.Text = "打开客户信息";
            this.btn_OpenC.UseVisualStyleBackColor = true;
            this.btn_OpenC.Click += new System.EventHandler(this.btn_OpenC_Click);
            // 
            // btn_Produce
            // 
            this.btn_Produce.Location = new System.Drawing.Point(164, 430);
            this.btn_Produce.Name = "btn_Produce";
            this.btn_Produce.Size = new System.Drawing.Size(75, 23);
            this.btn_Produce.TabIndex = 7;
            this.btn_Produce.Text = "生成";
            this.btn_Produce.UseVisualStyleBackColor = true;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(52, 430);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "修改";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(164, 378);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 23);
            this.btn_Del.TabIndex = 5;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(52, 378);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "商品编号：";
            // 
            // txt_SNote
            // 
            this.txt_SNote.Location = new System.Drawing.Point(309, 305);
            this.txt_SNote.Name = "txt_SNote";
            this.txt_SNote.Size = new System.Drawing.Size(146, 21);
            this.txt_SNote.TabIndex = 3;
            // 
            // txt_SAllNum
            // 
            this.txt_SAllNum.Location = new System.Drawing.Point(309, 171);
            this.txt_SAllNum.Name = "txt_SAllNum";
            this.txt_SAllNum.Size = new System.Drawing.Size(146, 21);
            this.txt_SAllNum.TabIndex = 3;
            // 
            // txt_SAllPrice
            // 
            this.txt_SAllPrice.Location = new System.Drawing.Point(309, 220);
            this.txt_SAllPrice.Name = "txt_SAllPrice";
            this.txt_SAllPrice.Size = new System.Drawing.Size(146, 21);
            this.txt_SAllPrice.TabIndex = 3;
            // 
            // txt_Sstand
            // 
            this.txt_Sstand.Location = new System.Drawing.Point(309, 30);
            this.txt_Sstand.Name = "txt_Sstand";
            this.txt_Sstand.Size = new System.Drawing.Size(146, 21);
            this.txt_Sstand.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "每箱数量：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "备注：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "每箱金额：";
            // 
            // txt_Cadd
            // 
            this.txt_Cadd.Location = new System.Drawing.Point(81, 168);
            this.txt_Cadd.Name = "txt_Cadd";
            this.txt_Cadd.Size = new System.Drawing.Size(146, 21);
            this.txt_Cadd.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "规格：";
            // 
            // txt_SAllMoney
            // 
            this.txt_SAllMoney.Location = new System.Drawing.Point(309, 257);
            this.txt_SAllMoney.Name = "txt_SAllMoney";
            this.txt_SAllMoney.Size = new System.Drawing.Size(146, 21);
            this.txt_SAllMoney.TabIndex = 3;
            // 
            // txt_SPriOne
            // 
            this.txt_SPriOne.Location = new System.Drawing.Point(309, 127);
            this.txt_SPriOne.Name = "txt_SPriOne";
            this.txt_SPriOne.Size = new System.Drawing.Size(146, 21);
            this.txt_SPriOne.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "地址：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "总金额：";
            // 
            // txt_Sunit
            // 
            this.txt_Sunit.Location = new System.Drawing.Point(81, 302);
            this.txt_Sunit.Name = "txt_Sunit";
            this.txt_Sunit.Size = new System.Drawing.Size(146, 21);
            this.txt_Sunit.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "每袋金额：";
            // 
            // txt_Ctel
            // 
            this.txt_Ctel.Location = new System.Drawing.Point(81, 124);
            this.txt_Ctel.Name = "txt_Ctel";
            this.txt_Ctel.Size = new System.Drawing.Size(146, 21);
            this.txt_Ctel.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "单位：";
            // 
            // txt_SSellNum
            // 
            this.txt_SSellNum.Location = new System.Drawing.Point(309, 79);
            this.txt_SSellNum.Name = "txt_SSellNum";
            this.txt_SSellNum.Size = new System.Drawing.Size(146, 21);
            this.txt_SSellNum.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "电话：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(253, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "数量：";
            // 
            // txt_SName
            // 
            this.txt_SName.Location = new System.Drawing.Point(81, 257);
            this.txt_SName.Name = "txt_SName";
            this.txt_SName.Size = new System.Drawing.Size(146, 21);
            this.txt_SName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "品名：";
            // 
            // txt_CName
            // 
            this.txt_CName.Location = new System.Drawing.Point(81, 79);
            this.txt_CName.Name = "txt_CName";
            this.txt_CName.Size = new System.Drawing.Size(146, 21);
            this.txt_CName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "收货单位：";
            // 
            // cb_Shop
            // 
            this.cb_Shop.FormattingEnabled = true;
            this.cb_Shop.Location = new System.Drawing.Point(81, 217);
            this.cb_Shop.Name = "cb_Shop";
            this.cb_Shop.Size = new System.Drawing.Size(121, 20);
            this.cb_Shop.TabIndex = 1;
            // 
            // cb_Client
            // 
            this.cb_Client.FormattingEnabled = true;
            this.cb_Client.Location = new System.Drawing.Point(81, 36);
            this.cb_Client.Name = "cb_Client";
            this.cb_Client.Size = new System.Drawing.Size(121, 20);
            this.cb_Client.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户编号：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(770, 695);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 695);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SNote;
        private System.Windows.Forms.TextBox txt_SAllPrice;
        private System.Windows.Forms.TextBox txt_Sstand;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Cadd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SAllMoney;
        private System.Windows.Forms.TextBox txt_SPriOne;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Sunit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Ctel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SSellNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_SName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Shop;
        private System.Windows.Forms.ComboBox cb_Client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_SAllNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_OpenS;
        private System.Windows.Forms.Button btn_OpenC;
        private System.Windows.Forms.Button btn_Produce;
    }
}

