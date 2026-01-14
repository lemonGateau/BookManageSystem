using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormReturnBook : FormBook
    {
        public FormReturnBook()
        {
            InitializeComponent();
        }

        private void FormReturnBook_Load(object sender, EventArgs e)
        {
            // ユーザが借りている書籍の一覧
            dataGridView1.DataSource = BookRepository.GetRentingBooks(LoginSession.userId);

            HideColumns(dataGridView1);
        }

        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            // 空白行を選択している場合
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("返却する書籍を選択してください。", "通知");
                return;
            }

            // 選択された書籍
            BookSearchView selectedBook = (BookSearchView)dataGridView1.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"{selectedBook.Title} を返しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                // 書籍を返却
                BookRepository.ReturnBook(selectedBook.HistoryId);

                MessageBox.Show("返却しました。");

                // 1番目の予約
                var reservation = ReservationRepository.GetReservations(isbn: selectedBook.Isbn, statusId: (int)StatusId.Reserved).LastOrDefault();

                // 予約者に貸出
                if (reservation != null)
                {
                    BookRepository.RentBook(selectedBook.ItemId, reservation.UserId);

                    ReservationRepository.CompleteReservation(reservation.ReservationId);
                }

                // 更新
                FormReturnBook_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
