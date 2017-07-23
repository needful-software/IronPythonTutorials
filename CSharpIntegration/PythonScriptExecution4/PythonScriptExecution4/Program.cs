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

namespace PythonScriptExecution4
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Scripting.Hosting.ScriptEngine pythonEngine = 
                IronPython.Hosting.Python.CreateEngine();

            // Print the default search paths
            System.Console.Out.WriteLine("Search paths:");
            ICollection<string> searchPaths = pythonEngine.GetSearchPaths();
            foreach (string path in searchPaths)
            {
                System.Console.Out.WriteLine(path);
            }
            System.Console.Out.WriteLine();

            // Now modify the search paths to include the directory
            // where the standard library has been installed
            searchPaths.Add("..\\..\\Lib");
            pythonEngine.SetSearchPaths(searchPaths);

            // Execute the script
            // We execute this script from Visual Studio
            // so the program will executed from bin\Debug or bin\Release
            Microsoft.Scripting.Hosting.ScriptSource pythonScript = 
                pythonEngine.CreateScriptSourceFromFile("..\\..\\HelloWorldBase64.py");
            pythonScript.Execute();
        }
    }
}
