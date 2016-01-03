using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using GeneralSolutions.Collections;

namespace GeneralSolutions
{
    class Program
    {  
        static void Main(string[] args)
        {
            TextFileWriterModule fileWriter = new TextFileWriterModule();
            fileWriter.Context.FileName = Properties.Settings.Default.LogFilePath;
            fileWriter.Context.IsAppend = true;
            fileWriter.Write(String.Format("{0} - Program started\n", DateTime.Now));

            TextWriterModule writer = new TextWriterModule();
            writer.Context = Console.Out;
            writer.Write(GetWelcomeMessage());

            AssemblyExaminerModule examiner = new AssemblyExaminerModule();
            List<String> properties = examiner.Read(Assembly.GetExecutingAssembly());
            writer.Write(properties, Environment.NewLine);            

            BrowserModule browser = new BrowserModule();
            BrowserModule.Logger = fileWriter;
            browser.Open("http://www.microsoft.com");

            fileWriter.Write(String.Format("{0} - Program stopped\n", DateTime.Now));

            BinaryTreeExample bte = new BinaryTreeExample();

            Console.ReadKey();
        }

        static IEnumerable<String> GetWelcomeMessage()
        {
            yield return "General Solutions command line tool\n\n";
        }

    }
}

////////////////////////////////////////////////////////////////////////////////////
// Implemenation details in VS2013
// - Automatically increment revision version using UpdateVersion command line utility in Pre-Build VS event
// - Remove FileVersion from AssemblyInfo so FileVersion becomes the same as product version
// - Read program settings
// - Main depends on TextWriterModule, low level implementation depends on high level implementation