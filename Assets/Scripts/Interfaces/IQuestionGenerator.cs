using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IQuestionGenerator
    {
        string GenerateQuestion();
        string CorrectAnswer {  get; }
        List<string> GenerateOptions(); // New method to generate multiple choice options where only 1 of 4 is correct.

    }
}
