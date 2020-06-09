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
    public partial class MemberShepForm : Form
    {
        SqlLogin sql = new SqlLogin();
        public MemberShepForm()
        {
            InitializeComponent();
            string[] tel = { "010", "011", "016", "017","018","019" };
            comboBox1.Items.AddRange(tel);
            comboBox1.SelectedIndex = 0;
        }
       private void button_singUp_Click(object sender, EventArgs e)
        {
            try
            {
                string telStr = comboBox1.SelectedItem as String + "-" + textBox_tel1.Text + "-" + textBox_tel2.Text;
                if (textBox_id.Text.Trim() == "")
                {
                    MessageBox.Show("빈칸이 있습니다. 다시 입력해 주세요");
                }
                else if (sql.Query_Select_Bool("WHERE ID = '" + textBox_id.Text + "'", "", 0))
                    {//중복아이디 check
                        MessageBox.Show("중복된 아이디 입니다.");
                    }
                else if (textBox_id.Text.Trim() == "" || textBox_pwd.Text.Trim() == "" || textBox_pwde.Text.Trim() == "" || textBox_pwde.Text.Trim() == "" || textBox_address.Text.Trim() == "" || textBox_tel1.Text.Trim() == "" || textBox_tel2.Text.Trim() == "")
                {
                    MessageBox.Show("빈칸이 있습니다. 다시 입력해 주세요");
                }
                else
                {
                   if (textBox_pwd.Text == textBox_pwde.Text)
                    {

                        sql.Query_Modify("INSERT INTO TB_LOGIN VALUES ('" + textBox_id.Text + "','" + textBox_pwd.Text + "','" + textBox_pwde.Text + "','" +
                        textBox_name.Text + "','" + telStr + "')");
                        MessageBox.Show(textBox_name.Text + "님 회원가입 완료 됐습니다.");
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 일치하지 않음");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("알수 없는 오류");
            }
              }

       
    }
        }
    

