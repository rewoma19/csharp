# My C# Learning Notes

What I learn while completing the Exercism C# challenges, with examples and mistakes to remember.

## Exercises

<!-- Keep this table in the order: #, Topic, Exercise, Solution, Learning notes. Number entries sequentially from 1 and continue this format when adding exercises. -->

| #   | Topic                                      | Exercise                          | Solution                                                                                    | Learning notes                              |
| --- | ------------------------------------------ | --------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------- |
| 1   | Basics                                     | Lucian's Luscious Lasagna         | [Code](./Basics/lucians-luscious-lasagna/LuciansLusciousLasagna.cs)                         | [Notes](#lucians-luscious-lasagna)          |
| 2   | Booleans and static methods                | Annalyn's Infiltration            | [Code](./Booleans/annalyns-infiltration/AnnalynsInfiltration.cs)                            | [Notes](#annalyns-infiltration)             |
| 3   | Numbers, conditions and conversions        | Cars, Assemble!                   | [Code](./NumbersAndIfs/cars-assemble/CarsAssemble.cs)                                       | [Notes](#cars-assemble)                     |
| 4   | Strings and text processing                | Log Levels                        | [Code](./Strings/log-levels/LogLevels.cs)                                                   | [Notes](#log-levels)                        |
| 5   | Classes, objects and instance fields       | Jedlik's Toys                     | [Code](./Classes/jedliks-toys/JedliksToys.cs)                                               | [Notes](#jedliks-toys)                      |
| 6   | Arrays, constructors and loops             | Bird Watcher                      | [Code](./ArrsAndForLoops/bird-watcher/BirdWatcher.cs)                                       | [Notes](#bird-watcher)                      |
| 7   | Decimals, interest and while loops         | Interest is Interesting           | [Code](./WhileLoops/interest-is-interesting/InterestIsInteresting.cs)                       | [Notes](#interest-is-interesting)           |
| 8   | Characters, Unicode and text cleanup       | Squeaky Clean                     | [Code](./Chars/squeaky-clean/SqueakyClean.cs)                                               | [Notes](#squeaky-clean)                     |
| 9   | Generic lists and duplicate checks         | Tracks on Tracks on Tracks        | [Code](./ListsAndTypes/tracks-on-tracks-on-tracks/TracksOnTracksOnTracks.cs)                | [Notes](#tracks-on-tracks-on-tracks)        |
| 10  | Constructors and object interaction        | Need for Speed                    | [Code](./Constructors/need-for-speed/NeedForSpeed.cs)                                       | [Notes](#need-for-speed)                    |
| 11  | Randomness and shared instance fields      | Roll the Die!                     | [Code](./Randomness/roll-the-die/RollTheDie.cs)                                             | [Notes](#roll-the-die)                      |
| 12  | Dates, times, parsing and formatting       | Booking up for Beauty             | [Code](./Datetimes/booking-up-for-beauty/BookingUpForBeauty.cs)                             | [Notes](#booking-up-for-beauty)             |
| 13  | Nullability, ternaries and null checks     | Tim from Marketing                | [Code](./Nullability/tim-from-marketing/TimFromMarketing.cs)                                | [Notes](#tim-from-marketing)                |
| 14  | Dictionaries, keys and value collections   | International Calling Connoisseur | [Code](./Dictionaries/international-calling-connoisseur/InternationalCallingConnoisseur.cs) | [Notes](#international-calling-connoisseur) |
| 15  | Inheritance, overrides and polymorphism    | Wizards and Warriors              | [Code](./Inheritance/wizards-and-warriors/WizardsAndWarriors.cs)                            | [Notes](#wizards-and-warriors)              |
| 16  | Extension methods and string ranges        | Log Analysis                      | [Code](./ExtensionMethods/log-analysis/LogAnalysis.cs)                                      | [Notes](#log-analysis)                      |
| 17  | Tuples, local variables and string ranges  | Phone Number Analysis             | [Code](./Tuples/phone-number-analysis/PhoneNumberAnalysis.cs)                               | [Notes](#phone-number-analysis)             |
| 18  | Switches, type patterns and guards         | Football Match Reports            | [Code](./Switches/football-match-reports/FootballMatchReports.cs)                           | [Notes](#football-match-reports)            |
| 19  | Enums, parsing and numeric casts           | Logs, Logs, Logs!                 | [Code](./Enums/logs-logs-logs/LogsLogsLogs.cs)                                              | [Notes](#logs-logs-logs)                    |
| 20  | Exceptions, switch guards and return types | Calculator Conundrum              | [Code](./Exceptions/calculator-conundrum/CalculatorConundrum.cs)                            | [Notes](#calculator-conundrum)              |
| 21  | Casting, type patterns and exact types     | Secure Munchester United          | [Code](./Casting/secure-munchester-united/SecureMunchesterUnited.cs)                        | [Notes](#secure-munchester-united)          |
| 22  | Properties, accessors and validation       | Weighing Machine                  | [Code](./Properties/weighing-machine/WeighingMachine.cs)                                    | [Notes](#weighing-machine)                  |

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

## Booking up for Beauty

### What I learned

- `DateTime` stores both a date and a time. It is **immutable**: operations such as `AddDays()` return a new value, so I must use or store the result.
- **Parsing** converts text into a value I can work with. `DateTime.Parse(appointmentDateDescription)` converts the appointment text into a `DateTime`.
- `DateTime.Now` gives the current local date and time.
- `appointmentDate.TimeOfDay` returns a `TimeSpan` representing the time elapsed since midnight.
- **Formatting** converts a value into text. `ToString("M/d/yyyy h:mm:ss tt")` controls how the appointment date and time appear in the description.

### Parsing the appointment text

```csharp
public static DateTime Schedule(string appointmentDateDescription)
{
    return DateTime.Parse(appointmentDateDescription);
}
```

For `"7/25/2019 13:45:00"`, this returns a value equivalent to `new DateTime(2019, 7, 25, 13, 45, 0)`.

**Culture** in this context means the language and regional conventions used to interpret or display date and time values. This exercise's tests set the culture to `en-US`, so `Parse` understands the numeric dates, month names, and weekday names without extra configuration. Text that cannot be parsed as a date causes a `FormatException`.

### Understanding the unfinished-method placeholder

The exercise originally contained a line like this:

```csharp
throw new NotImplementedException("Please implement Appointment.Schedule()");
```

| Part                      | Meaning                                                        |
| ------------------------- | -------------------------------------------------------------- |
| `NotImplementedException` | The exception type that signals unfinished code.               |
| `new`                     | Creates an exception object containing the supplied message.   |
| `throw`                   | Raises the exception and stops normal execution of the method. |

An **exception** signals a problem while the program is running. Code can catch and handle it; if it goes unhandled, it can stop the program. In this exercise, the test runner reports the thrown placeholder exception as a failed test. Implementing the method means replacing that placeholder with working code.

### Checking the afternoon boundaries

My solution creates these values inside `IsAfternoonAppointment`:

```csharp
TimeSpan timeOfTheDay = appointmentDate.TimeOfDay;
TimeSpan afternoonStart = new TimeSpan(12, 0, 0);
TimeSpan afternoonEnd = new TimeSpan(18, 0, 0);
```

The three constructor arguments are hours, minutes, and seconds. My condition is:

```csharp
timeOfTheDay >= afternoonStart && timeOfTheDay < afternoonEnd
```

Both comparisons must be true. Noon is included because of `>=`; 6 PM is excluded because of `<`. This builds on the range checks and `&&` used in earlier exercises.

| Appointment time | Is afternoon? |
| ---------------- | ------------- |
| `11:59:59`       | `false`       |
| `12:00:00`       | `true`        |
| `17:59:59`       | `true`        |
| `18:00:00`       | `false`       |

## Tim from Marketing

### What I learned

- `null` means a value is absent. `int?` can hold an integer or `null`; `string?` marks a string reference as possibly null for the compiler's checks. An empty string (`""`) is still a string value, not `null`.
- The **ternary operator**, `condition ? valueWhenTrue : valueWhenFalse`, chooses between two expressions. Only the chosen expression is evaluated.
- `is` checks whether a value matches a **pattern**, such as `null` or a type. `id is null` returns a Boolean; `id is not null` reverses that check.
- The **null-coalescing operator**, `??`, supplies a fallback value without assigning it. The **null-coalescing assignment operator**, `??=`, assigns the fallback only when the variable is null.
- `?.` calls a member only when the value is not null. For example, `department?.ToUpper()` returns uppercase text or `null`; it does not supply an `"OWNER"` fallback by itself.

### My completed solution

```csharp
static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string printPrefix = id is null ? "" : $"[{id}] - ";
        department ??= "Owner";

        return $"{printPrefix}{name} - {department.ToUpper()}";
    }
}
```

The prefix includes the brackets and separator so they disappear together when the ID is missing. Both branches of the ternary produce strings. String interpolation inserts that prefix and the name into the badge text, building on the Log Levels exercise.

Assigning `"Owner"` before calling `ToUpper()` ensures the department is no longer null. `ToUpper()` returns uppercase text, so `"Owner"` becomes `"OWNER"` without changing the string in place.

### Reading the ternary as if/else

```csharp
string printPrefix;

if (id is null)
{
    printPrefix = "";
}
else
{
    printPrefix = $"[{id}] - ";
}
```

`is null` performs the check; `? :` chooses which string to use. The `?` in `int?` has a different role: it makes the integer type nullable.

### is versus ==

For my `int? id`, `id is null` and `id == null` give the same result. `==` checks equality, while `is` matches a pattern. Custom types can redefine `==`, which is called **operator overloading**, but they cannot redefine the behavior of `is null`.

| Expression        | What it checks                 |
| ----------------- | ------------------------------ |
| `id is null`      | Whether the ID is absent.      |
| `id is not null`  | Whether the ID has a value.    |
| `id == 734`       | Whether the ID equals 734.     |
| `value is string` | Whether the value is a string. |

### Mistakes and fixes

| Mistake                                                     | Why it fails                                                                               | Fix                                                                     |
| ----------------------------------------------------------- | ------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------- |
| `id ?? ""`                                                  | An `int?` cannot use a string as its fallback this way.                                    | Use `id is null ? "" : $"[{id}] - "` to choose between two strings.     |
| `department ?? "Owner";`                                    | It does not assign the result, and this expression is not a valid standalone C# statement. | Use `department ??= "Owner";` or `department = department ?? "Owner";`. |
| Calling `department.ToUpper()` while it might still be null | Calling an instance method on null throws a `NullReferenceException`.                      | Assign the fallback first, then uppercase the resulting string.         |

`department ??= "Owner";` is equivalent here to:

```csharp
if (department is null)
{
    department = "Owner";
}
```

An existing department such as `"Marketing"` stays unchanged by this assignment. As with reassigning the parameter in Squeaky Clean, this changes the local parameter, not the caller's variable.

### Verification

I confirmed that all tests pass after the fix. The exercise tests cover an employee with an ID, an employee without an ID, an owner with an ID, and an owner without an ID. This records my reported test result; the tests were not rerun for this notes update.

## International Calling Connoisseur

### What I learned

- `Dictionary<int, string>` stores **key/value pairs**: each integer dialing code is a key associated with a string country name. Keys are unique.
- `dictionary[countryCode]` looks up a value by its key, not by its position. Even though this dictionary has integer keys, they are not list indexes.
- `ContainsKey(countryCode)` checks whether a key exists. Reading a missing key with `[]` throws a `KeyNotFoundException`; my lookup method checks first and returns `string.Empty` when the code is absent.
- Assigning `dictionary[countryCode] = countryName` replaces an existing value or adds a new entry if the key is absent. Task 7 requires updating only existing entries, so I check `ContainsKey()` before assigning.
- Like the lists in Tracks on Tracks on Tracks, a dictionary can change without being returned by the method that changes it. Changing the collection and returning a result are separate actions.

### Changing the dictionary and returning it

| Operation                       | What it does                                                | What it returns                     |
| ------------------------------- | ----------------------------------------------------------- | ----------------------------------- |
| `Add(countryCode, countryName)` | Adds a pair; throws an exception if the key already exists. | `void`: no value.                   |
| `Remove(countryCode)`           | Removes the pair if the key exists.                         | `bool`: whether a pair was removed. |
| `ContainsKey(countryCode)`      | Checks for the key without changing anything.               | `bool`: whether the key exists.     |

My exercise methods return `Dictionary<int, string>`, so I change the dictionary first and then return it:

```csharp
public static Dictionary<int, string> AddCountryToExistingDictionary(
    Dictionary<int, string> existingDictionary, int countryCode, string countryName)
{
    existingDictionary.Add(countryCode, countryName);
    return existingDictionary;
}
```

The caller and the parameter refer to the same dictionary, so the caller sees the added entry. Returning it does not create a copy. A bare `return;` cannot satisfy a method that promises to return a dictionary.

My removal method checks the key before calling `Remove()`. That works, but the check is optional here: removing a missing key simply returns `false` and leaves the dictionary unchanged.

### What .Values returns

For this dictionary, `.Values` returns a `Dictionary<int, string>.ValueCollection` containing the country names without their keys. It is a **live view**: changes to the dictionary are reflected in the collection. It is not a list and does not support positional access with `[i]`.

| Operation                  | `existingDictionary.Values` | `List<string>` |
| -------------------------- | --------------------------- | -------------- |
| Read `.Count`              | Yes                         | Yes            |
| Loop with `foreach`        | Yes                         | Yes            |
| Access an item using `[i]` | No                          | Yes            |

To use my preferred regular `for` loop, I copy the current values into a list:

```csharp
var countryNames = new List<string>(existingDictionary.Values);
```

The list is a separate collection. Later dictionary changes do not update it. This enables indexing but uses extra storage; a `foreach` loop over `.Values` would not need that copy.

### Finding the longest name with a for loop

My completed method is:

```csharp
public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
{
    string longestCountryName = string.Empty;
    var countryNames = new List<string>(existingDictionary.Values);

    for (int i = 0; i < countryNames.Count; i++) {
        if (countryNames[i].Length > longestCountryName.Length) {
            longestCountryName = countryNames[i];
        }
    }

    return longestCountryName;
}
```

`longestCountryName` remembers the longest name found so far. I compare the current name's `.Length` with the saved name's `.Length`, then save the name itself when it is longer. `.Count` counts names in the list; `.Length` measures each string.

Starting with `string.Empty` gives the comparison an initial length of zero. If the dictionary is empty, the loop never runs and the method returns `string.Empty`. Using `>` keeps the first encountered name when two names share the greatest length.

### Mistakes and fixes

| Mistake                                                    | Why it fails                                        | Fix                                                        |
| ---------------------------------------------------------- | --------------------------------------------------- | ---------------------------------------------------------- |
| `return existingDictionary.Add(countryCode, countryName);` | `Add()` returns no value.                           | Call `Add()`, then return the dictionary.                  |
| Using `i` before declaring it in the loop                  | The variable is not available outside its scope.    | Access list entries inside the loop where `i` is declared. |
| `existingDictionary.Values[i]`                             | The value collection does not support indexing.     | Copy the values into a list before using `[i]`.            |
| Comparing a name's `.Length` with a string variable        | One side is an integer and the other is a string.   | Compare both names' `.Length` values.                      |
| Assigning through `[]` without checking the key in task 7  | A missing key would be added, contrary to the task. | Guard the assignment with `ContainsKey()`.                 |

## Wizards and Warriors

### What I learned

- **Inheritance** lets child classes share behavior from a parent class. `Warrior : Character` means a warrior is a kind of character.
- An **abstract class** provides a shared foundation but cannot be created directly with `new Character(...)`. An abstract method has no body; a concrete child class must implement it.
- A **virtual method** supplies behavior that a child can replace using `override`. `Character.Vulnerable()` returns `false`; `Wizard` overrides it, while `Warrior` inherits it unchanged.
- `base("Wizard")` passes an argument to the parent constructor, which runs before the child constructor's body. A `protected` constructor is available to child classes; a `private` field is accessible only inside its declaring class.
- **Polymorphism** means the same method call can run different implementations depending on the actual object. A `Character target` can refer to a warrior or wizard, and `target.Vulnerable()` uses that object's implementation.

### Storing the character description

These members belong inside `Character`:

```csharp
private readonly string characterType;

protected Character(string characterType)
{
    this.characterType = characterType;
}

public override string ToString()
{
    return $"Character is a {characterType}";
}
```

`this.characterType` identifies the field, while the constructor parameter supplies its starting value. `readonly` allows assignment during initialization or construction and prevents later reassignment.

The child constructors call `base("Warrior")` and `base("Wizard")`. Both classes inherit this `ToString()` implementation, which replaces the method inherited from `object`. String interpolation inserts the stored type into the description.

### Same method name, different damage rules

`Character` declares the shared requirement:

```csharp
public abstract int DamagePoints(Character target);
```

Each child supplies its own implementation. Inside `Wizard`:

```csharp
public override int DamagePoints(Character target)
{
    if (spellPrepared)
    {
        return 12;
    }

    return 3;
}
```

The wizard checks its own spell state. The `target` parameter stays in the required method signature even though this implementation does not use it. `return` ends the method immediately, so the final `return 3;` runs only when the condition is false.

Inside `Warrior`:

```csharp
public override int DamagePoints(Character target)
{
    if (target.Vulnerable())
    {
        return 10;
    }

    return 6;
}
```

The warrior asks the character being attacked whether it is vulnerable. It does not need to check the target's class itself.

### Example to remember

```csharp
var warrior = new Warrior();
var wizard = new Wizard();

warrior.ToString();            // "Character is a Warrior"
wizard.Vulnerable();           // true
wizard.DamagePoints(warrior);  // 3
warrior.DamagePoints(wizard);  // 10

wizard.PrepareSpell();

wizard.Vulnerable();           // false
wizard.DamagePoints(warrior);  // 12
warrior.DamagePoints(wizard);  // 6
```

These are the expected results from the completed implementation. Attacking does not reset `spellPrepared`; this exercise does not require consuming the prepared spell.

## Log Analysis

### What I learned

- An **extension method** lets me call a helper as though it belongs to an existing type.
- In `log.SubstringAfter(": ")`, `log` becomes the `str` parameter and `": "` becomes the delimiter argument. A **delimiter** is text marking a boundary.
- `IndexOf(delimiter)` returns the delimiter's starting position. Adding `delimiter.Length` moves past the whole delimiter, including delimiters longer than one character.
- `IndexOf(delimiter, startIndex)` begins searching at `startIndex`. Its result is still a position in the original string, not a count of characters searched.
- Range syntax, `str[startIndex..endIndex]`, includes the start and excludes the end. It is syntax rather than a string method, and it produces the same text as `str.Substring(startIndex, endIndex - startIndex)`.

Unlike the instance methods from earlier exercises, these helpers do not require creating a `LogAnalysis` object. The `this` modifier keyword that comes before the first parameter enables the string-call syntax:

```csharp
string log = "[INFO]: File Deleted.";

log.SubstringAfter(": ");              // "File Deleted."
LogAnalysis.SubstringAfter(log, ": "); // Same call using static method syntax
```

### Understanding the search start and the range

For `"[INFO]: File Deleted."`:

```text
Character:  [ I N F O ] :
Index:      0 1 2 3 4 5 6
```

The opening delimiter `"["` starts at `0` and has length `1`, so `subStartIndex` is `1`.

```csharp
int endIndex = str.IndexOf("]", 1);
```

This means “find `"]"`, starting the search at position `1`.” It returns `5`, the closing bracket's position in the original string. Searching after the opening delimiter selects a closing delimiter that follows it.

### General helpers versus log-specific methods

Tasks 1 and 2 let the caller choose the delimiters. Tasks 3 and 4 know the log format and supply the delimiters themselves, reusing the helpers. These methods belong inside the same `LogAnalysis` class:

```csharp
public static string Message(this string str)
{
    return str.SubstringAfter(": ");
}

public static string LogLevel(this string str)
{
    return str.SubstringBetween("[", "]");
}
```

| General helper call              | Log-specific call | Result for `"[INFO]: File Deleted."` |
| -------------------------------- | ----------------- | ------------------------------------ |
| `log.SubstringAfter(": ")`       | `log.Message()`   | `"File Deleted."`                    |
| `log.SubstringBetween("[", "]")` | `log.LogLevel()`  | `"INFO"`                             |

This builds on calling one method from another in earlier exercises. The caller can ask for a message or level without needing to know the delimiters.

## Phone Number Analysis

### What I learned

- A **tuple** groups several values into one value.
- Names in a tuple return type describe the returned fields; they do not declare local variables inside the method. Local variables need their own declarations.
- `var` lets the compiler infer a local variable's type from its starting value. A comparison using `==` produces a `bool`; taking a slice of a string produces a `string`.
- Values in `return (IsNewYork, IsFake, LocalNumber);` fill the returned tuple by position. Local variable names do not have to match the tuple field names.
- Dot syntax reads a named tuple field: `phoneNumberInfo.IsFake` retrieves the Boolean already calculated by `Analyze`.

### Why local variables still need declarations

The return type `(bool IsNewYork, bool IsFake, string LocalNumber)` tells the caller what data it will receive. It does not create variables for the method's calculations.

Inside the method, either of these declarations creates a Boolean local variable (use one, not both):

```csharp
bool isNewYork = phoneNumber[0..3] == "212";
// Or let C# infer the same bool type:
var isNewYork = phoneNumber[0..3] == "212";
```

This is **type inference**: C# figures out the type from the expression on the right. The variable still has a fixed type. In contrast, `isNewYork = ...;` without `bool` or `var` assigns to an existing variable; it does not declare one.

My solution uses matching names for local variables and tuple fields, but they are separate declarations. Using `isNewYork`, `isFake`, and `localNumber` as local names and returning them in that order would still give callers the fields `IsNewYork`, `IsFake`, and `LocalNumber`.

### String ranges and counting from the end

This builds on ranges: indexes start at `0`, and a range includes its starting index but excludes its ending index.

For `"212-555-1234"`:

| Expression          | Selected positions   | Result   |
| ------------------- | -------------------- | -------- |
| `phoneNumber[0..3]` | Indexes 0, 1, and 2  | `"212"`  |
| `phoneNumber[4..7]` | Indexes 4, 5, and 6  | `"555"`  |
| `phoneNumber[^4..]` | Last four characters | `"1234"` |

`^4` means four positions from the end. Leaving the end of the range blank means continue to the end of the string.

## Football Match Reports

### What I learned

- A `switch` chooses a branch based on a value or its type.
- Several empty case labels can share one body.
- `break` exits the switch so execution continues after it. `return` exits the entire method. An assignment alone does not end a case.
- `default` handles inputs that match no case. Assigning a result in every branch ensures my local variable has a value before I return it.
- **Type pattern matching** checks an object's type and gives me a variable of that type. A `when` condition, called a **guard**, narrows when a case matches.

### Getting a type versus matching a type

`GetType()` returns an object's runtime type: the type of the value it actually contains.

```csharp
object report = 5000;
Console.WriteLine(report.GetType()); // System.Int32
```

### Where Incident comes from

Exercism supplies `Incident`, `Foul`, `Injury`, and `Manager` in [OffFieldActivitiesAndCharacters.cs](./Switches/football-match-reports/OffFieldActivitiesAndCharacters.cs). This project automatically includes its `.cs` files when compiling. Both files use the global namespace, so I can refer to those classes directly without importing the file.

A normal `using SomeNamespace;` directive lets me use types in that namespace by their short names. It does not import a source file.

### Specific types before general types

This builds on inheritance. `Injury : Incident` and `Foul : Incident` mean both types are kinds of incident.

```csharp
case Injury injury:
    description = $"Oh no! {injury.GetDescription()} Medics are on the field.";
    break;
case Incident incident:
    description = incident.GetDescription();
    break;
```

An injury matches both types, so I put `Injury` first to give it the special message. Putting `Incident` first would make the `Injury` case unreachable, causing a compiler error.

A foul uses the `Incident` case. Because `GetDescription()` is `virtual` and `Foul` overrides it, the call returns `"The referee deemed a foul."` automatically. I do not need a separate foul case.

### Using a guard instead of an if inside a case

```csharp
case Manager manager when manager.Club is null:
    description = manager.Name;
    break;
case Manager manager:
    description = $"{manager.Name} ({manager.Club})";
    break;
```

The first case requires both a `Manager` object and a missing club. The second handles the remaining managers. The guarded case must come first because the general case matches every manager.

For `new Manager("José Mourinho", null)`, the expected output is `"José Mourinho"`. For `new Manager("Jürgen Klopp", "Liverpool")`, it is `"Jürgen Klopp (Liverpool)"`.

## Logs, Logs, Logs!

### What I learned

- An **enum** defines named constants for a related set of choices.
- Without explicit assignments, enum values start at `0` and increase by one.
- `Substring(1, 3)` starts at index `1` and takes three characters. For `"[INF]: File deleted"`, it extracts `"INF"`.
- A `switch` maps each text code to an enum value. Each `return` exits the method, so these cases do not need `break`.
- Casting with `(int)logLevel` retrieves the enum's underlying integer for the short log format.

### Names and numbers

My enum assigns the required numbers explicitly:

```csharp
enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0,
}
```

The name makes the code readable; the number supplies the encoded level. `Unknown` has value `0` even though it appears last, because I assigned it explicitly.

### Understanding global::

Autocomplete suggested `global::LogLevel.Trace`. A **namespace** groups names in code; `global::` tells C# to begin looking in the outermost, global namespace.

My enum is declared outside any named namespace. In this exercise, `LogLevel.Trace` and `global::LogLevel.Trace` refer to the same value. The longer spelling can avoid confusion when another name would otherwise hide the enum.

### Mistake and fix

I originally used:

```csharp
return $"{logLevel}:{message}";
```

For `LogLevel.Error`, interpolation inserts the name `"Error"`, producing `"Error:Stack overflow"`. Assigning `Error = 6` does not make interpolation automatically use that number.

The corrected method casts before inserting the value:

```csharp
public static string OutputForShortLog(LogLevel logLevel, string message)
{
    return $"{(int)logLevel}:{message}";
}
```

`LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow")` now produces `"6:Stack overflow"`.

## Calculator Conundrum

### What I learned

- An **exception** signals an error. `throw` stops the normal execution path and lets an exception handler deal with the error; without a matching handler, it remains unhandled.
- `nameof(operation)` produces the string `"operation"`, regardless of the parameter's current value.
- A `when` condition adds a **guard** to a switch case. `operand2 is 0` matches the constant zero; here, `operand2 == 0` also works.
- `break` exits the switch, `return` exits the method with a value, and `throw` transfers control through exception handling. A `break` immediately after `return` or `throw` is unreachable.

### Where SimpleOperation comes from

Exercism supplies [SimpleOperation.cs](./Exceptions/calculator-conundrum/SimpleOperation.cs) in the same project. Its `Addition`, `Multiplication`, and `Division` methods are static, so I call them through the class without creating an object.

These alternatives calculate the same answer:

```csharp
int throughHelper = SimpleOperation.Addition(16, 51); // 67
int throughOperator = 16 + 51;                       // 67
```

The helper uses `+` internally. Reusing the supplied methods follows the exercise setup and lets me focus on error handling. As with the supplied classes in Football Match Reports, I do not need to import the source file.

### Understanding nameof and exception arguments

```csharp
string operation = "+";

Console.WriteLine(operation);         // +
Console.WriteLine(nameof(operation)); // operation

throw new ArgumentOutOfRangeException(nameof(operation));
```

The exception above records `"operation"` as the invalid parameter's name. `nameof` lets the compiler check that the name exists and lets editor rename tools update the reference.

Constructor arguments depend on the exception type. In my solution, `new ArgumentException(nameof(operation))` uses `"operation"` as the error **message**, not the parameter name. To provide both, I could write:

```csharp
throw new ArgumentException("Operation cannot be empty.", nameof(operation));
```

`new ArgumentNullException()` is valid; `new ArgumentNullException(nameof(operation))` would also identify the parameter.

| Input                                | Required behavior                            |
| ------------------------------------ | -------------------------------------------- |
| `""`                                 | Throw `ArgumentException`.                   |
| `null`                               | Throw `ArgumentNullException`.               |
| An unsupported symbol, such as `"-"` | Throw `ArgumentOutOfRangeException`.         |
| `"/"` with a zero divisor            | Return `"Division by zero is not allowed."`. |

### Using a guard instead of a nested if

This builds on the guarded `Manager` case in Football Match Reports:

```csharp
case "/" when operand2 is 0:
    return "Division by zero is not allowed.";
case "/":
    result = SimpleOperation.Division(operand1, operand2);
    break;
```

The specific case comes first. It returns the message immediately, so neither division nor the final formatted return runs for a zero divisor. The general case handles the remaining divisions.

My solution prevents division by zero with a guard; it does not catch a `DivideByZeroException`. Throwing an exception and catching one with `try`/`catch` are separate operations.

### Mistakes and fixes

| Mistake                                 | Cause                                    | Fix                               |
| --------------------------------------- | ---------------------------------------- | --------------------------------- |
| Assigning the error message to `result` | An `int` cannot store a string.          | Return the message directly.      |
| Using a bare `return;`                  | `Calculate` promises to return a string. | Supply the string after `return`. |
| Adding `break` after `throw`            | Execution cannot reach that statement.   | Remove the unnecessary `break`.   |

Successful calculations reach the final interpolation:

```csharp
return $"{operand1} {operation} {operand2} = {result}";
// Calculate(16, 51, "+") returns "16 + 51 = 67".
```

## Secure Munchester United

### What I learned

- **Type pattern matching** checks whether an object can be treated as a type and gives me a variable of that type: `support is Staff member`.
- In `Staff member`, `Staff` is the type and `member` is a variable name. `Staff staff` also works: C# distinguishes uppercase and lowercase names. Neither form creates a new object.
- `is Staff` includes classes that inherit from `Staff`, directly or indirectly. I check specific types before general types when they need special behavior.
- `GetType()` returns an object's actual runtime type. Comparing it with `typeof(Security)` checks for exactly `Security`, excluding its subclasses.
- `string.Empty` represents the same empty string as `""`. It adds no characters during interpolation, but cannot remove spaces already written outside the expression.

`TeamSupport` is an **interface**: it requires implementing types to provide a readable `Title` property. `Staff` implements that interface and is abstract, so I cannot create `new Staff()`. Concrete child classes supply their titles. `Manager` and `Chairman` implement `TeamSupport` directly; they do not inherit from `Staff`.

This builds on inheritance.

### Broad checks versus exact types

`Security : Staff` and `SecurityJunior : Security` mean a security junior is both a security member and a staff member.

| Object                 | `is Staff` | `is Security` | `GetType() == typeof(Security)` |
| ---------------------- | ---------- | ------------- | ------------------------------- |
| `new Physio()`         | `true`     | `false`       | `false`                         |
| `new Security()`       | `true`     | `true`        | `true`                          |
| `new SecurityJunior()` | `true`     | `true`        | `false`                         |
| `new Manager()`        | `false`    | `false`       | `false`                         |

Task 1 returns staff titles. Task 2 adds the priority suffix to `Security` and its subclasses. Task 3 changes that rule: only an object whose exact type is `Security` receives the suffix.

Checking `Staff` first would return a security member's title immediately and end the method before the security branch could run.

The exercise guarantees non-null input, so no null check is needed before `GetType()`.

## Weighing Machine

### What I learned

- A **field** stores data inside an object. A **property** provides access to data and can run code when it is read or changed. `weight` and `Weight` are different names because C# is case-sensitive.
- `get` runs when I read a property. `set` runs when I assign to it. These blocks are called **accessors**; C# calls the appropriate one automatically.
- Inside a setter, `value` is the incoming value. In `wm.Weight = 60.5;`, the setter receives `60.5` as `value`.
- An **auto-implemented property**, such as `{ get; set; }`, lets C# create hidden storage. A custom getter must explicitly return the field or calculation I want to read.
- A property can be get-only. `Precision` keeps its initial value; `DisplayWeight` calculates a result each time I read it.

### Reading and writing a property

```csharp
var wm = new WeighingMachine(precision: 3);
wm.Weight = 60.5;                 // Runs Weight's set accessor.
double currentWeight = wm.Weight; // Runs Weight's get accessor.
```

My `Weight` property uses a **backing field**: a field that holds the property's data.

```csharp
private double weight;

public double Weight
{
    get
    {
        return weight;
    }
    set
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        weight = value;
    }
}
```

The setter checks the incoming number before storing it. The getter returns the stored number. If the weight is `70` and an assignment of `-5` throws, the assignment never reaches `weight = value;`, so the stored weight remains `70`.

### Replacing an if with ThrowIfNegative

I replaced this explicit check:

```csharp
if (value < 0)
{
    throw new ArgumentOutOfRangeException(nameof(Weight));
}
```

with:

```csharp
ArgumentOutOfRangeException.ThrowIfNegative(value);
```

The helper throws for a negative incoming value and returns normally otherwise. Zero is allowed. This builds on exceptions: throwing stops the normal execution path, so the later assignment does not run.

The exception details differ slightly. The helper call above automatically records `"value"` as the parameter name; the original check records `"Weight"`. To explicitly use the property name, I can write:

```csharp
ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(Weight));
```

### Initial values and later assignments

My class uses a **primary constructor**: its parameter list appears directly after the class name. This shortened example shows how it initializes the get-only precision property:

```csharp
class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;
    public double TareAdjustment { get; set; } = 5.0;
}
```

`new WeighingMachine(precision: 3)` initializes `Precision` to `3`. Callers can read it but cannot assign a new value to it. With a conventional constructor, I could instead assign `Precision = precision;` inside the constructor body.

`TareAdjustment` starts at `5.0`, then accepts later assignments such as `wm.TareAdjustment = 10;`. The initializer establishes the default; the setter accepts each new value. It also allows negative adjustments. I use `double`, matching the exercise's decimal literals and the `Weight` property.

### Calculating the display in get

```csharp
public string DisplayWeight
{
    get
    {
        double adjustedWeight = Weight - TareAdjustment;
        string formattedWeight = adjustedWeight.ToString($"F{Precision}");
        return $"{formattedWeight} kg";
    }
}
```

Reading `wm.DisplayWeight` runs this calculation using the current weight and tare adjustment. No separate display field or setter is needed.

With precision `3`, `$"F{Precision}"` produces `"F3"`. This format displays exactly three decimal places, rounding as needed and keeping trailing zeros. It returns a string without changing the stored weight. For the exercise's formatting culture:

| Weight    | Tare adjustment | Precision | DisplayWeight  |
| --------- | --------------- | --------- | -------------- |
| `100.770` | `10`            | `3`       | `"90.770 kg"`  |
| `100.770` | `10`            | `1`       | `"90.8 kg"`    |
| `100`     | `110.567`       | `3`       | `"-10.567 kg"` |

A negative input weight is rejected, but a negative display weight is allowed when the tare adjustment is larger than the input weight.

### Mistakes and fixes

| Mistake                                                                    | Cause                                                                                                    | Fix                                                                                         |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| Declaring `Precision` without initializing it from a constructor parameter | The property does not receive the requested precision.                                                   | Initialize it from `precision`.                                                             |
| Setting `tareAdjustment = 5.0;` inside the setter                          | Each assignment ignores the incoming `value`; this also does not establish a default at object creation. | Use `public double TareAdjustment { get; set; } = 5.0;`.                                    |
| Using a bare `get;` beside a setter that writes a separately named field   | The getter does not automatically read that field.                                                       | Use an auto-property for simple storage, or explicitly return the field in a custom getter. |
| Calculating `DisplayWeight` inside `set`                                   | Reading the property runs `get`, so the calculation does not run.                                        | Calculate and return the formatted result inside `get`.                                     |
| Ending a property block with `};`                                          | A property block without an initializer does not take a trailing semicolon.                              | End it with `}`; an initializer such as `= 5.0;` does need its semicolon.                   |
