using System;

namespace LoanBuddy
{
    // Interface
    interface IApprovable
    {
        bool ApproveLoan();
        double CalculateEMI();
    }

    // Applicant class (Encapsulation)
    class Applicant
    {
        private string name;
        private int creditScore;
        private double income;
        private double loanAmount;

        public Applicant(string name, int creditScore, double income, double loanAmount)
        {
            this.name = name;
            this.creditScore = creditScore;
            this.income = income;
            this.loanAmount = loanAmount;
        }

        public string Name => name;
        public int CreditScore => creditScore;
        public double Income => income;
        public double LoanAmount => loanAmount;
    }

    // Abstract Loan class
    abstract class LoanApplication : IApprovable
    {
        protected Applicant applicant;
        protected int term; // months
        protected double interestRate;
        protected bool isApproved;

        protected LoanApplication(Applicant applicant, int term, double interestRate)
        {
            this.applicant = applicant;
            this.term = term;
            this.interestRate = interestRate;
        }

        protected bool CheckEligibility()
        {
            return applicant.CreditScore >= 650 &&
                   applicant.Income >= applicant.LoanAmount * 0.3;
        }

        public bool ApproveLoan()
        {
            isApproved = CheckEligibility();
            return isApproved;
        }

        protected double CalculateEMIFormula(double principal, double rate, int months)
        {
            double r = rate / (12 * 100);
            return (principal * r * Math.Pow(1 + r, months)) /
                   (Math.Pow(1 + r, months) - 1);
        }

        public abstract double CalculateEMI();
    }

    // Loan Types
    class HomeLoan : LoanApplication
    {
        public HomeLoan(Applicant applicant, int term)
            : base(applicant, term, 8.5) { }

        public override double CalculateEMI()
        {
            return CalculateEMIFormula(applicant.LoanAmount, interestRate, term);
        }
    }

    class AutoLoan : LoanApplication
    {
        public AutoLoan(Applicant applicant, int term)
            : base(applicant, term, 9.5) { }

        public override double CalculateEMI()
        {
            return CalculateEMIFormula(applicant.LoanAmount, interestRate, term);
        }
    }

    class PersonalLoan : LoanApplication
    {
        public PersonalLoan(Applicant applicant, int term)
            : base(applicant, term, 12.0) { }

        public override double CalculateEMI()
        {
            return CalculateEMIFormula(applicant.LoanAmount, interestRate, term);
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Credit Score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter Monthly Income: ");
            double income = double.Parse(Console.ReadLine());

            Console.Write("Enter Loan Amount: ");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("\nSelect Loan Type:");
            Console.WriteLine("1. Home Loan");
            Console.WriteLine("2. Auto Loan");
            Console.WriteLine("3. Personal Loan");

            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter Loan Term (in months): ");
            int term = int.Parse(Console.ReadLine());

            Applicant applicant = new Applicant(name, creditScore, income, loanAmount);

            LoanApplication loan = null;

            switch (choice)
            {
                case 1:
                    loan = new HomeLoan(applicant, term);
                    break;
                case 2:
                    loan = new AutoLoan(applicant, term);
                    break;
                case 3:
                    loan = new PersonalLoan(applicant, term);
                    break;
                default:
                    Console.WriteLine("Invalid Loan Type");
                    return;
            }

            if (loan.ApproveLoan())
            {
                Console.WriteLine("\nLoan Approved ");
                Console.WriteLine("Monthly EMI: " + loan.CalculateEMI());
            }
            else
            {
                Console.WriteLine("\nLoan Rejected ");
            }
        }
    }
}
