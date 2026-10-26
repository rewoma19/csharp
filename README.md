# My C# Learning Notes

What I learn while completing the Exercism C# challenges, with examples and mistakes to remember.

## Exercises

| Exercise                  | Topic                                | Solution                                                            | Learning notes                     |
| ------------------------- | ------------------------------------ | ------------------------------------------------------------------- | ---------------------------------- |
| Lucian's Luscious Lasagna | Basics                               | [Code](./Basics/lucians-luscious-lasagna/LuciansLusciousLasagna.cs) | [Notes](#lucians-luscious-lasagna) |
| Annalyn's Infiltration    | Booleans and static methods          | [Code](./Booleans/annalyns-infiltration/AnnalynsInfiltration.cs)    | [Notes](#annalyns-infiltration)    |
| Cars, Assemble!           | Numbers, conditions and conversions  | [Code](./NumbersAndIfs/cars-assemble/CarsAssemble.cs)               | [Notes](#cars-assemble)            |
| Log Levels                | Strings and text processing          | [Code](./Strings/log-levels/LogLevels.cs)                           | [Notes](#log-levels)               |
| Jedlik's Toys             | Classes, objects and instance fields | [Code](./Classes/jedliks-toys/JedliksToys.cs)                       | [Notes](#jedliks-toys)             |
| Bird Watcher              | Arrays, constructors and loops       | [Code](./ArrsAndForLoops/bird-watcher/BirdWatcher.cs)               | [Notes](#bird-watcher)             |

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

## Log Levels

### What I learned

- String positions, called **indexes**, start at `0`. `IndexOf(":")` finds the first colon's index, or returns `-1` if it is absent.
- `Substring(startIndex)` returns everything from that index to the end. `Substring(startIndex, length)` returns a specified number of characters; the second argument is a count, not an ending index.
- `Trim()` removes whitespace, including spaces, tabs and line breaks, from both ends of a string. It does not remove whitespace inside the string.
- Strings are **immutable**: their text cannot be changed in place. Methods such as `Trim()` and `ToLower()` return a result that I must use or store.
- String interpolation inserts values into text: `$"{message} ({level})"`.

### Extracting the message

My `Message` method finds the colon, takes the text after it, and then trims that text:

```csharp
int colonIndex = logLine.IndexOf(":");
string message = logLine.Substring(colonIndex + 1);
return message.Trim();
```

For `"[ERROR]:  Invalid operation  "`:

```text
Substring → "  Invalid operation  "
Trim      → "Invalid operation"
```

`colonIndex + 1` skips the colon. Trimming after extraction removes the whitespace surrounding the message.

### Understanding the substring length

My `LogLevel` method uses:

```csharp
string level = logLine.Substring(1, colonIndex - 2);
return level.Trim().ToLower();
```

Starting at index `1` skips `[`. Before the colon are the level's letters and two brackets, so subtracting `2` from the colon's index gives the number of letters.

| Input                | Colon index | Length (`colonIndex - 2`) | Extracted text |
| -------------------- | ----------- | ------------------------- | -------------- |
| `"[INFO]: Hello"`    | 6           | 4                         | `"INFO"`       |
| `"[ERROR]: Hello"`   | 7           | 5                         | `"ERROR"`      |
| `"[WARNING]: Hello"` | 9           | 7                         | `"WARNING"`    |

The length adjusts to each level. `ToLower()` then produces `"info"`, `"error"` or `"warning"`.

### Adding one versus incrementing

| Expression       | Value used by `Substring()`                        | Changes `colonIndex`? |
| ---------------- | -------------------------------------------------- | --------------------- |
| `colonIndex + 1` | The next index                                     | No                    |
| `++colonIndex`   | The next index, after increasing the variable      | Yes                   |
| `colonIndex++`   | The original index, before increasing the variable | Yes                   |

`++colonIndex` can skip the colon, but `colonIndex + 1` keeps the variable pointing to the colon. Using `colonIndex++` as the argument would include the colon in the extracted text.

### Mistake and fix

Initially, I trimmed the whole log line before extracting the message. The space after the colon was still inside that line, so trimming could not remove it. I also extracted from the original `logLine`, which still contained any trailing whitespace.

## Jedlik's Toys

### What I learned

- A **class** is a template; an **instance** is an individual object created from it. `new RemoteControlCar()` creates a new car.
- `Buy()` is a **static method**, called on the class: `RemoteControlCar.Buy()`. Its return type is `RemoteControlCar`, so it returns a car object.
- **Instance fields** store each object's information between method calls. Each car has its own `_distance`, starting at `0`, and `_battery`, starting at `100`.
- `private` restricts access to the fields to code inside the class. Public methods let callers drive the car and read its displays.
- A `void` method returns no value. `Drive()` changes the car's stored distance and battery instead.

## Bird Watcher

### What I learned

- An **array** stores a fixed number of elements of the same type. Its indexes start at `0`, so the last element of a nonempty array is at `Length - 1`.
- A **constructor** runs when I create an object with `new`. It has the same name as its class and no return type, not even `void`.
- `this.birdsPerDay` identifies the object's field; `birdsPerDay` in the constructor is the incoming parameter. Assigning the array stores a reference to the same array, not a new copy.
- Assigning an `int` to a local variable copies its value. Changing that variable does not change the array element the value came from.
- A `for` loop gives me an index to use; a `foreach` loop gives me each element's value. I can use either to build a running total or count matching elements.

### Understanding the constructor

```csharp
private int[] birdsPerDay;

public BirdCount(int[] birdsPerDay)
{
    this.birdsPerDay = birdsPerDay;
}
```

The field keeps the array available between method calls, just as the car fields in Jedlik's Toys keep distance and battery information.

```csharp
int[] counts = { 2, 5, 0, 7, 4, 1 };
BirdCount birdCount = new BirdCount(counts);
```

The constructor receives `counts`. The object's field and `counts` refer to the same array, so changing an element through either reference changes that shared array.

### Checking whether a value exists

```csharp
return Array.IndexOf(birdsPerDay, 0) != -1;
```

`Array.IndexOf` returns the first matching index, or `-1` when it cannot find the value. Comparing the result with `-1` checks whether a zero exists.

My original `!= 1` checked whether the result was anything except index `1`. It incorrectly returned `true` when no zero existed, because `-1 != 1` is true. It also returned `false` when the first zero was at index `1`.

### Summing up values

My `CountForFirstDays()` uses `birdsPerDay.AsSpan(0, numberOfDays)`. A **span** is a view of part of an existing array, not a copied array. The second argument is a length, so this selects the requested number of elements starting at index `0`. That length must fit within the array. The loop uses `i < days.Length` because an index equal to the length is already past the last element.
