namespace WindowsFormsApp1
{
    partial class PurchaseForm
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
            this.label_price = new System.Windows.Forms.Label();
            this.label_product_name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Explanation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.comboBox_count = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_colorSize = new System.Windows.Forms.ComboBox();
            this.groupBox_purchase = new System.Windows.Forms.GroupBox();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.textBox_tel2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_tel1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.label_purchase_count = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_user_name = new System.Windows.Forms.TextBox();
            this.textBox__user_memo = new System.Windows.Forms.TextBox();
            this.textBox__user_address = new System.Windows.Forms.TextBox();
            this.label_purchase_color = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_purchase_addres = new System.Windows.Forms.Label();
            this.label_purchase_total = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_purchase_cigar = new System.Windows.Forms.Label();
            this.label_purchase_size = new System.Windows.Forms.Label();
            this.label_purchase_name = new System.Windows.Forms.Label();
            this.button_buy_it = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox_purchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Location = new System.Drawing.Point(619, 61);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(66, 12);
            this.label_price.TabIndex = 44;
            this.label_price.Text = "label_price";
            // 
            // label_product_name
            // 
            this.label_product_name.AutoSize = true;
            this.label_product_name.Location = new System.Drawing.Point(619, 22);
            this.label_product_name.Name = "label_product_name";
            this.label_product_name.Size = new System.Drawing.Size(118, 12);
            this.label_product_name.TabIndex = 42;
            this.label_product_name.Text = "label_product_name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "색상 사이즈";
            // 
            // label_Explanation
            // 
            this.label_Explanation.AutoSize = true;
            this.label_Explanation.Location = new System.Drawing.Point(9, 231);
            this.label_Explanation.MinimumSize = new System.Drawing.Size(385, 40);
            this.label_Explanation.Name = "label_Explanation";
            this.label_Explanation.Size = new System.Drawing.Size(385, 40);
            this.label_Explanation.TabIndex = 40;
            this.label_Explanation.Text = "설명문";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "개수";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(576, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "금액";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(810, 472);
            this.button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(74, 30);
            this.button.TabIndex = 34;
            this.button.Text = "구매하기";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(933, 472);
            this.button_Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(74, 30);
            this.button_Back.TabIndex = 33;
            this.button_Back.Text = "뒤로가기";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // comboBox_count
            // 
            this.comboBox_count.FormattingEnabled = true;
            this.comboBox_count.Location = new System.Drawing.Point(621, 131);
            this.comboBox_count.Name = "comboBox_count";
            this.comboBox_count.Size = new System.Drawing.Size(167, 20);
            this.comboBox_count.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "상품명";
            // 
            // comboBox_colorSize
            // 
            this.comboBox_colorSize.FormattingEnabled = true;
            this.comboBox_colorSize.Location = new System.Drawing.Point(621, 94);
            this.comboBox_colorSize.Name = "comboBox_colorSize";
            this.comboBox_colorSize.Size = new System.Drawing.Size(167, 20);
            this.comboBox_colorSize.TabIndex = 52;
            this.comboBox_colorSize.SelectedIndexChanged += new System.EventHandler(this.comboBox_colorSize_SelectedIndexChanged);
            // 
            // groupBox_purchase
            // 
            this.groupBox_purchase.Controls.Add(this.textBox_tel);
            this.groupBox_purchase.Controls.Add(this.textBox_tel2);
            this.groupBox_purchase.Controls.Add(this.label19);
            this.groupBox_purchase.Controls.Add(this.textBox_tel1);
            this.groupBox_purchase.Controls.Add(this.label20);
            this.groupBox_purchase.Controls.Add(this.button_close);
            this.groupBox_purchase.Controls.Add(this.label_purchase_count);
            this.groupBox_purchase.Controls.Add(this.label14);
            this.groupBox_purchase.Controls.Add(this.textBox_user_name);
            this.groupBox_purchase.Controls.Add(this.textBox__user_memo);
            this.groupBox_purchase.Controls.Add(this.textBox__user_address);
            this.groupBox_purchase.Controls.Add(this.label_purchase_color);
            this.groupBox_purchase.Controls.Add(this.label13);
            this.groupBox_purchase.Controls.Add(this.label_purchase_addres);
            this.groupBox_purchase.Controls.Add(this.label_purchase_total);
            this.groupBox_purchase.Controls.Add(this.label18);
            this.groupBox_purchase.Controls.Add(this.label_purchase_cigar);
            this.groupBox_purchase.Controls.Add(this.label_purchase_size);
            this.groupBox_purchase.Controls.Add(this.label_purchase_name);
            this.groupBox_purchase.Controls.Add(this.button_buy_it);
            this.groupBox_purchase.Controls.Add(this.label11);
            this.groupBox_purchase.Controls.Add(this.label1);
            this.groupBox_purchase.Controls.Add(this.label9);
            this.groupBox_purchase.Controls.Add(this.label2);
            this.groupBox_purchase.Controls.Add(this.label3);
            this.groupBox_purchase.Controls.Add(this.label4);
            this.groupBox_purchase.Controls.Add(this.label5);
            this.groupBox_purchase.Controls.Add(this.label12);
            this.groupBox_purchase.Controls.Add(this.label15);
            this.groupBox_purchase.Controls.Add(this.label16);
            this.groupBox_purchase.Controls.Add(this.label17);
            this.groupBox_purchase.Location = new System.Drawing.Point(317, 94);
            this.groupBox_purchase.Name = "groupBox_purchase";
            this.groupBox_purchase.Size = new System.Drawing.Size(390, 454);
            this.groupBox_purchase.TabIndex = 53;
            this.groupBox_purchase.TabStop = false;
            this.groupBox_purchase.Text = "결제 창";
            this.groupBox_purchase.Visible = false;
            // 
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(118, 250);
            this.textBox_tel.MaxLength = 4;
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(44, 21);
            this.textBox_tel.TabIndex = 61;
            // 
            // textBox_tel2
            // 
            this.textBox_tel2.Location = new System.Drawing.Point(265, 250);
            this.textBox_tel2.MaxLength = 4;
            this.textBox_tel2.Name = "textBox_tel2";
            this.textBox_tel2.Size = new System.Drawing.Size(44, 21);
            this.textBox_tel2.TabIndex = 56;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 10F);
            this.label19.Location = new System.Drawing.Point(244, 255);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 14);
            this.label19.TabIndex = 60;
            this.label19.Text = "-";
            // 
            // textBox_tel1
            // 
            this.textBox_tel1.Location = new System.Drawing.Point(197, 250);
            this.textBox_tel1.MaxLength = 4;
            this.textBox_tel1.Name = "textBox_tel1";
            this.textBox_tel1.Size = new System.Drawing.Size(44, 21);
            this.textBox_tel1.TabIndex = 57;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 10F);
            this.label20.Location = new System.Drawing.Point(176, 255);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 14);
            this.label20.TabIndex = 59;
            this.label20.Text = "-";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(211, 374);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 31;
            this.button_close.Text = "취소";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label_purchase_count
            // 
            this.label_purchase_count.AutoSize = true;
            this.label_purchase_count.Location = new System.Drawing.Point(116, 108);
            this.label_purchase_count.Name = "label_purchase_count";
            this.label_purchase_count.Size = new System.Drawing.Size(29, 12);
            this.label_purchase_count.TabIndex = 30;
            this.label_purchase_count.Text = "수량";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "수량";
            // 
            // textBox_user_name
            // 
            this.textBox_user_name.Location = new System.Drawing.Point(117, 224);
            this.textBox_user_name.Name = "textBox_user_name";
            this.textBox_user_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_user_name.TabIndex = 27;
            // 
            // textBox__user_memo
            // 
            this.textBox__user_memo.Location = new System.Drawing.Point(117, 311);
            this.textBox__user_memo.Name = "textBox__user_memo";
            this.textBox__user_memo.Size = new System.Drawing.Size(100, 21);
            this.textBox__user_memo.TabIndex = 26;
            // 
            // textBox__user_address
            // 
            this.textBox__user_address.Location = new System.Drawing.Point(117, 283);
            this.textBox__user_address.Name = "textBox__user_address";
            this.textBox__user_address.Size = new System.Drawing.Size(100, 21);
            this.textBox__user_address.TabIndex = 25;
            // 
            // label_purchase_color
            // 
            this.label_purchase_color.AutoSize = true;
            this.label_purchase_color.Location = new System.Drawing.Point(116, 82);
            this.label_purchase_color.Name = "label_purchase_color";
            this.label_purchase_color.Size = new System.Drawing.Size(17, 12);
            this.label_purchase_color.TabIndex = 23;
            this.label_purchase_color.Text = "색";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "색깔";
            // 
            // label_purchase_addres
            // 
            this.label_purchase_addres.AutoSize = true;
            this.label_purchase_addres.Location = new System.Drawing.Point(114, 207);
            this.label_purchase_addres.Name = "label_purchase_addres";
            this.label_purchase_addres.Size = new System.Drawing.Size(69, 12);
            this.label_purchase_addres.TabIndex = 17;
            this.label_purchase_addres.Text = "배송지 정보";
            // 
            // label_purchase_total
            // 
            this.label_purchase_total.AutoSize = true;
            this.label_purchase_total.Location = new System.Drawing.Point(114, 182);
            this.label_purchase_total.Name = "label_purchase_total";
            this.label_purchase_total.Size = new System.Drawing.Size(73, 12);
            this.label_purchase_total.TabIndex = 16;
            this.label_purchase_total.Text = "총 결제 금액";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(114, 156);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "2500";
            // 
            // label_purchase_cigar
            // 
            this.label_purchase_cigar.AutoSize = true;
            this.label_purchase_cigar.Location = new System.Drawing.Point(114, 131);
            this.label_purchase_cigar.Name = "label_purchase_cigar";
            this.label_purchase_cigar.Size = new System.Drawing.Size(73, 12);
            this.label_purchase_cigar.TabIndex = 14;
            this.label_purchase_cigar.Text = "총 상품 금액";
            // 
            // label_purchase_size
            // 
            this.label_purchase_size.AutoSize = true;
            this.label_purchase_size.Location = new System.Drawing.Point(114, 55);
            this.label_purchase_size.Name = "label_purchase_size";
            this.label_purchase_size.Size = new System.Drawing.Size(41, 12);
            this.label_purchase_size.TabIndex = 13;
            this.label_purchase_size.Text = "사이즈";
            // 
            // label_purchase_name
            // 
            this.label_purchase_name.AutoSize = true;
            this.label_purchase_name.Location = new System.Drawing.Point(114, 28);
            this.label_purchase_name.Name = "label_purchase_name";
            this.label_purchase_name.Size = new System.Drawing.Size(45, 12);
            this.label_purchase_name.TabIndex = 12;
            this.label_purchase_name.Text = "상품명 ";
            // 
            // button_buy_it
            // 
            this.button_buy_it.Location = new System.Drawing.Point(131, 374);
            this.button_buy_it.Name = "button_buy_it";
            this.button_buy_it.Size = new System.Drawing.Size(75, 23);
            this.button_buy_it.TabIndex = 11;
            this.button_buy_it.Text = "결제하기";
            this.button_buy_it.UseVisualStyleBackColor = true;
            this.button_buy_it.Click += new System.EventHandler(this.button_buy_it_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "배송 메모";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "주소";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "수령인";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "휴대폰 번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "배송지 정보";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "총 결제 금액";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "배송비";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "상품 금액";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "사이즈";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "상품명 ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(279, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 215);
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.티셔츠_사이즈;
            this.pictureBox1.Location = new System.Drawing.Point(10, 341);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(10, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(243, 215);
            this.pictureBox.TabIndex = 31;
            this.pictureBox.TabStop = false;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 673);
            this.Controls.Add(this.groupBox_purchase);
            this.Controls.Add(this.comboBox_colorSize);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.label_product_name);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_Explanation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.comboBox_count);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PurchaseForm";
            this.Text = "Purchase";
            this.groupBox_purchase.ResumeLayout(false);
            this.groupBox_purchase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.Label label_product_name;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Explanation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button_Back;
        public System.Windows.Forms.ComboBox comboBox_count;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox comboBox_colorSize;
        private System.Windows.Forms.GroupBox groupBox_purchase;
        public System.Windows.Forms.Label label_purchase_count;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_user_name;
        private System.Windows.Forms.TextBox textBox__user_memo;
        private System.Windows.Forms.TextBox textBox__user_address;
        public System.Windows.Forms.Label label_purchase_color;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label_purchase_addres;
        private System.Windows.Forms.Label label_purchase_total;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label_purchase_cigar;
        public System.Windows.Forms.Label label_purchase_size;
        public System.Windows.Forms.Label label_purchase_name;
        private System.Windows.Forms.Button button_buy_it;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox textBox_tel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_tel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_tel;
    }
}