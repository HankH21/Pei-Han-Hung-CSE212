using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with the same priority and remove them from the queue.
    // Expected Result: The item with the highest priority is removed first, followed by
    // the second highest priority, and then the lowest priority: C, B, A
    // Defect(s) Found: The highest-priority item was not detected when it was the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 6);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority and one item with a lower priority.
    // Expected Result: The two highest-priority items are removed first in FIFO order: A, B, C
    // Defect(s) Found: Items with the same highest priority were not removed in FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 4);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 1);


        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to remove an item from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defect(s) found.
    public void TestPriorityQueue_3()
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
                    e.GetType(), e.Message)
            );
        }

    }

}