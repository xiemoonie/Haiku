using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RandomHaikuGenerator
{

    public interface ITimer
    {
        event TimerEvent OnTick;
        double Interval { get; set; }
        bool Enabled { get; set; }
        bool Autoreset { get; set; }

        void Start();
        void Stop();
        void Dispose();
    }
    public delegate void TimerEvent();
    public class TimerCook
    {
        public ITimer timer { get; set; }
        public TimerCook(ITimer timer)
        {
            this.timer = timer;
        }
        public void TimeToCook()
        {
            timer.OnTick += () =>
            {
                Console.WriteLine("Hey Something happened here on time!");
            };
            timer.Interval = 1 * 60000;

            timer.Autoreset = true;
            timer.Enabled = true;
            timer.Start();
        }

        public void TimeToCookMock(MockTimer mt)
        {
            mt.OnTick += () =>
            {
                Console.WriteLine("Hey Something happened here on time!");
            };
           
            mt.Start();
        }
    }

    public class MockTimer : ITimer
    {
        bool enabled = false;
        double interval = 1;
        bool autoreset = false;
        public double Interval { get =>interval; set => interval = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public bool Autoreset { get => autoreset; set => autoreset = value; }

        public event TimerEvent OnTick;

        public void Dispose()
        {
         
        }

        public void Start()
        {
      
        }

        public void Stop()
        {
         
        }
        public void Tick()
        {
            OnTick();
        }
    }


}
