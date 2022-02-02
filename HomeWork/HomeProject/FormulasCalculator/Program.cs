using FormulasLibrary;

namespace FormulasCalculator;

public static class Program
{
    public static void Main()
    {
        // Test t = new();
        // t.PublicMethod();
        
        Console.WriteLine("Калькулятор формул v1.0");
        Console.WriteLine("Выберите предмет:");

        string[] subjectArray = {"Математика", "Физика"};
        
        CslUtils.DisplayMenu(subjectArray);
        HandleSubjectMenu();
    }

    private static void HandleSubjectMenu()
    {
        var userChoice = CslUtils.HandleUserInput();
        CslUtils.Clear();
        Console.WriteLine("Выберите формулу");
        switch ((CalculatorSubjects)userChoice)
        {
            case CalculatorSubjects.Math:
                ShowMathFormulas();
                break;
            case CalculatorSubjects.Phys:
                ShowPhysFormulas();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void ShowPhysFormulas()
    {
        string[] physFormulasName = {"Вычислить скорость", "Вычислить плотность", "E=mc2"};
        CslUtils.DisplayMenu(physFormulasName);
        var input = CslUtils.HandleUserInput();
        CslUtils.Clear();
        Console.WriteLine("Формат");
        switch (input)
        {
            case 1:
                Console.WriteLine("Расстояние(м), время(сек)");
                var nums = CslUtils.HandleFormulaInput();
                Console.WriteLine("Ответ");
                CslUtils.Print(PhysicalFormulas.CalculateVelocity(nums[0], nums[1]));
                break;
            case 2:
                Console.WriteLine("Масса(граммы), объем(см^3)");
                var nums1 = CslUtils.HandleFormulaInput();
                Console.WriteLine("Ответ");
                CslUtils.Print(PhysicalFormulas.CalculateDensity(nums1[0], nums1[1]));
                break;
            case 3:
                break;
            default:
                throw new Exception();
        }
    }

    private static void ShowMathFormulas()
    {
        string[] mathFormulasName = {"Площадь круга", "Площадь квадрата", "Площадь прямоугольника"};
        CslUtils.DisplayMenu(mathFormulasName);
        var input = CslUtils.HandleUserInput();
        CslUtils.Clear();
        Console.WriteLine("Формат");
        switch (input)
        {
            case 1:
                Console.WriteLine("радиус");
                var nums = CslUtils.HandleFormulaInput();
                Console.WriteLine("Ответ");
                CslUtils.Print(MathFormulas.CalculateCircleArea(nums[0]));
                break;
            case 2:
                Console.WriteLine("длина,ширина");
                var nums1 = CslUtils.HandleFormulaInput();
                Console.WriteLine("Ответ");
                CslUtils.Print(MathFormulas.CalculateRectangleArea(nums1[0], nums1[1]));
                break;
            case 3:
                break;
            default:
                throw new Exception();
        }
    }
}

