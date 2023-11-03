using System;

// Unit 04 Develop: Mindfulness Program
// Submitted by: Crisanta Advincula

//Showing Creativity and Exceeding Requirements:
//Make sure no random prompts/questions are selected until they have all been used at least once in that session.
//This code is shown in the ReflectionActivity.cs inside the GetRandomQuestion(Random rnd) method. 
//This method selects a random question from the '_questions' list and ensure that question will not be repeated until all questions have been used at least once within a specific duration of time.
class Program
{    
    static void Main(string[] args)
    {
        DisplayMenu();
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
        Console.Write("Select a choice from the menu: ");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Clear();
            
            string activityName = "Breathing Activity";
            string activityDescription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
            
            BaseMindfulness baseMindfulness = new BaseMindfulness(activityName, activityDescription);
            BreathingActivity breathingActivity = new BreathingActivity(activityName, activityDescription, baseMindfulness._duration);

            breathingActivity.StartBreathing();
        }
        if (choice == 2)
        {
            Console.Clear();
            string activityName = "Reflecting Activity";
            string activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
            
            BaseMindfulness baseMindfulness = new BaseMindfulness(activityName, activityDescription);
            ReflectionActivity reflectionActivity = new ReflectionActivity(activityName, activityDescription, baseMindfulness._duration);

            reflectionActivity.StartReflection();
        }
        if (choice == 3)
        {
            Console.Clear();

            string activityName = "Listing Activity";
            string activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
            
            BaseMindfulness baseMindfulness = new BaseMindfulness(activityName, activityDescription);
            ListingActivity listingActivity = new ListingActivity(activityName, activityDescription, baseMindfulness._duration);

            listingActivity.StartListing();
        }
        else if (choice == 4)
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}