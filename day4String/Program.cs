
class StringPrograms
{
    static void Main()
    {

        //Length of a string
        string text = "CSharp, Language invented in 2002.";
        int length = text.Length; //15
        Console.WriteLine("The Length of a string : " + length);

        //Accessing a string
        string subString = text.Substring(7, 8);
        Console.WriteLine("The text from a string : " + subString);


        // count all the blank spaces 
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                count++;
            }
        }
        Console.WriteLine("The number of blank spaces in a string : " + count);

        ///Count all the special characters different way

        int count1 = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (!char.IsLetterOrDigit(text[i]) && !char.IsWhiteSpace(text[i]))
            {
                count1++;
            }
        }
        Console.WriteLine("The number of special characters are : " + count1);

        //count the number of words in a string

        int count2 = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                count2++;
            }
        }
        Console.WriteLine("The number of words in a string : " + count2);

        //count the vowel in a string

        int count3 = 0;

        int count4 = 0;
        

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
            {
                count3++;
            }
            if (text[i] == 'A' || text[i] == 'E' || text[i] == 'I' || text[i] == 'O' || text[i] == 'U')
            {
                count4++;
            }
        }
        Console.WriteLine("The number of vowels in a string : " + count3);
        Console.WriteLine("The number of uppercase vowels in a string : " + count4);


        


        Console.WriteLine(text.IndexOf("harp"));
        Console.WriteLine(text.ToUpper());
        string newString = text.Replace("CSharp", "Java");
        Console.WriteLine(newString);

        String replaced = text.Replace(" ", "");
        Console.WriteLine("Without space : " + replaced.Length);

        int pos = text.IndexOf("Language");
        string newText = text.Substring(pos, 8);
        Console.WriteLine("New Text Value " + newText.ToUpper());

        //Count all the blank space

        string data = "CSharp,Language";
        String[] lang = data.Split(',');
        foreach (string valuess in lang)
        {
            Console.WriteLine(valuess);
        }



    }
}

