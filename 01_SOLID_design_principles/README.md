# Section 1: The SOLID Design principles

## Single Responsibility Principle
The Single Responsibility Principle is very simple. A class should only be responsible for one thing and has one reason to change. 

> In the code example, we want the persistence of journals to be separate from the core journal functionality. 

> Solution: We create a Persistence class for this purpose.

## Open-Closed Principle
The Open-Closed Principle states that classes should be open for extension but closed for modification. This means that we should be able to add new things but never have to modify code that is already there.

> In the code example, we are building an ordering system where you can buy products with certain categories/traits. ProductFilter in this case is breaking the Open-Closed Principle since we should not have to go into the filter and edit code that is already there in order to edit the filtering possibilities. This is because we can assume that the filter has already been shipped to a customer.

> Solution: The answer to this problem is inheritance, we implement interfaces by using the Specification pattern. The first interface is ISpecification which works as a predicate to see if a T fulfills certain criterias, such as being a certain color. The other interface is IFilter is a filtering mechanism on any type T which uses the specification in order to filter the items. Now we create a BetterFilter by using these two interfaces. BetterFilter should never have to be modifed.

## Liskov Substitution Principle

## Interface Segregation Principle

## Dependency Inversion Principle