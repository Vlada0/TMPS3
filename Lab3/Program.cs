using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //chain of responsibility
            Console.WriteLine("Pattern Chain of responsibility\n");
            PlayHandler h1 = new AVIPlayHandler();
            PlayHandler h2 = new MP4PlayHandler();
            PlayHandler h3 = new MOVPlayHandler();
            
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            string[] formats = { "AVI", "MOV", "MOV", "MP4", "AVI", "MP4" };
            foreach (string format in formats)
            {
                h1.PlayRequest(format);
            }

            //command
            Console.WriteLine("\n\nPattern Command\n");
            InvokerCommand iCommand = new InvokerCommand();
            Film film = new Film("Titanic");

            bool exit = true;
            while (exit)
            {
                Console.WriteLine("Enter action (play/pause/stop)");
                string invoke = Console.ReadLine();
                switch (invoke)
                {
                    case "play":
                        iCommand.ExecuteCommand(new PlayCommand(film));
                        break;
                    case "pause":
                        iCommand.ExecuteCommand(new PauseCommand(film));
                        break;
                    case "stop":
                        iCommand.ExecuteCommand(new StopCommand(film));
                        break;
                    case "exit":
                        exit = false;
                        break;
                    default:
                        throw new Exception("Неверный выбор!!!");
                }
            }

            //mediator
            Console.WriteLine("\n\nPattern Mediator\n");
            ConcreteMediator m = new ConcreteMediator();

            PauseColleague c1 = new PauseColleague(m);
            PlayColleague c2 = new PlayColleague(m);

            m.Pause = c1;
            m.Play = c2;

            c1.Send("Pause is pressed");
            c2.Send("Play is pressed");

            //memento
            Console.WriteLine("\n\nPattern Memento\n");
            OriginatorFilm o = new OriginatorFilm();
            o.State = "Play";
            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();
            // Continue changing originator
            o.State = "Stop";
            // Restore saved state
            o.SetMemento(c.Memento);
            // Continue changing originator
            o.State = "Pause";
            // Restore saved state
            o.SetMemento(c.Memento);

            //strategy
            Console.WriteLine("\n\nPattern Strategy\n");
            ContextFilm context = new ContextFilm(new OnlineStrategy());
            context.ExecuteOperation();
            context.SetStrategy(new OfflineStrategy());
            context.ExecuteOperation();

            // Wait for user
            Console.ReadKey();
        }
    }
}
