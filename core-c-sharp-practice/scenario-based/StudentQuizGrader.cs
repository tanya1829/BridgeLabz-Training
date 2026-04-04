using System;

class StudentQuizGrader
{
    // The data is hidden using the encapsulation

    private string[] quizQuestions =
    {
        "What is the capital of India?",
        "Which language is mainly used for iOS app development?",
        "Which keyword is used to define a class in C#?",
        "Which data type is used to store whole numbers in C#?",
        "What does IDE stand for?",
        "Which company developed the Java programming language?",
        "Which symbol is used for multi-line comments in C#?",
        "Which loop checks the condition before executing the loop body?",
        "Which keyword is used to stop a loop in C#?",
        "Which access modifier allows access only within the same class?"

    };

    private string[] correctAnswers =
    {
        "Delhi",
        "Swift",
        "class",
        "int",
        "Integrated Development Environment",
        "Sun Microsystems",
        "/* */",
        "while",
        "break",
        "private"

    };

    private string[] studentAnswers = new string[10];

    // Case-insensitive string comparison (custom)
    private bool IsEqualIgnoreCase(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        for (int i = 0; i < s1.Length; i++)
        {
            char c1 = s1[i];
            char c2 = s2[i];

            if (c1 >= 'A' && c1 <= 'Z')
                c1 = (char)(c1 + 32);

            if (c2 >= 'A' && c2 <= 'Z')
                c2 = (char)(c2 + 32);

            if (c1 != c2)
                return false;
        }
        return true;
    }

    // calculating Score and giving feedback 

    private int CalculateScore(string[] correct, string[] student)
    {
        int score = 0;

        Console.WriteLine("\n--- Quiz Feedback ---");
        for (int i = 0; i < correct.Length; i++)
        {
            if (IsEqualIgnoreCase(correct[i], student[i]))
            {
                Console.WriteLine("Question " + (i + 1) + ": Correct");
                score++;
            }
            else
            {
                Console.WriteLine("Question " + (i + 1) + ": Incorrect");
            }
        }
        return score;
    }

    public void StartQuiz()
    {
        Console.WriteLine(" Welcome to EduQuiz - Student Quiz Grader");

        // Displaying Questions and taking Answers
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine("Q" + (i + 1) + ": " + questions[i]);
            Console.Write("Your Answer: ");
            studentAnswers[i] = Console.ReadLine();
            Console.WriteLine();
        }

        int score = CalculateScore(correctAnswers, studentAnswers);

        int percentage = (score * 100) / questions.Length;

        Console.WriteLine("\nTotal Score: " + score + "/" + questions.Length);
        Console.WriteLine("Percentage: " + percentage + "%");

        if (percentage >= 50)
            Console.WriteLine("Result: PASS");
        else
            Console.WriteLine("Result: FAIL");
    }
}


class Program
{
    static void Main()
    {
        StudentQuizGrader quiz = new StudentQuizGrader();
        quiz.StartQuiz();   // Student cannot access data directly
    }
}
