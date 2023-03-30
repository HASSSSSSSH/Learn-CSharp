namespace Fundamentals.Generic;

public class Class2<K, V> : Class1<K, V>
{
    private const string TAG = "Class2<T1, T2>";

    private Dictionary<K, V> dictionary = new Dictionary<K, V>();

    /// <summary>
    /// 方法的类型参数 K 与类的类型参数 K 不同
    /// </summary>
    public override void Method1<K>(K key)
    {
        base.Method1(key);

        Console.Out.WriteLine($"{TAG}: Method1<K>(K), typeof(K) = {typeof(K)}");

        if (dictionary.Count > 0)
        {
            Type outerTypeK = dictionary.Keys.GetEnumerator().Current!.GetType();
            Console.Out.WriteLine($"{TAG}: Method1<K>(K), outerTypeK = {outerTypeK}");
            Console.Out.WriteLine($"{TAG}: Method1<K>(K), (outerTypeK == typeof(K)) = {outerTypeK == typeof(K)}");
        }
    }

    /// <summary>
    /// 使用类的类型参数 K
    /// </summary>
    public void Method1(K key)
    {
        base.Method1(key);

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
