/*  Haggai P. Estavilla BSCS - 2A
*/
using System;
using System.Collections.Generic;

class TriageAlgorithm
{
    public static void Main(string[] args)
    {
        TriageAlgo triage = new TriageAlgo(4); //4 beds

        // Test Case 1: Add 3 patients (within bed limit)
        triage.AddPatient(new Patient("Lit", 22, 4));
        triage.AddPatient(new Patient("Mayo", 19, 2));
        triage.AddPatient(new Patient("Nive", 25, 1));

        triage.DisplayBeds(); // Expect: Nive, Mayo, Lit (sorted by priority)

        // Test Case 2: Add less urgent patient (priority 4)
        triage.AddPatient(new Patient("Lance", 23, 4));
        triage.DisplayBeds(); // Expect: No change — Lance should be rejected

        // Test Case 3: Add more urgent patient (priority 1)
        triage.AddPatient(new Patient("Zara", 20, 1));
        triage.DisplayBeds(); // Expect: Zara replaces Lit

        // Test Case 4: Add medium-priority patient (priority 2)
        triage.AddPatient(new Patient("Chris", 30, 2));
        triage.DisplayBeds(); // Expect: Chris replaces Mayo or Lit depending on current state

        // Test Case 5: Add another high-priority patient (priority 1)
        triage.AddPatient(new Patient("Anna", 27, 1));
        triage.DisplayBeds(); // Expect: Anna replaces lowest priority again
    }
}

public class Patient
{
    private String Name {get; set;}
    private int Age {get; set;}
    public int PriorityNum {get; set;}
    // 1 - Most Priority (Red) - Immediate/Emergency
    // 2 - Yellow - Delayed
    // 3 - Green - Minimal
    // 4 - Black - Expectant/Dead 

    public Patient (String name, int age, int priorityNum)
    {
        Name = name;
        Age = age;
        PriorityNum = priorityNum;
    }

    public String Display()
    {
        return $"Name: {Name}, Age: {Age}, Priority: {PriorityNum}";
    }
}

public class TriageAlgo
{
    private int beds;
    private List<Patient> bedsList;

    public TriageAlgo(int beds)
    {
        this.beds = beds;
        bedsList = new List<Patient>();
    }

    public void AddPatient(Patient newPatient)
    {
        if(bedsList.Count < beds)
        {
            bedsList.Add(newPatient);
            bedsList.Sort((a, b) => a.PriorityNum.CompareTo(b.PriorityNum)); 
        }
        else
        {
            bedsList.Sort((a, b) => a.PriorityNum.CompareTo(b.PriorityNum)); 
            if(newPatient.PriorityNum < bedsList[bedsList.Count - 1].PriorityNum)
            {
                bedsList[bedsList.Count - 1] = newPatient;
                bedsList.Sort((a, b) => a.PriorityNum.CompareTo(b.PriorityNum));
            }
        }
    }
    public void DisplayBeds()
    {
        Console.WriteLine("\nCurrent Bed Assignments: ");
        foreach(Patient p in bedsList)
        {
            Console.WriteLine(p.Display());
        }
    }
}