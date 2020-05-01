using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class PlayHandler
    {
        protected PlayHandler successor;

        public void SetSuccessor(PlayHandler successor)
        {
            this.successor = successor;
        }

        public abstract void PlayRequest(string format);
    }

    /// <summary>
    /// The 'ConcreteHandler1' class
    /// </summary>
    class AVIPlayHandler : PlayHandler
    {
        public override void PlayRequest(string format)
        {
            if (format == "AVI")
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, format);
            }
            else if (successor != null)
            {
                successor.PlayRequest(format);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler2' class
    /// </summary>
    class MP4PlayHandler : PlayHandler
    {
        public override void PlayRequest(string format)
        {
            if (format == "MP4")
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, format);
            }
            else if (successor != null)
            {
                successor.PlayRequest(format);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler3' class
    /// </summary>
    class MOVPlayHandler : PlayHandler
    {
        public override void PlayRequest(string format)
        {
            if (format == "MOV")
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, format);
            }
            else if (successor != null)
            {
                successor.PlayRequest(format);
            }
        }
    }
}
