class SwitchProg
{
    public void Manupulate() //Manupulate function created 
    {
        Console.WriteLine("Enter the option for performing the Student Details Manupulation: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Creation was successfull");
                break;
            case 2:
                Console.WriteLine("Updation was successfull");
                break;
            case 3:
                Console.WriteLine("Deletion was successfull");
                break;
            default:
                Console.WriteLine("");
                break;
        }
    }
}