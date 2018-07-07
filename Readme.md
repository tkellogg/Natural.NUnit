This project is an exploration into using assertion expressions that feel much
more natural to a C# developer. Instead of jumping on the "fluent" API bandwagon,
Natural NUnit makes heavy use of overloaded operators to use the expressiveness
of core C#.

Theory
=====================

Frameworks like [Rspec](http://rspec.info/) and [Jasmine](https://jasmine.github.io/) 
are perfectly suited to the BDD design pattern, mostly because the 
languages they're implemented in (Ruby & JavaScript) have certain features
that make them easy to implement BDD. C# has some features in common
with Ruby & JS, but current implementations [imo] don't make effective
usage of existing C# features and, as a result, they look ugly.

Quick Start
=====================

Use operator overloads for better assertions

```csharp
int result = CalculateRating();

// uses operator overloads instead of awkward fluent methods
Assert.That(result.Should() == 5);

// The == operator can also be an alias for Assert.That(actual, Is.EquivalentTo(expected))
var expected = new List<int>{ 5 };
var actual = new[]{ result };
Assert.That(actual.Should() == expected);

// it uses boolean operators to combine assertions
Assert.That(result.Should() > 3 && result.Should() < 6);

// it allows you to use parentheses for clarity. Use the !operator to negate expressions
Assert.That(result.Should() > 3 && !(result.Should() < 6 || result.Should() > 60));

// Not yet implemented
// it allows you to use clearer, more mathematical range specs
Assert.That(3 < result.Should() < 6);
```

Please fork & contribute!
