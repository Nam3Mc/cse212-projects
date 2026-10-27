public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // what would i do to solve this task is use a for loop
        // so i wil set the first var as 1 set the secomd parameter of the for loop to stop once the var declared
        // is equal or minor that the length, inside the loop i will multiply the number times the declarer var and 
        // add eacu value to an empty array, finally i will return the array of values 

        List<double> results = new(); 
        for (var i = 1; i <= length; i++)
        {
            results.Add( number * i );
            Console.WriteLine(number * i);
        }

        return results.ToArray(); // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // to comple this activity i set the split index as var taking the data.Count  - amount and using GetRange 
        // using these to values splitIndex, amount will give me the tail range then i will set the variable for head 
        // with the GetRange and the following parameters 0 and splitIndex to have the first part 
        //  as this is a void and will return nothing i would clena the data and then addRange tail and head 
        int splitIndex = data.Count - amount;
        var tail = data.GetRange(splitIndex, amount);
        var head = data.GetRange(0, splitIndex);
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);

    }
}
