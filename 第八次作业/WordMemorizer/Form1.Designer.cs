namespace WordMemorizer;

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
    private Label lblTitle;
    private Label lblChineseLabel;
    private Label lblChineseMeaning;
    private Label lblInputLabel;
    private TextBox txtEnglishInput;
    private Label lblResult;
    private Label lblProgress;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblChineseLabel = new System.Windows.Forms.Label();
        this.lblChineseMeaning = new System.Windows.Forms.Label();
        this.lblInputLabel = new System.Windows.Forms.Label();
        this.txtEnglishInput = new System.Windows.Forms.TextBox();
        this.lblResult = new System.Windows.Forms.Label();
        this.lblProgress = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(28, 24);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(255, 42);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "英语单词默写系统";
        // 
        // lblChineseLabel
        // 
        this.lblChineseLabel.AutoSize = true;
        this.lblChineseLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblChineseLabel.Location = new System.Drawing.Point(31, 101);
        this.lblChineseLabel.Name = "lblChineseLabel";
        this.lblChineseLabel.Size = new System.Drawing.Size(117, 28);
        this.lblChineseLabel.TabIndex = 1;
        this.lblChineseLabel.Text = "中文词义：";
        // 
        // lblChineseMeaning
        // 
        this.lblChineseMeaning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblChineseMeaning.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblChineseMeaning.Location = new System.Drawing.Point(31, 140);
        this.lblChineseMeaning.Name = "lblChineseMeaning";
        this.lblChineseMeaning.Size = new System.Drawing.Size(511, 80);
        this.lblChineseMeaning.TabIndex = 2;
        this.lblChineseMeaning.Text = "-";
        this.lblChineseMeaning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblInputLabel
        // 
        this.lblInputLabel.AutoSize = true;
        this.lblInputLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblInputLabel.Location = new System.Drawing.Point(31, 247);
        this.lblInputLabel.Name = "lblInputLabel";
        this.lblInputLabel.Size = new System.Drawing.Size(117, 28);
        this.lblInputLabel.TabIndex = 3;
        this.lblInputLabel.Text = "英文拼写：";
        // 
        // txtEnglishInput
        // 
        this.txtEnglishInput.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtEnglishInput.Location = new System.Drawing.Point(31, 286);
        this.txtEnglishInput.Name = "txtEnglishInput";
        this.txtEnglishInput.Size = new System.Drawing.Size(511, 40);
        this.txtEnglishInput.TabIndex = 4;
        this.txtEnglishInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEnglishInput_KeyDown);
        // 
        // lblResult
        // 
        this.lblResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblResult.Location = new System.Drawing.Point(31, 344);
        this.lblResult.Name = "lblResult";
        this.lblResult.Size = new System.Drawing.Size(511, 44);
        this.lblResult.TabIndex = 5;
        this.lblResult.Text = "请输入英文后按 Enter";
        this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblProgress
        // 
        this.lblProgress.AutoSize = true;
        this.lblProgress.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblProgress.Location = new System.Drawing.Point(398, 38);
        this.lblProgress.Name = "lblProgress";
        this.lblProgress.Size = new System.Drawing.Size(144, 24);
        this.lblProgress.TabIndex = 6;
        this.lblProgress.Text = "第 0 / 0 个单词";
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(584, 421);
        this.Controls.Add(this.lblProgress);
        this.Controls.Add(this.lblResult);
        this.Controls.Add(this.txtEnglishInput);
        this.Controls.Add(this.lblInputLabel);
        this.Controls.Add(this.lblChineseMeaning);
        this.Controls.Add(this.lblChineseLabel);
        this.Controls.Add(this.lblTitle);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "背单词程序";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
