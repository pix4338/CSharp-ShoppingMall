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
    public partial class Form5 : Form
    {
        SqlLogin sqlLogin = new SqlLogin();
        public Form5()
        {
  
            InitializeComponent();
            label_id.Text = LoginForm.idValue;
            DataSet ds = sqlLogin.Query_Select_DataSet("WHERE id = '" + label_id.Text + "'");
            textBox_pwd.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
            textBox_name.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            textBox_address.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
            String tel_inform= ds.Tables[0].Rows[0]["TEL"].ToString();
            String tel1 = tel_inform.Substring(3, 4);
            String tel2 = tel_inform.Substring(7, 4);
            textBox_tel1.Text = tel1;
            textBox_tel2.Text = tel2;
            string[] tel = { "010", "011", "016", "017", "018", "019" };
            comboBox1.Items.AddRange(tel);
            comboBox1.SelectedIndex = 0;

        }

        private void button_singUp_Click(object sender, EventArgs e)
        {
            string id = LoginForm.idValue;
            string str = "";
            if(sqlLogin.Query_Select_Bool("WHERE ID ='"+ id + "' AND PWD = '"+ textBox_pwd.Text + "'","", 0))
            {//입력 비밀번호가 맞으면
                if(textBox1.Text != "" & textBox2.Text != "") { 
                if (textBox1.Text == textBox2.Text )
                {
                    sqlLogin.Query_Modify("UPDATE TB_LOGIN SET PWD =" + textBox2.Text + "WHERE ID = '" + LoginForm.idValue + "'");
                    str += "비밀번호 ";
                }
                else
                {
                    MessageBox.Show("일치하지 않습니다.");
                }
                }
               
                string tel1 = comboBox1.SelectedItem as String;
                string tele = tel1 + textBox_tel1.Text + textBox_tel2.Text;
                if (textBox_name.Text != "")
                {
                    sqlLogin.Query_Modify("UPDATE TB_LOGIN SET NAME = '" + textBox_name.Text + "' WHERE ID = '" + LoginForm.idValue + "'");
                    str += "이름 ";
                }
                if (textBox_address.Text != "")
                {
                    sqlLogin.Query_Modify("UPDATE TB_LOGIN SET ADDRESS = '" + textBox_address.Text + "' WHERE ID = '" + LoginForm.idValue + "'");
                    str += "주소 ";
                }
                if (textBox_tel1.Text != ""&& textBox_tel2.Text != "")
                {
                    sqlLogin.Query_Modify("UPDATE TB_LOGIN SET TEL = '" + tele + "' WHERE ID = '" + LoginForm.idValue + "'");
                    str += "전화번호 ";
                }
                else
                {

                    MessageBox.Show("sad");
                }
              
                MessageBox.Show(str + "수정 완료");

            }
            else
            {
               MessageBox.Show("비밀번호 일치하지 않습니다.");
            }
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            label_id.Text = LoginForm.idValue;
        }


    }
}
