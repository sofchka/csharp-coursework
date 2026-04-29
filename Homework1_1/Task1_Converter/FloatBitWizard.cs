using System;
namespace Task1_Converter;

public static class FloatBitWizard
{
    // float -> 32-bit string
    // Example:
    // 12.375f -> "0 | 10000010 | 10001100000000000000000" (Pretty True)
    //
    // IEEE 754 float structure:
    // 1 bit  -> sign
    // 8 bits -> exponent
    // 23 bits -> mantissa / fraction.
    
    public static string ToBits(float number, bool pretty = false)
    {
        int signBit = 0; // for sign

        // IsNegativeInfinity because in c# we have -0.0f which is not detected with "-0.0f < 0f"
        if (number < 0f || (number == 0f && float.IsNegativeInfinity(1f / number)))
        {
            signBit = 1;
            number = -number;
        }

        // C# cases special

        // NaN = "0 | 11111111 | 10000000000000000000000"
        if (float.IsNaN(number))
        {
            string result = "0" + "11111111" + "10000000000000000000000";
            return FormatResult(result, pretty);
        }

        // Infinity (if we did 1/0 or -1/0) = "SIG | 11111111 | 00000000000000000000000"
        if (float.IsPositiveInfinity(number))
        {
            string result = signBit + "11111111" + "00000000000000000000000";
            return FormatResult(result, pretty);
        }

        // Zero (0.0f / -0.0f) = SIG | 0s
        if (number == 0f)
        {
            string result = signBit + "00000000" + "00000000000000000000000";
            return FormatResult(result, pretty);
        }

        // to make more correct / stable
        double value = number;

        // Exponent
        int exponent = 0;
        double temp = value;

        if (temp >= 2.0)  // if Amboxj mas is more than 0000010, then we need to shift it left (1100.011 -> 1.100011)
        {
            while (temp >= 2.0)
            {
                temp /= 2.0;
                exponent++;
            }
        }
        else if (temp < 1.0) // the opposite if it is all zeros we need to bring 1 
        {
            while (temp < 1.0)
            {
                temp *= 2.0;
                exponent--;
            }
        }
        
        int biasedExponent = exponent + 127;

        // Mantissa
        double fraction = temp - 1.0;

        char[] mantissaBits = new char[23];

        for (int i = 0; i < 23; i++)
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
        
        string exponentBits = IntToBinary(biasedExponent, 8);

        string raw = signBit + exponentBits + new string(mantissaBits);

        return FormatResult(raw, pretty); // pretty or not
    }

    public static float FromBits(string bits)
    {
        string clean = CleanBits(bits);

        if (clean.Length != 32)
            throw new ArgumentException("Input must contain exactly 32 bits.");

        int sign = clean[0] - '0';
        string exponentPart = clean.Substring(1, 8);
        string mantissaPart = clean.Substring(9, 23);

        int biasedExponent = BinaryToInt(exponentPart);

        double mantissa = 0.0;
        double bitValue = 0.5;

        for (int i = 0; i < 23; i++)
        {
            if (mantissaPart[i] == '1')
                mantissa += bitValue;

            bitValue /= 2.0;
        }

        // Special cases again
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
                return float.NaN;

            return sign == 0 ? float.PositiveInfinity : float.NegativeInfinity;
        }
        
        // value = 1.mantissa * 2^(biasedExponent - 127)

        double res;
        
        if (biasedExponent == 0)
        {
            // Very small denormal numbers. They do not have the hidden 1.
            // value = mantissa * 2^(-126)
            res = mantissa * Pow2(-126);
        }
        else
        {
            int realExponent = biasedExponent - 127;
            res = (1.0 + mantissa) * Pow2(realExponent);
        }

        if (sign == 1)
            res = -res;

        return (float)res;
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

        return $"{res[0]} | {res.Substring(1, 8)} | {res.Substring(9, 23)}";
    }
}