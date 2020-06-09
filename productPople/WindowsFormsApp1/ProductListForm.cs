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


    public partial class ProductListForm : Form
    {
        public static string ProductName
        {
            get;
            set;
        }


        SqlProduct Psql = new SqlProduct();
        String cataegiry = "";
        DataSet ds;
        DataSet dsCount;
        String img;
        int tableNum;
        int count;
        int start;
        int and;
        int and1;
        int and2;
        int pageNow;
        int page;
        private List<Button> myButtons = new List<Button>();
        public ProductListForm()
        {
           
            InitializeComponent();
          

           if (LoginForm.idValue != null)
            {
            button_login.Text = "로그아웃";
            }
           /* dsCount = Psql.Query_Select_DataSet_Productget(cataegiry);
            count = int.Parse(dsCount.Tables[0].Rows.Count.ToString());*/
            button_back.Visible = false;
            button_next.Visible = false;
            label_productCount.Visible = false;
            //SELECT Product_Name,Img_Name1,Stock FROM TB_PRODUCT ORDER BY Stock ASC,Product_Name

            DataSet dsBestProduct =  Psql.Query_Select_DataSet("SELECT Product_Name,Img_Name1,Stock FROM TB_PRODUCT ORDER BY Stock ASC,Product_Name");
            String[] imgName = new String[9];
            for (int i = 0; i < 9; i++) {
                imgName[i] = dsBestProduct.Tables[1].Rows[i]["Img_Name1"].ToString();
              
              
            }
            pictureBoxBest1.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[0]);
            pictureBoxBest2.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[1]);
            pictureBoxBest3.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[2]);

            pictureBoxBest4.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[3]);
            pictureBoxBest5.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[4]);
            pictureBoxBest6.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[5]);

            pictureBoxBest7.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[6]);
            pictureBoxBest8.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[7]);
            pictureBoxBest9.Load(@" Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + imgName[8]);


        }
        public void ProductPrint()
        {
            if (tableNum == 1)
            {
                product1();
                product2Null();
                product3Null();
                product4Null();
                product5Null();
                product6Null();
            }
            else if (tableNum == 2)
            {
                product1();
                product2();
                product3Null();
                product4Null();
                product5Null();
                product6Null();
            }
            else if (tableNum == 3)
            {
                product1();
                product2();
                product3();
                product4Null();
                product5Null();
                product6Null();
            }
            else if (tableNum == 4)
            {
                product1();
                product2();
                product3();
                product4();
                product5Null();
                product6Null();
            }
            else if (tableNum == 5)
            {
                product1();
                product2();
                product3();
                product4();
                product5();
                product6Null();
            }
            else if (tableNum == 6)
            {
                product1();
                product2();
                product3();
                product4();
                product5();
                product6();
            }
        }

        //제품 이미지 출력 메소드
        public void Productget()
        {//이미지에 출력할 rnum  where rnum  >= start and rnum <= and
            start = 1;
            and = 6;
            //다음 페이지에 출력 하기 위해 넣어줌
            and2 = and;
            //제품 정보를 구하는 메소드
            ds = Psql.Query_Select_DataSet_Productget(cataegiry, start, and);
            //검색 결과 row수 구한다.
            tableNum = int.Parse(ds.Tables[0].Rows.Count.ToString());
            //tableNum에 맞춰 제품을 출력
            ProductPrint();
        }
       
        public void ProducNextget()
        {//다음 페이지의 제품을 보여주기 위한 메소드
            //다음페이지 rnum을 구한다.  where rnum  >= and1 and rnum <= and2
            and1 = and2 + 1;
            and2 = and1 + 5;
            ds = Psql.Query_Select_DataSet_Productget(cataegiry, and1, and2);
            tableNum = int.Parse(ds.Tables[0].Rows.Count.ToString());
            ProductPrint();
                
        }
        public void ProducBackget()
        {//이전 페이지의 제품을 보여주기 위한 메소드
         //이전페이지 rnum을 구한다.  where rnum  >= and1 and rnum <= and2
            and1 = and1 - 6;
            and2 = and1 + 5;
                if (and1 <= 0)
                {
                    and1 = 1;
                }   
                    ds = Psql.Query_Select_DataSet_Productget(cataegiry, and1, and2);
                    tableNum = int.Parse(ds.Tables[0].Rows.Count.ToString());
            ProductPrint();
        }
       
        public void butAdd()
        {//제품 테이블 전체 개수를 구한다.
           dsCount = Psql.Query_Select_DataSet_Productget(cataegiry);
           count = int.Parse(dsCount.Tables[0].Rows.Count.ToString());
           label_productCount.Text = "";
            //한 페이지에 6개의 제품이 출력이 될수 있는데
            //제품이 6개이상 이라면 다음 페이지 생성을 위한 코드
            if (count > 6)
            {
                bool pageB = (count % 6 == 0 ? true : false);
                if (pageB)
                {//페이지 총 개수를 구한다
                    page = count / 6;
                    //버튼과 페이지수를 나타내는 label을 보여준다.
                    label_productCount.Visible = true;
                    button_back.Visible = true;
                    button_next.Visible = true;
                    label_productCount.Text = "총" + page + "페이지 입니다.";
                }
                else
                {//나눈 나머지가 0이 아니라면 한페이지 더 보여줘야 하기 때문에 1을 더해준다
                    page = count / 6 +1 ;
                    //버튼과 페이지수를 나타내는 label을 보여준다.
                    label_productCount.Visible = true;
                    button_back.Visible = true;
                    button_next.Visible = true;
                    label_productCount.Text = "총" + page + "페이지 입니다.";
                }
            }
            else
            {
                button_next.Visible = false;
                button_back.Visible = false;
            }
        }
        private void button_next_Click(object sender, EventArgs e)
        {//다음 버튼 눌렀을시 
            if (pageNow== page) {
                //다음 페이지 제품 정보가 없을 경우
                MessageBox.Show("마지막 페이지 입니다.");
            }
            else
            {//지금 현제 페이지 수를 나타낸다.
                pageNow += 1;
                label_pageNow.Text = pageNow.ToString();
                //다음 페이지의 제품을 보여주기 위한 메소드
                ProducNextget();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {// 이전
            if (pageNow == 1)
            {//이전 페이지 제품 정보가 없을 경우
                MessageBox.Show("처음 페이지 입니다.");
            }
            else
            {//지금 현제 페이지 수를 나타낸다.
                pageNow -= 1;
                label_pageNow.Text = pageNow.ToString();
                //이전 페이지의 제품을 보여주기 위한 메소드
                ProducBackget();
            }
        }

        //pictureBox,label_name,label_price 보여주는 메소드
        public void productVisbleTrue()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;

            label_name1.Visible = true;
            label_name2.Visible = true;
            label_name3.Visible = true;
            label_name4.Visible = true;
            label_name5.Visible = true;
            label_name6.Visible = true;

            label_price1.Visible = true;
            label_price2.Visible = true;
            label_price3.Visible = true;
            label_price4.Visible = true;
            label_price5.Visible = true;
            label_price6.Visible = true;
        }
        public void productVisbleFalse()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;

            label_name1.Visible = false;
            label_name2.Visible = false;
            label_name3.Visible = false;
            label_name4.Visible = false;
            label_name5.Visible = false;
            label_name6.Visible = false;

            label_price1.Visible = false;
            label_price2.Visible = false;
            label_price3.Visible = false;
            label_price4.Visible = false;
            label_price5.Visible = false;
            label_price6.Visible = false;

            label_pageNow.Visible = false;
            label_productCount.Visible = false;
            button_next.Visible = false;
            button_back.Visible = false;


        }
        private void button3_Click(object sender, EventArgs e)
        {//상의 버튼 클릭시
            //상의 제외한 버튼
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            //상의 버튼
            button3.BackColor = Color.DarkGray;
            button3.ForeColor = Color.White;

            //메인 label,groupBox 숨김
            label1.Visible = false;
            groupBox1.Visible = false;
            //현제 페이지 수
            pageNow = 1;
            label_pageNow.Text = pageNow.ToString();
            label_pageNow.Visible = true;
            //검색할 카테고리
            cataegiry = "상의";
            //pictureBox,label_name,label_price 보여주는 메소드
            productVisbleTrue();
            //제품을 출력하는 메소드
            Productget();
            //버튼 여부 메소드
            butAdd();
        }
        private void button4_Click(object sender, EventArgs e)
        {//하의
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            button4.BackColor = Color.DarkGray;
            button4.ForeColor = Color.White;
            label1.Visible = false;
            groupBox1.Visible = false;
            pageNow = 1;
            label_pageNow.Text = pageNow.ToString();
            label_pageNow.Visible = true;
            cataegiry = "하의";
            Productget();
            butAdd();
        }
        private void button5_Click(object sender, EventArgs e)
        {//신발
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            button5.BackColor = Color.DarkGray;
            button5.ForeColor = Color.White;
            label1.Visible = false;
            groupBox1.Visible = false;
            pageNow = 1;
            label_pageNow.Text = pageNow.ToString();
            label_pageNow.Visible = true;
            cataegiry = "신발";
            Productget();
        }
        private void button6_Click(object sender, EventArgs e)
        {//악세사리
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
            button6.BackColor = Color.DarkGray;
            button6.ForeColor = Color.White;
            label1.Visible = false;
            groupBox1.Visible = false;
            pageNow = 1;
            label_pageNow.Text = pageNow.ToString();
            label_pageNow.Visible = true;
            cataegiry = "악세사리";
            Productget();
        }
       
        public void product1()
        {
            int i = 0;
            label_name1.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price1.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            label_price1.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString(); 
            pictureBox1.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
            
        }
        public void product2()
        {
            int i = 1;
            label_name2.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price2.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString();
            pictureBox2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
        }
        public void product3()
        {
            int i = 2;
            label_name3.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price3.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString();
            pictureBox3.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
        }
        public void product4()
        {
            int i = 3;
            label_name4.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price4.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString();
            pictureBox4.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
        }
        public void product5()
        {
            int i = 4;
            label_name5.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price5.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString();
            pictureBox5.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
        }
        public void product6()
        {
            int i = 5;
            label_name6.Text = ds.Tables[0].Rows[i]["Product_Name"].ToString();
            label_price6.Text = ds.Tables[0].Rows[i]["Cigar"].ToString();
            img = ds.Tables[0].Rows[i]["img_name1"].ToString();
            pictureBox6.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\" + img);
        }

        public void product1Null()
        {
            label_name1.Text = "";
            label_price1.Text = "";
            label_price1.Text = "";
            pictureBox1.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }
        public void product2Null()
        {
            label_name2.Text = "";
            label_price2.Text = "";
            label_price2.Text = "";
            pictureBox2.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }
        public void product3Null()
        {
            label_name3.Text = "";
            label_price3.Text = "";
            label_price3.Text = "";
            pictureBox3.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }
        public void product4Null()
        {
            label_name4.Text = "";
            label_price4.Text = "";
            label_price4.Text = "";
            pictureBox4.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }
        public void product5Null()
        {
            label_name5.Text = "";
            label_price5.Text = "";
            label_price5.Text = "";
            pictureBox5.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }
        public void product6Null()
        {
            label_name6.Text = "";
            label_price6.Text = "";
            label_price6.Text = "";
            pictureBox6.Load(@"Z:\공부\C#\sql_과제\productPople\WindowsFormsApp1\img\흰.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductName = label_name1.Text;
            PurchaseForm purchaseForm= new PurchaseForm();
            purchaseForm.ShowDialog();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProductName = label_name2.Text;
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ProductName = label_name3.Text;
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProductName = label_name4.Text;
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProductName = label_name5.Text;
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ProductName = label_name6.Text;
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }
        private void button_mypage_Click(object sender, EventArgs e)
        {//mypage 버튼
            MypageForm form = new MypageForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {//로고 버튼
            
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;

            label1.Visible = true;
            groupBox1.Visible = true;
            productVisbleFalse();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {//로그인 버튼
            if (LoginForm.idValue != null)
            {
                LoginForm.idValue = null;
                button_login.Text = "로그인";
            }
            else { 
            this.Visible = false;
            LoginForm form = new LoginForm();
            form.Show();
            }


        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            // Graphics g = e.Greaphis;
          
        }
    }
}
