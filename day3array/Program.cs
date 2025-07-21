class Program
{

    // method is in pascal case (eg : AddOperation())
    static void Main()
    {
        int noOfStudent = 5;
        string[] sName = new string[noOfStudent];
        
        Console.WriteLine("Enter the names of 5 students :");

        for (int i = 0; i < noOfStudent; i++)
        {

            Console.WriteLine("Enter name of student " + (i + 1));
            sName[i]=Console.ReadLine();
        }
         Console.WriteLine("Student Data :");
            for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("The " + (i+1) + "student name is : " + sName[i]);

        }

    }


}
