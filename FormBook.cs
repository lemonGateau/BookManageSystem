using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormBook : Form
    {
        protected void SetUpComboBox<T>(ComboBox combo, IEnumerable<T> list, string displayMember, string valueMember)
        {
            // 項目リストを設定
            combo.DataSource = list;

            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
        }

        protected void HideColumns(DataGridView dgv)
        {
            dgv.Columns["ItemId"].Visible = false;
            dgv.Columns["HistoryId"].Visible = false;
            dgv.Columns["IsRented"].Visible = false;
        }

        // グレーアウト処理
        protected void ApplyRowFormatting(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgv.NewRowIndex) return;

            // 現在の行のデータオブジェクト（BookSearchView）を取得
            BookSearchView book = (BookSearchView)dgv.Rows[e.RowIndex].DataBoundItem;

            if (book != null && book.IsRented)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.ForeColor = Color.DimGray;
                e.CellStyle.SelectionBackColor = Color.DarkGray;
            }
        }
    }
}
