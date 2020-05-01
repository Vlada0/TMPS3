using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    abstract class Mediator
    {
        public abstract void Send(string message,
          Colleague colleague);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    class ConcreteMediator : Mediator
    {
        private PauseColleague pause;
        private PlayColleague play;

        public PauseColleague Pause
        {
            set { pause = value; }
        }

        public PlayColleague Play
        {
            set { play = value; }
        }

        public override void Send(string message,
          Colleague colleague)
        {
            if (colleague == pause)
            {
                play.Notify(message);
            }
            else
            {
                pause.Notify(message);
            }
        }
    }

    /// <summary>
    /// The 'Colleague' abstract class
    /// </summary>
    abstract class Colleague
    {
        protected Mediator mediator;

        // Constructor
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class PauseColleague : Colleague
    {
        // Constructor
        public PauseColleague(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Pause gets message from Play: "
              + message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class PlayColleague : Colleague
    {
        // Constructor
        public PlayColleague(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Play gets message from Pause: "
              + message);
        }
    }
}
