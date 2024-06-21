using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Array;

[TestClass]
public class ArrayTest
{
    private const string TAG = "ArrayTest";

    /// <summary>
    /// 一维数组
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 声明一个包含 5 个元素的一维数组, 但未初始化
        int[] array1 = new int[5];

        // 声明和初始化一个包含 5 个元素的一维数组
        int[] array2 = new int[] { 1, 2, 3, 4, 5 };

        // 声明和初始化一个包含 5 个元素的一维数组
        int[] array3 = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"{TAG}: array1[0] = {array1[0]}");
        Console.WriteLine($"{TAG}: array2[0] = {array2[0]}");
        Console.WriteLine($"{TAG}: array3[0] = {array3[0]}");
    }

    /// <summary>
    /// 多维数组
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        // 二维数组
        int[,] array2D = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // 三维数组
        int[,,] array3D = new int[1, 2, 3]
        {
            { { 1, 2, 3 }, { 4, 5, 6 } },
        };

        // 显示数组的维数
        Console.WriteLine($"{TAG}: array2D.Rank = {array2D.Rank}");
        Console.WriteLine($"{TAG}: array3D.Rank = {array3D.Rank}");

        // 在二维数组中, 可以将左索引视为行, 将右索引视为列
        // 2
        Console.WriteLine($"{TAG}: array2D[0, 1] = {array2D[0, 1]}");
        // 5
        Console.WriteLine($"{TAG}: array2D[1, 1] = {array2D[1, 1]}");
        // 6
        Console.WriteLine($"{TAG}: array2D[1, 2] = {array2D[1, 2]}");

        // 使用 foreach 语句遍历二维数组
        StringBuilder builder = new StringBuilder($"{TAG}: array2D = [");
        foreach (var n in array2D)
        {
            builder.Append($"{n}, ");
        }

        builder.Remove(builder.Length - 2, 2);
        builder.Append(']');
        Console.WriteLine(builder.ToString());

        // 可以将三维数组视为包含多个二维数组的数组
        // 2
        Console.WriteLine($"{TAG}: array3D[0, 0, 1] = {array3D[0, 0, 1]}");
        // 5
        Console.WriteLine($"{TAG}: array3D[0, 1, 1] = {array3D[0, 1, 1]}");
        // 6
        Console.WriteLine($"{TAG}: array3D[0, 1, 2] = {array3D[0, 1, 2]}");

        // 遍历三维数组
        Console.WriteLine($"{TAG}: array3D: ");
        for (int i = 0; i < array3D.GetLength(0); i++)
        {
            for (int j = 0; j < array3D.GetLength(1); j++)
            {
                for (int k = 0; k < array3D.GetLength(2); k++)
                {
                    Console.Write($"{array3D[i, j, k]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// 交错数组
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        // 交错数组
        int[][] jaggedArray = new int[6][];
        jaggedArray[0] = new int[] { 1, 2 };
        jaggedArray[1] = new int[] { 3, 4, 5 };
        jaggedArray[5] = new int[] { 6, 7, 8, 9 };

        // 2
        Console.WriteLine($"{TAG}: jaggedArray[0][1] = {jaggedArray[0][1]}");

        // 5
        Console.WriteLine($"{TAG}: jaggedArray[1][2] = {jaggedArray[1][2]}");

        // 会抛出 NullReferenceException
        // 必须先初始化交错数组的元素才能使用
        // Console.WriteLine($"{TAG}: jaggedArray[2][2] = {jaggedArray[2][2]}");

        // 6
        Console.WriteLine($"{TAG}: jaggedArray[5][0] = {jaggedArray[5][0]}");
    }
}
