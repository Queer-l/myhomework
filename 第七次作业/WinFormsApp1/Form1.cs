using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            // 设置请求头，模拟浏览器，避免被反爬拦截
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
        }

        // 按钮点击事件，设计器双击按钮会自动生成
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键词！");
                return;
            }

            // 清空之前的结果
            txtBaidu.Clear();
            txtBing.Clear();
            btnSearch.Enabled = false;

            try
            {
                // 并行执行两个搜索任务
                var baiduTask = GetBaiduSummaryAsync(keyword);
                var bingTask = GetBingSummaryAsync(keyword);

                // 等待任务完成并更新UI
                string baiduResult = await baiduTask;
                string bingResult = await bingTask;

                txtBaidu.Text = baiduResult;
                txtBing.Text = bingResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"出错了：{ex.Message}");
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        // 百度搜索并提取前200字
        private async Task<string> GetBaiduSummaryAsync(string keyword)
        {
            string url = $"https://www.baidu.com/s?wd={Uri.EscapeDataString(keyword)}";
            string html = await _httpClient.GetStringAsync(url);

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // 百度结果摘要节点
            var node = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'c-abstract')]")
                        ?? doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'result-op')]//h3");

            if (node != null)
            {
                string text = node.InnerText.Trim();
                return text.Length > 200 ? text.Substring(0, 200) + "..." : text;
            }
            return "百度未找到相关摘要";
        }

        // 必应搜索并提取前200字
        private async Task<string> GetBingSummaryAsync(string keyword)
        {
            string url = $"https://www.bing.com/search?q={Uri.EscapeDataString(keyword)}";
            string html = await _httpClient.GetStringAsync(url);

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // 必应结果摘要节点
            var node = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'b_caption')]/p")
                        ?? doc.DocumentNode.SelectSingleNode("//li[contains(@class, 'b_algo')]//h2");

            if (node != null)
            {
                string text = node.InnerText.Trim();
                return text.Length > 200 ? text.Substring(0, 200) + "..." : text;
            }
            return "必应未找到相关摘要";
        }
    }
}
