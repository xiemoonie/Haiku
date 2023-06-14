using System;
using System.Collections.Generic;
using System.Text;
//State Pattern Design Patter
namespace RandomHaikuGenerator
{
    public class Computer
    {
        ComputerState _currentState;

        public Computer()
        {
            _currentState = new OffState();
        }
        public void PressPowerButton()
        {
            _currentState.PressPowerButton(this);
        }
        public void SetState(ComputerState state)
        {
            _currentState= state;
        }
       
    }
    public interface ComputerState
    {
        void PressPowerButton(Computer computer);
    }

    public class OnState : ComputerState
    {
        public void PressPowerButton(Computer computer) {
            Console.WriteLine("Computer is already on. Going to sleep mode...");
            computer.SetState(new SleepState());
        }

    }

    public class OffState : ComputerState
    {
        public void PressPowerButton(Computer computer) {
            Console.WriteLine("Turning on Computer");
            computer.SetState(new OnState());
        }

    }
    public class SleepState : ComputerState
    {
        public void PressPowerButton(Computer computer) {
            Console.WriteLine("Waking up computer");
            computer.SetState(new OnState());
        }

    }




}
