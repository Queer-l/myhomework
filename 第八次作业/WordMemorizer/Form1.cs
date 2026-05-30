using Microsoft.Data.Sqlite;

namespace WordMemorizer;

public partial class Form1 : Form
{
    private readonly string _dbPath = Path.Combine(Application.StartupPath, "words.db");
    private readonly List<WordItem> _words = new();
    private int _currentIndex;

    public Form1()
    {
        InitializeComponent();
        InitializeDatabase();
        LoadWords();
        ShowCurrentWord();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection($"Data Source={_dbPath}");
        connection.Open();

        var createCommand = connection.CreateCommand();
        createCommand.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Words (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                English TEXT NOT NULL UNIQUE,
                Chinese TEXT NOT NULL
            );
            """;
        createCommand.ExecuteNonQuery();

        var countCommand = connection.CreateCommand();
        countCommand.CommandText = "SELECT COUNT(*) FROM Words;";
        var count = Convert.ToInt32(countCommand.ExecuteScalar());

        if (count > 0)
        {
            return;
        }

        var seedWords = new List<WordItem>
        {
            new("apple", "苹果"),
            new("book", "书"),
            new("computer", "计算机"),
            new("teacher", "老师"),
            new("student", "学生"),
            new("morning", "早晨"),
            new("friend", "朋友"),
            new("water", "水"),
            new("school", "学校"),
            new("happy", "高兴的")
        };

        using var transaction = connection.BeginTransaction();
        foreach (var word in seedWords)
        {
            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO Words (English, Chinese) VALUES ($english, $chinese);";
            insertCommand.Parameters.AddWithValue("$english", word.English);
            insertCommand.Parameters.AddWithValue("$chinese", word.Chinese);
            insertCommand.ExecuteNonQuery();
        }

        transaction.Commit();
    }

    private void LoadWords()
    {
        _words.Clear();
        using var connection = new SqliteConnection($"Data Source={_dbPath}");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT English, Chinese FROM Words ORDER BY Id;";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            _words.Add(new WordItem(reader.GetString(0), reader.GetString(1)));
        }
    }

    private void ShowCurrentWord()
    {
        if (_words.Count == 0)
        {
            lblChineseMeaning.Text = "数据库中没有单词";
            lblProgress.Text = "第 0 / 0 个单词";
            txtEnglishInput.Enabled = false;
            lblResult.Text = "请先在数据库添加单词";
            lblResult.ForeColor = Color.DarkOrange;
            return;
        }

        var current = _words[_currentIndex];
        lblChineseMeaning.Text = current.Chinese;
        lblProgress.Text = $"第 {_currentIndex + 1} / {_words.Count} 个单词";
        txtEnglishInput.Text = string.Empty;
        txtEnglishInput.Focus();
    }

    private void TxtEnglishInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter || _words.Count == 0)
        {
            return;
        }

        e.SuppressKeyPress = true;
        CheckInput();
    }

    private void CheckInput()
    {
        var userInput = txtEnglishInput.Text.Trim();
        var answer = _words[_currentIndex].English;

        if (string.Equals(userInput, answer, StringComparison.OrdinalIgnoreCase))
        {
            lblResult.Text = "正确";
            lblResult.ForeColor = Color.Green;
        }
        else
        {
            lblResult.Text = $"错误（正确答案：{answer}）";
            lblResult.ForeColor = Color.Red;
        }

        _currentIndex++;
        if (_currentIndex >= _words.Count)
        {
            _currentIndex = 0;
        }

        ShowCurrentWord();
    }

    private sealed record WordItem(string English, string Chinese);
}
