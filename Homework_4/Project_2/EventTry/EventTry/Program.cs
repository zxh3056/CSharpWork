using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventTry
{
    
    class Clock
    {
        public delegate void ClockAlarm();
        public delegate void ClockTick();
        public event ClockAlarm clockAlarm;
        public event ClockTick clockTick;
        public int alarmHour, alarmMinute, alarmSecond = 0;
        public void SetAlarm(int hour,int minute,int second)
        {
            alarmHour = hour;
            alarmMinute = minute;
            alarmSecond = second;
        }
        public void Tick()
        {
            clockTick();
        }
        public void Alarm()
        {
            clockAlarm();
        }
    }
    class ClockStart//闹钟的启动程序
    {
       public Clock clock = new Clock();
       
        public void Start()
        {
          
            while (true)
            {
                clock.Tick();
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                if (clock.alarmHour == hour && clock.alarmMinute == minute && clock.alarmSecond == second)
                {
                    clock.Alarm();
                }
                Thread.Sleep(1000);
            }
            
        }
      
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClockStart clockstart = new ClockStart();
            clockstart.clock.clockAlarm += Alarming;
            clockstart.clock.clockTick += Ticking;
            clockstart.clock.SetAlarm(15, 10, 30);
            clockstart.Start();
        }
        public static void Alarming()
        {
            Console.WriteLine("闹钟响了！！！！！！！");
        }
        public static void Ticking()
        {
            Console.WriteLine("滴答");
        }
    }
}
