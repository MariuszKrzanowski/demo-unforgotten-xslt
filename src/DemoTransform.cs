//-----------------------------------------------------------------------
// <copyright file="DemoTransform.cs" company="Mr Matrix Mariusz Krzanowski">
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

using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace MrMatrixNet.UnforgottenXSLT.SamplesRunner
{
    public class DemoTransform
    {
        private const string DemoNamespaceUri = "letsetdemoclass-demo-namespace";
        private XslCompiledTransform _demoTransform;

        public DemoTransform(string transformPath)
        {
            _demoTransform = new XslCompiledTransform(true);
            _demoTransform.Load(transformPath);
        }

        public void Execute(string sourcePath, string resultPath)
        {
            using (var resultStream = new FileStream(resultPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                using (var inputStream = new FileStream(sourcePath, FileMode.Open))
                {
                    var readerSettings = new XmlReaderSettings();
                    readerSettings.DtdProcessing = DtdProcessing.Ignore;
                    var xmlReader = XmlReader.Create(inputStream, readerSettings);

                    XsltArgumentList argumentList = new XsltArgumentList();
                    argumentList.AddExtensionObject(DemoNamespaceUri, new DemoXslExtension());

                    _demoTransform.Transform(xmlReader, argumentList, resultStream);
                }
            }
        }
    }
}
