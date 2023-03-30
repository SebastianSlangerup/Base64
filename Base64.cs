namespace Base64;

public class Base64
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    
    public static char Encode(string input)
    {
        int shiftedCharacter = 0;
        int remainder = 0;
        foreach (var character in input)
        {
            // character 'M': 01001101
            // 01001101 >> 2 = 010011
            shiftedCharacter = character >> 2;
        }

        char[] base64Array = Base64Chars.ToCharArray();
        return base64Array[shiftedCharacter]; // 19th character = T
        
    }
    
    public static string Decode(string input)
    {
        char[] charInput = input.ToCharArray();
        foreach (char ch in charInput)
        {
            Console.WriteLine(Convert.ToString(ch, toBase: 2));
        }



        return input;
    }
}