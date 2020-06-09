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
    public partial class PurchaseForm : Form
    {
        SqlProduct pSql = new SqlProduct();
        SqlLogin uSqp = new SqlLogin();
        DataSet ds;
        String product_name = ProductListForm.ProductName;
        int count;
        public PurchaseForm()
        {
            InitializeComponent();
            int i = 0;
           
            label_product_name.Text = product_name;
            ds = pSql.Query_Select_DataSet("Where  Product_Name = '" + product_name + "'");
            count = int.Parse(ds.Tables[0].Rows.Count.ToString());//테이블 row수
            //comboBox_colorSize넣어줄 값들
            String[] product = new String[count];
                while (i < count)
                {
                    
                    String colorStr = ds.Tables[0].Rows[i]["Color"].ToString();
                    String sizeStr = ds.Tables[0].Rows[i]["Size"].ToString();
                    product[i] =colorStr + " " + sizeStr;
                    i++;
                }
            comboBox_colorSize.Items.AddRange(product);
            //ds.Tables[0].Rows[i]["Cigar"].ToString(); 
            label_price.Text = ds.Tables[0].Rows[0]["Cigar"].ToString();

           //IMG, 설명
            string ImgName = ds.Tables[0].Rows[0]["Img_Name1"].ToString();
            string ExplanationStr = ds.Tables[0].Rows[0]["Explanation"].ToString();
            string ImgSize = ds.Tables[0].Rows[0]["Img_Size"].ToString();
            pictureBox.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgName);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;//이미지 알맞게 배치 하도록함
            pictureBox1.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgSize);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //<설명>
            label_Explanation.Text = "";
            string[] val = ExplanationStr.Split(new string[] { "\\n" }, StringSplitOptions.None);
            for (i = 0; i < val.Length; i++)
            {
                label_Explanation.Text += val[i] + Environment.NewLine;
            }
            if (ds.Tables[0].Rows[0]["Img_Name2"].ToString().Equals(""))
            {
                pictureBox2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                string ImgName2 = ds.Tables[0].Rows[0]["Img_Name2"].ToString();
                pictureBox2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + ImgName2);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;//이미지 알맞게 배치 하도록함
            }
        }


        private void comboBox_colorSize_SelectedIndexChanged(object sender, EventArgs e)
        {//comboBox_colorSize 콤보박스 클릭시 발생
         // ds = pSql.Query_Select_DataSet("Where  Product_Name = '" + product_name + "'");
            int index = comboBox_colorSize.SelectedIndex;
            if (index > -1)
            {

                int stocknum = int.Parse(ds.Tables[0].Rows[index]["stock"].ToString());
                comboBox_count.Items.Clear();
                string[] data = new string[stocknum];
                for (int j = 0; j < stocknum; j++)
                {
                    data[j] = (j + 1).ToString();
                }
                comboBox_count.Items.AddRange(data);

            }

        }

    

        private void button_Back_Click(object sender, EventArgs e)
        { 
            Close();
        }

        private void button_Click(object sender, EventArgs e)
        {//구매하기 버튼
            if (LoginForm.idValue == null)
            {
                MessageBox.Show("로그인을 해주세요");
            }
            else
            {
                int index = comboBox_colorSize.SelectedIndex;
                if (index <= -1)
                {
                    MessageBox.Show("선택해주세요");
                }
                else
                {
                    String purchase_size = ds.Tables[0].Rows[index]["Size"].ToString();
                    String purchase_color = ds.Tables[0].Rows[index]["Color"].ToString();
                    String purchase_count = comboBox_count.SelectedItem as String;
                    String purchase_cigar = ds.Tables[0].Rows[index]["Cigar"].ToString();
                    String total = (int.Parse(purchase_cigar) * int.Parse(purchase_count) + 2500).ToString();

                    //회원 정보 
                    DataSet uds = uSqp.Query_Select_DataSet("WHERE ID = '" + LoginForm.idValue + "'");
                    int countU = uds.Tables[0].Rows.Count;
                    String tel_inform = uds.Tables[0].Rows[0]["TEL"].ToString();
                    textBox_tel.Text = tel_inform.Substring(0, 3);
                    textBox_tel1.Text = tel_inform.Substring(4, 4);
                    textBox_tel2.Text = tel_inform.Substring(9, 4);

                    if (countU != 0)
                    {// 로그인이 된 상태라면
                        textBox_user_name.Text = uds.Tables[0].Rows[0]["NAME"].ToString();
                        textBox__user_address.Text = uds.Tables[0].Rows[0]["ADDRESS"].ToString();
                        textBox__user_memo.Text = uds.Tables[0].Rows[0]["ADDRESS"].ToString();
                    }

                    label_purchase_name.Text = product_name;
                    label_purchase_size.Text = purchase_size;
                    label_purchase_color.Text = purchase_color;
                    label_purchase_count.Text = purchase_count;
                    label_purchase_cigar.Text = purchase_cigar;
                    label_purchase_total.Text = total;
                    //
                    groupBox_purchase.Visible = true;
                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {//취소 버튼
            groupBox_purchase.Visible = false;
        }

        private void button_buy_it_Click(object sender, EventArgs e)
        {//결제 버튼
            if(LoginForm.idValue == null)
            {
                MessageBox.Show("로그인을 해주세요");
            }
            else
            {
                if (MessageBox.Show("구매 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataSet buy_ds = pSql.Query_Select_DataSet("Where  Product_Name = '" + label_purchase_name.Text + "' And Size = '" + label_purchase_size.Text + "' AND COLOR = '" + label_purchase_color.Text + "'");
                    String isbn = buy_ds.Tables[0].Rows[0]["Isbn"].ToString();
                    pSql.Query_Modify("UPDATE TB_PRODUCT SET NetProfit = NetProfit+(" + label_purchase_cigar.Text + "-Originalprice) *" + int.Parse(label_purchase_count.Text) + ", Stock=Stock-" + int.Parse(label_purchase_count.Text) + "WHERE Isbn = '" + isbn + "'");
                    //순이익 = 순이익 + (시가 -원가)*상품 개수(사용자가 구매한 개수)   /   재고(남은 상품)=  재고 - 상품 개수 (사용자가 구매한 개수)
                    //상품 재고를 update를 하기 위해
                    ds = pSql.Query_Select_DataSet("Where  Product_Name = '" + product_name + "'");
                    MessageBox.Show("구매완료");
                }
                else
                {
                    MessageBox.Show("아니요 클릭");
                }

            }
           
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
