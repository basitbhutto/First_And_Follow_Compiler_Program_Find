using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************Abdul Basit*************");
            int basit = 0;
            string[] arr;
            arr = new string[100];


            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the token");
                arr[i] = Convert.ToString(Console.ReadLine());
                Console.WriteLine("if You Want to insert Token Then  press 1 and if you want to end program press 0");
                int b = Convert.ToInt32(Console.ReadLine());
                if (b == 0)
                {
                    goto sa;
                }

                basit++;

            }
            sa:

            for (int i = 0; i < basit; i++)
            {
                if (arr[i] == "if" || arr[i] == "while" || arr[i] == "break" || arr[i] == "continue" || arr[i] == "double" || arr[i] == "return" || arr[i] == "case" || arr[i] == "sizeof" || arr[i] == "short" || arr[i] == "switch" || arr[i] == "void" || arr[i] == "struct" || arr[i] == "int" || arr[i] == "float" || arr[i] == "char" || arr[i] == "long" || arr[i] == "typedef" || arr[i] == "unsigned" || arr[i] == "static" || arr[i] == "goto" || arr[i] == "string" || arr[i] == "float" || arr[i] == "decimal")
                {
                    Console.WriteLine(arr[i] + " is Keyword");
                }
                else if (arr[i] == "+" || arr[i] == "-" || arr[i] == "*" || arr[i] == "/" || arr[i] == ">" || arr[i] == "<" || arr[i] == "=")
                //if (arr[i] == " " || arr[i] == "+" || arr[i] == "-" || arr[i] == "*" || arr[i] == "/" || arr[i] == "," || arr[i] == ";" || arr[i] == ">" || arr[i] == "<" || arr[i] == "=" || arr[i] == "(" || arr[i] == ")" || arr[i] == "[" || arr[i] == "]" || arr[i] == "{" || arr[i] == "}")
                {
                    Console.WriteLine(arr[i] + " is OPERATOR");
                }
                else if (!arr[i].StartsWith("1") && !arr[i].StartsWith("2") && !arr[i].StartsWith("3") && !arr[i].StartsWith("4") && !arr[i].StartsWith("5") && !arr[i].StartsWith("6") && !arr[i].StartsWith("7") && !arr[i].StartsWith("8") && !arr[i].StartsWith("9") && !arr[i].StartsWith("0"))
                {
                    Console.WriteLine(arr[i] + "  IS A VALID IDENTIFIER");
                }


                else if (arr[i].StartsWith("1") || arr[i].StartsWith("2") || arr[i].StartsWith("3") || arr[i].StartsWith("4") || arr[i].StartsWith("5") || arr[i].StartsWith("6") || arr[i].StartsWith("7") || arr[i].StartsWith("8") || arr[i].StartsWith("9") || arr[i].StartsWith("0"))
                {
                    if (arr[i].EndsWith("1") || arr[i].EndsWith("2") || arr[i].EndsWith("3") || arr[i].EndsWith("4") || arr[i].EndsWith("5") || arr[i].EndsWith("6") || arr[i].EndsWith("7") || arr[i].EndsWith("8") || arr[i].EndsWith("9") || arr[i].EndsWith("0"))
                    {
                        Console.WriteLine(arr[i] + " is CONSTANT");
                    }
                    else if (!arr[i].EndsWith("1") || !arr[i].EndsWith("2") || !arr[i].EndsWith("3") || !arr[i].EndsWith("4") || !arr[i].EndsWith("5") || !arr[i].EndsWith("6") || !arr[i].EndsWith("7") || !arr[i].EndsWith("8") || !arr[i].EndsWith("9") || !arr[i].EndsWith("0") || !arr[i].EndsWith("_"))
                    {
                        Console.WriteLine(arr[i] + " IS NOT A VALID IDENTIFIER");
                    }

                }
            }

        
  
        Console.WriteLine("Token is "+basit);
            Console.ReadLine();

        }
    }
}
