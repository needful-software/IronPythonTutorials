/*
    Copyright (c) 2015 Xavier Leclercq

    Permission is hereby granted, free of charge, to any person obtaining  a
    copy of this software and associated documentation files (the "Software"),
    to deal in the Software without restriction, including without limitation
    the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
    IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportModule1
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Scripting.Hosting.ScriptEngine pythonEngine = IronPython.Hosting.Python.CreateEngine();

            ICollection<string> searchPaths = pythonEngine.GetSearchPaths();
            searchPaths.Add("..\\..");
            pythonEngine.SetSearchPaths(searchPaths);

            Microsoft.Scripting.Hosting.ScriptScope scope = IronPython.Hosting.Python.ImportModule(pythonEngine, "HelloWorldModule");
            
            dynamic printHelloWorldFunction = scope.GetVariable("PrintHelloWorld");
            printHelloWorldFunction();

            dynamic printMessageFunction = scope.GetVariable("PrintMessage");
            printMessageFunction("Goodbye!");

            dynamic addFunction = scope.GetVariable("Add");
            System.Console.Out.WriteLine("The sum of 1 and 2 is " + addFunction(1, 2));
        }
    }
}
