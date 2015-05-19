using Library;
using Microsoft.CodeAnalysis.Scripting.CSharp;

namespace ConsoleScript
{
    class Program
    {
        static void Main(string[] args)
        {
            // デフォルトで`System`名前空間は参照設定されている
            var code1 = "Console.WriteLine(\"Hello world!\"); //コメント";
            var script1 = CSharpScript.Create(code1);
            script1.Run();

            // 匿名オブジェクトをパラメータとして渡す
            var code2 = "Console.WriteLine(Message);";
            var script2 = CSharpScript.Create(code2);
            //script2.Run(new { Message = "Thanks!" }); // Microsoft.CodeAnalysis.Scripting.CompilationErrorException

            // Personクラスオブジェクトをスクリプト側で変更しメソッドを実行する
            var code3 = "Greet(); Name=\"Yuta\"; Age=27; Greet();";
            var script3 = CSharpScript.Create(code3);
            var script3state = script3.Run(new Person());

            // script3の結果を引き継ぐ
            var code4 = "Greet();";
            var script4 = CSharpScript.Create(code4);
            script4.Run(script3state);

#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
