# Learn-CSharp

此项目是本人在学习 C# 过程中，为了加深对知识点的理解而编写的代码示例。

另外，可在 [C# 基础](https://hasssssssh.github.io/csharp/fundamentals/)、[C# 不安全代码](https://hasssssssh.github.io/csharp/unsafe-code/) 以及 [C# 异步编程](https://hasssssssh.github.io/csharp/asynchronous-programming/) 查看我在学习过程中所作的笔记，将笔记与代码示例配合起来阅读。



## 简介

项目使用 [MSTest](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-intro) 来编写和运行测试。找到带有 `TestClass` 特性的类，可以直接从一系列名为 "TestMethodXXX" 的带有 `TestMethod` 特性的方法运行测试：

<img src=".\Doc\Images\doc_image_1.jpg" style="zoom: 40%;" />

项目中的类和方法都带有注释，在关键代码上也有相关注释，可以通过阅读注释再配合运行和调试来进一步理解代码。

项目使用的 IDE 是 JetBrains Rider 2022.3.1。

-----------

项目中包含 3 个 Project：

- [**Fundamentals**](https://github.com/HASSSSSSSH/Learn-CSharp/tree/main/Fundamentals)：关于 C# 基础知识的示例。
  - **Array**：数组的相关示例。示例包括：一维数组、多维数组、交错数组、遍历数组等。
  - **Attribute**：特性的相关示例。示例包括：应用特性、自定义特性、检索特性中的信息等。
  - **BoxingUnboxing**：装箱和取消装箱的相关示例。示例包括：装箱和取消装箱值类型、隐式装箱等。
  - **Class**：类类型的相关示例。
    - **Accessibility**：测试不同的可访问性。
    - **Member**：类成员的相关示例。
      - **Constant**：常量的相关示例。示例包括：声明常量、使用 readonly 字段等。
      - **Constructor**：构造函数的相关示例。示例包括：声明和调用构造函数、实现单例模式等。
      - **Event**：事件的相关示例。示例包括：声明事件、订阅事件和取消订阅等。
      - **Field**：字段的相关示例。示例包括：声明和使用实例和静态字段等。
      - **Indexer**：索引器的相关示例。示例包括：声明和使用索引器等。
      - **Method**：方法的相关示例。示例包括：声明和调用带有各种方法参数类型的方法、声明和调用重载方法等。
      - **Operator**：运算符的相关示例。示例包括：重载运算符、使用重载运算符等。
      - **Property**：属性的相关示例。示例包括：声明和使用属性等。
  - **Deconstruct**：析构的相关示例。示例包括：析构元组、析构用户定义类型、使用支持析构的系统类型等。
  - **Delegate**：委托类型的相关示例。示例包括：实例化和使用委托、多播委托等。
  - **Enum**：枚举类型的相关示例。示例包括：枚举类型与其基础整型类型之间的显式转换、使用作为位标志的枚举类型等。
  - **Equality**：相等性的相关示例。示例包括：比较引用类型的引用相等性、比较 string 的引用相等性、比较值类型的值相等性等。
  - **Exception**：异常的相关示例。示例包括：自定义异常、引发和捕获异常、使用 finally 语句等。
  - **Generic**：泛型类型的相关示例。示例包括：声明和使用泛型类和泛型方法、泛型的类型检查、泛型的类型转换等。
    - **Constraint**：泛型类型参数约束的相关示例。示例包括：测试各种类型参数约束等。
  - **Interface**：接口类型的相关示例。示例包括：实现接口、使用接口实现类等。
  - **Iterator**：迭代器的相关示例。示例包括：实现简单的迭代器、使用 IEnumerator 进行迭代、创建集合类等。
  - **NullableRefType**：可为 null 引用类型的相关示例。示例包括：声明和使用可为 null 的引用类型、控制可为 null 的上下文等。
  - **NullableValueType**：可为 null 值类型的相关示例。示例包括：声明和使用可为 null 值类型、检查可为 null 值类型的实例、从可为 null 的值类型转换为基础类型、检查 `System.Type` 实例是否表示已构造的可为 null 值类型等
  - **ObjectOriented**：面向对象的相关示例。示例包括：测试面向对象的继承和多态性。
  - **PatternMatching**：模式匹配的相关示例。示例包括：使用模式匹配进行 null 检查、使用模式匹配进行类型测试、使用模式匹配比较离散值等。
  - **Record**：记录类型的相关示例。示例包括：使用位置参数来声明和实例化记录、使用记录来创建依赖于值相等性的数据模型等。
  - **Reflection**：反射的相关示例。示例包括：使用 `Assembly`、使用 `Module`、获取 `Type` 对象、反射创建对象、列出类的成员等。
    - **Generic**：对泛型使用反射的相关示例。示例包括：检查泛型类型和泛型方法、检查 `Type` 对象是否表示泛型类型定义、检查泛型类型是开放式还是封闭式、创建封闭式泛型类型、检查类型实参和类型形参等。
  - **Struct**：结构类型的相关示例。示例包括：声明结构、结构的初始化和默认值、使用 readonly 结构等。
  - **Tuple**：元组类型的相关示例。示例包括：声明元组、使用元组自身的方法等。
  - **TypeConversion**：类型转换和类型测试的相关示例。示例包括：隐式转换、显式转换、执行用户定义的显式和隐式转换以及 `is`、`as`、`typeof` 运算符的使用等。
- [**Unsafe**](https://github.com/HASSSSSSSH/Learn-CSharp/tree/main/Unsafe)：关于 C# 不安全代码的示例。
- [**Async**](https://github.com/HASSSSSSSH/Learn-CSharp/tree/main/Async)：关于 C# 异步编程的示例。注意，该 Project 没有使用 MSTest，而是使用 `Main` 方法作为 C# 应用程序的入口点。


