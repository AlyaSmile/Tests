using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestOfLogicalAndForDaysMatrix();
            //TestWithObjects();
            //TestStruct();
            //TestListAction();
            //TestIntObj();
            //TestStrings();
            //TestLock();
            //TestYeildClass.TestYield();
            //ThreadClass.TreadsTest();
            ExClass.ExTest();
            Console.ReadLine();
        }

        private static void TestOfLogicalAndForDaysMatrix()
        {
            char[] charMatrix = "1010101010101010101010101010000".ToCharArray();
            int daysMatrix = 0;

            for (int i = 30; i > -1; i--)
            {
                daysMatrix <<= 1;
                char c = charMatrix[i];
                if (c != '0')
                {
                    daysMatrix += 1;
                }
            }

            var departureDate1 = new DateTime(2018, 10, 1);
            var departureDate2 = new DateTime(2018, 10, 2);
            var departureDate3 = new DateTime(2018, 10, 3);
            var departureDate4 = new DateTime(2018, 10, 4);

            var dayMatrixlist = new List<int>()
            {
                1 << (departureDate1.Day - 1), // 1000000000000000000000000000000
                1 << (departureDate2.Day - 1), // 0100000000000000000000000000000
                1 << (departureDate3.Day - 1), // 0010000000000000000000000000000
                1 << (departureDate4.Day - 1)  // 0001000000000000000000000000000
            };

            foreach (var myMatrix in dayMatrixlist)
            {
                Console.WriteLine((daysMatrix & myMatrix) == 0);
                // 1000000000000000000000000000000 и 1010101010101010101010101010000 = 1000000000000000000000000000000
                // 0100000000000000000000000000000 и 1010101010101010101010101010000 = 0000000000000000000000000000000
                // 0010000000000000000000000000000 и 1010101010101010101010101010000 = 0010000000000000000000000000000
                // 0001000000000000000000000000000 и 1010101010101010101010101010000 = 0000000000000000000000000000000
            }
        }

        private static void TestWithObjects()
        {
            // нельзя кастовать к расширенному объекту - ошибка
            B obj1 = (B)new A();
            obj1.Foo();

            // class B
            B obj2 = new B();
            obj2.Foo();

            // class B
            A obj3 = new B();
            obj3.Foo();
        }


        public struct S : IDisposable
        {
            private bool dispose;
            public void Dispose()
            {
                dispose = true;
            }
            public bool GetDispose()
            {
                return dispose;
            }
        }

        private static void TestStruct()
        {
            var s = new S();
            // В using происходит неявное копирование структуры в новую переменную, и для уже вызывается Dispose, а не для оригинальной переменной s.
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());
        }

        private static void TestListAction()
        {
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }
            foreach (var action in actions)
            {
                // когда это вызывается , счетчие уже 10
                action();
            }
        }

        private static void TestIntObj()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((short)obj);
        }

        private static void TestStrings()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            /*
             * если две строки имеют одинаковый набор символов и создаются во время компиляции, то они фактически указывают 
             * на один и тот же объект. строка s1 создается в процессе выполнения, поэтому она будет указывать на другой объект,
             * отличный от s2 и s3. А так как при сравнении объектов сравниваются ссылки, то поэтому мы получим false, так как s1 и s2 разные объекты.
             */
            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);
        }



        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }

        static void TestLock()
        {
            lock (syncObject)
            {
                Write();
            }
        }
    }
}