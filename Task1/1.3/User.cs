namespace Task1.Zadanie3;

//1.3
public struct User
{
    public string name = "Илья";

    public int age = 23;

    public User(string name)
    {
        this.name = name;
    }

    public User(int age)
    {
        this.age = age;
    }

    public User(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{name};{age}";
    }
}