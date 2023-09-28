// Matching a type & attribute
// C# 1-0 to 6
// if (fruit.GetType() == typeof(Apple) && fruit.Color == "Red") 
// { var apple = fruit as Apple; ... }
// C# 7.0
// switch(fruit)
//{
//case Apple apple when apple.Color == "Red":
//...   
//}
// C# 8.0
// var whatfruit = fruit switch {
// Apple => "This is an apple",
// Orange => "This is an orange",
// _ => "I don't know what this is"
//    }

using Microsoft.Win32.SafeHandles;

TestResult testResult = new Positive();
if(testResult is not Positive){}
if(testResult is  Positive  {NumberOfTests: > 2} ){
    var result = testResult as Positive;
}

if(testResult is Positive {NumberOfTests : > 2} positive){
    // do something with positive
}

if(testResult is Positive {
    NumberOfTests : > 2 and <=5 } p){
    // do something with positive
}

var outCome = testResult switch {
    Positive => "Positive",
    (_, isValid: false) => "What?",
    Negative => "Negative",
    _ => "Unknown"
};






class TestResult {
    public int NumberOfTests { get; set; }
    public bool IsValid { get; set; }
    public DateTimeOffset TestedOn { get; set; }

    public void Deconstruct(
        out int daysSinceTested, 
        out bool isValid) 
    {
        daysSinceTested = (int) (DateTimeOffset.Now - TestedOn).TotalDays;
        isValid = IsValid;
    }
}

class Positive: TestResult {}
class Negative: TestResult {}

