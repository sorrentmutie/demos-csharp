var p = new Person("Mario", "Rossi");
var q = new Person("Mario", "Rossi");

var r = p with { FirstName = "Luigi" };

System.Console.WriteLine(p == q);

record Person(string FirstName, string LastName) {}

// EF Core relies on reference types to track changes