using System;
using System.IO;
using System.Runtime.Loader;
using Amazon.Lambda.TestUtilities;

namespace AWSLambdaDotnetLocal
{
    class DynamicLambdaInvoker
    {
        private static readonly string[] FUNCTION_SEPARATOR = { "::" };
        private string _functionAssemblyName;
        private string _functionFullyQualifiedClass;
        private string _functionName;
        private dynamic _lambdaClass;

        public DynamicLambdaInvoker(string folderPath, string functionHandler)
        {
            var functionParts = functionHandler.Split(FUNCTION_SEPARATOR, StringSplitOptions.None);
            _functionAssemblyName = functionParts[0];
            _functionFullyQualifiedClass = functionParts[1];
            _functionName = functionParts[2];

            var fullAssemblyPath = Path.Combine(folderPath, _functionAssemblyName + ".dll");

            var lambdaAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(fullAssemblyPath);
            var lambdaType = lambdaAssembly.GetType(_functionFullyQualifiedClass);
            _lambdaClass = Activator.CreateInstance(lambdaType);


        }

        public void Invoke(string jsonInput)
        {
            var lambdaContext = new TestLambdaContext();
            Console.WriteLine(_lambdaClass.FunctionHandler(jsonInput, lambdaContext));
        }
    }
}