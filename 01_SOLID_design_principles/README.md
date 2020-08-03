# Section 1: The SOLID Design principles

## Single Responsibility Principle
The Single Responsibility Principle is very simple. A class should only be responsible for one thing and has one reason to change. 

* A class should only have one reason to change.
* *Separation of concerns* - different classes handling different, independent tasks/problems.

## Open-Closed Principle
The Open-Closed Principle states that classes should be open for extension but closed for modification. This means that we should be able to extend the functionality but never have to modify code that is already there.

* Classes should be open for extension but closed for modification.
* If you have a class that has been written and tested then it is often bad to come back into this class and modify it. Try to instead extend the class by using inheritance, interfaces and dependency injection.

## Liskov Substitution Principle
The idea here is quite simple. You should be able to substitute a base type for a subtype, which sounds somewhat cryptic but makes sense when looking at an example.

* You should be able to substitute a base type for a subtype.
* A descendant should be able to be cast to its base type and stored in a variable of the base type and still be able to operate correctly for the most part. This means that you might want to make certain methods virtual in order to access the correct members.

## Interface Segregation Principle
The idea behind the Interface Segregation Principle is that interfaces should not be too large, it is better to have many small ones rather than one big. In this way, nobody who wants to implement your interface needs to implement functions that they don't need. Don't bundle multiple different concerns into a single interface.

* Don't put too much into an interface; split it into separate interfaces.
* YAGNI - You Ain't Going To Need It

## Dependency Inversion Principle
The Dependency Inversion Principle states that high-level parts of a system should not depend on the low-level parts of a system directly. They should instead depend on some sort of abstraction.

* High-level modules should not depend upon low-level ones; use abstractions
* Basically you should not expose the implementation details directly. If you are emulating a database store and have a collection in there you should not expose it directly, instead provide a queryable interface that contains methods for accessing the collection.

## Code examples

### Code example: Single Responsibility Principle
We want the persistence of journals to be separate from the core journal functionality. 

#### Solution
We create a Persistence class for this purpose.

### Code example: Open-Closed Principle
We are building an ordering system where you can buy products with certain categories/traits. ProductFilter in this case is breaking the Open-Closed Principle since we should not have to go into the filter and edit code that is already there in order to edit the filtering possibilities. This is because we can assume that the filter has already been shipped to a customer.

#### Solution
The answer to this problem is inheritance, we implement interfaces by using the Specification pattern. The first interface is ISpecification which works as a predicate to see if a T fulfills certain criterias, such as being a certain color. The other interface is IFilter is a filtering mechanism on any type T which uses the specification in order to filter the items. Now we create a BetterFilter by using these two interfaces. BetterFilter should never have to be modifed.

In this way, we never have to modify BetterFilter that has already been shipped to customers. Instead, we can add new modules that implement the ISpecification interface.

### Code example: Liskov Substitution Principle
We have a program that contains basic shapes such as squares and rectangles. Since a square is a kind of rectangle, we decide to inherit the Rectangle class in our Square class. In the Square class, we define setters for the height and the width to make sure that they are always equal. This works fine when writing `Square sq = new Square();` but if we write `Rectangle sq = new Square();` it stops working because then `sq.Width = 4` only sets the width and not the height. 

The above violates the Liskov Substitution Principle since you should always be able to "upcast" and use the base type when creating the variable.

#### Solution
The solution to this is to make the properties of the base class (Rectangle) virtual and then override them in the subclass (Square).

### Code example: Interface Segregation Principle
In the example we have documents and certain machines that work on documents such as scanners, printers etc. We build an IMachine interface that has methods Print, Scan and Fax. This works well for a MultiFunctionPrinter class that can implement all of these methods. However, an OldFashionedPrinter cannot Fax or Scan so we get two additional methods where we just throw exceptions or something.

#### Solution
We create smaller interfaces like IPrinter and IScanner.

### Code example: Dependency Inversion Principle
We are building a genealogy application (the study of family histories). For our low-level part we have a Relationships class and for our high-level part we have a Research class where we want to access relationships. 

One way to make Research able to access Relationships properties is to make a public list of relations in the Relationships class and then inject the Relationships class into the Research constructor. The problem with this is that we are accessing a very low-level part of the Relationships class. This prevents the Relationships class from changing the way relations are stored if it would want to.

#### Solution
We form an abstraction by creating an interface IRelationshipBrowser that Relationships implement and then inject that into the Research constructor. We now depend on an abstraction instead of the low-level module directly.