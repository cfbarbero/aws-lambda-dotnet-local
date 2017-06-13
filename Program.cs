using System;
using System.Runtime.Loader;
using Amazon.Lambda.TestUtilities;

namespace AWSLambdaDotnetLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lambdaInvoker = new DynamicLambdaInvoker(@"C:\Temp\aws-lambda-dotnet-sample\", "aws-lambda-dotnet-sample::aws_lambda_dotnet_sample.Function::FunctionHandler");

            lambdaInvoker.Invoke("test");
        }
    }
}
