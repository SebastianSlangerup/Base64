namespace Base64;

public static class Base64
{
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    
    public static string Encode(string input)
    {
        char[] letters = input.ToCharArray();
        string binaryInput = "";

        foreach (char letter in letters)
        {
            string binaryLetter = Convert.ToString(letter, 2);

            // This makes sure that binaryLetter will always be 8 digits long
            while (binaryLetter.Length < 8)
            {
                binaryLetter = "0" + binaryLetter;
            }

            binaryInput += binaryLetter;
        }

        // Create an array that will house the sextets
        // e.g ["011001", "010001", "110001"]
        string[] binarySextets = new string[input.Length * 2];
        
        // Split the binary input into sextets (6 bits per group)
        string sextetString = "";
        int iterator = 0;
        foreach (char digit in binaryInput)
        {
            sextetString += digit;
            if (iterator % 6 == 0)
            {
                // Populate the sextet array with the new sextet string
                binarySextets[iterator / 6 - 1] = sextetString;
                // Reset the string to start over
                sextetString = "";
            }

            iterator++;
        }

        // Refresh the binaryInput variable to fill it up with sextets instead.
        binaryInput = "";
        string result = "";
        char[] base64Chars = Base64Chars.ToCharArray();
        
        foreach (var sextet in binarySextets)
        {
            if (sextet == null)
            {
                continue;
            }
            
            binaryInput += sextet + " ";

            result += base64Chars[Convert.ToInt16(sextet, 2)];
        }

        return result;
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