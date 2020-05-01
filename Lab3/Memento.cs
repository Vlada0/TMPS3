using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// The 'Originator' class
    /// </summary>
    class OriginatorFilm
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        // Creates memento
        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        // Restores original state
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
