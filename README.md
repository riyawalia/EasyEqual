# EasyEqual
### Objective
Tired of writing repetitive object.equals to compare primitive and non-primitive fields of every complex class you define? <br>
This application uses Reflection and Generic Types and allows you to simply generate &lt;T>.Equal for any class. It not only checks whether objects are of the same instance but also if they are different instances but equal with respect to field values.  

### Features 

### Syntax

EasyEquals supports the popular AAA style of unit tests by providing an easy to understand syntax:
```C#
var compare = new Compare<Fruit>(); 
compare.SetUp(apples, oranges); 
Assert.IsFalse(compare.AreEqual()); 
```

Define a compare instance for a single type and use it repetitively: 

```C#
public Compare<Fruit> compare = new Compare<Fruit>(); 

compare.SetUp(apples, apples); 
Assert.IsTrue(compare.AreEqual());

compare.SetUp(apples, seasonedApples);
Assert.IsTrue(compare.AreEqual());
```

Make use of constructors to execute a detailed equality:
```C#
var compareQuality = compare<Fruit>(rottenFruits, freshFruit);  
bool areEqual = compareQuality.AreEqual(); 
Console.WriteLine(compareEquality.Differences()); 
Console.WriteLine(compareEquality.Differences(deepEquality: true)); 
```

EasyEquals also supports a quick and dirty syntax to use outside of unit tests:
```C#
bool areEqual = Compare<Fruit>.AreEqual(oranges, oranges); 
```
Overload functions to include more features: 
```C#
Compare<Fruit>.AreEqual(hisApples, myApples, deepEquality: true); 

var compare = new Compare<Fruit>(); 
compare.SetUp(ourApples, theirApples); 
Assert.IsTrue(compare.AreEqual(deepEquality:true)); 
```
### Currently Working On
This application currently supports a shallow equality check of all types - simple and complex. I am currently working on supporting 
 * Deep Equality including nested complex types
 * Accessing a detailed description of unequal values to support well-defined error messages if assertion fails during unit tests 

### Contacting me 
If you have any ideas about any new features I could implement, feel free to contact me on riya.walia@edu.uwaterloo.ca 
