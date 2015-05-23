using Library;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;
using System.IO;
using System.Linq;

namespace ConsoleScript
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sample1

            // デフォルトで`System`名前空間は参照設定されている
            var code1 = "Console.WriteLine(\"Hello world!\"); //コメント";
            var script1 = CSharpScript.Create(code1);
            script1.Run();

            #endregion

            #region sample2

            // 匿名オブジェクトをパラメータとして渡す
            var code2 = "Console.WriteLine(Message);";
            var script2 = CSharpScript.Create(code2);
            //script2.Run(new { Message = "Thanks!" }); // Microsoft.CodeAnalysis.Scripting.CompilationErrorException

            #endregion

            #region sample3

            // Personクラスオブジェクトをスクリプト側で変更しメソッドを実行する
            var code3 = "Greet(); Name=\"Yuta\"; Age=27; Greet();";
            var script3 = CSharpScript.Create(code3);
            var script3state = script3.Run(new Person());

            #endregion

            #region sample4

            // script3の結果を引き継ぐ
            var code4 = "Greet();";
            var script4 = CSharpScript.Create(code4);
            script4.Run(script3state);

            #endregion

            #region sample5

            // コードをテキストファイルから読み込んで実行する
            var code5 = File.ReadAllText(@"..\ConsoleScript\code5.txt");
            var script5 = CSharpScript.Create(code5);
            script5.Run();

            #endregion

            #region sample6

            // System.Linq名前空間を組み込んでメソッドを実行する
            var data = new Data { Numbers = Enumerable.Range(1, 5) };
            var code6 = "Console.WriteLine(Numbers.Sum())";
            var script6 = CSharpScript.Create(code6,
                new ScriptOptions()
                    .WithReferences(typeof(int).Assembly, typeof(Enumerable).Assembly)
                    .WithNamespaces("System", "System.Linq")
                );
            script6.Run(data);

            #endregion

            #region sample7

            // 独自の名前空間を組み込んで列挙体を表示する
            var code7 = "Console.WriteLine(string.Join(\",\", Enum.GetNames(typeof(Fukuoka))));";
            var script7 = CSharpScript.Create(code7,
                new ScriptOptions()
                    .WithReferences(typeof(int).Assembly, typeof(Fukuoka).Assembly)
                    .WithNamespaces("System", "Library")
                );
            script7.Run();

            #endregion

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
