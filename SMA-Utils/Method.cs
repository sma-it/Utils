﻿using System;
using System.Reflection;


namespace SMUtils
{
    public class Method
    {
        private MethodInfo method;
        private object obj;

        public Method(MethodInfo method, object obj)
        {
            this.method = method;
            this.obj = obj;
        }

        public object Invoke()
        {
            return Invoke(new object[] { });
        }

        public object Invoke(object arg)
        {
            return Invoke(new object[] { arg });
        }

        public object Invoke(object[] args)
        {
            try
            {
                return method.Invoke(obj, args);
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Using your method "
                    + method.Name
                    + " with arguments "
                    + args.ToString()
                    + "resulted in this error: \n\t"
                    + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return null;
        }

        public bool HasReturnType(Type type)
        {
            return method.ReturnType == type;
        }

        public Type GetReturnType()
        {
            return method.ReturnType;
        }
    }
}