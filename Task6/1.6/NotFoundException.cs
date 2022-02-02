namespace Task6._1._6;

public class NotFoundException : Exception
{
    public NotFoundException(string name) : base($"Объект '{name}' не найден"){}
}