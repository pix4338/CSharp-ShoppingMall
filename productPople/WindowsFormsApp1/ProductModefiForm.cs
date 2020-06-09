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
    public partial class ProductModefiForm : Form
    {
        SqlProduct sql = new SqlProduct();
        int Isbn;
        public ProductModefiForm()
        {
            InitializeComponent();
            //추가할때 필요한 시리얼 번호를 구한다.
            DataSet ds = sql.Query_Select_DataSet("SELECT MAX(Isbn) as Isbn FROM TB_PRODUCT ");
            Isbn = 1 + int.Parse(ds.Tables[1].Rows[0]["Isbn"].ToString());
            label_NIsbn.Text = Isbn.ToString();
            //DataGridView에 제품 테이블을 사용자에게 출력
            dataGridView1.DataSource = sql.Query_Select(3).DataSource;
            dataGridView1.DataMember = "TB_PRODUCT";
            string[] category = { "상의", "하의", "악세사리","신발" };
            comboBox1.Items.AddRange(category);
            comboBox1.SelectedIndex = 0;
            


        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try {
                label_Isbn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox_Product_Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_Color.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox_Stock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox_Originalprice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox_Cigar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox_ProductImg1.Text= dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox_ProductImg2.Text= dataGridView1.CurrentRow.Cells[14].Value.ToString();
                textBox_SizImg.Text= dataGridView1.CurrentRow.Cells[15].Value.ToString();
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
               
                switch (category){
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
        private void button1_Click(object sender, EventArgs e)
        {//추가 버튼
            try
            {//comboBox에서 선택한 값 가져옴
                string categoryStr = comboBox1.SelectedItem as String;
                //사용자가 입력한 값 자료형 변환
                int stock = int.Parse(textBox_Stock.Text);
                int originalprice = int.Parse(textBox_Originalprice.Text);
                int cigar = int.Parse(textBox_Cigar.Text);
                string sizStr = "";
                //사이즈 체크를 하기 위해 불 자료형 선언
                bool sizB = false;
                //null 체크를 해준다.
                if (textBox_Product_Name.Text.Trim() == "" || textBox_Color.Text.Trim() == "" || textBox_Stock.Text.Trim() == "" 
                    || textBox_Originalprice.Text.Trim() == "" || textBox_Cigar.Text.Trim() == "")
                {
                    MessageBox.Show("빈칸이 있습니다. 다시입력해주세요");
                } else
                {//사이즈 선택 확인
                    if (radioButton1.Checked == true)
                    {
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
                    else
                    {
                        MessageBox.Show("사이즈를 선택해 주세요");
                    }//사이즈를 선택할시 true 선택 안했을시 false
                    if (sizB)
                    {//검색 결과가 있다면 불값을 return 해주는 메소드 이다. 결과가 있다면 true 없다면 false를 return해준다.
                        if (sql.Query_Select_Bool("Product_Name = '" + textBox_Product_Name.Text + "'"))
                            { 
                                if (MessageBox.Show("똑같은 상품 이름 존재 합니다. 추가 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {//Yes
                                    if (textBox_ProductImg1.Text.Trim() != "" || textBox_ProductImg2.Text.Trim() != "" || textBox_SizImg.Text.Trim() != "")
                                    {
                                        MessageBox.Show("메인 이미지가 이미 존재합니다.");
                                    }
                                    else if (sql.Query_Select_Bool("Product_Name = '" + textBox_Product_Name.Text + "'AND Color = '" + textBox_Color.Text + "'AND Size ='" + sizStr + "'"))
                                    {
                                        //상품명은 같은데 색상과 사이즈가 같을때
                                        MessageBox.Show("입력하신 상품명,Color,Siz가 존재함니다.");
                                    }
                                    else
                                    {
                                        //총원가 = 원가 x 제품 개수
                                        int originalTotal = int.Parse(textBox_Originalprice.Text) * int.Parse(textBox_Stock.Text);
                                        //총시가 = 시가 x 제품 개수
                                        int cigarTotal = int.Parse(textBox_Cigar.Text) * int.Parse(textBox_Stock.Text);
                                        //쿼리를 실행하는 메소드 
                                        sql.Query_Modify("INSERT INTO TB_PRODUCT VALUES ('" + Isbn + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + categoryStr + "','"
                                            + textBox_Product_Name.Text + "','" + sizStr + "','" + textBox_Color.Text + "'," +textBox_Stock.Text + "," + textBox_Originalprice.Text + ","
                                            + originalTotal + "," + textBox_Cigar.Text + "," + cigarTotal + "," + 0 + "," + textBox_Stock.Text + ",'" + textBox_ProductImg1.Text
                                            + "','" + textBox_ProductImg2.Text + "','" + textBox_SizImg.Text + "','" + richTextBox1.Text + "')");
                                        //추가한 결과 DataGridView에 사용자에게 출력해준다
                                        dataGridView1.DataSource = sql.Query_Select(3).DataSource;//검색 결과 DataGridView return 메소드
                                    MessageBox.Show("상품 추가 완료");
                                    //다음 제품 추가를 위해 시리얼번호를 추가해준다.
                                    Isbn += 1;
                                    label_NIsbn.Text = Isbn.ToString();
                                    }
                                }  // No                           
                            }
                            else//중복된 제품이름이 없을시
                            {
                                if (textBox_ProductImg1.Text.Trim() == "" || textBox_SizImg.Text.Trim() == "")
                                {//중복되지 않은 상품이름인 경우 제품 사진을 등록을 해야한다.
                                //구매자의 상품 목록,상품 설명에 띄우기 위해
                                    MessageBox.Show("사진을 선택해주세요");
                                }
                                else
                                {   //총원가 = 원가 x 제품 개수
                                    int originalTotal = int.Parse(textBox_Originalprice.Text) * int.Parse(textBox_Stock.Text);
                                    //총시가 = 시가 x 제품 개수
                                    int cigarTotal = int.Parse(textBox_Cigar.Text) * int.Parse(textBox_Stock.Text);
                                     sql.Query_Modify("INSERT INTO TB_PRODUCT VALUES ('" + Isbn + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + categoryStr + "','"
                                         + textBox_Product_Name.Text + "','" + sizStr + "','" + textBox_Color.Text + "'," + textBox_Stock.Text + "," + textBox_Originalprice.Text + ","
                                         + originalTotal + "," + textBox_Cigar.Text + "," + cigarTotal + "," + 0 + "," + textBox_Stock.Text + ",'" + textBox_ProductImg1.Text
                                         + "','" + textBox_ProductImg2.Text + "','" + textBox_SizImg.Text + "','" + richTextBox1.Text + "')");
                                    //추가한 결과 DataGridView에 사용자에게 출력해준다.
                                    dataGridView1.DataSource = sql.Query_Select(3).DataSource;//검색 결과 DataGridView return 메소드
                                    MessageBox.Show("상품 추가 완료");
                                    //다음 제품 추가를 위해 시리얼번호를 추가해준다.
                                    Isbn += 1;
                                    label_NIsbn.Text = Isbn.ToString();
                          }
                       }
                   }//사이즈를 선택 하였을때
                }//빈칸이 없을때
            }catch (Exception erorr)
            {
                MessageBox.Show(erorr + "");
            }
        }

        //시리얼 번호 상품명 색상 재고 원가 시가 대분류 사이즈
        //   sql.Query_Modify("insert TB_PRODUCT VALUES ('" + label_Isbn.Text+"','"+ DateTime.Now.ToString("yyyy-MM-dd")+"','"+categoryStr+"','"+ textBox_Product_Name.Text+"','"+sizStr+"','"+textBox_Color.Text+"',"+textBox_Stock.Text+","+textBox_Originalprice.Text+","+originalprice*stock+","+textBox_Cigar.Text+","+cigar*stock+",0,0)");

        private void button2_Click(object sender, EventArgs e)
        {//수정 버튼
         //label_Isbn변경 
            if (MessageBox.Show("수정하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (sql.Query_Select_Bool("Isbn = '" + label_Isbn.Text + "'")){

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
                    if (sizB) {

                        string categoryStr = comboBox1.SelectedItem as String;
                        DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = '" + label_Isbn.Text + "'");
                        string rich = richTextBox1.Text;
                        string rich2 = "";
                        string str2 = ds.Tables[0].Rows[0]["Explanation"].ToString();
                        string[] val = rich.Split(new string[] { "\n" }, StringSplitOptions.None);
                        int count = sql.Query_Select_DataSet("WHERE Product_Name = '" + textBox_Product_Name.Text + "'AND Color = '" + textBox_Color.Text + "'AND Size ='" + sizStr + "'AND isbn!="+label_Isbn.Text).Tables[0].Rows.Count;


                        for (int i = 0; i < val.Length; i++)
                        {
                            rich2 += val[i] + " \\n";
                        }
                        if (count != 0)
                        {
                            //상품명은 같은데 색상과 사이즈가 같을때
                            MessageBox.Show("입력하신 상품명,Color,Siz가 존재함니다.");
                        }
                        else { 
                      
                                if (ds.Tables[0].Rows[0]["Category"].ToString() != categoryStr || ds.Tables[0].Rows[0]["Isbn"].ToString() != label_Isbn.Text ||
                                    ds.Tables[0].Rows[0]["Product_Name"].ToString() != textBox_Product_Name.Text || ds.Tables[0].Rows[0]["Size"].ToString() != sizStr ||
                                    ds.Tables[0].Rows[0]["Color"].ToString() != textBox_Color.Text || ds.Tables[0].Rows[0]["Stock"].ToString() != textBox_Stock.Text ||
                                    ds.Tables[0].Rows[0]["Originalprice"].ToString() != textBox_Originalprice.Text || ds.Tables[0].Rows[0]["Cigar"].ToString() != textBox_Cigar.Text ||
                                    ds.Tables[0].Rows[0]["Img_Name1"].ToString() != textBox_ProductImg1.Text || ds.Tables[0].Rows[0]["Img_Name2"].ToString() != textBox_ProductImg2.Text ||
                                    ds.Tables[0].Rows[0]["Img_Size"].ToString() != textBox_SizImg.Text || str2 + "\n" != richTextBox1.Text || rich2 != rich)
                                {
                                    int originalprice_x_count = int.Parse(textBox_Originalprice.Text) * int.Parse(textBox_Stock.Text);
                                    int cigar_x_count = int.Parse(textBox_Cigar.Text) * int.Parse(textBox_Stock.Text);
                                    sql.Query_Modify("UPDATE TB_PRODUCT SET Category = '" + categoryStr + "',Size = '" + sizStr + "',Product_Name ='" + textBox_Product_Name.Text + "',Color = '" + textBox_Color.Text
                                                        + "',Img_Name1 = '" + textBox_ProductImg1.Text + "',Img_Name2 = '" + textBox_ProductImg2.Text + "',Img_Size = '" + textBox_SizImg.Text
                                                        + "',Explanation = '" + richTextBox1.Text + "' WHERE Isbn =  " + label_Isbn.Text );
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
                        MessageBox.Show("사이즈를 선택해 주세요");
                    }

                } else
                {//라벨 속성이 없을때
                    MessageBox.Show("없는 상품입니다.");
                }
            
            }
            else
            {//아니오
              
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {//삭제 버튼
            
            if (sql.Query_Select_Bool("Isbn = '" + label_Isbn.Text + "'")){
                DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = '" + label_Isbn.Text + "'");
               string product_Name = ds.Tables[0].Rows[0]["Product_Name"].ToString();
               string size = ds.Tables[0].Rows[0]["Size"].ToString();
               string color = ds.Tables[0].Rows[0]["Color"].ToString();
                if (MessageBox.Show(label_Isbn.Text+"번 상품명 : " +product_Name+", 사이즈 : "+size+", 색상 : "+color+"\n"+"삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sql.Query_Modify("DELETE FROM TB_PRODUCT WHERE Isbn = "+ label_Isbn.Text);
                    MessageBox.Show("삭제 완료");
                    dataGridView1.DataSource = sql.Query_Select(3).DataSource;
                    Isbn -= 1;
                    label_Isbn.Text = Isbn.ToString();
                }
                else
                {
                    MessageBox.Show("아니요 클릭");
                }
            }
            else
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


        private void button_ImgAdd2_Click(object sender, EventArgs e)
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

        private void button_ImgAdd3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {//재고 추가 버튼
            if (sql.Query_Select_Bool("Isbn = '" + label_Isbn.Text + "'"))
            {
                DataSet ds = sql.Query_Select_DataSet("WHERE Isbn = '" + label_Isbn.Text + "'");
                string product_Name = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                string size = ds.Tables[0].Rows[0]["Size"].ToString();
                string color = ds.Tables[0].Rows[0]["Color"].ToString();
                string isbn = ds.Tables[0].Rows[0]["Isbn"].ToString();
                if (MessageBox.Show(label_Isbn.Text + "번 상품명 : " + product_Name + ", 사이즈 : " + size + ", 색상 : " + color + "\n" + "추가 하시겠습니까??", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {//재고 시가 원가 수정
                 // ,Count=" + textBox_Stock.Text + ",Originalprice =" + textBox_Originalprice.Text + ",Originalprice_x_Count =" + originalprice_x_count + ",Cigar = " + textBox_Cigar.Text
                 //  +",Cigar_x_Count = " + cigar_x_count +
                 //  UPDATE [MYDB].[dbo].[TB_PRODUCT] SET
                    sql.Query_Modify("UPDATE TB_PRODUCT SET  COUNT = COUNT +"+textBox_Stock.Text+ ", Stock = Stock + " + textBox_Stock.Text + " , Originalprice ="+textBox_Originalprice.Text + ", Originalprice_x_Count =  Originalprice *" +
                        textBox_Stock.Text + ", Cigar = "+textBox_Cigar.Text+",Cigar_x_Count =  Cigar *" + textBox_Stock.Text + " where ISBN = "+label_Isbn.Text);
                    MessageBox.Show("수정 완료");
                    dataGridView1.DataSource = sql.Query_Select(3).DataSource;

                }
                else
                {
                   // MessageBox.Show("아니요 클릭");
                }
            }
            else
            {

            }
        }
    }
}
