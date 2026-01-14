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
    public partial class FormCreateCategory : Form
    {
        public FormCreateCategory()
        {
            InitializeComponent();
        }

        private void buttonCreateCategory_Click(object sender, EventArgs e)
        {
            // 空白の場合
            if (string.IsNullOrWhiteSpace(textBoxCategory.Text))
            {
                return;
            }

            try
            {
                _ = MasterRepository.CreateCategory(new Category(textBoxCategory.Text));

                MessageBox.Show("登録が完了しました");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
