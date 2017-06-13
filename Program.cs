using System;
using System.Runtime.Loader;
using Amazon.Lambda.TestUtilities;

namespace aws_lambda_dotnet_local
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\Temp\aws-lambda-dotnet-sample\aws-lambda-dotnet-sample.dll");
            var myType = myAssembly.GetType("aws_lambda_dotnet_sample.Function");
            dynamic myInstance = Activator.CreateInstance(myType);

            var lambdaContext = new TestLambdaContext();
            Console.WriteLine(myInstance.FunctionHandler("test", lambdaContext));
        }
    }
}
