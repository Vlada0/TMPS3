using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class OnlineStrategy : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Watching film online");
        }
    }

    public class OfflineStrategy : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Watching film offline");
        }
    }

    public class ContextFilm
    {
        private IStrategy _strategy;

        public ContextFilm(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }
}
