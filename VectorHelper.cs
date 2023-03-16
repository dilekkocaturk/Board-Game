using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    internal static class VectorHelper
    {
        /*
         * This class is used for bfs algorithm
         */
       
        public static List<T> InitializedList<T>(int size, T value)
        {
            List<T> temp = new List<T>();
            for (int count = 1; count <= size; count++)
            {
                temp.Add(value);
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(new List<T>(innerSize));
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(InitializedList(innerSize, value));
            }

            return temp;
        }
        

    }
}
