using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace work6
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        // 抓取按钮点击事件
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            // 校验输入
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("请输入有效的URL地址！", "提示");
                return;
            }

            
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            try
            {
                // 防止重复点击
                btnFetch.Text = "抓取中...";
                btnFetch.Enabled = false;

                // 获取网页HTML内容
                string html = await client.GetStringAsync(url);

                // 正则提取手机号
                var phones = Regex.Matches(html, @"1[3-9]\d{9}")
                                  .Cast<Match>()
                                  .Select(m => m.Value)
                                  .Distinct()
                                  .ToList();

                // 正则提取邮箱
                var emails = Regex.Matches(html, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")
                                  .Cast<Match>()
                                  .Select(m => m.Value)
                                  .Distinct()
                                  .ToList();

                // 显示结果到界面
                txtPhone.Lines = phones.ToArray();
                txtEmail.Lines = emails.ToArray();

                
                MessageBox.Show($"抓取完成！\n找到 {phones.Count} 个手机号，{emails.Count} 个邮箱", "完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("抓取失败：" + ex.Message, "错误");
            }
            finally
            {
                // 9. 恢复按钮状态
                btnFetch.Enabled = true;
                btnFetch.Text = "开始抓取";
            }
        }
    }
}
