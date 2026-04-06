using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProctor
{
	internal interface IExamOperations
	{
		void VisitQuestion();
		void SubmitAnswer();
		void EvaluateExam();
	}
}