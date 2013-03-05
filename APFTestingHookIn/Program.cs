using System;
using APFTestingModel;

namespace APFTestingHookIn {
    class Program {
        private static void Main(string[] args)
        {
            using (Facade _apf = new Facade())
            {
                var test = _apf.TestDBConnection();
            }
        }
    }
}

