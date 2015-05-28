using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;
using System.IO;

namespace TaskScript
{
    class Program
    {
        static void Main(string[] args)
        {
            // スクリプト内で非同期処理を実行する
            Console.WriteLine("script start");
            var code = File.ReadAllText(@"..\TaskScript\task.script.txt");
            var script = CSharpScript.Create(code);
            script.Run();
            Console.WriteLine("script end");

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
