using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{


    public partial class Form2 : Form
    {
        public static string ProductIsbn
        {
            get;
            set;
        }
        public static string ProductCount
        {
            get;
            set;
        }
        SqlProduct sql = new SqlProduct();
       public string str;

        private void Form2_Load(object sender, EventArgs e)
        {
            string idValue = LoginForm.idValue;
            
        }


        public Form2()
        {

           
            InitializeComponent();
            dataGridView1.DataSource = sql.Query_Select(1).DataSource;
            dataGridView1.DataMember = "TB_PRODUCT";



        }
        




        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
           
            try
            {
      
                textBox_ProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox_Size.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox_Color.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_Cigar.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                int stockNum = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                comboBox_Count.Items.Clear();
                string[] data = new string[stockNum];
                
                for (int i = 0;i< stockNum; i++)
                {//재고 숫자 만큼 comboBox에 표시
                    data[i] = (i+1).ToString();
                }
                comboBox_Count.Items.AddRange(data);
                comboBox_Count.SelectedIndex = 0;


            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//구매하기
            ProductIsbn = sql.Query_Select_DataSet("WHERE Product_Name = '" + textBox_ProductName.Text + "' AND " + "Color = '" +
                      textBox_Color.Text + "' AND Size = '" + textBox_Size.Text + "'").Tables[0].Rows[0]["Isbn"].ToString();
            ProductCount = comboBox_Count.SelectedItem as String;
            Form4 showForm4 = new Form4(); 
            showForm4.label_ProductName.Text = textBox_ProductName.Text;
            showForm4.label_Size.Text = textBox_Size.Text;
            showForm4.label_Color.Text = textBox_Color.Text;
            showForm4.ShowDialog();
            dataGridView1.DataSource = sql.Query_Select(1).DataSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void 회원ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 showForm5 = new Form5();
            showForm5.ShowDialog();
        }
        private void 나의정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyInformationForm MyForom = new MyInformationForm();
            MyForom.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm showForm1 = new LoginForm();
            showForm1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {//이미지 보기
            groupBox3.Visible = true;
            ProductIsbn = sql.Query_Select_DataSet("WHERE Product_Name = '" + textBox_ProductName.Text + "' AND " + "Color = '" +textBox_Color.Text + "' AND Size = '" + textBox_Size.Text + "'").Tables[0].Rows[0]["Isbn"].ToString();
            //if (sql.Query_Select_Bool("Isbn = " + ProductIsbn)) {
                DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = " + ProductIsbn);
                label11.Text = textBox_ProductName.Text;
                label12.Text = textBox_Size.Text;
                label13.Text = textBox_Cigar.Text;
                label14.Text = textBox_Color.Text;
                int stockNum = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                comboBox1.Items.Clear();
                string[] data = new string[stockNum];

                for (int i = 0; i < stockNum; i++)
                {//재고 숫자 만큼 comboBox에 표시
                    data[i] = (i + 1).ToString();
                }
                comboBox1.Items.AddRange(data);
                comboBox1.SelectedIndex = 0;
                string ImgName = ds.Tables[0].Rows[0]["Img_Name1"].ToString();
                string ExplanationStr = ds.Tables[0].Rows[0]["Explanation"].ToString();
                string ImgSize = ds.Tables[0].Rows[0]["Img_Size"].ToString();
                //label_ProductName.Text = textBox_ProductName.Text;
                //label_Cigar.Text = textBox_Cigar.Text + "원";

                pictureBox.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgName);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;//이미지 알맞게 배치 하도록함
                pictureBox1.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgSize);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//이미지 알맞게 배치 하도록함
                label_Explanation.Text = "";
                string[] val = ExplanationStr.Split(new string[] { "\\n" }, StringSplitOptions.None);
                for (int i = 0; i < val.Length; i++)
                {
                    label_Explanation.Text += val[i] + Environment.NewLine;
                }
                if (ds.Tables[0].Rows[0]["Img_Name2"].ToString().Equals("")){
                // MessageBox.Show("없는 테이블 입니다.");
                pictureBox2.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    string ImgName2 = ds.Tables[0].Rows[0]["Img_Name2"].ToString();
                    pictureBox2.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgName2);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;//이미지 알맞게 배치 하도록함
                }
            //}else
            //{
            //    MessageBox.Show("없는 테이블 입니다.");
            //}
        }
       
            private void button_Back_Click(object sender, EventArgs e)
        {//뒤로가기
         //string s = richTextBox1.Text;
         //label_Explanation.Text = s;
            groupBox3.Visible = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {//구매
            ProductIsbn = sql.Query_Select_DataSet("WHERE Product_Name = '" + textBox_ProductName.Text + "' AND " + "Color = '" +
                     textBox_Color.Text + "' AND Size = '" + textBox_Size.Text + "'").Tables[0].Rows[0]["Isbn"].ToString();
            ProductCount = comboBox1.SelectedItem as String;
            Form4 showForm4 = new Form4();
            showForm4.label_ProductName.Text = textBox_ProductName.Text;
            showForm4.label_Size.Text = textBox_Size.Text;
            showForm4.label_Color.Text = textBox_Color.Text;
            showForm4.ShowDialog();
            dataGridView1.DataSource = sql.Query_Select(1).DataSource;
        }

       
    }
}
