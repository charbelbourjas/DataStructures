using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSorting
{
    public class Sorting
    {
        private static System.Diagnostics.Stopwatch sortingWatch = new System.Diagnostics.Stopwatch();
        private static long count = 0;
        public static float currentTime, minTime = 9999, maxTime, avgTime;

        public static string getCurrentTime()
        {
            return Sorting.currentTime.ToString("n6") + "ms";
        }

        public static string getMinTime()
        {
            return Sorting.minTime.ToString("n6") + "ms";
        }

        public static string getMaxTime()
        {
            return Sorting.maxTime.ToString("n6") + "ms";
        }

        public static string getAvgTime()
        {
            return Sorting.avgTime.ToString("n6") + "ms";
        }

        public static void DepthSort(Particle[] particles)
        {
            sortingWatch.Restart();

            // You can select which sorting algorithm you'll be using by uncommenting one of the two function calls below
            // You can visually test both of your algorithms this way

            QuicksortDepthSort(particles);
            //InsertionDepthSort(particles);

            sortingWatch.Stop();
            UpdateTimes((float)sortingWatch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency);
        }

        public static void InsertionDepthSort(Particle[] particles)
        {
            for (int i = 0; i < particles.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (particles[j - 1].depth > particles[j].depth)
                    {
                        Particle temp = particles[j - 1];
                        particles[j - 1] = particles[j];
                        particles[j] = temp;
                    }
                }
            }
        }


        public static void QuicksortDepthSort(Particle[] particles)
        {
            Quicksort(particles, 0, particles.Length - 1);
        }

        public static void Quicksort(Particle[] p, int start, int end)
        {
            if (end > start)
            {
                int Index1 = (start + end) / 2;
                int Index2 = Partition(p, Index1, start, end);
                Quicksort(p, start, Index2 - 1);
                Quicksort(p, Index2 + 1, end);
            }
        }

        public static int Partition(Particle[] p, int index, int start, int end)
        {
            float depth = p[index].depth;

            Swap(p, index, end);

            int next1 = start;
            for (int i = start; i < end; i++)
            {
                if (p[i].depth <= depth)
                {
                    Swap(p, i, next1);
                    next1++;
                }
            }

            Swap(p, next1, end);
            return next1;
        }

        public static void Swap(object[] arr, int obj1, int obj2)
        {
            object temp = arr[obj1];
            arr[obj1] = arr[obj2];
            arr[obj2] = temp;
        }
    




    public static void UpdateTimes(float time)
        {
            time *= 1000;
            count++;
            currentTime = time;
            minTime = minTime < time ? minTime : time;
            maxTime = maxTime > time ? maxTime : time;
            avgTime = avgTime == 0 ? time : ((avgTime * (count - 1)) + time) / count;
        }
    }
}
