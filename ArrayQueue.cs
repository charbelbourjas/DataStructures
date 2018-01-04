using System;
using System.Collections.Generic;
using System;

namespace ArrayQueues
{
    /// <summary>
    /// A queue internally implemented as an array
    /// </summary>
    public class ArrayQueue : Queue
    {
        private static int DataSize = 100;
        object[] data = new object[DataSize];
        int head = 0;
        int tail = 0;
        int counter = 0;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            if (counter < DataSize)
            {
                data[tail] = o;
                tail = (tail + 1) % data.Length;
                counter = counter + 1;
            }

            else {
                throw new QueueFullException();
            }

        }

        /// <summary>
        /// Remove object from beginning of queue.
        ///
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
        if (counter > 0)
        {
            object NewItem = data[head];
                head = (head + 1)%data.Length;
                counter = counter - 1;
                return NewItem;
        }
            else
            {
                throw new QueueEmptyException();
            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get {
                return counter;
               }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// </summary>
        public override bool IsFull
        {
            get
            {
                if (counter == DataSize)
                {
                    return true;
                }
                else return false;

            }
        }
    }
}
