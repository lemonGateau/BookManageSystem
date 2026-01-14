using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormRentalRanking : Form
    {
        public FormRentalRanking()
        {
            InitializeComponent();
        }

        private void FormRentalRanking_Load(object sender, EventArgs e)
        {
            // 書籍の抽出
            dataGridView1.DataSource = BookRepository.GetRentalRanking(100);
            dataGridView1.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
