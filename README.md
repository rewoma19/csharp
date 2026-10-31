# My C# Learning Notes

What I learn while completing the Exercism C# challenges, with examples and mistakes to remember.

## Exercises

| Exercise                   | Topic                                 | Solution                                                                     | Learning notes                       |
| -------------------------- | ------------------------------------- | ---------------------------------------------------------------------------- | ------------------------------------ |
| Lucian's Luscious Lasagna  | Basics                                | [Code](./Basics/lucians-luscious-lasagna/LuciansLusciousLasagna.cs)          | [Notes](#lucians-luscious-lasagna)   |
| Annalyn's Infiltration     | Booleans and static methods           | [Code](./Booleans/annalyns-infiltration/AnnalynsInfiltration.cs)             | [Notes](#annalyns-infiltration)      |
| Cars, Assemble!            | Numbers, conditions and conversions   | [Code](./NumbersAndIfs/cars-assemble/CarsAssemble.cs)                        | [Notes](#cars-assemble)              |
| Log Levels                 | Strings and text processing           | [Code](./Strings/log-levels/LogLevels.cs)                                    | [Notes](#log-levels)                 |
| Jedlik's Toys              | Classes, objects and instance fields  | [Code](./Classes/jedliks-toys/JedliksToys.cs)                                | [Notes](#jedliks-toys)               |
| Bird Watcher               | Arrays, constructors and loops        | [Code](./ArrsAndForLoops/bird-watcher/BirdWatcher.cs)                        | [Notes](#bird-watcher)               |
| Interest is Interesting    | Decimals, interest and while loops    | [Code](./WhileLoops/interest-is-interesting/InterestIsInteresting.cs)        | [Notes](#interest-is-interesting)    |
| Squeaky Clean              | Characters, Unicode and text cleanup  | [Code](./Chars/squeaky-clean/SqueakyClean.cs)                                | [Notes](#squeaky-clean)              |
| Tracks on Tracks on Tracks | Generic lists and duplicate checks    | [Code](./ListsAndTypes/tracks-on-tracks-on-tracks/TracksOnTracksOnTracks.cs) | [Notes](#tracks-on-tracks-on-tracks) |
| Need for Speed             | Constructors and object interaction   | [Code](./Constructors/need-for-speed/NeedForSpeed.cs)                        | [Notes](#need-for-speed)             |
| Roll the Die!              | Randomness and shared instance fields | [Code](./Randomness/roll-the-die/RollTheDie.cs)                              | [Notes](#roll-the-die)               |

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

## Interest is Interesting

### What I learned

- `float` and `decimal` both represent numbers with fractional parts. `decimal` is normally used for money because it can represent decimal amounts more precisely.
- A **cast** explicitly converts a value to another type. `InterestRate()` returns a `float`, so I use `(decimal)` before calculating with a `decimal` balance. C# does not directly mix `float` and `decimal` in arithmetic.
- **Compound interest** means each year's interest is calculated using the updated balance, including previous interest. Reusing my methods also selects the correct rate when the balance crosses into a new range.

### Counting years with a while loop

```csharp
public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
{
    int years = 0;

    while (balance < targetBalance) {
        balance = AnnualBalanceUpdate(balance);
        years++;
    }

    return years;
}
```

Each repetition represents one year:

1. Check whether the current balance is below the target.
2. Calculate and store the balance after one more year.
3. Increase the year count by one, then check the condition again.

## Squeaky Clean

### What I learned

- The five tasks gradually extend one `Clean` method. Each new rule must preserve the behavior required by the earlier tasks.
- A `char` represents one UTF-16 code unit, written with single quotes, such as `'a'`. A `string` contains a sequence of these units, written with double quotes, such as `"a"` or `"CTRL"`. Some symbols, including many emoji, occupy two `char` values.
- `char.IsControl()` detects control characters such as tabs (`'\t'`), line breaks (`'\n'`) and the null character (`'\0'`). `char.IsLetter()` recognizes letters, including letters outside the English alphabet.
- An indexed `for` loop lets me replace array entries and inspect the next entry. Before accessing `letters[i + 1]`, I check `i + 1 < letters.Length`.
- `string.Concat(letters)` joins the array entries. Setting an entry to `""` makes it contribute no text to the result; it does not shorten the array.

### Immutable strings versus reassigning parameters

Strings are immutable, but an ordinary parameter can be reassigned. `Replace` returns a result that I need to store:

```csharp
identifier = identifier.Replace(' ', '_');
```

This makes the local parameter refer to the replacement string. It does not modify the original string or reassign the caller's variable:

```csharp
string original = "my Id";
string cleaned = Identifier.Clean(original);
// original is "my Id"; cleaned is "my_Id".
```

`Replace` was enough for task 1. The later rules need character checks and decisions, so my solution keeps the space replacement and adds a loop.

### Building and updating my array

`Split()` without arguments splits around whitespace, not into individual characters. Instead, I create an array and fill each entry with a one-character string:

```csharp
string[] letters = new string[identifier.Length];

for (int i = 0; i < identifier.Length; i++) {
    letters[i] = identifier[i].ToString();
}
```

The entries are strings so they can later hold `"CTRL"` or `""`. Assigning `character = "CTRL"` only reassigns a local variable; `letters[i] = "CTRL"` updates the array entry that will be joined into the result.

### Why character[0] always uses zero

For input `"ab\tc"`, the array contains `"a"`, `"b"`, `"\t"`, and `"c"`. When `i` is `2`:

```csharp
string character = letters[i]; // "\t": a string containing one tab
char currentChar = character[0]; // '\t': the tab itself
bool isControl = char.IsControl(currentChar); // true
```

`i` selects an array entry. `0` selects the first character inside that entry's string. The tab was at index `2` in the original input, but it is at index `0` in its own one-character string. `char.IsControl(character, 0)` is another way to check that same character.

### Applying the remaining rules

| Rule                    | How my implementation handles it                                                                                    |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------- |
| Control characters      | Replace the entry with `"CTRL"`.                                                                                    |
| Hyphens                 | Set the hyphen entry to `""`, then uppercase the next entry with `ToUpperInvariant()` if it exists.                 |
| Nonletters              | Remove entries for which `!char.IsLetter(currentChar)` is true, except underscores, which task 1 needs to preserve. |
| Lowercase Greek letters | Remove characters in the inclusive range from `'\u03B1'` to `'\u03C9'`.                                             |

`ToUpperInvariant()` uses casing rules that do not depend on the computer's language settings. An `if` / `else if` chain selects just one branch per iteration, so control characters and hyphens get their special handling before the removal rules.

### Unicode lookalikes and the failing tests

I accidentally used `⍵` (U+2375) instead of Greek lowercase `ω` (U+03C9). The larger numeric value made my range too wide and removed letters such as `ḃ` and `Ḃ`. Three tests failed because those letters disappeared.

Unicode escapes avoid that visual mix-up. `\u` followed by four hexadecimal digits identifies the character directly:

```csharp
else if (currentChar >= '\u03B1' && currentChar <= '\u03C9') {
    letters[i] = "";
}
```

`'\u03B1'` means `'α'`, and `'\u03C9'` means `'ω'`. The comparisons include both boundaries. On a Mac, Control + Command + Space opens Character Viewer, but Unicode escapes are easier to distinguish in this check.

### Other ways to build the result

I could also accumulate text with `string result = "";` and `+=`, or use a `StringBuilder` and `Append()`. Repeated string concatenation creates replacement strings and copies the accumulated text. `StringBuilder` uses a mutable buffer, which can avoid repeated copying when there are many additions. My final solution uses an array and joins it once.

`var result = new StringBuilder();` and `StringBuilder result = new StringBuilder();` declare the same type. `var` asks the compiler to infer the type; it does not make the value mutable or change how it works.

## Tracks on Tracks on Tracks

### What I learned

- `List<T>` is a **generic type**: `T` is a placeholder for the type of items it stores. `List<string>` stores strings and can grow or shrink as items are added or removed.
- `new List<string>()` creates an empty list. A collection initializer such as `new List<string> { "C#", "Clojure", "Elm" }` creates a list with starting values in that order.
- `.Count` is a property that gives the number of items; it needs no parentheses. `.Contains(language)` is a method that returns whether an item is present.
- List indexes start at `0`. Before reading an item, I must check that its index is less than `.Count`.
- A method can change a list without returning the list. Its return type tells me what, if anything, I can use from the call.

### Changing a list and returning a value

| List method        | What it changes                              | What it returns                      |
| ------------------ | -------------------------------------------- | ------------------------------------ |
| `Add(language)`    | Adds an item at the end.                     | `void`: no value.                    |
| `Reverse()`        | Reverses the items in the existing list.     | `void`: no value.                    |
| `Remove(language)` | Removes the first matching item, if present. | `bool`: whether an item was removed. |

My exercise methods return `List<string>`, so I first change the list and then return it:

```csharp
public static List<string> AddLanguage(List<string> languages, string language)
{
    languages.Add(language);
    return languages;
}
```

The same pattern works for `ReverseList` and `RemoveLanguage`. The caller and the parameter refer to the same list, so the caller sees these changes too.

My original `return languages.Add(language);` tried to return a value from a `void` method. `languages = languages.Reverse();` had the same problem. `return languages.Remove(language);` returned a Boolean where the exercise method required a list.

### Checking positions safely

`&&` and `||` use **short-circuit evaluation**: `&&` skips its right side when the left side is false; `||` skips its right side when the left side is true.

### Finding duplicates with foreach

```csharp
public static bool IsUnique(List<string> languages)
{
    var uniqueLangs = new List<string>();

    foreach (string lang in languages)
    {
        if (uniqueLangs.Contains(lang))
        {
            return false;
        }

        uniqueLangs.Add(lang);
    }

    return true;
}
```

`uniqueLangs` remembers the languages already visited. I check for a match before adding the current language; adding it first would make every check find a match.

For `"C#", "Elm", "C#"`, the loop remembers the first two languages, then returns `false` when it reaches the repeated `"C#"`. A `return` inside the loop exits the whole method. `return true` belongs after the loop because I can only declare the list unique after checking every item.

My unfinished version declared `bool isUnique;` without assigning it. Returning directly removes the need for that variable and gives every path a result.

## Need for Speed

### What I learned

- A **constructor** sets up a new object. It has the class's name and no return type. `new RemoteControlCar(5, 2)` passes speed and battery drain to the constructor.
- **Instance fields** remember each car's values between method calls. Speed and battery drain describe the car; battery and total distance change as it drives.
- `this.speed = speed;` copies the incoming parameter into the object's field. Receiving a parameter does not automatically save it for other methods.
- A method can change an object, report a value, or create an object. `Drive()` changes the car, `DistanceDriven()` reports its distance, and `Nitro()` creates a new car.
- One object can use another object's public methods. `RaceTrack` drives and checks the supplied car without accessing its private fields.

### Setting up each car

These fields and the constructor belong inside `RemoteControlCar`:

```csharp
private int battery;
private int speed;
private int batteryDrain;
private int distanceDriven = 0;

public RemoteControlCar(int speed, int batteryDrain)
{
    this.speed = speed;
    this.battery = 100;
    this.batteryDrain = batteryDrain;
}
```

`RaceTrack(int distance)` follows the same pattern: `this.distance = distance;` stores the track's length for later use.

### Driving changes the stored values

```csharp
public void Drive()
{
    if (!BatteryDrained())
    {
        this.distanceDriven += this.speed;
        this.battery -= this.batteryDrain;
    }
}
```

`!BatteryDrained()` means the car still has enough charge for a drive. If that condition is false, neither field changes. `+=` adds to the existing value; `-=` subtracts from it.

For a car with speed `5` and battery drain `2`:

`Drive()` returns `void` because it changes the car rather than returning a result. `DistanceDriven()` returns the saved total without changing it.

### A drained battery does not have to be empty

The question is whether there is enough charge for another drive. With `40%` remaining and a drain of `60%`, the car cannot drive. When battery and drain are equal, it can drive once more, so the comparison is `<`, not `<=`.

### Checking whether the car finishes

This method belongs inside `RaceTrack`:

```csharp
public bool TryFinishTrack(RemoteControlCar car)
{
    while ((car.DistanceDriven() < this.distance) && !car.BatteryDrained())
    {
        car.Drive();
    }

    return car.DistanceDriven() >= this.distance;
}
```

The loop continues while the car has not finished AND has enough battery.

The final `>=` checks whether the car reached or passed the finish line. A car can succeed even if its last drive drains the battery. The method drives the supplied car, so the caller sees its updated distance and battery afterward.

### Mistakes and fixes

| Mistake                                                       | Why it fails                                                               | Fix                                                                               |
| ------------------------------------------------------------- | -------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `var car = new RemoteControlCar();` directly inside the class | `var` cannot declare a field, and this constructor requires two arguments. | Remove the unnecessary field; the tests create cars with speed and battery drain. |
| Receiving `batteryDrain` without saving it                    | Other methods need the drain value after the constructor finishes.         | Add a field and assign `this.batteryDrain = batteryDrain;`.                       |
| Checking only `battery == 0`                                  | Some remaining charge may still be insufficient for a drive.               | Check `battery < batteryDrain`.                                                   |

## Roll the Die!

### What I learned

- `Random` is a class in the `System` namespace. A **namespace** groups related types. The normal import is `using System;`, not `using System.Random;`.
- This project enables **implicit usings** with `<ImplicitUsings>enable</ImplicitUsings>`, so `System` is imported automatically and I can write `Random` without adding an import.
- `Next(min, max)` returns a random whole number including `min` but excluding `max`. `Next(1, 19)` therefore gives a die roll from 1 through 18.
- `NextDouble()` returns a `double` from 0.0 up to, but excluding, 1.0.
- A **local variable** declared inside a method is available only within its scope. An **instance field** declared inside the class, outside its methods, can be reused by both methods. Each `Player` gets its own generator.

### Creating the generator once

My solution reuses one generator for both methods:

```csharp
public class Player
{
    private readonly Random random = new Random();

    public int RollDie()
    {
        return random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        double min = 0.0;
        double max = 100.0;
        return random.NextDouble() * (max - min) + min;
    }
}
```

In `Random random = new Random();`, the first `Random` is the type, `random` is the field name, and `new Random()` creates the generator. `private` limits access to code inside `Player`.

`readonly` means I cannot replace the field's generator after initialization or construction. It does not freeze the generator: calling its methods still produces new random values, which can sometimes repeat.

`random.NextDouble() * (max - min) + min` multiplies by the range's width, then shifts the result to start at `min`. Here, `min` is 0 and `max` is 100, so this is equivalent to `random.NextDouble() * 100`.
