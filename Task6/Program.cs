//1.1
// try
// {
//     string a = "";
//     int b = Convert.ToInt16(a);
// }
// catch(Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }
// finally
// {
//     Console.WriteLine("Finnaly block");
// }
//
// //1.2
//
// string num = Console.ReadLine();
//
// if (int.TryParse(num, out var x))
// {
//     Console.WriteLine("Введённое число");
// }
// else
// {
//     Console.WriteLine("Это не число");
// }

//Блоки catch инкапсулируют код, который обрабатывает ошибочные ситуации, происходящие в коде блока try.
//Это также удобное место для протоколирования ошибок.

// //1.3
// var x1 = 1;
// try
// {
//     x1 -= 1;
//     throw new Exception();
// }
// catch when (x1 == 0)
// {
//     Console.WriteLine("Без указания типа");
// }
// catch (Exception) when (x1 == 2)
// {
//     Console.WriteLine("С указанием типа");
// }
// finally
// {
//     x1 = 0;
// }

using Task6._1._6;

var person = new Person() { Name = "Ivan" };
person = null;
try
{
    if (person is null)
    {
        throw new NotFoundException(nameof(Person));
    }
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

// using Task6._1._7;
//
// try
// {
//     TestClass.Method1();
// }
// catch (DivideByZeroException ex)
// {
//     Console.WriteLine($"Catch в Main : {ex.Message}");
// }
// finally
// {
//     Console.WriteLine("Блок finally в Main");
// }
//
// Console.WriteLine("Конец метода Main");
// Console.Read();

