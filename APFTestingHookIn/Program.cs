using System;
using APFTestingModel;

namespace APFTestingHookIn {
    class Program {
        private static void Main(string[] args)
        {
            using (Facade _apf = new Facade(ExamType.PilotExam))
            {
                var exam = _apf.FetchSpecificQuestion;
            }
        }
    }
}

