using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuickStartToTDD.Calculators.Impl;

namespace QuickStartToTDD.ComplexObjects
{
    public class InsaneSort<T> : IEnumerable<T>
    {
        private readonly Dictionary<T, double> itemWeights;
        private List<T> list = new List<T>();

        public InsaneSort(IEnumerable<T> elements)
        {
            list.AddRange(elements);
            CalculateWeights();
            try
            {
                Sort(itemWeights);
            }
            catch (ArgumentException)
            {
                // retain the list without sorting
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Sort(Dictionary<T, double> weights)
        {
            if (weights == null)
            {
                throw new ArgumentNullException("list");
            }
            if (!weights.Any())
            {
                throw new ArgumentException("The list must be not empty", "list");
            }

            double[] values = weights.Values.ToArray();
            T[] keys = weights.Keys.ToArray();
            Array.Sort(values, keys);
            list = new List<T>(keys);
        }

        private void CalculateWeights()
        {
            double max = double.MinValue;
            foreach (T item in list)
            {
                CalculateItemWeight(item);
                max = Math.Max(max, itemWeights[item]);
            }
            foreach (KeyValuePair<T, double> pair in itemWeights)
            {
                itemWeights[pair.Key] = Math.Round(itemWeights[pair.Key]/max, 2);
            }
        }

        private void CalculateItemWeight(T item)
        {
            CalcFibonacci fib = new CalcFibonacci();
            itemWeights.Add(item, fib.Calc(item.GetHashCode()));
        }
    }
}