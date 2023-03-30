namespace Fundamentals.Interface;

public interface IInterface5 : IInterface3, IInterface2
{
    void Method1(int a);

    void Method1(int? a);

    void Method2(int[] array);
}
