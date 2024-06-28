namespace Fundamentals.Generic;

/// <summary>
/// Class2 继承自 Class1
/// 将 Class2 的类型参数 K 和 V 指定给 Class1 的类型参数 A 和 B
/// </summary>
public class Class2<K, V> : Class1<K, V>
{
    private const string TAG = "Class2<K, V>";

    private Dictionary<K, V> dictionary = new Dictionary<K, V>();

    /// <summary>
    /// Method1[k](k) 是泛型方法, 继承自 Class1`2[K,V]
    /// 比较方法的类型参数 K 和类的类型参数 K
    /// </summary>
    public override void Method1<K>(K key)
    {
        Console.Out.WriteLine($"{TAG}: Method1[K](K), typeof(K) = {typeof(K)}");

        if (dictionary.Count > 0)
        {
            Type outerTypeK = dictionary.Keys.GetEnumerator().Current!.GetType();
            Console.Out.WriteLine($"{TAG}: Method1[K](K), outerTypeK = {outerTypeK}");
            Console.Out.WriteLine($"{TAG}: Method1[K](K), (outerTypeK == typeof(K)) = {outerTypeK == typeof(K)}");
        }
    }

    /// <summary>
    /// 使用类的类型参数 K
    /// </summary>
    public void Method1(K key)
    {
        Console.Out.WriteLine($"{TAG}: Method1(K), typeof(K) = {typeof(K)}");

        base.X = key!;
        Type outerTypeK = base.X.GetType();
        Console.Out.WriteLine($"{TAG}: Method1(K), outerTypeK = {outerTypeK}");
        Console.Out.WriteLine($"{TAG}: Method1(K), (outerTypeK == typeof(K)) = {outerTypeK == typeof(K)}");
    }

    public void Add(K key, V value)
    {
        dictionary.Add(key, value);
    }
}
