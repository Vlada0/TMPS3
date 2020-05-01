using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public abstract class Command
    {
        public abstract void Execute();
    }

    public class Film
    {
        private string title;
        public Film(string ftitle)
        {
            this.title = ftitle;
        }

        public void Play()
        {
            Console.WriteLine(this.title + " play");
        }
        public void Stop()
        {
            Console.WriteLine(this.title + " stop");
        }
        public void Pause()
        {
            Console.WriteLine(this.title + " pause");
        }
    }

    //ConcreteCommand
    public class PlayCommand : Command
    {
        private Film film;

        public PlayCommand(Film f)
        {
            this.film = f;
        }
        public override void Execute()
        {
            film.Play();
        }
    }

    //ConcreteCommand
    public class PauseCommand : Command
    {
        private Film film;

        public PauseCommand(Film f)
        {
            this.film = f;
        }
        public override void Execute()
        {
            film.Pause();
        }
    }

    //ConcreteCommand
    public class StopCommand : Command
    {
        private Film film;

        public StopCommand(Film f)
        {
            this.film = f;
        }
        public override void Execute()
        {
            film.Stop();
        }
    }


    public class InvokerCommand
    {
        // private Command cmd;
        public void ExecuteCommand(Command cmd)
        {
            cmd.Execute();
        }
    }
}
