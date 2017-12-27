using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace hw18
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskOne();
            TaskTwo();

            Console.ReadLine();
        }

        static void TaskOne()
        {
            Type myType = typeof(Console);
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual ";
                Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");

                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        static void TaskTwo()
        {
            Person person1 = new Person() { Name = "Alex", Age = 28 };
            Type myType = person1.GetType();

            foreach (FieldInfo fieldInfo in myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var value = fieldInfo.GetValue(person1);
                Console.WriteLine(value);
            }
        }
    }
}
