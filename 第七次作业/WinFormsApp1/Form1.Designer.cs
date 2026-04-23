namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearch = new Button();
            txtKeyword = new TextBox();
            txtBaidu = new TextBox();
            txtBing = new TextBox();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(329, 285);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "开始搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(309, 325);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(150, 30);
            txtKeyword.TabIndex = 1;
            // 
            // txtBaidu
            // 
            txtBaidu.Location = new Point(97, 108);
            txtBaidu.Multiline = true;
            txtBaidu.Name = "txtBaidu";
            txtBaidu.ScrollBars = ScrollBars.Vertical;
            txtBaidu.Size = new Size(193, 315);
            txtBaidu.TabIndex = 2;
            // 
            // txtBing
            // 
            txtBing.Location = new Point(529, 98);
            txtBing.Multiline = true;
            txtBing.Name = "txtBing";
            txtBing.ScrollBars = ScrollBars.Vertical;
            txtBing.Size = new Size(201, 310);
            txtBing.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBing);
            Controls.Add(txtBaidu);
            Controls.Add(txtKeyword);
            Controls.Add(btnSearch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private TextBox txtKeyword;
        private TextBox txtBaidu;
        private TextBox txtBing;
    }
}
