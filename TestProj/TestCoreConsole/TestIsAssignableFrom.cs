﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCoreConsole
{
    class TestIsAssignableFrom
    {
        public static void Start()
        {
            Test1();
        }

        public static void Test1()
        {
            // Demonstrate classes:
            Console.WriteLine("Defined Classes:");
            Room room1 = new Room();
            Kitchen kitchen1 = new Kitchen();
            Bedroom bedroom1 = new Bedroom();
            Guestroom guestroom1 = new Guestroom();
            MasterBedroom masterbedroom1 = new MasterBedroom();

            Type room1Type = room1.GetType();
            Type kitchen1Type = kitchen1.GetType();
            Type bedroom1Type = bedroom1.GetType();
            Type guestroom1Type = guestroom1.GetType();
            Type masterbedroom1Type = masterbedroom1.GetType();

            Console.WriteLine("room assignable from kitchen: {0}", room1Type.IsAssignableFrom(kitchen1Type));
            Console.WriteLine("bedroom assignable from guestroom: {0}", bedroom1Type.IsAssignableFrom(guestroom1Type));
            Console.WriteLine("kitchen assignable from masterbedroom: {0}", kitchen1Type.IsAssignableFrom(masterbedroom1Type));

            // Demonstrate arrays:
            Console.WriteLine();
            Console.WriteLine("Integer arrays:");

            int[] array2 = new int[2];
            int[] array10 = new int[10];
            int[,] array22 = new int[2, 2];
            int[,] array24 = new int[2, 4];

            Type array2Type = array2.GetType();
            Type array10Type = array10.GetType();
            Type array22Type = array22.GetType();
            Type array24Type = array24.GetType();

            Console.WriteLine("int[2] assignable from int[10]: {0}", array2Type.IsAssignableFrom(array10Type));
            Console.WriteLine("int[2] assignable from int[2,4]: {0}", array2Type.IsAssignableFrom(array24Type));
            Console.WriteLine("int[2,4] assignable from int[2,2]: {0}", array24Type.IsAssignableFrom(array22Type));

            // Demonstrate generics:
            Console.WriteLine();
            Console.WriteLine("Generics:");

            // Note that "int?[]" is the same as "Nullable<int>[]"
            int?[] arrayNull = new int?[10];
            List<int> genIntList = new List<int>();
            List<Type> genTList = new List<Type>();

            Type arrayNullType = arrayNull.GetType();
            Type genIntListType = genIntList.GetType();
            Type genTListType = genTList.GetType();

            Console.WriteLine("int[10] assignable from int?[10]: {0}", array10Type.IsAssignableFrom(arrayNullType));
            Console.WriteLine("List<int> assignable from List<Type>: {0}", genIntListType.IsAssignableFrom(genTListType));
            Console.WriteLine("List<Type> assignable from List<int>: {0}", genTListType.IsAssignableFrom(genIntListType));

            //自定义的
            Console.WriteLine("List<Int32> assignable from AAA: {0}", typeof(List<Int32>).IsAssignableFrom(typeof(AAA)));
            Console.WriteLine("I<T> assignable from BBB: {0}", typeof(I<String>).IsAssignableFrom(typeof(BBB)));

            var type = typeof(BBB);
            var type2 = typeof(CCC);
            var type2Info = typeof(CCC).GetTypeInfo()
                                .ImplementedInterfaces
                                .FirstOrDefault(it => it.Name == typeof(I<>).Name);
            Console.ReadLine();
        }
    }

    public interface I<T>
    {
        T ShowMsg();
    }

    public class BBB : I<String>
    {
        public virtual string ShowMsg()
        {
            throw new NotImplementedException();
        }
    }

    public class CCC : BBB
    {
        public override string ShowMsg()
        {
            throw new NotImplementedException();
        }
    }

    class AAA : List<Int32>
    {

    }

    class Room
    {
    }

    class Kitchen : Room
    {
    }

    class Bedroom : Room
    {
    }

    class Guestroom : Bedroom
    {
    }

    class MasterBedroom : Bedroom
    {
    }
}
