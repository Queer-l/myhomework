using System;
using System.Threading;


public class AlarmClock
{
    // 嘀嗒事件
    public event EventHandler Tick;
    // 响铃事件
    public event EventHandler Alarm;

    // 闹钟当前时间
    public DateTime CurrentTime { get; private set; }
    // 闹钟设定时间
    public DateTime AlarmTime { get; set; }

    public AlarmClock(DateTime alarmTime)
    {
        CurrentTime = DateTime.Now;
        AlarmTime = alarmTime;
    }

    // 触发嘀嗒事件
    protected virtual void OnTick(EventArgs e)
    {
        Tick?.Invoke(this, e);
    }

    // 触发响铃事件
    protected virtual void OnAlarm(EventArgs e)
    {
        Alarm?.Invoke(this, e);
    }

    // 启动闹钟
    public void Start()
    {
        while (true)
        {
            CurrentTime = DateTime.Now;
            OnTick(EventArgs.Empty); 

            // 判断是否到达响铃时间
            if (Math.Abs((CurrentTime - AlarmTime).TotalSeconds) < 1)
            {
                OnAlarm(EventArgs.Empty); 
                break; 
            }

            Thread.Sleep(1000); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 设置5秒后响铃
        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        AlarmClock clock = new AlarmClock(alarmTime);

        // 订阅嘀嗒事件
        clock.Tick += (sender, e) =>
        {
            Console.WriteLine($"[{clock.CurrentTime:HH:mm:ss}] 嘀嗒...");
        };

        // 订阅响铃事件
        clock.Alarm += (sender, e) =>
        {
            Console.WriteLine($"[{clock.CurrentTime:HH:mm:ss}] 🔔 闹钟响了！！！");
        };

        Console.WriteLine($"闹钟已设定，将在 {alarmTime:HH:mm:ss} 响铃...\n");
        clock.Start();
    }
}
