This work in progress is intended to bridge the gap between NUnit and 
Behavior Driven Design (BDD). Other BDD frameworks in C# rewrite what 
NUnit provides. Behavioral NUnit attempts to add BDD to NUnit without 
throwing out the good parts of NUnit.

Theory
=====================

Frameworks like [Rspec](http://rspec.info/) and [Jasmine](http://pivotal.github.com/jasmine/) 
are perfectly suited to the BDD design pattern, mostly because the 
languages they're implemented in (Ruby & JavaScript) have certain features
that make them easy to implement BDD. C# has some features in common
with Ruby & JS, but current implementations [imo] don't make effective
usage of existing C# features and, as a result, they look ugly.

I'm still working on Behavioral NUnit, but my hope is that it will bring
beauty to BDD in C#. 

Quick Start
=====================

Use operator overloads for better assertions

```csharp
var spec = new Spec();
var result = CalculateRating();
spec.It["uses operator overloads instead of awkward fluent methods"] = 
    result.Should() == 5;

spec.It["uses boolean operators to combine assertions"] =
    result.Should() > 3 && result.Should() < 6;

spec.It["allows you to use parentheses for clarity"] =
    result.Should() > 3 && (result.Should() < 6 || result.Should() > 60);

// Not yet implemented
spec.It["allows you to use clearer, more mathematical range specs"] = 
		3 < result.Should() < 6;
```

Collection and string spec API's are still undesigned & unimplemented. No
idea will be implemented until it's truly beautiful & utterly clear.
Much of this is still theory and not even releasable yet. If the idea 
interests you, please fork the repository and contribute your ideas.
