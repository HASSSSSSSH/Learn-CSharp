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
        // 定义一个 unsafe 代码块
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
            Console.WriteLine($"*p1 = {*p1}");

            // p2 是指向 int 指针的指针
            int** p2 = &p1;
            Console.WriteLine($"**p2 = {**p2}");

            // p3 是指向未知类型的指针, 不能对 void* 类型的指针直接使用间接寻址运算符 *
            void* p3 = &numbers[1];
            Console.WriteLine($"*(int*)p3 = {*((int*)p3)}");

            // p4 是指向 int 指针的一维数组
            int*[] p4 = { &numbers[2], &numbers[1] };
            Console.WriteLine($"*p4[0] = {*p4[0]}, *p4[1] = {*p4[1]}");
        }
    }

    /// <summary>
    /// 对指针执行运算
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        int[] a = new int[5] { 10, 20, 30, 40, 50 };

        unsafe
        {
            // 使用 fixed 语句将对象固定在堆上
            fixed (int* p1 = &a[0])
            {
                int* p2 = p1;
                Console.WriteLine($"*p2 = {*p2}");
                Console.WriteLine($"*(++p2) = {*(++p2)}");
                Console.WriteLine($"*(++p2) = {*(++p2)}");
                Console.WriteLine($"*p1 = {*p1}");
                *p1 += 1;
                Console.WriteLine($"*p1 = {*p1}");
                p2 -= 2;
                Console.WriteLine($"*p2 = {*p2}");
            }
        }

        Console.WriteLine($"a[0] = {a[0]}");
    }

    /// <summary>
    /// 使用函数指针
    /// </summary>
    [TestMethod]
    public unsafe void TestMethod3()
    {
        // 只能在 unsafe 上下文中声明函数指针
        static T UnsafeCombine<T>(delegate*<T, T, T> combinator, T left, T right)
        {
            return combinator(left, right);
        }

        static int localMultiply(int x, int y) => x * y;

        int value = UnsafeCombine(&localMultiply, 2, 3);
        Console.WriteLine($"UnsafeCombine return: {value}");
    }
}
