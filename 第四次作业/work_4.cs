using System;
using System.IO;

class FileMergeTool
{
    static void Main()
    {
        try
        {
            // 文件路径
            string file1 = @"file1.txt";
            string file2 = @"file2.txt";

            // 读取内容
            string c1 = File.ReadAllText(file1);
            string c2 = File.ReadAllText(file2);
            string merge = c1 + Environment.NewLine + c2;

            // 输出目录
            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(outDir);
            string outFile = Path.Combine(outDir, "merged.txt");

            // 写入文件
            File.WriteAllText(outFile, merge);
            Console.WriteLine("合并成功：" + outFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("错误：" + ex.Message);
        }
    }
}