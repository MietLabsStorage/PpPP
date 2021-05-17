using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.States
{
    class Table
    {
        private static Table _instance;

        public static Dictionary<string, int> Value { get; private set; }

        private Table()
        {
            Value = new Dictionary<string, int>()
            {
                {"msk", 0},
                {"mzh", 1},
                {"zvn", 2},
                {"NN", 3},
                {"dzr", 4},
                {"vlg", 5},
                {"kam", 6}
            };
        }

        public static Table Instance()
        {
            if (_instance == null)
                _instance = new Table();
            return _instance;
        }
    }
}