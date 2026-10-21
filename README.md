# My C# Learning Notes

What I learn while completing the Exercism C# challenges, with examples and mistakes to remember.

## Exercises

| Exercise                  | Topic  | Solution                                                     | Learning notes                     |
| ------------------------- | ------ | ------------------------------------------------------------ | ---------------------------------- |
| Lucian's Luscious Lasagna | Basics | [Code](./lucians-luscious-lasagna/LuciansLusciousLasagna.cs) | [Notes](#lucians-luscious-lasagna) |

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

## Commands and project files

Run commands from the exercise folder:

```bash
dotnet test
```

This restores required packages, builds the code, and runs the tests. Packages are reusable code the project depends on. `dotnet test --no-restore` skips the restore step and is useful when the required packages have already been restored.

Building creates `bin/` for compiled output and supporting libraries, and `obj/` for intermediate build files. The repository's [.gitignore](./.gitignore) ignores these folders in every exercise. Source code, tests, and project files still belong in version control.
