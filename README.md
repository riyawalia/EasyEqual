# EasyEqual
### Objective
Tired of writing repetitive object.equals to compare primitive and non-primitive fields of every complex class you define? <br>
This application uses Reflection and Generic Types and allows you to simply generate &lt;T>.Equal for any class. It not only checks whether objects are of the same instance but also if they are different instances but equal with respect to field values.  

### Features 

### Syntax

EasyEquals supports the popular AAA style of unit tests by providing an easy to understand syntax. 
```C#
var compare = new Compare<Foo>(); 
compare.SetUp(actualResult, expectedResult); 
Assert.IsTrue(compare.AreEqual()); 
```

Define a compare instance for a single type and use it repetitively: 

```C#
public Compare<Foo> compare = new Compare<Foo>(); 

compare.SetUp(actualFoo, expectedFoo); 
Assert.IsTrue(compare.AreEqual());

compare.SetUp(actualResult, expectedResult);
Assert.IsTrue(compare.AreEqual());
```

Make use of constructors
```C#
var compareFlavor = compare<Foo>(vanillaFoo, fruityFoo);  
compareFlavor.AreEqual(); 
compareFlavor.AreEqual(deepEquality: true); 
```

EasyEquals also supports a quick and dirty syntax to use outside of unit tests. 
```C#
var areEqual = Compare<Foo>.AreEqual(actualResult, expectedResult); 
```
Overload functions to include more features: 
```C#
Compare<Foo>.AreEqual(actualResult, expectedResult, deepEquality: true); 
var compare = new Compare<Foo>(); 
compare.SetUp(actualResult, expectedResult); 
Assert.IsTrue(compare.AreEqual(deepEquality:true)); 
```

