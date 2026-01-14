using System;
using System.Collections.Generic;
using System.Text;

namespace BookManageSystem
{
    public class BookSearchView
    {
        // 識別用
        public int ItemId { get; set; }
        public int HistoryId { get; set; }

        // 表示用
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string OfficeName { get; set; } = null!;
        public string RackId { get; set; } = null!;

        // 状態フラグ
        public bool IsRented { get; set; }
    }
}
