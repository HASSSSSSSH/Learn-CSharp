using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Array;

[TestClass]
public class ArrayTest
{
    private const string TAG = "ArrayTest";

    [TestMethod]
    public void TestMethod1()
    {
        // 一维数组
        int[] array1 = new int[5];

        // 声明和初始化一个包含 5 个元素的一维数组
        int[] array2 = new int[] { 1, 2, 3, 4, 5 };

        // 声明和初始化一个包含 5 个元素的一维数组
        int[] array3 = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"{TAG}: array1[0] = {array1[0]}");
        Console.WriteLine($"{TAG}: array2[0] = {array2[0]}");
        Console.WriteLine($"{TAG}: array3[0] = {array3[0]}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        // 二维数组
        int[,] multiDimensionalArray1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // 三维数组
        int[,,] multiDimensionalArray2 = new int[1, 2, 3]
        {
            { { 1, 2, 3 }, { 4, 5, 6 } },
        };

        // 显示数组的维数
        Console.WriteLine($"{TAG}: multiDimensionalArray1.Rank = {multiDimensionalArray1.Rank}");
        Console.WriteLine($"{TAG}: multiDimensionalArray2.Rank = {multiDimensionalArray2.Rank}");

        // 2
        Console.WriteLine($"{TAG}: multiDimensionalArray1[0, 1] = {multiDimensionalArray1[0, 1]}");

        // 5
        Console.WriteLine($"{TAG}: multiDimensionalArray1[1, 1] = {multiDimensionalArray1[1, 1]}");

        // 6
        Console.WriteLine($"{TAG}: multiDimensionalArray1[1, 2] = {multiDimensionalArray1[1, 2]}");

        // 2
        Console.WriteLine($"{TAG}: multiDimensionalArray1[0, 0, 1] = {multiDimensionalArray2[0, 0, 1]}");

        // 5
        Console.WriteLine($"{TAG}: multiDimensionalArray1[0, 1, 1] = {multiDimensionalArray2[0, 1, 1]}");

        // 6
        Console.WriteLine($"{TAG}: multiDimensionalArray1[0, 1, 2] = {multiDimensionalArray2[0, 1, 2]}");
    }

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

        // NullReferenceException
        // Console.WriteLine($"{TAG}: jaggedArray[2][2] = {jaggedArray[2][2]}");

        // 6
        Console.WriteLine($"{TAG}: jaggedArray[5][1] = {jaggedArray[5][0]}");
    }
}
