using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unsafe;

[TestClass]
public class UnsafeTest
{
    /// <summary>
    /// 使用指针类型
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 声明一个 unsafe 代码块
        unsafe
        {
            int length = 5;

            // 使用 stackalloc 表达式在栈上分配内存块
            int* numbers = stackalloc int[length];

            // 初始化
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }

            // p1 是指向 int 的指针
            int* p1 = &numbers[1];
            Console.WriteLine($"(int)p1 = {(int)p1:X}");
            Console.WriteLine($"*p1 = {*p1}");

            // p2 是指向 int 指针的指针
            int** p2 = &p1;
            Console.WriteLine($"\n(int)p2 = {(int)p2:X}");
            Console.WriteLine($"(int)*p2 = {(int)*p2:X}");
            Console.WriteLine($"**p2 = {**p2}");

            // p3 是指向 int 指针的一维数组
            int*[] p3 = { &numbers[2], &numbers[1] };
            Console.WriteLine($"\n*p3[0] = {*p3[0]}, *p3[1] = {*p3[1]}");

            // p4 是指向未知类型的指针, 不能对 void* 类型的指针直接使用间接寻址运算符 *
            void* p4 = &numbers[1];
            Console.WriteLine($"\n(int)p4 = {(int)p4:X}");
            Console.WriteLine($"*((int*)p4) = {*((int*)p4)}");
        }
    }

    /// <summary>
    /// 对指针执行运算
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        int[] arr = new int[5] { 10, 20, 30, 40, 50 };

        // 声明一个 unsafe 代码块
        unsafe
        {
            // 使用 fixed 语句固定用于指针操作的变量
            fixed (int* p1 = &arr[0])
            {
                int* p2 = p1;
                Console.WriteLine($"*p2 = {*p2}");
                Console.WriteLine($"*(++p2) = {*(++p2)}");
                Console.WriteLine($"*(++p2) = {*(++p2)}");
                Console.WriteLine($"*(--p2) = {*(--p2)}");

                Console.WriteLine($"\n*p1 = {*p1}");
                *p1 += 1;
                Console.WriteLine($"*p1 = {*p1}");

                if (p2 > p1)
                {
                    p2 -= (p2 - p1);
                    Console.WriteLine($"\n*p2 = {*p2}");
                }
            }
        }

        Console.WriteLine($"\narr[0] = {arr[0]}");
    }

    /// <summary>
    /// 使用函数指针
    /// </summary>
    [TestMethod]
    public unsafe void TestMethod3()
    {
        // 注意到在方法的声明中使用了 unsafe 修饰符
        // 只能在 unsafe 上下文中声明函数指针
        // 只能在 unsafe 上下文中调用采用 delegate* 的方法

        static U Combine<T, U>(Func<T, T, U> combinator, T left, T right)
        {
            return combinator(left, right);
        }

        static U UnsafeCombine<T, U>(delegate*<T, T, U> combinator, T left, T right)
        {
            return combinator(left, right);
        }

        // 只能在 static 函数上使用 & 运算符来获取函数的地址
        static string localMultiply(int x, int y) => (x * y).ToString();

        string value1 = Combine(localMultiply, 2, 3);
        string value2 = UnsafeCombine(&localMultiply, 2, 3);
        Console.WriteLine($"Combine return: \"{value1}\"");
        Console.WriteLine($"UnsafeCombine return: \"{value2}\"");
    }
}
