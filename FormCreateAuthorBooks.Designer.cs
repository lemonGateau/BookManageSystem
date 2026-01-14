namespace BookManageSystem
{
    partial class FormCreateAuthorBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCreateAuthorBooks = new Button();
            textBoxLastName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxFirstName = new TextBox();
            label3 = new Label();
            textBoxIsbn = new TextBox();
            SuspendLayout();
            // 
            // buttonCreateAuthorBooks
            // 
            buttonCreateAuthorBooks.Location = new Point(362, 507);
            buttonCreateAuthorBooks.Margin = new Padding(3, 4, 3, 4);
            buttonCreateAuthorBooks.Name = "buttonCreateAuthorBooks";
            buttonCreateAuthorBooks.Size = new Size(122, 43);
            buttonCreateAuthorBooks.TabIndex = 13;
            buttonCreateAuthorBooks.Text = "登録";
            buttonCreateAuthorBooks.UseVisualStyleBackColor = true;
            buttonCreateAuthorBooks.Click += buttonCreateAuthorBooks_Click;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(210, 254);
            textBoxLastName.Margin = new Padding(3, 4, 3, 4);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(145, 31);
            textBoxLastName.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 254);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 11;
            label1.Text = "著者名(苗字)*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(438, 254);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 14;
            label2.Text = "(名前)*";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(542, 254);
            textBoxFirstName.Margin = new Padding(3, 4, 3, 4);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(145, 31);
            textBoxFirstName.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 157);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 15;
            label3.Text = "ISBN*";
            // 
            // textBoxIsbn
            // 
            textBoxIsbn.Location = new Point(210, 154);
            textBoxIsbn.Name = "textBoxIsbn";
            textBoxIsbn.Size = new Size(477, 31);
            textBoxIsbn.TabIndex = 16;
            // 
            // FormCreateAuthorBooks
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 609);
            Controls.Add(textBoxIsbn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonCreateAuthorBooks);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxLastName);
            Controls.Add(label1);
            Name = "FormCreateAuthorBooks";
            Text = "FormCreateAuthorBooks";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreateAuthorBooks;
        private TextBox textBoxLastName;
        private Label label1;
        private Label label2;
        private TextBox textBoxFirstName;
        private Label label3;
        private TextBox textBoxIsbn;
    }
}