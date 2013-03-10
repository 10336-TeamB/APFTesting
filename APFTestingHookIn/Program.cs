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
            var theoryExamTemplate = _facade.CreateTheoryComponentFormat(ExamType.PackerExam, 20, 11);
        }
    }
}

