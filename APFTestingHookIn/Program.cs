using System;
using APFTestingModel;

namespace APFTestingHookIn {
    class Program {
        public static void Main(string[] args)
        {
            Facade _facade = new Facade();
            //_facade.CreateAssessmentTaskPilot("Test Title", "Test Detail", 50);
            Guid id = new Guid("818fe6fc-a007-4058-9551-c0ff189b4a52");
            //_facade.EditAssessmentTaskPilot(id, "Test Title 2", "Test Detail 2", 10);
            //_facade.DeleteAssessmentTaskPilot(id);
            //Console.WriteLine(_facade.checkIsReferenced(id));
            //Console.ReadKey();

        }
    }
}

