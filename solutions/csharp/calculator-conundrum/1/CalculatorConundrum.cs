public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        int result;

        switch (operation) {
            case "+":
                result = SimpleOperation.Addition(operand1, operand2);
                break;
            case "*":
                result = SimpleOperation.Multiplication(operand1, operand2);
                break;
            case "/" when operand2 is 0:
                return "Division by zero is not allowed.";
            case "/":
                result = SimpleOperation.Division(operand1, operand2);
                break;
            case "":
                throw new ArgumentException(nameof(operation));
            case null:
                throw new ArgumentNullException();
            default:
                throw new ArgumentOutOfRangeException(nameof(operation));
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
}
