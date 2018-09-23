//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Mr Matrix Mariusz Krzanowski">
//     (c) 2018 Mr Matrix Mariusz Krzanowski 
// </copyright>
// <author>Mariusz Krzanowski</author>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
//-----------------------------------------------------------------------

using System;

namespace MrMatrixNet.UnforgottenXSLT.SamplesRunner
{

    class Program
    {
        static DemoSetup[] demoOptions = new DemoSetup[]
               {
                    new DemoSetup(Resources.Demo01,"01.xslt","article.xml","result-1.xml")
                    ,new DemoSetup(Resources.Demo02,"02.xslt","article.xml","result-2.xml")
                    ,new DemoSetup(Resources.Demo03,"03.xslt","article.xml","result-3.xml")
                    ,new DemoSetup(Resources.Demo04,"04.xslt","article.xml","result-4.xml")
                    ,new DemoSetup(Resources.Demo05,"05.xslt","article.xml","result-5.xml")
                    ,new DemoSetup(Resources.Demo06,"06.xslt","article.xml","result-6.xml")
                    ,new DemoSetup(Resources.Demo07,"07.xslt","article.xml","result-7.xml")
                    ,new DemoSetup(Resources.Demo08,"08.xslt","article.xml","result-8.xml")
                    ,new DemoSetup(Resources.Demo09,"09.xslt","article.xml","result-9.xml")
                    ,new DemoSetup(Resources.Demo10,"10.xslt","article.xml","result-10.xml")
                    ,new DemoSetup(Resources.Demo11,"11.xslt","template.html","result-11.html")
                    ,new DemoSetup(Resources.Demo12,"12.xslt","template.html","result-12.html")
               };

        static void Main(string[] args)
        {
            string line;
            int chosenOptionIndex;
            while(true)
            {
                Console.WriteLine("Choose an numeric option to run and press ENTER:");
                for (int i = 0; i < demoOptions.Length; i++)
                {
                    Console.WriteLine($"{i}\t{demoOptions[i].Title}");
                }
                


                line = Console.ReadLine();
                if ((!int.TryParse(line, out chosenOptionIndex) || chosenOptionIndex < 0 || chosenOptionIndex >= demoOptions.Length))
                {
                    Console.Beep();
                    Console.WriteLine($"Invalid option [{line}]. Try e.g. 9<ENTER>");
                }
                else
                {
                    break;
                }
            }



           var choosenOption = demoOptions[chosenOptionIndex];
           var demoTransform = new DemoTransform($"demo-transformations\\{choosenOption.TransformationPath}");


           demoTransform.Execute($"content\\{choosenOption.SourcePath}", choosenOption.DestinationPath);


            Console.WriteLine("Press ENTER to end program.");
            Console.ReadLine();
        }
    }
}
