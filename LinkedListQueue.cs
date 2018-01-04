using System;

namespace LinkedList
{
    public class Node
    {
        public Node Next { get; set; }
        public object Data { get; set; }
        public Node (object o)
        {
            this.Data = o;
        }
    }
    /// <summary>
    /// A queue internally implemented as a linked list of objects
    /// </summary>
    public class LinkedListQueue : Queue
    {
        private int counter = 0;
        private Node head = null;
        private Node tail = null;

        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            Node newNode = new Node(o);
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
            }
            counter++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            if (head == null)
            {
                throw new QueueEmptyException();
            }
            object result = head.Data;
            head = head.Next;
            counter--;
            return result;
        }

        /// <summary>
        /// The number of elements in the queue.
        ///
        ///
        /// </summary>
        public override int Count
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// Note: LinkedListQueues can be grown to arbitrary length, and so can
        /// never fill.
        /// </summary>
        public override bool IsFull
        {
            get
            {
                return false;
            }
        }
    }
}
