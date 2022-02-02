namespace Task10.Task1;

public static class Extension
{
    public static int GetCharCount(this string word, char symbol) 
        => word.Count(x => x == symbol);
}