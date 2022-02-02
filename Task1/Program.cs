using Task1.Zadanie1and2;
using Task1.Zadanie3;
using Task1.Zadanie4and5;
using Task1.Zadanie6;

// 1.1-1.2
// var m1 = new Motocycle("moto1");
//
// var m2 = new Motocycle("moto2", "123");
//

//1.3
 var user1 = new User("User", 22);
 Console.WriteLine(user1.ToString());
 user1.age = 23;
 Console.WriteLine(user1.ToString());

//1.4
// var state = new State
// {
//     Name = "NY",
//     Country = new Country()
// };
//
// var state1 = new State
// {
//     Name = "NY",
//     Country = new Country
//     {
//         Name = "USA"
//     }
// };
//
// var state2 = new State
// {
//     Name = "Tatarstan",
//     Country = new Country
//     {
//         Name = "Russia"
//     }
// };
// Console.WriteLine(state2.ToString());
//
// state1 = state2;
// state2.Name = "USA";
//
// Console.WriteLine(state2.ToString());
//
// var country1 = new Country()
// {
//     Name = "Russia"
// };
//
// var country2 = new Country()
// {
//     Name = "France"
// };
//
// country1 = country2;
// country2.Name = "Italy";
// Console.WriteLine(country1.Name);
// Console.WriteLine(country2.Name);

//1.5
// State state1 = new State(); 
// State state2 = new State();
//          
// state2.Country = new Country();
// state2.Country.Name = "5";
// state1 = state2;
// state2.Country.Name = "8";
// Console.WriteLine(state1.Country.Name);
// Console.WriteLine(state2.Country.Name);
//
// //1.6
// Person p = new Person { name = "Tom", age=23 };
// ChangePerson(p);
// // ChangePerson1(ref p);  
//  
// Console.WriteLine(p.name);
// Console.WriteLine(p.age);
//  
// Console.Read();
//
// static void ChangePerson(Person person)
// {
//     person.name = "Alice";
//     person = new Person { name = "Bill", age = 45 };
//     Console.WriteLine(person.name);
// }
//
// static void ChangePerson1(ref Person person)
// {
//     person.name = "Alice";
//     person = new Person { name = "Bill", age = 45 };
// }
