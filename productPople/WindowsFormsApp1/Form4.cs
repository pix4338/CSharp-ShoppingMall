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
    public partial class Form4 : Form
    {
        SqlProduct sql = new SqlProduct();
        SqlLogin sqluser = new SqlLogin();
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox_UserName.Text = LoginForm.idValue;
            //   ProductName = Form2.ProductName;
            string productName = Form2.ProductIsbn;
            label_Addres.Text = "한진택배";
            label_ProductCount.Text = Form2.ProductCount;
            int countP = sql.Query_Select_DataSet("WHERE Isbn = '" + Form2.ProductIsbn + "'").Tables[0].Rows.Count;
            if (countP != 0)
            {//상품 금액 , 총 결제 금액 label 값을 넣어줌
                string ciar = sql.Query_Select_DataSet("WHERE Isbn = '" + Form2.ProductIsbn + "'").Tables[0].Rows[0]["Cigar"].ToString();
                label_Cigar.Text = (int.Parse(ciar) * int.Parse(Form2.ProductCount)).ToString();
                int total = int.Parse(label_Cigar.Text) * int.Parse(Form2.ProductCount) + 2500;
                label_Total.Text = total.ToString();
            }
            int countU = sqluser.Query_Select_DataSet("WHERE ID = '" + LoginForm.idValue + "'").Tables[0].Rows.Count;
            if (countU != 0)
            {// 고객 정보 자동 입력
                textBox_UserName.Text = sqluser.Query_Select_DataSet("WHERE ID = '" + LoginForm.idValue + "'").Tables[0].Rows[0]["NAME"].ToString();
                textBox_Address.Text = sqluser.Query_Select_DataSet("WHERE ID = '" + LoginForm.idValue + "'").Tables[0].Rows[0]["ADDRESS"].ToString();
                textBox_Tel.Text = sqluser.Query_Select_DataSet("WHERE ID = '" + LoginForm.idValue + "'").Tables[0].Rows[0]["TEL"].ToString();
            }


        }
        public Form4()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sql.Query_Modify("UPDATE TB_PRODUCT SET NetProfit = (NetProfit+" + label_Cigar.Text + ")-(Originalprice *" + Form2.ProductCount + "), Stock=Stock-" + Form2.ProductCount + "WHERE Isbn = '" + Form2.ProductIsbn+"'");
          
            MessageBox.Show("구매완료");
            
        }

     
    }
}
