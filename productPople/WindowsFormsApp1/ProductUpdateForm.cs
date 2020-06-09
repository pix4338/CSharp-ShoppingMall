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
    public partial class ProductUpdateForm : Form
    {
        SqlProduct sql = new SqlProduct();
        public ProductUpdateForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = sql.Query_Select(3).DataSource;
            dataGridView1.DataMember = "TB_PRODUCT";
            string[] category = { "상의", "하의", "악세사리", "신발" };
            comboBox1.Items.AddRange(category);
            comboBox1.SelectedIndex = 0;

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                label_Isbn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox_Product_Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_Color.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                label_Stock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                label_Originalprice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                label_Cigar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox_ProductImg1.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox_ProductImg2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                textBox_SizImg.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                string rich = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                string category = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string siz = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                switch (siz)
                {
                    case "S":
                        radioButton1.Checked = true;
                        break;
                    case "M":
                        radioButton2.Checked = true;
                        break;
                    case "L":
                        radioButton3.Checked = true;
                        break;
                }

                switch (category)
                {
                    case "상의":
                        comboBox1.SelectedIndex = 0;
                        break;
                    case "하의":
                        comboBox1.SelectedIndex = 1;
                        break;
                    case "악세사리":
                        comboBox1.SelectedIndex = 2;
                        break;
                    case "신발":
                        comboBox1.SelectedIndex = 3;
                        break;
                }
                richTextBox1.Text = "";
                string[] val = rich.Split(new string[] { "\\n" }, StringSplitOptions.None);
                for (int i = 0; i < val.Length; i++)
                {
                    richTextBox1.Text += val[i] + Environment.NewLine;
                }
                pictureBox_img2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
                if (textBox_ProductImg1.Text != "")
                {
                    pictureBox_img1.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + textBox_ProductImg1.Text);
                }

                if (textBox_ProductImg2.Text != "")
                {
                    pictureBox_img2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + textBox_ProductImg2.Text);
                }
                if (textBox_SizImg.Text != "")
                {
                    pictureBox_img3.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + textBox_SizImg.Text);
                }
            }
            catch (Exception)
            {

            }
           

        }
        private void button_ImgAdd1_Click(object sender, EventArgs e)
        {
            //이미지 추가
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {//openFileDialog1.ShowDialog화면에 띄운다
                 //  openFileDialog1 실행 OK눌렀다면IF 문으로 들어옴
                    pictureBox_img1.Image = Image.FromFile(openFileDialog1.FileName);//파일 명(경로)
                    textBox_ProductImg1.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK);
            }
        }

    

        private void button_ImgAdd3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {//openFileDialog1.ShowDialog화면에 띄운다
                 //  openFileDialog1 실행 OK눌렀다면IF 문으로 들어옴
                    pictureBox_img3.Image = Image.FromFile(openFileDialog1.FileName);//파일 명(경로)
                    textBox_SizImg.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK);
            }

        }

        private void button_ImgAdd2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {//openFileDialog1.ShowDialog화면에 띄운다
                 //  openFileDialog1 실행 OK눌렀다면IF 문으로 들어옴
                    pictureBox_img2.Image = Image.FromFile(openFileDialog1.FileName);//파일 명(경로)
                    textBox_ProductImg2.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//수정 버튼
         //label_Isbn변경 
            if (MessageBox.Show("수정하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (sql.Query_Select_Bool("Isbn = '" + label_Isbn.Text + "'"))
                {

                    string sizStr = "";
                    bool sizB = false;
                    string message = "";
                    if (radioButton1.Checked == true)
                    {//사이즈
                        sizStr = "S";
                        sizB = true;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        sizStr = "M";
                        sizB = true;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        sizStr = "L";
                        sizB = true;
                    }
                    if (sizB)
                    {

                        string categoryStr = comboBox1.SelectedItem as String;
                        DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = '" + label_Isbn.Text + "'");
                        string rich = richTextBox1.Text;
                        string rich2 = "";
                        string str2 = ds.Tables[0].Rows[0]["Explanation"].ToString();
                        string[] val = rich.Split(new string[] { "\n" }, StringSplitOptions.None);
                        DataSet dsCount = sql.Query_Select_DataSet("WHERE Product_Name = '" + textBox_Product_Name.Text + "'AND Color = '" + textBox_Color.Text + "'AND Size ='" + sizStr + "'AND isbn!=" + label_Isbn.Text);
                        int count = dsCount.Tables[0].Rows.Count;


                        for (int i = 0; i < val.Length; i++)
                        {
                            rich2 += val[i] + " \\n";
                        }
                        if (count != 0)
                        {
                            //상품명은 같은데 색상과 사이즈가 같을때
                            MessageBox.Show("입력하신 상품명,Color,Siz가 존재함니다.");
                        }
                        else
                        {
                            DataSet dsMain = sql.Query_Select_DataSet("SELECT Img_Name1, Explanation FROM TB_PRODUCT where Isbn = " + label_Isbn.Text);
                            String Explanation = dsMain.Tables[1].Rows[0]["Explanation"].ToString();
                            String Img_Name1 = dsMain.Tables[1].Rows[0]["Img_Name1"].ToString();
                            if (Explanation == "" || Img_Name1 == "" || Explanation == null || Img_Name1 == null)
                            {
                                if (textBox_ProductImg1.Text.Trim() != "" || textBox_ProductImg2.Text.Trim() != "" || textBox_SizImg.Text.Trim() != "")
                                {
                                    MessageBox.Show("수정 불가");
                                }
                                else
                                {
                                    if (ds.Tables[0].Rows[0]["Category"].ToString() != categoryStr || ds.Tables[0].Rows[0]["Isbn"].ToString() != label_Isbn.Text ||
                                    ds.Tables[0].Rows[0]["Product_Name"].ToString() != textBox_Product_Name.Text || ds.Tables[0].Rows[0]["Size"].ToString() != sizStr ||
                                    ds.Tables[0].Rows[0]["Color"].ToString() != textBox_Color.Text || ds.Tables[0].Rows[0]["Stock"].ToString() != label_Stock.Text ||
                                    ds.Tables[0].Rows[0]["Originalprice"].ToString() != label_Originalprice.Text || ds.Tables[0].Rows[0]["Cigar"].ToString() != label_Cigar.Text ||
                                    ds.Tables[0].Rows[0]["Img_Name1"].ToString() != textBox_ProductImg1.Text || ds.Tables[0].Rows[0]["Img_Name2"].ToString() != textBox_ProductImg2.Text ||
                                    ds.Tables[0].Rows[0]["Img_Size"].ToString() != textBox_SizImg.Text || str2 + "\n" != richTextBox1.Text || rich2 != rich)
                                    {
                                        int originalprice_x_count = int.Parse(label_Originalprice.Text) * int.Parse(label_Stock.Text);
                                        int cigar_x_count = int.Parse(label_Cigar.Text) * int.Parse(label_Stock.Text);
                                        sql.Query_Modify("UPDATE TB_PRODUCT SET Category = '" + categoryStr + "',Size = '" + sizStr + "',Product_Name ='" + textBox_Product_Name.Text + "',Color = '" + textBox_Color.Text
                                                            + "',Img_Name1 = '" + textBox_ProductImg1.Text + "',Img_Name2 = '" + textBox_ProductImg2.Text + "',Img_Size = '" + textBox_SizImg.Text
                                                            + "',Explanation = '" + richTextBox1.Text + "' WHERE Isbn =  " + label_Isbn.Text);
                                        MessageBox.Show("변경완료");
                                        dataGridView1.DataSource = sql.Query_Select(3).DataSource;
                                    }
                                    else
                                    {
                                        MessageBox.Show("변경 사항이 없습니다.");

                                    }
                                }
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["Category"].ToString() != categoryStr || ds.Tables[0].Rows[0]["Isbn"].ToString() != label_Isbn.Text ||
                                ds.Tables[0].Rows[0]["Product_Name"].ToString() != textBox_Product_Name.Text || ds.Tables[0].Rows[0]["Size"].ToString() != sizStr ||
                                ds.Tables[0].Rows[0]["Color"].ToString() != textBox_Color.Text || ds.Tables[0].Rows[0]["Stock"].ToString() != label_Stock.Text ||
                                ds.Tables[0].Rows[0]["Originalprice"].ToString() != label_Originalprice.Text || ds.Tables[0].Rows[0]["Cigar"].ToString() != label_Cigar.Text ||
                                ds.Tables[0].Rows[0]["Img_Name1"].ToString() != textBox_ProductImg1.Text || ds.Tables[0].Rows[0]["Img_Name2"].ToString() != textBox_ProductImg2.Text ||
                                ds.Tables[0].Rows[0]["Img_Size"].ToString() != textBox_SizImg.Text || str2 + "\n" != richTextBox1.Text || rich2 != rich)
                                {
                                    int originalprice_x_count = int.Parse(label_Originalprice.Text) * int.Parse(label_Stock.Text);
                                    int cigar_x_count = int.Parse(label_Cigar.Text) * int.Parse(label_Stock.Text);
                                    sql.Query_Modify("UPDATE TB_PRODUCT SET Category = '" + categoryStr + "',Size = '" + sizStr + "',Product_Name ='" + textBox_Product_Name.Text + "',Color = '" + textBox_Color.Text
                                                        + "',Img_Name1 = '" + textBox_ProductImg1.Text + "',Img_Name2 = '" + textBox_ProductImg2.Text + "',Img_Size = '" + textBox_SizImg.Text
                                                        + "',Explanation = '" + richTextBox1.Text + "' WHERE Isbn =  " + label_Isbn.Text);
                                    MessageBox.Show("변경완료");
                                    dataGridView1.DataSource = sql.Query_Select(3).DataSource;
                                }
                                else
                                {
                                    MessageBox.Show("변경 사항이 없습니다.");

                                }
                            }

                            }
                        }
                    else
                    {
                        MessageBox.Show("사이즈를 선택해 주세요");
                    }

                }
                else
                {//라벨 속성이 없을때
                    MessageBox.Show("없는 상품입니다.");
                }

            }
            else
            {//아니오

            }

        }

     
    }
}
