
using System;

namespace Deque
{
    /// <summary>
    /// A double-ended queue
    /// Implement this as a doubly-linked list
    /// </summary>
    public class Deque
    {
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>


        public class node
        {
            public node prev = null;
            public node next = null;
            public object data = null;
        }


        private node head = new node()
        { prev = null, next = null, data = null };
        private node tail = new node() { prev = null, next = null, data = null };
        private node placeholder;
        int counter = 0;


        public void AddFront(object o)
        {
            node new_dllnode = new node();
            new_dllnode.data = o;
            if (counter == 0)
            {
                head = new_dllnode;
                tail = new_dllnode;
            }
            else
            {
                head.prev = new_dllnode;
                new_dllnode.next = head;
                head = new_dllnode;
            }
            counter++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveFront()
        {
            if (counter == 0)
            {
                throw new QueueEmptyException();
            }
            else if (counter == 1)
            {
                object front = head.data;
                head = placeholder;
                tail = placeholder;
                counter--;
                return front;
            }
            else
            {
                object front = head.data;
                head = head.next;
                head.prev = null;
                counter--;
                return front;
            }
        }

        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>

        public void AddEnd(object o)
        {
            node newnode2 = new node();
            newnode2.data = o;
            if (counter == 0)
            {
                tail = newnode2;
                head = tail;
            }
            else
            {
                tail.next = newnode2;
                newnode2.prev = tail;
                tail = tail.next;
            }
            counter++;
        }


        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveEnd()
        {
            if (counter == 0)
            {
                throw new QueueEmptyException();
            }
            else if (counter == 1)
            {
                object front = head.data;
                head = placeholder;
                tail = placeholder;
                counter--;
                return front;
            }
            else
            {
                node current = tail;
                object end = current.data;
                tail = tail.prev;
                tail.next = null;
                counter--;
                return end;
            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// True if the queue is empty and dequeuing is forbidden.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return counter == 0;

            }
        }
    }
}
