using Microsoft.CodeAnalysis.Scripting.CSharp;

namespace ConsoleScript
{
    class Program
    {
        static void Main(string[] args)
        {
            // デフォルトで`System`名前空間は参照設定されている
            var code = "Console.WriteLine(\"Hello world!\");";
            var script = CSharpScript.Create(code);
            script.Run();

#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
