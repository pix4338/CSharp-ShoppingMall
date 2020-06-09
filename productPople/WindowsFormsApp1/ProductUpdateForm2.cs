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
    public partial class ProductUpdateForm2 : Form
    {
        SqlProduct sql = new SqlProduct();
        public ProductUpdateForm2()
        {
            InitializeComponent();

            dataGridView1.DataSource = sql.Query_Select(3).DataSource;
            dataGridView1.DataMember = "TB_PRODUCT";
       

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                label_Isbn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                label_Product_Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                label_Color.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                label_Stock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                label_Originalprice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                label_Cigar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                label_ProductImg1.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                label_ProductImg2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                label_SizImg.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                label_category.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                label_size.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                
               
                pictureBox_img2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
                if (label_ProductImg1.Text != "")
                {
                    pictureBox_img1.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + label_ProductImg1.Text);
                }

                if (label_ProductImg2.Text != "")
                {
                    pictureBox_img2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + label_ProductImg2.Text);
                }
                if (label_SizImg.Text != "")
                {
                    pictureBox_img3.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + label_SizImg.Text);
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
                    label_ProductImg1.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
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
                    label_SizImg.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
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
                    label_ProductImg2.Text = openFileDialog1.SafeFileName;//경로명을 넣어준다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //재고 추가 버튼
                if (sql.Query_Select_Bool("Isbn = '" + label_Isbn.Text + "'"))
                {//재고만 값이 있다면 원가만 값이 있다면 시가만 값이 있다면 
                    DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = '" + label_Isbn.Text + "'");
                    string product_Name = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                    string size = ds.Tables[0].Rows[0]["Size"].ToString();
                    string color = ds.Tables[0].Rows[0]["Color"].ToString();
                    string isbn = ds.Tables[0].Rows[0]["Isbn"].ToString();
                    if (MessageBox.Show(label_Isbn.Text + "번 상품명 : " + product_Name + ", 사이즈 : " + size + ", 색상 : " + color + "\n" + "수정 하시겠습니까??", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {//재고 시가 원가 수정
                     // ,Count=" + label_Stock.Text + ",Originalprice =" + label_Originalprice.Text + ",Originalprice_x_Count =" + originalprice_x_count + ",Cigar = " + label_Cigar.Text
                     //  +",Cigar_x_Count = " + cigar_x_count +
                     //  UPDATE [MYDB].[dbo].[TB_PRODUCT] SET
                    if (textBox_StockAdd.Text.Trim() != "")
                    {
                        sql.Query_Modify("UPDATE TB_PRODUCT SET  COUNT = COUNT +" + textBox_StockAdd.Text + ", Stock = Stock + " + textBox_StockAdd.Text + " , Originalprice_x_Count =  Originalprice * ( COUNT +" +
                            textBox_StockAdd.Text + "), Cigar_x_Count =  Cigar *( COUNT +" +textBox_StockAdd.Text + ")where ISBN = " + label_Isbn.Text);
                        textBox_StockAdd.Text = "";
                    }
                    if (textBox_Originalprice.Text.Trim() != "")
                    {
                        sql.Query_Modify("UPDATE TB_PRODUCT SET Originalprice = Originalprice +" + label_Originalprice.Text + ", Originalprice_x_Count =  count * (Originalprice +" +
                            textBox_Originalprice.Text + ") where ISBN = " + label_Isbn.Text);
                        textBox_Originalprice.Text = "";
                    }
                    if (textBox_Cigar.Text.Trim() != "")
                    {
                        sql.Query_Modify("UPDATE TB_PRODUCT SET Cigar = Cigar + " + textBox_Cigar.Text + ",Cigar_x_Count =  count * (Cigar +" + textBox_Cigar.Text + ") where ISBN = " + label_Isbn.Text);
                        textBox_Cigar.Text = "";
                    }
                    if (textBox_StocOut.Text.Trim() != "")
                    {
                        sql.Query_Modify("UPDATE TB_PRODUCT SET  COUNT = COUNT -" + textBox_StocOut.Text + ", Stock = Stock - " + textBox_StocOut.Text + " , Originalprice_x_Count =  Originalprice * ( COUNT -" +
                             textBox_StocOut.Text + ") ,Cigar_x_Count =  Cigar * ( COUNT -" + textBox_StocOut.Text + ") where ISBN = " + label_Isbn.Text);
                        textBox_StocOut.Text = "";
                    }
                    //sql.Query_Modify("UPDATE TB_PRODUCT SET  COUNT = COUNT +" + label_Stock.Text + ", Stock = Stock + " + label_Stock.Text + " , Originalprice =" + label_Originalprice.Text + ", Originalprice_x_Count =  Originalprice *" +
                    //        label_Stock.Text + ", Cigar = " + label_Cigar.Text + ",Cigar_x_Count =  Cigar *" + label_Stock.Text + " where ISBN = " + label_Isbn.Text);
                    //    MessageBox.Show("수정 완료");
                    dataGridView1.DataSource = sql.Query_Select(3).DataSource;

                    }
                    else
                    {
                        // MessageBox.Show("아니요 클릭");
                    }
                }
                else
                {
                  MessageBox.Show("없는 상품 입니다.");
            }
            
        }
        
    }
}
