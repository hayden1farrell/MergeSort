using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //test data for mergeLists routine
            List<int> TestList1 = new List<int> { 2,4, 7, 8, 9, 12 };
            List<int> TestList2 = new List<int> { 1, 3, 5, 8, 10, 14, 15 };
            List<int> TestList = new List<int> {5,6,12,6,13,18,3,8,1,23,45,11,9,1,34,78,3,6,7};


            List<int> TestResult = new List<int>();

            Console.WriteLine("TEST 1 - TestLists 1 and 2 merged");
            TestResult = MergeLists(TestList1, TestList2);
            
            //show merged list TEST 1
            Console.Write("Merged lists : ");
            foreach (int item in TestResult)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("TEST 2- merge sorts Test List");
            Console.Write("Sorted test list : ");
            TestResult = MergeSort(TestList);

            //show merged list TEST 2
            foreach (int item in TestResult)
            {
                Console.Write(item + ", ");
            }
            Console.ReadLine();

            Console.Write("BIG test list : ");
            int[] bigList = ReadFileData();
            List<int> bigListData = new List<int>(); 
            foreach (int item in bigList)
            {
                bigListData.Add(item);
            }

            TestResult = MergeSort(bigListData);

            //show merged list TEST 2
            foreach (int item in TestResult)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine($"Size: {TestResult.Count}");
            Console.ReadLine();
        }

        static List<int> MergeLists(List<int> L1, List<int> L2)
        {
            List<int> mergedList = new List<int>();
            int indexLeft = 0, indexRight = 0;
            while (indexLeft < L1.Count || indexRight < L2.Count)
            {
                if (indexLeft < L1.Count && indexRight < L2.Count)  
                {  
                    if (L1[indexLeft] <= L2[indexRight])
                    {
                        mergedList.Add(L1[indexLeft]);
                        indexLeft++;
                    }
                    else
                    {
                        mergedList.Add(L2[indexRight]);
                        indexRight++;
                    }
                }
                else if (indexLeft < L1.Count)
                {
                    mergedList.Add(L1[indexLeft]);
                    indexLeft++;
                }
                else if (indexRight < L2.Count)
                {
                    mergedList.Add(L2[indexRight]);
                    indexRight++;
                }  
            }

            return mergedList;
        }

        static List<int> MergeSort(List<int>ListToSort)
        {
            List<int> SortedList = new List<int>();
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            // ACTIVITY 2 - split LISTTOSORT INTO LEFT and RIGHT List
            // find the mid point 
            // copy firt half of list to left list
            //copy second half of list to right list
            int half = ListToSort.Count /2;
            for (int i = 0; i < half; i++)
            {
                leftList.Add(ListToSort[i]);
            }
            for (int i = half; i < ListToSort.Count; i++)
            {
                rightList.Add(ListToSort[i]);
            }
            //ACTIVITY 3  = dont forget the base case! (you cant merge sort lists of 1 or less)
            // Mergesort the left list
            // Mergesort the right list
            if(leftList.Count > 1)
                leftList = MergeSort(leftList);
            if(rightList.Count > 1)
                rightList = MergeSort(rightList);



            //ACTIVITY 4
            //use your mergeLists routine to merge these two sorted lists together
            SortedList = MergeLists(leftList, rightList);
            return SortedList;
        }
        static int[] ReadFileData(){
            string packetData = File.ReadAllText("numbers.txt");
            return packetData.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        }
    }
    
}