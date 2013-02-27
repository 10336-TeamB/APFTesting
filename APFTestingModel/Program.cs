using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingModel.Managers;

namespace APFTestingModel
{
	class Program
	{
		public static void Main(string[] args)
		{
			APFTestingEntities _context = new APFTestingEntities();

			TheoryQuestionManager _tqm = new TheoryQuestionManager();
			var randomQuestions = _tqm.FetchRandomQuestions(1);

			foreach (var item in randomQuestions)
			{
				Console.WriteLine("{0}\n",item.Description);
			}

			Console.Read();
		}
	}
}
