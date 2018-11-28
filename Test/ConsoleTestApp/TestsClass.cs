using System;
namespace ConsoleTestApp
{
    public class A
    {
        public virtual void Foo()
        {
            Console.Write("Class A");
        }
    }

    public class B : A
    {
        public override void Foo()
        {
            Console.Write("Class B");
        }
    }
}
