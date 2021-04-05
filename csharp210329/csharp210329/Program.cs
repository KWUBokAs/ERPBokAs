using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
namespace csharp210329 {
    class Animal {
        public virtual void Eat() {
            Console.WriteLine("동물이 먹는다.");
        }
        public virtual void Speek() {
            Console.WriteLine("동물이 소리낸다.");
        }
    }
    class Pig : Animal {
        public override void Eat() {
            Console.WriteLine("꿀꿀 아 돼지사료 맛이쪙.");
        }
        public override void Speek() {
            Console.WriteLine("꿀꿀꿀.");
        }
    }
    class Human : Animal {
        public override void Eat() {
            Console.WriteLine("오늘 점심은 라면이네.");
        }
        public override void Speek() {
            Console.WriteLine("야 김대리 이게 일이라고 해온거야?");
        }
    }
    [Serializable]
    public class Student {
        public int age = 0;
        public string name = "";
    }

    public static class MyStaticClass {
        static string myValue;
        public static void setValue(string val) {
            myValue = val;
        }
        public static string getValue() {
            return myValue;
        }
    }

    public class MyNotStaticClass {
        public static int count;
        public int mcount;
        public static int methodCount() {
            return count;
        }
        public int methodmCount() {
            return mcount;
        }
        public static void setcount(int value) {
            count = value;

        }

    }
    
    class Program {
        public static void Assignment2() {

        }
        public static void Assingment2A() {
            Pig p = new Pig();
            Human k = new Human();
            Animal[] animals = { p, k };
            foreach (Animal animal in animals) {
                animal.Eat();
                animal.Speek();
            }
        }
        public static void Assignment2B() {
            void myMethod(ref int n, out int result) {
                result = n * 1000; // 8 * 1000 = 8000
                n -= 7; // 8 -7 = 1
            }
            int myvalue = 8;
            myMethod(ref myvalue, out int result);
            Console.WriteLine("myValue: {0} result: {1}",myvalue,result);
        }

        public static void Assignment2C() {
            List<int> myintlist = new List<int>();
            List<string> mystringlist = new List<string>();
            myintlist.Add(7);
            myintlist.Add(10);
            myintlist.Add(1520);
            mystringlist.Add("Hel");
            mystringlist.Add("lo, ");
            mystringlist.Add(".NET World!");

            foreach(var myval in myintlist) {
                Console.Write(myval + " ");
            }
            Console.WriteLine("");
            foreach (var myval in mystringlist) {
                Console.Write(myval);
            }

        }
        public static void Assignment2D() {
            Student astudent = new Student();
            astudent.age = 17;
            astudent.name = "김갑환";
            Stream ws = new FileStream("a.student", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ws, astudent);
            ws.Close();
        }
        [Flags]
        public enum mycustumenum {
            None = 0,
            Move = 1 << 0, // 1
            Jump = 1 << 1, // 2
            Sit = 1 << 2, // 4
            Fly = 1 << 3, // 8
            Stop = 1 << 4 //16            
        }
        public static void Assignment2E() {
            mycustumenum myenum;
            myenum = mycustumenum.Move | mycustumenum.Fly | mycustumenum.None;
            if (myenum == mycustumenum.None) {
                Console.WriteLine("I am None");
            }
            if (myenum == mycustumenum.Move) {
                Console.WriteLine("I am Move");
            }
            if (myenum == mycustumenum.Jump) {
                Console.WriteLine("I am Jump");
            }
            if (myenum == mycustumenum.Sit) {
                Console.WriteLine("I am Sit");
            }
            if (myenum == mycustumenum.Fly) {
                Console.WriteLine("I am Fly");
            }
            if (myenum == mycustumenum.Stop) {
                Console.WriteLine("I am Stop");
            }
            if (myenum.HasFlag(mycustumenum.None)) {
                Console.WriteLine("I am None 2");
            }
            if (myenum.HasFlag(mycustumenum.Move)) {
                Console.WriteLine("I am Move 2");
            }
            if (myenum.HasFlag(mycustumenum.Jump)) {
                Console.WriteLine("I am Jump 2");
            }
            if (myenum.HasFlag(mycustumenum.Sit)) {
                Console.WriteLine("I am Sit 2");
            }
            if (myenum.HasFlag(mycustumenum.Fly)) {
                Console.WriteLine("I am Fly 2");
            }
            if (myenum.HasFlag(mycustumenum.Stop)) {
                Console.WriteLine("I am Stop 2");
            }
        }
        public static void Assignment2F() {
            MyStaticClass.setValue("마이 리틀 과제");
            Console.WriteLine("값 출력: "+MyStaticClass.getValue());

            MyNotStaticClass mnsc1 = new MyNotStaticClass();
            MyNotStaticClass mnsc2 = new MyNotStaticClass();
            mnsc1.mcount = 70;
            mnsc2.mcount = 30;

            MyNotStaticClass.count = 100;
            Console.WriteLine("mnsc1: "+mnsc1.mcount);
            Console.WriteLine("mnsc2: " + mnsc2.mcount);
            Console.WriteLine("count: " + MyNotStaticClass.count);
        }

        public static void Assignment2G() {
            Thread mythread1 = new Thread(new ThreadStart(Run1));
            Thread mythread2 = new Thread(new ThreadStart(Run2));

            mythread1.Start();
            Console.WriteLine("");
            mythread2.Start();
            mythread1.Join();
            mythread2.Join();
        }
        public static void Run1() {
            for(int i=0; i< 10; i++) {
                Console.Write(" "+i);
            }
            Console.WriteLine("");
        }
        public static void Run2() {
            for (int i = 10; i >= 0; i--) {
                Console.Write(" " + i);
            }
            Console.WriteLine("");
        }
        delegate int delegateMethod(int a, int b);
        public static void Assignment2H() {
            delegateMethod method1 = new delegateMethod(Add);
            int result1 = method1(1, 4);
            delegateMethod method2 = delegate (int a, int b)
            {
                a = a * a;
                b /= 2;
                return a + b;
            };
            int result2 = method2(7, 14);
            Console.WriteLine("result1 = "+result1);
            Console.WriteLine("result2 = " + result2);
        }
        public static int Add(int a, int b) {
            return a + b;
        }
        public static int Sub(int a, int b) {
            return a - b;
        }
        public static int Mul(int a, int b) {
            return a * b;
        }

        static void Main(string[] args) {
            Assignment2H();
        }
    }
}
