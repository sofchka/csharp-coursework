using System;
namespace Task1_Bonus;

public static class DoubleBitWizard
{
    public static string ToBits(double number, bool pretty = false)
    {
        int signBit = 0;

        if (number < 0.0 || (number == 0.0 && double.IsNegativeInfinity(1.0 / number)))
        {
            signBit = 1;
            number = -number;
        }

        if (double.IsNaN(number))
        {
            string result = "0" + "11111111111" + "1000000000000000000000000000000000000000000000000000";
            return FormatResult(result, pretty);
        }

        if (double.IsInfinity(number))
        {
            string result = signBit + "11111111111" + "0000000000000000000000000000000000000000000000000000";
            return FormatResult(result, pretty);
        }

        if (number == 0.0)
        {
            string result = signBit + "00000000000" + "0000000000000000000000000000000000000000000000000000";
            return FormatResult(result, pretty);
        }

        double value = number;

        int exponent = 0;
        double temp = value;

        if (temp >= 2.0)
        {
            while (temp >= 2.0)
            {
                temp /= 2.0;
                exponent++;
            }
        }
        else if (temp < 1.0)
        {
            while (temp < 1.0)
            {
                temp *= 2.0;
                exponent--;
            }
        }

        int biasedExponent = exponent + 1023;

        double fraction = temp - 1.0;

        char[] mantissaBits = new char[52];

        for (int i = 0; i < 52; i++)
        {
            fraction *= 2.0;

            if (fraction >= 1.0)
            {
                mantissaBits[i] = '1';
                fraction -= 1.0;
            }
            else
            {
                mantissaBits[i] = '0';
            }
        }

        string exponentBits = IntToBinary(biasedExponent, 11);

        string raw = signBit + exponentBits + new string(mantissaBits);

        return FormatResult(raw, pretty);
    }

    public static double FromBits(string bits)
    {
        string clean = CleanBits(bits);

        if (clean.Length != 64)
            throw new ArgumentException("Input must contain exactly 64 bits.");

        int sign = clean[0] - '0';
        string exponentPart = clean.Substring(1, 11);
        string mantissaPart = clean.Substring(12, 52);

        int biasedExponent = BinaryToInt(exponentPart);

        double mantissa = 0.0;
        double bitValue = 0.5;

        for (int i = 0; i < 52; i++)
        {
            if (mantissaPart[i] == '1')
                mantissa += bitValue;

            bitValue /= 2.0;
        }

        if (biasedExponent == 2047)
        {
            bool mantissaIsZero = true;

            for (int i = 0; i < mantissaPart.Length; i++)
            {
                if (mantissaPart[i] == '1')
                {
                    mantissaIsZero = false;
                    break;
                }
            }

            if (!mantissaIsZero)
                return double.NaN;

            return sign == 0 ? double.PositiveInfinity : double.NegativeInfinity;
        }

        double res;

        if (biasedExponent == 0)
        {
            res = mantissa * Pow2(-1022);
        }
        else
        {
            int realExponent = biasedExponent - 1023;
            res = (1.0 + mantissa) * Pow2(realExponent);
        }

        if (sign == 1)
            res = -res;

        return res;
    }

    private static string CleanBits(string bits)
    {
        string clean = "";

        foreach (char c in bits)
        {
            if (c == '0' || c == '1')
                clean += c;
        }

        return clean;
    }

    private static string IntToBinary(int value, int bitCount)
    {
        char[] result = new char[bitCount];

        for (int i = bitCount - 1; i >= 0; i--)
        {
            int bit = value % 2;
            result[i] = bit == 1 ? '1' : '0';
            value /= 2;
        }

        return new string(result);
    }

    private static int BinaryToInt(string bits)
    {
        int result = 0;

        for (int i = 0; i < bits.Length; i++)
        {
            result = result * 2 + (bits[i] - '0');
        }

        return result;
    }

    private static double Pow2(int power)
    {
        double result = 1.0;

        if (power >= 0)
        {
            for (int i = 0; i < power; i++)
                result *= 2.0;
        }
        else
        {
            for (int i = 0; i < -power; i++)
                result /= 2.0;
        }

        return result;
    }

    private static string FormatResult(string res, bool pretty)
    {
        if (!pretty)
            return res;

        return $"{res[0]} | {res.Substring(1, 11)} | {res.Substring(12, 52)}";
    }
}