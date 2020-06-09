using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    class SqlProduct
    {
        public SqlConnection conn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter da;
        public DataSet ds;
        public DataGridView dataGridView= new DataGridView();
        static string sqlcommand;
        bool checkBool;
        public void ConnectDB()
        {
            conn.ConnectionString = $"Data Source=({"local"}); Initial Catalog={"MYDB"}; Integrated Security = {"SSPI"}; Timeout=3";
            conn = new SqlConnection(conn.ConnectionString);

            conn.Open();
        }
        public DataGridView Query_Select(int i)
        {
            //사용자에게 출력할 테이블 
            ConnectDB();//DB연결
            cmd.Connection = conn;//연결
            if (i == 1)
            {
                cmd.CommandText = "SELECT  Category as '대분류',Product_Name as '상품명',Size as '사이즈' ,Color as '색깔',Cigar as '가격',Stock as '재고 수량' FROM TB_PRODUCT WHERE Stock > 0 ";
            }
            else if (i == 2)
            {
                cmd.CommandText = "SELECT Isbn as '시리얼번호' ,Date as '날짜' ,Category as '대분류',Product_Name as '상품명',Size as '사이즈' ,Color as '색깔',Count as '상품 개수'," +
                    " Originalprice as '원금', Originalprice_x_Count as '원금 x 개수' , Cigar as '가격',Cigar_x_Count as '시가 x 개수',NetProfit as '순이익',Stock as '재고 수량' FROM TB_PRODUCT";
            }
            else if (i == 3)
            {
                cmd.CommandText = "SELECT Isbn as '시리얼번호' ,Date as '날짜' ,Category as '대분류',Product_Name as '상품명',Size as '사이즈' ,Color as '색깔',Count as '상품 개수'," +
                    " Originalprice as '원금', Originalprice_x_Count as '원금 x 개수' , Cigar as '가격',Cigar_x_Count as '시가 x 개수',NetProfit as '순이익',Stock as '재고 수량'," +
                    "Img_Name1 as '상품 img1' ,Img_Name2 as '상품 img2',Img_Size as 'Siz img',Explanation as '상품 설명' FROM TB_PRODUCT";
            }

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("없는 테이블 입니다.");
                return dataGridView = null;
            }
            else
            {
                dataGridView.DataSource = ds;
                return dataGridView;
            }
        }
        public bool Query_Select_Bool(string str)
        {//검색 결과가 있다면 불값을 return 해주는 메소드 이다. 결과가 있다면 true 없다면 false를 return해준다.
            ConnectDB();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TB_PRODUCT WHERE "+str;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {//검색 없음
                return false;
            }
            else
            {//검색 결과 없음
                return true;
            }    
        }
        public DataGridView Query_Select(string str)
        {
            ConnectDB();
            cmd.Connection = conn;
           
            cmd.CommandText = str;
            
                //1,3,9,15,
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
               {
                    MessageBox.Show("없는 테이블 입니다.");
                    return dataGridView = null;
                }
                else
                {
                    dataGridView.DataSource = ds;
                    return dataGridView;
                }
        }
        public DataSet Query_Select_DataSet(string str)
        {//필요한 값을 가져오는 메소드
            ConnectDB();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TB_PRODUCT " + str;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            return ds;
        }

        //Overloading
        public DataSet Query_Select_DataSet_Productget(string category)
        {//제품 ROW수를 구하기 위한 메소드
            ConnectDB();
            cmd.Connection = conn;
            cmd.CommandText = "select * from (select ROW_NUMBER() OVER(ORDER BY  mIsbn ) AS rnum, b.* " +
                              "from (select  Product_Name, img_name1, Cigar, max(Isbn) as mIsbn from TB_PRODUCT " +
                              "where Category =  '" + category + "' group by Product_Name,img_name1 ,Cigar)b)a";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            return ds;
        }

        //Overloading
        public DataSet Query_Select_DataSet_Productget(string category,int startNum,int andNum)
        {//제품 목록에 출력할 제품 내용
            ConnectDB();
            cmd.Connection = conn;
            cmd.CommandText = "select * from (select ROW_NUMBER() OVER(ORDER BY  mIsbn ) AS rnum, b.* from (select  Product_Name, img_name1, Cigar, max(Isbn) as mIsbn" +
                              " from TB_PRODUCT where  Img_Name1 !='' AND Category =  '" + category + "' group by Product_Name,img_name1 ,Cigar)b)a" +
                              " where rnum  >= "+startNum+" and rnum <= "+andNum;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "TB_PRODUCT");
            conn.Close();
            return ds;
        }
        public void Query_Modify(string str)
        {//update,select,delete,alter 등 실행하는 메소드
            ConnectDB();
            sqlcommand = str;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlcommand;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
