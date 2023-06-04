//Bitmap
class Program
{
    static int HammingDistance(string[] strArr)
    {
        string str1 = strArr[0];
        string str2 = strArr[1];

        int distance = 0;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                distance++;
            }
        }

        return distance;
    }


    static void Main()
    {
        string[] strArr = { "coder", "codec" };
        int distance = HammingDistance(strArr);
        Console.WriteLine(distance);
    }
}
//Multibrackets

class ProgramTwo
{
    static int MultipleBrackets(string str)
    {
        Stack<char> stack = new Stack<char>();
        int openCount = 0;
        int squareOpenCount = 0;
        int roundOpenCount = 0;

        foreach (char c in str)
        {
            if (c == '(')
            {
                stack.Push(c);
                openCount++;
                roundOpenCount++;
            }
            else if (c == '[')
            {
                stack.Push(c);
                openCount++;
                squareOpenCount++;
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Peek() != '(')
                    return 0;

                stack.Pop();
                openCount--;
                roundOpenCount--;
            }
            else if (c == ']')
            {
                if (stack.Count == 0 || stack.Peek() != '[')
                    return 0;

                stack.Pop();
                openCount--;
                squareOpenCount--;
            }
        }

        if (stack.Count == 0)
        {
            return openCount == 0 ? 1 : 0;
        }

        return 0;
    }

    static void Main()
    {
        string str1 = "(hello [world])(!)";
        string str2 = "((hello [world])";
        int result1 = MultipleBrackets(str1);
        int result2 = MultipleBrackets(str2);
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
}