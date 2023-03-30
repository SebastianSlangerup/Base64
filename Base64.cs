namespace Base64;

public class Base64
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    
    public static string Encode(string input)
    {
        char[] letters = input.ToCharArray();

        string fullBinaryInput = "";

        foreach (char letter in letters)
        {
            string binaryLetter = Convert.ToString(letter, 2);

            while (binaryLetter.Length < 8)
            {
                binaryLetter = "0" + binaryLetter;
            }

            fullBinaryInput += binaryLetter;
        }

        // ["011010", "000101", "101010"...]
        string[] binarySextets = new string[input.Length * 2];
        int iterator = 1;
        string sextetString = ""; // "001010"
        
        // Split the binary input into sextets (6 bits per group)
        foreach (char binaryChar in fullBinaryInput)
        {
            sextetString += binaryChar;
            if (iterator % 6 == 0)
            {
                binarySextets[iterator / 6 - 1] = sextetString;
                // Start repopulating the sextet string
                sextetString = "";
            }

            iterator++;
        }

        fullBinaryInput = "";
        string resultingInput = "";
        char[] base64Chars = Base64Chars.ToCharArray();
        
        foreach (var sextet in binarySextets)
        {
            if (sextet == null)
            {
                continue;
            }
            fullBinaryInput += sextet + " ";

            resultingInput += base64Chars[Convert.ToInt16(sextet, 2)];
        }

        return resultingInput;
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