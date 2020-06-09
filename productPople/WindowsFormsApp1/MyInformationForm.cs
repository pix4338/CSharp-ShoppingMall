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
    public partial class MyInformationForm : Form
    {
        SqlLogin sql = new SqlLogin();
        public MyInformationForm()
        {
            InitializeComponent();

            label_id.Text = LoginForm.idValue;
            DataSet ds = sql.Query_Select_DataSet("WHERE id = '" + label_id.Text + "'");

            textBox_name.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            textBox_address.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
            String tel = ds.Tables[0].Rows[0]["TEL"].ToString();
            String tel1 = tel.Substring(0, 3);
            textBox_tel2.Text = tel.Substring(4, 4);
            textBox_tel3.Text = tel.Substring(9, 4);
            //textBox_address.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
            //String tel_inform = ds.Tables[0].Rows[0]["TEL"].ToString();
            string[] tell = { "010", "011", "016", "017", "018", "019" };
            comboBox1.Items.AddRange(tell);
            
            switch (tel1) {
                case "010":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "011":
                    comboBox1.SelectedIndex = 1;
                    break;
                case "016":
                    comboBox1.SelectedIndex = 2;
                    break;
                case "017":
                    comboBox1.SelectedIndex = 3;
                    break;
                case "018":
                    comboBox1.SelectedIndex = 4;
                    break;
                case "019":
                    comboBox1.SelectedIndex = 5;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id = LoginForm.idValue;
            string str = "";
            if (sql.Query_Select_Bool("WHERE ID ='" + id + "' AND PWD = '" + textBox_pwd.Text + "'", "", 0))
            {//입력 비밀번호가 맞으면
                if (textBox_Npwd.Text != "" & textBox_Npwd2.Text != "")
                {
                    if (textBox_Npwd.Text == textBox_Npwd2.Text)
                    {
                        sql.Query_Modify("UPDATE TB_LOGIN SET PWD =" + textBox_Npwd.Text + "WHERE ID = '" + LoginForm.idValue + "'");
                        str += "비밀번호 ";
                    }
                    else
                    {
                        MessageBox.Show("일치하지 않습니다.");
                    }
                }

                string tel1 = comboBox1.SelectedItem as String;
                string tele = tel1 +"-"+ textBox_tel2.Text + "-" + textBox_tel3.Text;
               
                sql.Query_Modify("UPDATE TB_LOGIN SET ADDRESS = '" + textBox_address.Text + "' ,TEL = '" + tele + "', NAME = '" + textBox_name.Text + "' WHERE ID = '" + LoginForm.idValue + "'"); 
                MessageBox.Show( "수정 완료");
            }else
            {
                MessageBox.Show("비밀번호 일치하지 않습니다.");
            }

        }
    }
}
