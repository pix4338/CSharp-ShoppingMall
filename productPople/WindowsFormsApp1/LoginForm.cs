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
   
    public partial class LoginForm : Form
    {
        

        public static string idValue
        {
            get;
            set;
        }

        SqlLogin sql = new SqlLogin();
        
        public LoginForm()
        {
            idValue = "";
            InitializeComponent();
            
            Text = "로그인";
        }
      

        private void button_login_Click(object sender, EventArgs e)
        {//로그인 버튼
            try
            {
                if (textBox_id.Text.Trim() == "" || textBox_pwd.Text.Trim() == "")
                {
                    MessageBox.Show("빈칸이 있습니다. 다시 입력해 주세요");
                }
                else
                {
                    SqlLogin sqle = new SqlLogin();
                    int count = sqle.Query_Select_DataSet("WHERE ID = '" + textBox_id.Text + "' and pwd ='" + textBox_pwd.Text + "'").Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        string strId = sqle.Query_Select_DataSet("WHERE ID = '" + textBox_id.Text + "' and pwd ='" + textBox_pwd.Text + "'").Tables[0].Rows[0]["ID"].ToString();
                        string strPwd = sqle.Query_Select_DataSet("WHERE ID = '" + textBox_id.Text + "' and pwd ='" + textBox_pwd.Text + "'").Tables[0].Rows[0]["PWD"].ToString();
                        string strName = sqle.Query_Select_DataSet("WHERE ID = '" + textBox_id.Text + "' and pwd ='" + textBox_pwd.Text + "'").Tables[0].Rows[0]["NAME"].ToString();
                        if (strId == textBox_id.Text && strPwd == textBox_pwd.Text)
                        {
                            if (textBox_id.Text == "1" && textBox_pwd.Text == "1")
                            {
                                MessageBox.Show("운영자님 환영합니다.");
                                Form6 showForm6 = new Form6();
                                showForm6.Show();
                                this.Visible = false;
                            }
                            else
                            {
                                idValue = textBox_id.Text;
                                MessageBox.Show(strName + "님 환영합니다.");
                                // 추가
                                //  Form2 showForm2 = new Form2();
                                   ProductListForm showForm2  =new ProductListForm();
                                 showForm2.Show();
                                  //sql.Id = textBox_id.Text;
                                  this.Visible = false;

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("로그인 실패");
                    }
                }
            }catch(Exception error)
            {
                //MessageBox.Show("로그인 실패");
                MessageBox.Show("" + error);
            }
            }
       

        private void button_singUp_Click(object sender, EventArgs e)
        {
            //회원가입 버튼
            MemberShepForm showForm3 = new MemberShepForm();
            showForm3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int num = 1;
        int nume = 1;
        private void textBox_id_Click(object sender, EventArgs e)
        {
            textBox_id.ForeColor = Color.Black;
            if (num > 0)
            {
                textBox_id.Text = "";
                num -= 1;
            }

        }

        private void textBox_pwd_Click(object sender, EventArgs e)
        {
            textBox_pwd.ForeColor = Color.Black;
            if (nume > 0)
            {
                textBox_pwd.Text = "";
                num -= 1;
            }
        }
    }
    }

