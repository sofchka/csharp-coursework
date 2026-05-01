using System;

namespace Task2_BigNumbers;

public static class BigNumCalculator
{
    public static string Add(string a, string b)
    {
        a = CleanNumber(a);
        b = CleanNumber(b);

        bool aIsNegative = a.StartsWith("-");
        bool bIsNegative = b.StartsWith("-");

        if (aIsNegative)
            a = a.Substring(1);

        if (bIsNegative)
            b = b.Substring(1);

        if (aIsNegative && bIsNegative)
        {
            string result = "-" + AddPositives(a, b);

            if (result == "-0")
                return "0";

            return result;
        }

        if (aIsNegative)
            return SubtractWithSign(b, a);

        if (bIsNegative)
            return SubtractWithSign(a, b);

        return AddPositives(a, b);
    }

    public static string Subtract(string a, string b)
    {
        a = CleanNumber(a);
        b = CleanNumber(b);

        bool aIsNegative = a.StartsWith("-");
        bool bIsNegative = b.StartsWith("-");

        if (aIsNegative)
            a = a.Substring(1);

        if (bIsNegative)
            b = b.Substring(1);

        if (!aIsNegative && bIsNegative)
            return AddPositives(a, b);

        if (aIsNegative && !bIsNegative)
        {
            string result = "-" + AddPositives(a, b);

            if (result == "-0")
                return "0";

            return result;
        }

        if (aIsNegative && bIsNegative)
            return SubtractWithSign(b, a);

        return SubtractWithSign(a, b);
    }

    public static string Multiply(string a, string b)
    {
        a = CleanNumber(a);
        b = CleanNumber(b);

        bool aIsNegative = a.StartsWith("-");
        bool bIsNegative = b.StartsWith("-");

        if (aIsNegative)
            a = a.Substring(1);

        if (bIsNegative)
            b = b.Substring(1);

        bool resultIsNegative = aIsNegative != bIsNegative;

        string product = MultiplyPositives(a, b);

        if (resultIsNegative && product != "0")
            return "-" + product;

        return product;
    }

    private static string AddPositives(string a, string b)
    {
        while (a.Length < b.Length)
            a = "0" + a;

        while (b.Length < a.Length)
            b = "0" + b;

        char[] result = new char[a.Length + 1];
        int carry = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitA = a[i] - '0';
            int digitB = b[i] - '0';

            int sum = digitA + digitB + carry;

            carry = sum / 10;
            result[i + 1] = (char)('0' + sum % 10);
        }

        result[0] = (char)('0' + carry);

        return RemoveLeadingZeros(new string(result));
    }

    private static string SubtractPositives(string a, string b)
    {
        while (b.Length < a.Length)
            b = "0" + b;

        char[] result = new char[a.Length];
        int borrow = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitA = a[i] - '0' - borrow;
            int digitB = b[i] - '0';

            if (digitA < digitB)
            {
                digitA += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }

            result[i] = (char)('0' + digitA - digitB);
        }

        return RemoveLeadingZeros(new string(result));
    }

    private static string SubtractWithSign(string a, string b)
    {
        int compare = ComparePositives(a, b);

        if (compare == 0)
            return "0";

        if (compare > 0)
            return SubtractPositives(a, b);

        string result = "-" + SubtractPositives(b, a);

        if (result == "-0")
            return "0";

        return result;
    }

    private static string MultiplyPositives(string a, string b)
    {
        if (a == "0" || b == "0")
            return "0";

        int[] result = new int[a.Length + b.Length];

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitA = a[i] - '0';

            for (int j = b.Length - 1; j >= 0; j--)
            {
                int digitB = b[j] - '0';

                int multiplication = digitA * digitB;

                int leftPosition = i + j;
                int rightPosition = i + j + 1;

                int sum = multiplication + result[rightPosition];

                result[rightPosition] = sum % 10;
                result[leftPosition] += sum / 10;
            }
        }

        string answer = "";

        for (int i = 0; i < result.Length; i++)
            answer += (char)('0' + result[i]);

        return RemoveLeadingZeros(answer);
    }

    private static int ComparePositives(string a, string b)
    {
        a = RemoveLeadingZeros(a);
        b = RemoveLeadingZeros(b);

        if (a.Length > b.Length)
            return 1;

        if (a.Length < b.Length)
            return -1;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > b[i])
                return 1;

            if (a[i] < b[i])
                return -1;
        }

        return 0;
    }

    private static string RemoveLeadingZeros(string number)
    {
        int i = 0;

        while (i < number.Length - 1 && number[i] == '0')
            i++;

        return number.Substring(i);
    }

    private static string CleanNumber(string number)
    {
        if (string.IsNullOrEmpty(number))
            return "0";

        string trimmedNumber = number.Trim();

        if (trimmedNumber.Length == 0)
            return "0";

        bool isNegative = trimmedNumber.StartsWith("-");

        string digits = isNegative ? trimmedNumber.Substring(1) : trimmedNumber;

        if (digits.Length == 0)
            return "0";

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] < '0' || digits[i] > '9')
                return "0";
        }

        digits = RemoveLeadingZeros(digits);

        if (digits == "0")
            return "0";

        if (isNegative)
            return "-" + digits;

        return digits;
    }
}