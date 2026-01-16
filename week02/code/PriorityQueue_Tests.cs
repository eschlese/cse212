using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add four items to the queue with one being of higher priority. Run
    // until queue is empty. Apple 1, Orange 1, Banana 1, Mango 2.
    // Expected Result: Mango, Apple, Orange, Banana
    // Defect(s) Found: Expected Mango, actual Banana, line 22. Priority isn't working. 
    // Expected Apple, actual Mango, line 23. Dequeue isn't removing items from queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Orange", 1);
        priorityQueue.Enqueue("Banana", 1);
        priorityQueue.Enqueue("Mango", 2);

        Assert.AreEqual("Mango", priorityQueue.Dequeue());
        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("Orange", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Add eight items of varying priorities, with multiple being the same
    // priority. Run until queue is empty. Apple 4, Orange 2, Banana 1, Mango 2, Pear 3,
    // Pineapple 3, Grape 1, Lychee 5.
    // Expected Result: Lychee, Apple, Pear, Pineapple, Orange, Mango, Banana, Grape
    // Defect(s) Found: Expected Lychee, actual Apple, line 52. Priority isn't working
    // Expected Apple, actual Lychee, line 52. Dequeue isn't removing items from queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Apple", 4);
        priorityQueue.Enqueue("Orange", 2);
        priorityQueue.Enqueue("Banana", 1);
        priorityQueue.Enqueue("Mango", 2);
        priorityQueue.Enqueue("Pear", 3);
        priorityQueue.Enqueue("Pineapple", 3);
        priorityQueue.Enqueue("Grape", 1);
        priorityQueue.Enqueue("Lychee", 5);

        string[] expected = ["Lychee", "Apple", "Pear", "Pineapple", "Orange", "Mango", "Banana", "Grape"];

        foreach (string fruit in expected)
        {
            Assert.AreEqual(fruit, priorityQueue.Dequeue());
        }

    }

    [TestMethod]
    // Scenario: Check if error is thrown when queue is empty and dequeue attempt made.
    // Expected Result: error message "The queue is empty."
    // Defect(s) Found: None!
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("It didn't do the thing");
        }
        catch (InvalidOperationException error)
        {
            Assert.AreEqual("The queue is empty.", error.Message);
        }
    }
}