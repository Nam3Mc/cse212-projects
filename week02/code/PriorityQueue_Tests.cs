using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue low(1), high(10), med(5) and dequeue three times.
    // Expected Result: "high", "med", "low".
    // Defect(s) Found: Dequeue returned the same highest-priority item over and
    //                  over because it never removed the item from the queue
    //                  (missing RemoveAt). After the first call the queue still
    //                  contained the same items.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);
        priorityQueue.Enqueue("med", 5);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("med",  priorityQueue.Dequeue());
        Assert.AreEqual("low",  priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items with identical priority (5): "first",
    //           "second", "third".
    // Expected Result: "first", "second", "third" (FIFO tie-break).
    // Defect(s) Found: Dequeue used >= when scanning for the highest priority,
    //                  so a later item with equal priority replaced the earlier
    //                  one. First Dequeue returned "second" (and, combined with
    //                  the loop bug, could also skip the real front). Fixed by
    //                  using > so the earliest high-priority item wins.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first",  5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third",  5);

        Assert.AreEqual("first",  priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third",  priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message
    //                  "The queue is empty."
    // Defect(s) Found: None — the empty-check was already correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message));
        }
    }

    [TestMethod]
    // Scenario: The item with the highest priority is the LAST item added.
    //           Enqueue a(1), b(2), c(10).
    // Expected Result: "c" first, then "b", then "a".
    // Defect(s) Found: Dequeue loop condition was index < Count - 1, which
    //                  skipped the last element entirely. It returned "b"
    //                  instead of "c". Fixed by using index < Count.
    public void TestPriorityQueue_LastItemHighest()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 10);

        Assert.AreEqual("c", priorityQueue.Dequeue());
        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("a", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Highest priority is tied between an early and the very last
    //           item: a(1), b(10), c(10). Must pick b (earlier) then c, then a.
    // Expected Result: "b", "c", "a".
    // Defect(s) Found: Combined bug — the loop skipped the last item (so c was
    //                  never even considered as a candidate), and >= would have
    //                  preferred the later equal-priority item anyway. After the
    //                  fix (> with index < Count) the FIFO winner "b" is chosen.
    public void TestPriorityQueue_TieWithLast()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 10);
        priorityQueue.Enqueue("c", 10);

        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("c", priorityQueue.Dequeue());
        Assert.AreEqual("a", priorityQueue.Dequeue());
    }
}