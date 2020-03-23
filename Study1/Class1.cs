#define Trace
using System;
using System.Diagnostics;
public class Myclass
{
    [Conditional("Trace")]
    public static void Message(string msg)
    {
        Console.WriteLine(msg);
    }

    [Obsolete("please use new method",false)]
    public void oldmethod() { }

    public void newmethod() { }
}
class Test
{
    static void function1()
    {
        Myclass.Message("In Function 1.");
        function2();
    }
    static void function2()
    {
        Myclass.Message("In Function 2.");
    }
    public static void Main()
    {
        Myclass.Message("In Main function.");
        function1();
        Myclass myclass = new Myclass();
        myclass.oldmethod();
        Console.ReadKey();
    }
}