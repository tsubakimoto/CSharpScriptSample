using Library;
using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;
using System.Windows.Forms;

namespace WinFormScript
{
    public partial class Form1 : Form
    {
        private Person me = new Person { Name = "Yuta", Age = 17 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var code1 = "Plus(10);";
            var script1 = CSharpScript.Create(code1);
            script1.Run(me);
            textBox1.AppendText(me.Age.ToString() + Environment.NewLine);
        }
    }
}
