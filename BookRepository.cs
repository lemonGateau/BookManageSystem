using System;
using System.Collections.Generic;
using System.Text;

namespace BookManageSystem
{
    public static class BookRepository
    {
        /// <summary>
        /// bookテーブル、book_itemテーブルに書籍を登録する
        /// </summary>
        /// <param name="book"></param>
        /// <param name="bookItem"></param>
        /// <returns>itemId</returns>
        public static int CreateBook(Book book, BookItem bookItem)
        {
            using var db = new BookDBContext();

            // 書籍が未登録の場合
            if (!db.Books.Any(b => b.Isbn == book.Isbn))
            {
                db.Books.Add(book);
            }

            // 保管場所を登録
            db.BookItems.Add(bookItem);

            db.SaveChanges();

            return bookItem.ItemId;
        }

        /// <summary>
        /// 蔵書を削除する
        /// </summary>
        /// <param name="itemId"></param>
        public static void DeleteBook(int itemId)
        {
            using var db = new BookDBContext();
            var bookItem = db.BookItems.Find(itemId);

            if (bookItem != null)
            {
                bookItem.IsDeleted = true;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 貸出履歴を登録する
        /// </summary>
        /// <param name="itemId"></param>
        public static int RentBook(int itemId, int userId)
        {
            using var db = new BookDBContext();
            var history = new RentalHistory { ItemId = itemId, UserId = userId, RentalDate = DateTime.Today };

            db.RentalHistories.Add(history);
            db.SaveChanges();

            return history.HistoryId;
        }

        /// <summary>
        /// 返却日を登録する
        /// </summary>
        /// <param name="historyId"></param>
        public static void ReturnBook(int historyId)
        {
            using var db = new BookDBContext();
            var history = db.RentalHistories.Find(historyId);

            if (history == null)
            {
                throw new Exception("履歴が見当たりません");
            }

            history.ReturnDate = DateTime.Today;
            db.SaveChanges();
        }

        /// <summary>
        /// 書籍が登録済みか
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public static bool IsExistsBook(string isbn)
        {
            using var db = new BookDBContext();

            return db.Books.Any(b => b.Isbn == isbn);
        }

        /// <summary>
        /// 貸し出し中か
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static bool IsRented(int itemId)
        {
            using var db = new BookDBContext();

            return db.RentalHistories.Any(h => h.ItemId == itemId && h.ReturnDate == null);
        }

        /// <summary>
        /// キーワードで検索し、項目で絞り込む
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="publisherName"></param>
        /// <param name="categoryName"></param>
        /// <param name="officeName"></param>
        /// <returns></returns>
        public static List<BookSearchView> GetFilteredBooks(string keyword, string publisherName, string categoryName, string officeName)
        {
            var searchedBooks = new List<BookSearchView>();

            // キーワード検索（タイトルと著者）
            searchedBooks.AddRange(GetBookSearchViewByTitle(keyword));
            searchedBooks.AddRange(GetBookSearchViewByAuthor(keyword));

            return searchedBooks
                .DistinctBy(b => b.ItemId)
                .Where(b => (publisherName == "すべての出版社"   || b.PublisherName == publisherName))
                .Where(b => (categoryName  == "すべてのカテゴリ" || b.CategoryName  == categoryName))
                .Where(b => (officeName    == "すべてのオフィス" || b.OfficeName    == officeName))
                .ToList();
        }

        /// <summary>
        /// 書籍をタイトルで検索する
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static List<BookSearchView> GetBookSearchViewByTitle(string title)
        {
            // 空白除去
            title = title.Replace(" ", "").Replace("　", "");

            using var db = new BookDBContext();

            return db.BookItems
                .Where(bi => !bi.IsDeleted && bi.Book.Title.Contains(title))
                .OrderBy(bi => bi.Book.Isbn)
                .ThenBy(bi => bi.ItemId)
                .Select(bi => new BookSearchView
                {
                    ItemId        = bi.ItemId,
                    Isbn          = bi.Isbn,
                    Title         = bi.Book.Title,
                    PublisherName = bi.Book.Publisher.Name,
                    CategoryName  = bi.Book.Category.Name,
                    OfficeName    = bi.Office.Name,
                    RackId        = bi.RackId,
                    IsRented      = db.RentalHistories.Any(h => h.ItemId == bi.ItemId && h.ReturnDate == null)
                })
                .OrderBy(bi => bi.ItemId)
                .ToList();
        }

        /// <summary>
        /// 書籍を著者IDで検索する
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static List<BookSearchView> GetBookSearchViewByAuthor(string name)
        {
            // 空白除去
            name = name.Replace(" ", "").Replace("　", "");

            using var db = new BookDBContext();

            // 名前に合致する著者が書いた本のISBNリストを取得する
            var targetIsbns = db.AuthorBooks
                .Where(ab => (ab.Author.LastName + ab.Author.FirstName).Contains(name))
                .Select(ab => ab.Isbn)
                .Distinct()
                .ToList();

            return db.BookItems
                .Where(bi => !bi.IsDeleted && targetIsbns.Contains(bi.Isbn))
                .OrderBy(bi => bi.Book.Isbn)
                .ThenBy(bi => bi.ItemId)
                .Select(bi => new BookSearchView
                {
                    ItemId        = bi.ItemId,
                    Isbn          = bi.Isbn,
                    Title         = bi.Book.Title,
                    PublisherName = bi.Book.Publisher.Name,
                    CategoryName  = bi.Book.Category.Name,
                    OfficeName    = bi.Office.Name,
                    RackId        = bi.RackId,
                    IsRented      = db.RentalHistories.Any(h => h.ItemId == bi.ItemId && h.ReturnDate == null)
                })
                .OrderBy(bi => bi.ItemId)
                .ToList();
        }

        /// <summary>
        /// 貸し出し中の書籍一覧を取得する
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<BookSearchView> GetRentingBooks(int userId)
        {
            using var db = new BookDBContext();

            return db.RentalHistories
                .Where(h => h.UserId == userId && h.ReturnDate == null)
                .Where(h => !h.BookItem.IsDeleted)
                .Select(h => new BookSearchView
                {
                    ItemId        = h.ItemId,
                    HistoryId     = h.HistoryId,
                    Isbn          = h.BookItem.Isbn,
                    Title         = h.BookItem.Book.Title,
                    PublisherName = h.BookItem.Book.Publisher.Name,
                    CategoryName  = h.BookItem.Book.Category.Name,
                    OfficeName    = h.BookItem.Office.Name,
                    RackId        = h.BookItem.RackId,
                    IsRented      = true
                })
                .OrderBy(r => r.ItemId)
                .ToList();
        }

        /// <summary>
        /// ランキングを取得する
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<RentalRanking> GetRentalRanking(int num = 5)
        {
            using var db = new BookDBContext();

            return db.RentalHistories
                .GroupBy(h => new { h.BookItem.Book.Isbn, h.BookItem.Book.Title })
                .Select(g => new RentalRanking { Title = g.Key.Title, Count = g.Count() })
                .OrderByDescending(r => r.Count)
                .ThenBy(r => r.Title)
                .Take(num)
                .ToList();
        }
    }
}
