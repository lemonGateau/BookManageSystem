using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookManageSystem
{
    public partial class FormRentBook : FormBook
    {
        public FormRentBook()
        {
            InitializeComponent();
        }

        private void FormRentBook_Load(object sender, EventArgs e)
        {
            // ドロップダウンリストの設定
            var publisherList = MasterRepository.GetPublishers();
            var categoryList  = MasterRepository.GetCategories();
            var officeList    = MasterRepository.GetOffices();

            // リストの先頭に"すべて"の項目を追加
            categoryList.Insert(0, new Category { CategoryId = -1, Name = "すべてのカテゴリ" });
            publisherList.Insert(0, new Publisher { PublisherId = -1, Name = "すべての出版社" });
            officeList.Insert(0, new Office { OfficeId = -1, Name = "すべてのオフィス" });

            SetUpComboBox(comboBoxPublisher, publisherList, "Name", "PublisherId");
            SetUpComboBox(comboBoxCategory , categoryList , "Name", "CategoryId");
            SetUpComboBox(comboBoxOffice   , officeList   , "Name", "OfficeId");

            // グレーアウトの設定
            dataGridView1.CellFormatting += (s, e) => ApplyRowFormatting(dataGridView1, e);

            textBoxSearch.PlaceholderText = "タイトル、著者名で検索";

            // 表の初期化
            buttonSearch.PerformClick();

            // 不要カラムの非表示
            HideColumns(dataGridView1);

        }

        /// <summary>
        /// 書籍を抽出して表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string publisherName = comboBoxPublisher.Text;
            string categoryName  = comboBoxCategory.Text;
            string officeName    = comboBoxOffice.Text;

            // キーワードで検索
            dataGridView1.DataSource = BookRepository.GetFilteredBooks(textBoxSearch.Text, publisherName, categoryName, officeName);
        }

        /// <summary>
        /// 書籍の貸し出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRentBook_Click(object sender, EventArgs e)
        {
            // 空白行を選択している場合
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("借りる書籍を選択してください。");
                return;
            }

            // 選択された書籍
            BookSearchView selectedBook = (BookSearchView)dataGridView1.CurrentRow.DataBoundItem;

            // 書籍が貸出中の場合
            if (BookRepository.IsRented(selectedBook.ItemId))
            {
                if (MessageBox.Show("貸出中です。予約しますか", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 書籍を予約する
                    _ = ReservationRepository.ReserveBook(selectedBook.Isbn, LoginSession.userId);

                    MessageBox.Show("予約が完了しました。");
                }

                return;
            }
            else
            {
                if (MessageBox.Show($"{selectedBook.Title} を借りますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                // 書籍を借りる
                try
                {
                    _ = BookRepository.RentBook(selectedBook.ItemId, LoginSession.userId);

                    MessageBox.Show("貸出しました。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // 表の更新
                buttonSearch.PerformClick();
            }
        }
    }
}
