using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 書籍の登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateBook_Click(object sender, EventArgs e)
        {
            FormCreateBook formCreateBook = new FormCreateBook();
            formCreateBook.ShowDialog();
        }

        /// <summary>
        /// 書籍の削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            FormDeleteBook formDeleteBook = new FormDeleteBook();
            formDeleteBook.ShowDialog();
        }

        /// <summary>
        /// 書籍を借りる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            FormRentBook formRentBook = new FormRentBook();
            formRentBook.ShowDialog();
        }

        /// <summary>
        /// 書籍を返す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            FormReturnBook formReturnBook = new FormReturnBook();
            formReturnBook.ShowDialog();
        }

        /// <summary>
        /// ランキングを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRentRanking_Click(object sender, EventArgs e)
        {
            FormRentalRanking formRanking = new FormRentalRanking();
            formRanking.ShowDialog();
        }

        /// <summary>
        /// 予約一覧を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmReservation_Click(object sender, EventArgs e)
        {
            FormReservation formReservation = new FormReservation();
            formReservation.ShowDialog();
        }

        /// <summary>
        /// 出版社の登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreatePublish_Click(object sender, EventArgs e)
        {
            FormCreatePublisher formCreatePublish = new FormCreatePublisher();
            formCreatePublish.ShowDialog();
        }

        /// <summary>
        /// カテゴリの登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateCategory_Click(object sender, EventArgs e)
        {
            FormCreateCategory formCreateCategory = new FormCreateCategory();
            formCreateCategory.ShowDialog();
        }

        /// <summary>
        /// 著者の登録、書籍への割当
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateAuthorBooks_Click(object sender, EventArgs e)
        {
            FormCreateAuthorBooks formCreateAuthorBooks = new FormCreateAuthorBooks();
            formCreateAuthorBooks.ShowDialog();
        }
    }
}
