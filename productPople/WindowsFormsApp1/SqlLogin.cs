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
    
    class SqlLogin
    {
        public  SqlConnection conn = new SqlConnection();
        public  SqlCommand cmd = new SqlCommand();
        public  SqlDataAdapter da;
        public  DataSet ds;
        static string sqlcommand;
        bool checkBool;
        private string Form2_value;


        public string Id { get; set; }

        public void ConnectDB()
        {
            conn.ConnectionString = $"Data Source=({"local"}); Initial Catalog={"MYDB"}; Integrated Security = {"SSPI"}; Timeout=3";
            conn = new SqlConnection(conn.ConnectionString);

            conn.Open();
        }
        public bool Query_Select_Bool(string str,string str2 ,int chekNum)
        {
            try
            {
                ConnectDB();
                //DataGridView dataGridView = new DataGridView();
                //SQL 명령어 선언

                cmd.Connection = conn;//연결
                cmd.CommandText = "SELECT * FROM TB_LOGIN " + str;//검색

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "TB_LOGIN");
                int inta = ds.Tables[0].Rows.Count;
                conn.Close();//연결 해제
                if (chekNum == 1)
                { //
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("실패");
                        checkBool = false;
                    }
                    else if(ds.Tables[0].Rows[0]["ID"].ToString() == str2)
                    {
                        MessageBox.Show("성공");
                        checkBool =true;//빌린여부를 알아온다.
                    }
                    else
                    {
                        MessageBox.Show("실패");
                        checkBool = false;
                    }
                }
                else
                {
                   
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        checkBool = false;
                    }
                    else
                    {
                        checkBool = true;
                    }

                }
                return checkBool;
            }
            catch (Exception error)
            {
                MessageBox.Show(error + "");
                return checkBool;
            }
        }
        public void Query_Modify(string str)
        {
                ConnectDB();
                sqlcommand = str;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlcommand;
                cmd.ExecuteNonQuery();
                conn.Close();
        }
        public DataSet Query_Select_DataSet(string str)
        { 
                ConnectDB();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM TB_LOGIN " + str;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "TB_LOGIN");
                int inta = ds.Tables[0].Rows.Count;
                conn.Close();
                return ds;
        }
    }
}
