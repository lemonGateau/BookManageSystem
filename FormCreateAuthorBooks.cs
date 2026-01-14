using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormCreateAuthorBooks : Form
    {
        public FormCreateAuthorBooks()
        {
            InitializeComponent();
        }

        private void buttonCreateAuthorBooks_Click(object sender, EventArgs e)
        {
            // 必須項目が空白の場合
            if (string.IsNullOrWhiteSpace(textBoxIsbn.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text) || string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                return;
            }

            Author newAuthor = new Author {LastName = textBoxLastName.Text, FirstName = textBoxFirstName.Text };
 
            // 著者登録
            newAuthor.AuthorId = MasterRepository.CreateAuthor(newAuthor);

            bool isCreated = MasterRepository.CreateAuthorBooks(textBoxIsbn.Text, newAuthor.AuthorId);

            if (isCreated)
            {
                MessageBox.Show("著者を書籍に登録しました");
            }
            else
            {
                MessageBox.Show("書籍が存在しません");
            }
        }
    }
}
