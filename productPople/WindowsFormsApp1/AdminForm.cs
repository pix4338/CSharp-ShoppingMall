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
    public partial class Form6 : Form
    {
        SqlProduct sql = new SqlProduct();
        string str = "Isbn as '시리얼번호', Date as '날짜', Category as '대분류',Product_Name as '상품명',Size as '사이즈' ,Color as '색깔',Count as '상품 개수', Originalprice as '원금', Originalprice_x_Count as '원금 x 개수' , Cigar as '가격',Cigar_x_Count as '시가 x 개수',NetProfit as '순이익',Stock as '재고 수량'";

        public Form6()
        {
            InitializeComponent();
            dataGridView1.DataSource = sql.Query_Select(2).DataSource;
            dataGridView1.DataMember = "TB_PRODUCT";
            
        }

        private void 상품관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductModefiForm form = new ProductModefiForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {//조회
            try
            {
                if (textBox_Isbn.Text.Trim() == "" && textBox_Date.Text.Trim() == "" && textBox_Dates.Text.Trim() == "")
                {
                    dataGridView1.DataSource = sql.Query_Select(2).DataSource;
                }
                else
                {
                    if (textBox_Date.Text.Trim() != "" && textBox_Dates.Text.Trim() != "")
                    {//날짜~
                        if (sql.Query_Select_Bool("DATE  BETWEEN '" + textBox_Date.Text + "' AND '" + textBox_Dates.Text + "'"))
                        {
                            dataGridView1.DataSource = sql.Query_Select("SELECT "+ str + " FROM TB_PRODUCT WHERE DATE  BETWEEN '" + textBox_Date.Text + "' AND '" + textBox_Dates.Text + "'").DataSource;
                        }
                        else
                        {
                            MessageBox.Show("없는 테이블 입니다.");
                        }
                    }
                    else if (textBox_Isbn.Text.Trim() != "" && textBox_Date.Text.Trim() != "")
                    {//날짜 , 라벨
                        if (sql.Query_Select_Bool("Isbn = '" + textBox_Isbn.Text + "' AND Date = '" + textBox_Date.Text + "'"))
                        {
                            dataGridView1.DataSource = sql.Query_Select("SELECT " + str + " FROM TB_PRODUCT WHERE DATE Isbn = '" + textBox_Isbn.Text + "' AND Date = '" + textBox_Date.Text + "'").DataSource;
                        }
                        else
                        {
                            MessageBox.Show("없는 테이블 입니다.");
                        }
                    }
                    else if (textBox_Date.Text.Trim() != "")
                    {//날짜
                        if (sql.Query_Select_Bool("DATE = '" + textBox_Date.Text + "'"))
                        {
                            dataGridView1.DataSource = sql.Query_Select("SELECT " + str + " FROM TB_PRODUCT WHERE DATE = '" + textBox_Date.Text + "'").DataSource;
                        }
                        else
                        {
                            MessageBox.Show("없는 테이블 입니다.");
                        }

                    }
                    else if (textBox_Isbn.Text.Trim() != "")
                    {//라벨
                        if (sql.Query_Select_Bool("Isbn='" + textBox_Isbn.Text + "'"))
                        {
                            dataGridView1.DataSource = sql.Query_Select("SELECT " + str + " FROM TB_PRODUCT WHERE Isbn='" + textBox_Isbn.Text + "'").DataSource;
                        }
                        else
                        {
                            MessageBox.Show("없는 테이블 입니다.");
                        }
                    }
                }
                textBox_Isbn.Text = "";
                textBox_Date.Text = "";
                textBox_Dates.Text = "";
            }
            catch(Exception )
            {
                textBox_Isbn.Text = "";
                textBox_Date.Text = "";
                textBox_Dates.Text = "";
            }
        }

        private void textBox_Date_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
              //  textBox_Isbn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
               // textBox_Date.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            }
            catch(Exception )
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {//재고 적은 순
         //dataGridView1.DataSource
            dataGridView1.DataSource = sql.Query_Select("SELECT " + str + " FROM[MYDB].[dbo].[TB_PRODUCT] ORDER BY Stock ASC").DataSource;

        }
       
        private void button3_Click(object sender, EventArgs e)
        {//순이익이 많은 제품
            dataGridView1.DataSource = sql.Query_Select("SELECT " + str + " FROM[MYDB].[dbo].[TB_PRODUCT] ORDER BY NetProfit DESC").DataSource;
        }

        private void 제품수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {//제품 수정
            ProductUpdateForm updateFrom = new ProductUpdateForm();
            updateFrom.ShowDialog();
        }

        private void 제품재고원가시가수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductUpdateForm2 updateFrom2 = new ProductUpdateForm2();
            updateFrom2.ShowDialog();
        }
    }
}
