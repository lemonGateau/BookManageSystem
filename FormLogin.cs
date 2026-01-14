using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BookManageSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Employeeドロップダウンリストの設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBoxLoginUser.DataSource = MasterRepository.GetEmployees();
            comboBoxLoginUser.DisplayMember = "UserId";
            comboBoxLoginUser.ValueMember = "UserId";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // userIdを保持する
            LoginSession.userId = int.Parse(comboBoxLoginUser.Text);

            string password = LoginSession.ComputeHash(textBoxPassword.Text);

            // ハッシュコードが一致したらログイン
            if (password == MasterRepository.GetHashedPassword(LoginSession.userId))
            {
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("ユーザIDかパスワードが異なります");
            }
        }
    }
}
