using System;

namespace MyHeapSort
{
    internal class MyHeapSort
    {
        public static void Main(string[] args)
        {
            int[] array = { 5, -55, 52, -9, 4, 0, 25, 11 };
            HeapSort(array);
            PrintArray(array);
        }

        public static void Heapify(int[] arr, int current, int n)
        {
            int lSon;
            int rSon;
            while (true)
            {
                lSon = current * 2 + 1;
                rSon = current * 2 + 2;
                if (lSon < n && rSon < n && arr[current] <= Math.Max(arr[lSon], arr[rSon]))
                {
                    if (arr[rSon] < arr[lSon])
                    {
                        Swap(arr, current, lSon);
                        current = lSon;
                    }
                    else
                    {
                        Swap(arr, current, rSon);
                        current = rSon;
                    }
                }
                else if (lSon < n && arr[current] <= arr[lSon])
                {
                    Swap(arr, current, lSon);
                    current = lSon;
                }
                else
                    break;
            }
        }

        public static void BuildMaxHeap(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
                Heapify(arr, i, arr.Length - 1);
        }

        public static void HeapSort(int[] arr)
        {
            BuildMaxHeap(arr);
            HeapSort(arr, arr.Length - 1);
        }

        public static void HeapSort(int[] arr, int n)
        {
            if (n == 0) return;
            Swap(arr, 0, n);
            Heapify(arr, 0, n - 1);
            HeapSort(arr, n - 1);
        }

        public static void Swap(int[] arr, int a, int b)
        {
            arr[a] += arr[b];
            arr[b] = arr[a] - arr[b];
            arr[a] -= arr[b];
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }


    }
}