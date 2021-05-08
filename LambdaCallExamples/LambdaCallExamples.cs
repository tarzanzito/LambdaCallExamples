
using System.Reflection;

namespace Candal
{
    public delegate void ModelDelegate(string key, AnyModel model);

    public class LambdaCallExamples
    {
        public void CallStaticLambda(AnyModel model)
        {

            System.Type[] typeArray = new System.Type[] { typeof(string), typeof(AnyModel) };

            //get static methodInfo 
            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //static  method name e signatue
           // System.Reflection.MethodInfo methodInfob = typeof(AnyClass).GetMethod("Create", typeArray); //static method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");

            System.Linq.Expressions.ParameterExpression param1 = System.Linq.Expressions.Expression.Parameter(typeof(string), "v");
            System.Linq.Expressions.ParameterExpression param2 = System.Linq.Expressions.Expression.Parameter(typeof(AnyModel), "c");

            //set destination call and  parameters right parameters: => method(v, c)
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(methodInfo, param1, param2);

            //set left parameters  (v, c) => ....
            System.Linq.Expressions.ParameterExpression[] parameterExpressionArray =
                new System.Linq.Expressions.ParameterExpression[] { param1, param2 };

            //final lambda
            System.Linq.Expressions.Expression<ModelDelegate> lambdaExpression =
            System.Linq.Expressions.Expression.Lambda<ModelDelegate>(methodCall, parameterExpressionArray);

            ModelDelegate action = lambdaExpression.Compile();

            //Execute
            action.Invoke("value Static", model);
        }

        
        public void CallInstanceLambda1(AnyModel model)
        {
            //call: void Create1(string a, AnyModel b)

            //create instance
            AnyClass anyClass = new AnyClass();

            System.Type[] typeArray = new System.Type[] { typeof(string), typeof(AnyModel) };

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            //create constant expression for instance
            System.Linq.Expressions.ConstantExpression thisParameter =
                System.Linq.Expressions.Expression.Constant(anyClass); //instance


            System.Linq.Expressions.ParameterExpression param1 =
                System.Linq.Expressions.Expression.Parameter(typeof(string), "v");
            System.Linq.Expressions.ParameterExpression param2 =
                System.Linq.Expressions.Expression.Parameter(typeof(AnyModel), "c");


            // Creating an expression for the method call and specifying its parameter.
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(thisParameter, methodInfo, param1, param2);

 
            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            System.Linq.Expressions.ParameterExpression[] parameterExpressionArray =
                new System.Linq.Expressions.ParameterExpression[] { param1, param2 };


            System.Linq.Expressions.Expression<ModelDelegate> lambdaExpression =
            System.Linq.Expressions.Expression.Lambda<ModelDelegate>(methodCall, parameterExpressionArray);

            ModelDelegate action = lambdaExpression.Compile();

            action.Invoke("value One", model);
        }


        public void CallInstanceLambda2(AnyModel model)
        {
            //call void Create1()

            //create instance
            AnyClass anyClass = new AnyClass();

            System.Type[] typeArray = new System.Type[0]; //parms

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            //create constant expression for instance
            System.Linq.Expressions.ConstantExpression thisParameter =
                System.Linq.Expressions.Expression.Constant(anyClass); //instance


            System.Linq.Expressions.ParameterExpression param1 =
                System.Linq.Expressions.Expression.Parameter(typeof(string), "v");
            System.Linq.Expressions.ParameterExpression param2 =
                System.Linq.Expressions.Expression.Parameter(typeof(AnyModel), "c");


            // Creating an expression for the method call and specifying its parameter.
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(thisParameter, methodInfo); //no parms


            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            System.Linq.Expressions.ParameterExpression[] parameterExpressionArray =
                new System.Linq.Expressions.ParameterExpression[] { param1, param2 };


            System.Linq.Expressions.Expression<ModelDelegate> lambdaExpression =
            System.Linq.Expressions.Expression.Lambda<ModelDelegate>(methodCall, parameterExpressionArray);

            ModelDelegate action = lambdaExpression.Compile();

            action.Invoke("value Two", model);
        }


        public void CallInstanceLambda3(AnyModel model)
        {
            //create instance
            AnyClass anyClass = new AnyClass();

            System.Type[] typeArray = new System.Type[] { typeof(string) };

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            //create constant expression for instance
            System.Linq.Expressions.ConstantExpression thisParameter =
                System.Linq.Expressions.Expression.Constant(anyClass); //instance


            System.Linq.Expressions.ParameterExpression param1 =
                System.Linq.Expressions.Expression.Parameter(typeof(string), "v");
            System.Linq.Expressions.ParameterExpression param2 =
                System.Linq.Expressions.Expression.Parameter(typeof(AnyModel), "c");


            // Creating an expression for the method call and specifying its parameter.
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(thisParameter, methodInfo, param1);


            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            System.Linq.Expressions.ParameterExpression[] parameterExpressionArray =
                new System.Linq.Expressions.ParameterExpression[] { param1, param2 };


            System.Linq.Expressions.Expression<ModelDelegate> lambdaExpression =
            System.Linq.Expressions.Expression.Lambda<ModelDelegate>(methodCall, parameterExpressionArray);

            ModelDelegate action = lambdaExpression.Compile();

            action.Invoke("value Three", model);
        }


        public void CallInstanceLambda4(AnyModel model)
        {
            //create instance
            AnyClass anyClass = new AnyClass();

            System.Type[] typeArray = new System.Type[] { typeof(AnyModel) };

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            //create constant expression for instance
            System.Linq.Expressions.ConstantExpression thisParameter =
                System.Linq.Expressions.Expression.Constant(anyClass); //instance


            System.Linq.Expressions.ParameterExpression param1 =
                System.Linq.Expressions.Expression.Parameter(typeof(string), "v");
            System.Linq.Expressions.ParameterExpression param2 =
                System.Linq.Expressions.Expression.Parameter(typeof(AnyModel), "c");


            // Creating an expression for the method call and specifying its parameter.
            System.Linq.Expressions.MethodCallExpression methodCall =
                System.Linq.Expressions.Expression.Call(thisParameter, methodInfo, param2);


            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            System.Linq.Expressions.ParameterExpression[] parameterExpressionArray =
                new System.Linq.Expressions.ParameterExpression[] { param1, param2 };


            System.Linq.Expressions.Expression<ModelDelegate> lambdaExpression =
            System.Linq.Expressions.Expression.Lambda<ModelDelegate>(methodCall, parameterExpressionArray);

            ModelDelegate action = lambdaExpression.Compile();

            action.Invoke("value Four", model);
        }


        public void CallStaticDelegate(AnyModel model)
        {
            System.Type[] typeArray = new System.Type[] { typeof(string), typeof(AnyModel) };

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            System.Type delegateType = typeof(ModelDelegate);
            System.Delegate delegateNew = System.Delegate.CreateDelegate(delegateType, null, methodInfo);
            ModelDelegate action = (ModelDelegate)delegateNew;


            action.Invoke("value Static delegate", model);
        }


        public void CallInstanceDelegate(AnyModel model)
        {
            //create instance
            AnyClass anyClass = new AnyClass();

            System.Type[] typeArray = new System.Type[] { typeof(string), typeof(AnyModel) };

            System.Reflection.MethodInfo methodInfo = typeof(AnyClass).GetMethod("Create1", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public,
                null, CallingConventions.Any, typeArray, null); //instance  method name e signatue

            if (methodInfo == null)
                throw new System.Exception("Method not found.");


            System.Type delegateType = typeof(ModelDelegate);
            System.Delegate delegateNew = System.Delegate.CreateDelegate(delegateType, anyClass, methodInfo);
            ModelDelegate action = (ModelDelegate)delegateNew;


            action.Invoke("value Instance Delegate", model);
        }



        //static void LookAtThis(System.Linq.Expressions.Expression<Action> expression)
        //{
        //    //inspect:
        //    System.Reflection.MethodInfo method = ((System.Linq.Expressions.MethodCallExpression)expression.Body).Method;
        //    System.Diagnostics.Debug.Print("Method = '{0}'", method.Name);

        //    //execute:
        //    Action action = expression.Compile();
        //    action();
        //}
        //static void LookAtThis2(System.Linq.Expressions.Expression<Action<string, int>> expression)
        //{
        //    //inspect:
        //    System.Reflection.MethodInfo method = ((System.Linq.Expressions.MethodCallExpression)expression.Body).Method;
        //    System.Diagnostics.Debug.Print("Method = '{0}'", method.Name);

        //    //execute:
        //    Action<string, int> action = expression.Compile();
        //    action("tarzanzito", 20);
        //}

        //private static Func<int, int> ComposeLambda(Func<int, int> innerLambda)
        //{
        //    Func<int, int> outerLambda = i => i + 2;
        //    var parameter = System.Linq.Expressions.Expression.Parameter(typeof(int));

        //    var callInner = System.Linq.Expressions.Expression.Invoke(System.Linq.Expressions.Expression.Constant(innerLambda), parameter);
        //    var callOuter = System.Linq.Expressions.Expression.Invoke(System.Linq.Expressions.Expression.Constant(outerLambda), callInner);

        //    var composedLambdaExpression = System.Linq.Expressions.Expression.Lambda<Func<int, int>>(callOuter, parameter);
        //    return composedLambdaExpression.Compile();
        //}
    }
}

