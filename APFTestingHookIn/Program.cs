using System;
using APFTestingModel;

namespace APFTestingHookIn {
    class Program {
        public static void Main(string[] args)
        {
            Facade _facade = new Facade();
            //var theoryExamTemplate = _facade.CreateExam(new Guid("0DEEC85C-6EDE-4356-995E-E3AB852D746E"), new Guid("0DEEC85C-6EDE-4356-995E-E3AB852D746E"), ExamType.PilotExam);

            _facade.CreateExam(new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff"), new Guid("c120f78b-bc26-4855-9425-c9e5fb9e8c2b"), ExamType.PilotExam);

            //Guid guid1;
            //Guid guid2;
            //Guid guid3;

            //for (var i = 0; i < 10; i++)
            //{
            //    var timer1 = new System.Diagnostics.Stopwatch();
            //    var timer2 = new System.Diagnostics.Stopwatch();
            //    var timer3 = new System.Diagnostics.Stopwatch();

                

                

            //    timer2.Start();
            //    Guid.Parse("00000000-6EDE-4356-995E-000000000000");
            //    timer2.Stop();

            //    timer3.Start();
            //    new Guid("00000000-6EDE-4356-995E-000000000000");
            //    timer3.Stop();

            //    timer1.Start();
            //    Guid.NewGuid();
            //    timer1.Stop();

            //    Console.Out.WriteLine("NewGuid took {0}", timer1.ElapsedTicks);
            //    Console.Out.WriteLine("Guid.Parse took {0}", timer2.ElapsedTicks);
            //    Console.Out.WriteLine("new Guid took {0}\n", timer3.ElapsedTicks);
            //}
            //Console.ReadKey();
        }
    }
}

