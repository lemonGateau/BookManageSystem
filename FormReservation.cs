using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormReservation : Form
    {
        public FormReservation()
        {
            InitializeComponent();
        }

        private void FormReservation_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReservationRepository.GetReservationViews(userId: LoginSession.userId);

            dataGridView1.Columns["ReservationId"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["StatusId"].Visible = false;

            // グレーアウトの設定
            dataGridView1.CellFormatting += (s, e) => ApplyRowFormatting(dataGridView1, e);
        }

        private void buttonCancelReservation_Click(object sender, EventArgs e)
        {
            // 空白行を選択している場合
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("キャンセルする予約を選択してください。", "通知");
                return;
            }

            // 選択された予約
            var reservation = (ReservationView)dataGridView1.CurrentRow.DataBoundItem;

            // 予約をキャンセルする
            try
            {
                if (reservation.StatusId == (int)StatusId.Reserved)
                {
                    ReservationRepository.CancelReservation(reservation.ReservationId);

                    MessageBox.Show("予約をキャンセルしました。");

                    // 表の更新
                    dataGridView1.DataSource = ReservationRepository.GetReservationViews(userId: LoginSession.userId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // グレーアウト処理
        protected void ApplyRowFormatting(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgv.NewRowIndex) return;

            // 現在の行のデータオブジェクト（ReservationView）を取得
            ReservationView reservation = (ReservationView)dgv.Rows[e.RowIndex].DataBoundItem;

            if (reservation != null && reservation.StatusId != (int)StatusId.Reserved)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.ForeColor = Color.DimGray;
                e.CellStyle.SelectionBackColor = Color.DarkGray;
            }
        }
    }
}
