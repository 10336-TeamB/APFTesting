using System;
using APFTestingModel;

namespace APFTestingHookIn {
    class Program {
        //private static void Main(string[] args)
        //{
        //    using (Facade _apf = new Facade())
        //    {
                
        //    }
        //}
        
        public static void Main(string[] args)
        {
            Facade _facade = new Facade();
            var theoryExamTemplate = _facade.CreateExam(new Guid("0DEEC85C-6EDE-4356-995E-E3AB852D746E"), new Guid("0DEEC85C-6EDE-4356-995E-E3AB852D746E"), ExamType.PilotExam);
        }
    }
}

