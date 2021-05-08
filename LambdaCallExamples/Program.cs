using System;

namespace Candal
{
    class Program
    {
        static void Main(string[] args)
        {
            LambdaCallExamples examples = new LambdaCallExamples();

            AnyModel model = new AnyModel();

            model.name = "name0";
            examples.CallStaticLambda(model);

            model.name = "name1";
            examples.CallInstanceLambda1(model);

            model.name = "name2";
            examples.CallInstanceLambda2(model);

            model.name = "name3";
            examples.CallInstanceLambda3(model);

            model.name = "name4";
            examples.CallInstanceLambda4(model);

            model.name = "name5";
            examples.CallStaticDelegate(model);

            model.name = "name6";
            examples.CallInstanceDelegate(model);
        }
    }
}

