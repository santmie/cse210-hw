using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Back in your Program.cs file, add code to your Main function.
        // Create a new job instance named job1 .
        // Set the member variables using the dot notation (for example, job1._jobTitle = "Software Engineer";
        // Verify that you can display the company of this job on the screen, again using the dot notation to access the member variable.
        // Create a second job, set its variables, display this company on the screen as well.
        
        // Console.WriteLine(job1._jobTitle);
        // Console.WriteLine(job1._company);
        // Console.WriteLine(job2._company);

        // Return to your Program.cs file. Remove the lines of code where you displayed the 
        // company earlier, and replace them with calls to your new method. Remember that you call the 
        // method using the same dot notation such as job1.Display();

        // job1.DisplayJobDetails();
        // job2.DisplayJobDetails();

        // Return to your Program.cs. Add the end of the Main function, create a new instance of the Resume class.
        // Add the two jobs you created earlier, to the list of jobs in the resume object.
    
        Resume myResume = new Resume();

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume._name = "Allison Rose";

        // Verify that you can access and display the first job title using dot notation similar to myResume._jobs[0]._jobTitle 
        // string jobOne = myResume._jobs[0]._jobTitle;
        // string jobTwo = myResume._jobs[1]._jobTitle;
        // Console.WriteLine(jobOne);
        // Console.WriteLine(jobTwo);

        myResume.DisplayJobs();

    }
}