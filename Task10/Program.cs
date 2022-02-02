
using Task10.Task1;
using Task10.Task2;
using Task10.Task3;

namespace Task10;

class Program
{
    static void Main()
    {
        //Task1
        // string testWord = "высокопревосходительство";
        // Console.WriteLine(testWord.GetCharCount('о'));
        
        //Task2
        // Person person = new Person();
        // person.Eat();
        // person.Move();
        // person.DoWork();
        
        //Task3
        // var user = new
        // {
        //     Name = "Tom", 
        //     Age = 34
        // };
        //
        // var student = new
        // {
        //     Name = "Alice",
        //     Age = 21
        // };
        //
        // var manager = new
        // {
        //     Name = "Bob",
        //     Age = "26",
        //     Company = "Microsoft"
        // };
        //
        // Console.WriteLine(user.Age);

        // var person = new Human()
        // {
        //     Name = "Dima",
        //     Age = 20
        // };
        //
        // var person1 = new {person.Name, person.Age};
        // Console.WriteLine(person1.Name);
        
        //Task4
        
        //Task5
        // int? i = null;
        // Nullable<int> i1 = null;

        var person = new Person();
        person.Id = 0;
        var human = new Human();
        human.Id = 1;

        int? ad = null;
        int aderg = 0;

        bool ju = ad == aderg;

        var yyy = new
        {
            person.Id,
    
        };
        
        //Task6
        int? i = 5;
        int y = (int) i;

        int a = 5;
        int? b = a;

        int x = 5;
        double? x1 = x;

        double x2 = 5;
        float? x3 = (float) x2;

        float? d = 1;
        double? f = d;

        float? d1 = 1;
        double d2 = (double) d1;
    }

    public class A{
        private void GetSum(int[] numbers)
        {
            var a = 0;
            bool IsGreaterThanFive(int number)
            {
                return number > 5;
            }
            foreach (var number in numbers)
            {
                if (IsGreaterThanFive(number))
                {
                    a += number;
                }
            }

        }
    }
}