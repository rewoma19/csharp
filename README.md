# My C# Learning Notes

What I learn while completing the Exercism C# challenges, with examples and mistakes to remember.

## Exercises

| Exercise                  | Topic                               | Solution                                                            | Learning notes                     |
| ------------------------- | ----------------------------------- | ------------------------------------------------------------------- | ---------------------------------- |
| Lucian's Luscious Lasagna | Basics                              | [Code](./Basics/lucians-luscious-lasagna/LuciansLusciousLasagna.cs) | [Notes](#lucians-luscious-lasagna) |
| Annalyn's Infiltration    | Booleans and static methods         | [Code](./Booleans/annalyns-infiltration/AnnalynsInfiltration.cs)    | [Notes](#annalyns-infiltration)    |
| Cars, Assemble!           | Numbers, conditions and conversions | [Code](./NumbersAndIfs/cars-assemble/CarsAssemble.cs)               | [Notes](#cars-assemble)            |

## Lucian's Luscious Lasagna

### What I learned

- A **class** groups related code. A **method** is a function defined inside a class.
- `public` lets code outside the class call a method. Without an access modifier, methods in a class are private.
- `int` represents a whole number. Before a method name, it specifies the type of value the method returns.
- A **parameter** is a named input in a method definition, such as `int numOfLayers`. An **argument** is the value supplied when calling it, such as `3`.
- `return` sends a value back to the code that called the method. Another method can use that value directly or store it in a local variable.

### Example to remember

These methods belong inside the `Lasagna` class:

```csharp
public int PreparationTimeInMinutes(int numOfLayers)
{
    return numOfLayers * 2;
}

public int ElapsedTimeInMinutes(int numOfLayers, int minutesInOven)
{
    int prepMinutes = PreparationTimeInMinutes(numOfLayers);
    return prepMinutes + minutesInOven;
}
```

For 3 layers and 20 oven minutes, the preparation method returns `6`, and the elapsed-time method returns `26`.

Calling the preparation method reuses the calculation. The local variable `prepMinutes` names its result; using the method call directly in the addition also works.

### Mistake and fix

I initially left out `public`, so the tests could not call my methods. When adding it, I removed `int` by mistake. The correct declaration needs both: `public int MethodName(...)`.

### Verification

My test run reported **7 succeeded, 0 failed, and 0 skipped**. A skipped test does not run and counts as neither passed nor failed.

## Annalyn's Infiltration

### What I learned

- `bool` holds either `true` or `false`. Before a method name, it means the method returns a Boolean value.
- `!` means NOT: it flips `true` to `false` and `false` to `true`.
- `&&` means AND: both conditions must be true. `||` means OR: at least one condition must be true.
- A `static` method belongs to the class itself. I call it using the class name without creating an object.
- Local variables such as `escapeOptionOne` and `escapeOptionTwo` give names to conditions, making the rescue rules easier to follow.

### Example to remember

```csharp
static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }
}
```

Call it using the class name:

```csharp
bool canAttack = QuestLogic.CanFastAttack(false);
// canAttack is true because the knight is asleep.
```

In `public static bool CanFastAttack(bool knightIsAwake)`, `public` allows callers outside the class to access the method, `static` means no object is needed, and the first `bool` is the return type. `bool knightIsAwake` declares the input parameter.

### Static methods versus instance methods

An **instance** is an individual object created from a class. The earlier `Lasagna` methods are instance methods, so I create a `Lasagna` object first:

```csharp
Lasagna lasagna = new Lasagna();
int prepMinutes = lasagna.PreparationTimeInMinutes(3);
```

The quest methods use the values passed into them and do not need information stored in an individual object, so static methods suit this exercise.

`QuestLogic` is also declared as a **static class**. I cannot create it with `new QuestLogic()`. To turn the earlier example into an instance method, I would need to remove `static` from both the class and the method.

`static` does not mean “cannot change.” A static field (a variable declared in a class) can hold a changing value shared across instances. An instance field gives each object its own value. A static method cannot directly access instance fields without an object to access them through.

### Reading the rescue logic

My solution names two ways to escape:

```csharp
bool escapeOptionOne = petDogIsPresent && !archerIsAwake;
bool escapeOptionTwo = !petDogIsPresent && (prisonerIsAwake && !knightIsAwake && !archerIsAwake);
return escapeOptionOne || escapeOptionTwo;
```

With the dog, the archer must be asleep. Without the dog, the prisoner must be awake and both guards must be asleep. The final `||` returns `true` if either escape option is possible.

### Verification

These examples were checked against the exercise source and test names.

## Cars, Assemble!

### What I learned

- `int` stores whole numbers; `double` can store fractional values such as `0.9` and `1193.4`.
- A range check needs two comparisons joined with `&&`: `speed >= 1 && speed <= 4` means speed is at least 1 AND at most 4.
- Dividing two integers discards the fractional part. `90 / 100` gives `0`, while `90.0 / 100` gives `0.9`.
- A local variable can be declared without a starting value, but every path that reaches a read of it must assign it first.
- A cast such as `(int)19.89` explicitly converts a value to another type. This conversion discards the fractional part, giving `19`; it does not round to the nearest integer.

### Declaring a variable before assigning it

```csharp
double successRate;
```

This declares an **uninitialized local variable**, not an undefined variable. C# knows its name and type, but it has no assigned value yet.

```csharp
double successRate;
if (speed == 0)
{
    successRate = 0.0;
}
else
{
    successRate = 1.0;
}
return successRate;
```

This simplified example is valid because both branches assign a value before `return` reads it. In my full `SuccessRate` method, every `if`/`else if` branch assigns a value, and the final `else` covers the remaining cases. Reading an unassigned local variable causes a compiler error.

### Converting units

The parentheses in `(int)(prodRatePerHr / 60)` make the division happen before the conversion. Casting the hourly rate first and then using integer division also gives the correct result for this exercise's nonnegative values, but dividing first expresses the intended calculation more clearly.

### Mistakes and fixes

| Mistake                          | Why it fails                                                                         | Fix                        |
| -------------------------------- | ------------------------------------------------------------------------------------ | -------------------------- |
| `1 <= speed <= 4`                | C# cannot chain comparisons this way; the first comparison produces a Boolean value. | `speed >= 1 && speed <= 4` |
| `double successRate = 90 / 100;` | Integer division produces `0` before it is stored as a `double`.                     | Use `0.9` or `90.0 / 100`. |
| `int(prodRatePerHr)`             | This is not C# cast syntax.                                                          | Use `(int)prodRatePerHr`.  |
