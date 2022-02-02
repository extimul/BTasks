// See https://aka.ms/new-console-template for more information

using Task3._1._1;
using Task3._1._6;
using Task3._1._8;

// MathLib.E = 12

//1.6
var z1 = new Complex(15, 35);
var z2 = new Complex(16, 35);

var z3 = new Complex(15, 55);
var z4 = new Complex(15, 55);

var sum = z1 + z2;
Console.WriteLine(sum.ToString());
var sub = z1 - z2;
Console.WriteLine(sub.ToString());
var mul = z1 * z2;
Console.WriteLine(mul.ToString());
var div = z1 / z2;
Console.WriteLine(div.ToString());

var eq = z3 == z4;
Console.WriteLine(eq.ToString());

//1.8
User user = new()
{
    Phone = new()
    {
        Company = new()
        {
            Name = "Microsoft"
        }
    }
};

string? companyName = user.Phone?.Company?.Name;

if (!string.IsNullOrEmpty(companyName))
{
    Console.WriteLine(companyName);
}

//1.9
//using Task3._1._9;
// var employee = new Employee("Anton");
// var employee1 = new Employee("Anton", "Ivanov");

//1.11
// using Task3._1._12;
//
// //Upcasting
// Person person = new Employee("Ivan", "Microsoft");
// Person person1 = new Client("Anton", "Alfa");
//
// object person3 = new Employee("Airat", "23");
//
// Console.WriteLine(person.Name);
// Console.WriteLine(person1.Name);
//
// //Downcasting
//
// Person person2 = new Employee("Dima","Apple");
// Employee employee = (Employee)person2;
// Console.WriteLine(employee.Company);
//
// object obj = new Employee("John", "1");
// Employee employee1 = (Employee)obj;
//
// object a = new Employee("Mark", "S");
// Employee? e = a as Employee;    