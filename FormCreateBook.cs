using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookManageSystem
{
    public partial class FormCreateBook : FormBook
    {
        public FormCreateBook()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ドロップダウンリストの初期設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCreateBook_Load(object sender, EventArgs e)
        {
            SetUpComboBox(comboBoxPublisher, MasterRepository.GetPublishers(), "Name", "PublisherId");
            SetUpComboBox(comboBoxCategory , MasterRepository.GetCategories(), "Name", "CategoryId");
            SetUpComboBox(comboBoxOffice   , MasterRepository.GetOffices()   , "Name", "OfficeId");
        }

        /// <summary>
        /// 書籍の新規登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateBook_Click(object sender, EventArgs e)
        {
            // isbn, title, price, last_name, first_nameが空白の場合
            if (string.IsNullOrWhiteSpace(textBoxIsbn.Text) || string.IsNullOrWhiteSpace(textBoxTitle.Text) || string.IsNullOrWhiteSpace(textBoxPrice.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) || string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("必須項目*を入力してください");

                return;
            }

            // 新規登録する書籍
            Book newBook = new Book 
            {
                Isbn = textBoxIsbn.Text,
                Title = textBoxTitle.Text,
                PublisherId = (int)comboBoxPublisher.SelectedValue,
                CategoryId = (int)comboBoxCategory.SelectedValue,
                Price = int.Parse(textBoxPrice.Text)
            };

            // 保管場所
            BookItem newBookItem = new BookItem
            {
                Isbn = textBoxIsbn.Text,
                OfficeId = (int)comboBoxOffice.SelectedValue,
                RackId = comboBoxRack.SelectedValue.ToString()
            };

            // 著者
            Author newAuthor = new Author
            {
                LastName = textBoxLastName.Text,
                FirstName = textBoxFirstName.Text
            };

            // 書籍の登録
            _ = BookRepository.CreateBook(newBook, newBookItem);

            // 著者の登録
            int authorId = MasterRepository.CreateAuthor(newAuthor);
            MasterRepository.CreateAuthorBooks(newBook.Isbn, authorId);

            MessageBox.Show("登録が完了しました");

            this.Close();
        }

        /// <summary>
        /// ラックドロップダウンリストの設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int officeId = (int)comboBoxOffice.SelectedIndex + 1;   //officeIdと対応

            // ラックドロップダウンリストの設定
            SetUpComboBox(comboBoxRack, MasterRepository.GetRacks(officeId), "RackId", "RackId");
        }
    }
}
