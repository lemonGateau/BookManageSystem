using System;
using System.Collections.Generic;
using System.Text;

namespace BookManageSystem
{
    public static class MasterRepository
    {
        /// <summary>
        /// 出版社を登録する
        /// </summary>
        /// <param name="publisher"></param>
        public static int CreatePublisher(Publisher publisher)
        {
            using var db = new BookDBContext();

            var existingPublisher = db.Publishers.FirstOrDefault(p => p.Name == publisher.Name);

            // 登録済みの場合
            if (existingPublisher != null)
            {
                return existingPublisher.PublisherId;
            }

            db.Publishers.Add(publisher);

            db.SaveChanges();

            return publisher.PublisherId;
        }

        /// <summary>
        /// カテゴリを登録する
        /// </summary>
        /// <param name="category"></param>
        public static int CreateCategory(Category category)
        {
            using var db = new BookDBContext();

            var existingCategory = db.Categories.FirstOrDefault(p => p.Name == category.Name);

            // 登録済みの場合
            if (existingCategory != null)
            {
                return existingCategory.CategoryId;
            }

            db.Categories.Add(category);

            db.SaveChanges();

            return category.CategoryId;
        }

        /// <summary>
        /// 著者を登録する
        /// </summary>
        /// <param name="author"></param>
        /// <returns>author_id</returns>
        public static int CreateAuthor(Author author)
        {
            using var db = new BookDBContext();

            // 著者が登録済みの場合
            var existingAuthor = db.Authors.FirstOrDefault(a => a.LastName == author.LastName && a.FirstName == author.FirstName);
            if (existingAuthor != null)
            {
                return existingAuthor.AuthorId;
            }

            // 著者を登録
            db.Authors.Add(author);

            db.SaveChanges();

            return author.AuthorId;
        }

        /// <summary>
        /// 著者と書籍の関係を登録する
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author_id"></param>
        public static bool CreateAuthorBooks(string isbn, int authorId)
        {
            using var db = new BookDBContext();

            // 書籍、著者が未登録の場合
            if (!db.Books.Any(b => b.Isbn == isbn) || !db.Authors.Any(a => a.AuthorId == authorId))
            {
                return false;
            }

            // 著者と書籍の関係が未登録の場合
            if (!db.AuthorBooks.Any(ab => ab.Isbn == isbn && ab.AuthorId == authorId))
            {
                db.AuthorBooks.Add(new AuthorBook { Isbn = isbn, AuthorId = authorId });
                db.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// 著者が登録済みか
        /// </summary>
        /// <param name="author_id"></param>
        /// <returns></returns>
        public static bool IsExistsAuthor(string lastName, string firstName)
        {
            using var db = new BookDBContext();

            return db.Authors.Any(a => a.LastName == lastName && a.FirstName == firstName);
        }

        /// <summary>
        /// 著者が書籍に割り当てられているか
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author_id"></param>
        /// <returns></returns>
        public static bool IsExistsAuthorBooks(string isbn, int authorId)
        {
            using var db = new BookDBContext();

            return db.AuthorBooks.Any(ab => ab.Isbn == isbn && ab.AuthorId == authorId);
        }

        /// <summary>
        /// 出版社一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static List<Publisher> GetPublishers()
        {
            using var db = new BookDBContext();

            return db.Publishers
                .OrderBy(p => p.PublisherId)
                .ToList();
        }

        /// <summary>
        /// カテゴリ一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetCategories()
        {
            using var db = new BookDBContext();

            return db.Categories
                .OrderBy(c => c.CategoryId)
                .ToList();
        }

        /// <summary>
        /// 著者一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static List<Author> GetAuthors()
        {
            using var db = new BookDBContext();

            return db.Authors
                .OrderBy(a => a.AuthorId)
                .ToList();
        }

        /// <summary>
        /// オフィス一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static List<Office> GetOffices()
        {
            using var db = new BookDBContext();

            return db.Offices
                .OrderBy(o => o.OfficeId)
                .ToList();
        }

        /// <summary>
        /// ラック一覧を取得する
        /// </summary>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public static List<Rack> GetRacks(int officeId)
        {
            using var db = new BookDBContext();

            return db.Racks
                .Where(r => r.OfficeId == officeId)
                .OrderBy(r => r.RackId)
                .ToList();
        }

        /// <summary>
        /// 社員一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetEmployees()
        {
            using var db = new BookDBContext();

            return db.Employees
                .OrderBy(e => e.UserId)
                .ToList();
        }

        /// <summary>
        /// ハッシュ化パスワードを取得する
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string? GetHashedPassword(int userId)
        {
            using var db = new BookDBContext();

            return db.Employees
                .Where(e => e.UserId == userId)
                .Select(e => e.Password)
                .FirstOrDefault();
        }
    }
}
