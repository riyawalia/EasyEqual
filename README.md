# EasyEqual
### Objective
Tired of writing repetitive `object.Equals()` to unit test every complex class you define? <br>
Simply include this library in your project to use value-based equality functions for all your classes.  

### Usages

EasyEqual now supports a single equality function for all types - giving you an easy to read, instinctive syntax:
``` C#
var equality = Compare.AreEqual(apples, apples);
var inequality = Compare.AreUnequal(apples, oranges); 
```
EasyEqual also supports a quick and dirty syntax for unit tests 
``` C#
Compare.AssertEqual(apples, apples, "Apples should be equal to apples"); 
Compare.AssertUnequal(apples, oranges, "Apples should not be equal to oranges"); 
```

Overload functions to include more features: 
```C#
Compare.AreEqual(hisApples, myApples, ignorePrivateFields: true); 
```
### Conventions 
This library uses standard PascalCase and camelCase naming conventions as outlined by Microsoft [here!](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions) 
### Currently Working On
This application currently supports a shallow equality check of all types - simple and complex. <br> I am currently working on supporting - 
 * Deep equality checks including nested complex types
 * Accessing a detailed description of unequal values to support well-defined error messages if assertion fails during unit tests 
 * Equality checks on interchangeable data types based on values (such as "45".ToInt() and 45)
 * Determining the data type of input parameters at run time (To migrate from Compare &lt;Fruit> to simply Compare)
 * Making this project self-containable so it easy to clone and include in your project on cross platforms 
### Download
Coming soon
### Features 
Coming soon
### Requirements
Coming soon
### Contact Me 
If you have ideas about any new features I could implement, feel free to contact me on riya.walia@edu.uwaterloo.ca .
