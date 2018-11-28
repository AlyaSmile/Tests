using System;
namespace ConsoleTestApp
{
    public static class ExClass
    {
        class MyCustomException : DivideByZeroException
        {

        }

        public static void ExTest()
        {
            try
            {
                Calc();
            }
            catch (MyCustomException)
            {
                Console.WriteLine("Catch MyCustomException");
                throw;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Catch Exception");
            }
            Console.ReadLine();
        }

        private static void Calc()
        {
            int result = 0;
            var x = 5;
            int y = 0;
            try
            {
                result = x / y;
            }
            catch (MyCustomException)
            {
                Console.WriteLine("Catch DivideByZeroException");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Catch Exception");
            }
            finally
            {
                throw new MyCustomException();
            }
        }
    }
}
