using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _03_2_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////
            /// List<T>, Stack<T>, Queue<T>, HashSet<T>, Dictionary<TKey, TValue>, ArrayList
            /// The important collections >>> List<T>, Dictionary<T> (rarely), ArrayList (rarely)
            /////////////////////////////////////////
            // generic collections (one data type): List class >> List<T>, Stack Class (LIFO, Push(), Pop()), Queue Class (FIFO, Enqueue(), Dequeue())
            // Non generic collections (multiple data types): ArrayList class, HashTable Class

            Employee emp1 = new Employee() { EmployeeNo = 1, FullName = "Abdallah", StartSalary = 1555, };
            Employee emp2 = new Employee() { EmployeeNo = 2, FullName = "Wafaa", StartSalary = 9000, };
            Employee emp3 = new Employee() { EmployeeNo = 3, FullName = "Doaa", StartSalary = 1000, };

            #region List<T> ::: Add, Insert, Remove, CopyTo, GetRange, Sort, Reverse

            /*
             List<T> reserves 4 places im memory (Capacity) for initial Add, then when we add 4 items, it reserves 8, then 16 ans so on...
             so if we have 10 items (more than 8 and less than 16), it reserves 16 places in the memory (Capacity)
             so we can add initial capacity so as not to reserve extra places like, Capacity = 10 instead of 16 when have 9 items
             and when exceeding 10 items, it will multiply the Capacity by 2 to be 20 and so on
             
             using >>>> List<string> names = new List<string>(10);
             */



            // creation
            List<string> countryNames = new List<string>();  // type safety, dynamic length(Count)
            List<string> names = new List<string>() { "Ali", "Essam", "Ahmed" };
            List<int> numbersList = new List<int>();



            // add, insert
            // adding to the end of the List
            // insert in a certain index
            countryNames.Add("Egypt"); // index: 0
            countryNames.Add("Saudi Arabia"); // index: 1
            countryNames.Add("China"); // index: 2
            countryNames.Add("Germany"); // index: 3
            countryNames.Add("USA"); // index: 4
            countryNames.Insert(0, "Japan"); // Japan, Egypt, saudi arabic, china, germany, USA



            // Accessing, Count
            Console.WriteLine(countryNames[0]);
            countryNames[0] = "Korea";
            Console.WriteLine(countryNames[countryNames.Count - 1]); // USA



            // looping
            Console.WriteLine("----------Looping----------");
            for (int i = 0; i < countryNames.Count; i++)
            {
                Console.Write("***" + countryNames[i]); // ***Korea***Egypt***Saudi Arabia***China***Germany***USA
            }
            Console.WriteLine();
            foreach (var country in countryNames) Console.Write("---" + country); // ---Korea---Egypt---Saudi Arabia---China---Germany---USA



            // remove elements
            Console.WriteLine("----------Removing----------");
            countryNames.Remove("Germany"); // remove: removes the first occurence in case of duplication // Japan,Egypt,Saudi Arabia,China,USA
            countryNames.Remove("usa"); // will not work, case  sensitive



            // copying list
            Console.WriteLine("----------Copying List to Array, new List----------");
            string[] countryNamesArray = new string[5];
            countryNames.CopyTo(countryNamesArray, 0); // 2nd param: starting from index 0 >>> // Korea,Egypt,Saudi Arabia,China

            // copying List to new List
            List<string> newCountryNames = new List<string>(countryNames);

            // copy part of the list
            var shortList = countryNames.GetRange(1, 3); // 1st param: start index, 2nd param: num of elements >>> Egypt,Saudi Arabia,China

            // sort, reverse
            countryNames.Sort(); // China,Egypt,Korea,Saudi Arabia
            countryNames.Reverse(); // Saudi Arabia,Korea,Egypt,China



            // Sorting user-defined class
            Console.WriteLine("********* sorting by salary using IComparable<ClassName> *********");
            //Employee emp1 = new Employee() { EmployeeNo = 1, FullName = "Abdallah", StartSalary = 1555, };
            //Employee emp2 = new Employee() { EmployeeNo = 2, FullName = "Wafaa", StartSalary = 9000,};
            //Employee emp3 = new Employee(){ EmployeeNo = 3, FullName = "Doaa", StartSalary = 1000, };
            //List<Employee> emps = new List<Employee>() { emp1, emp2, emp3};
            List<Employee> emps = new List<Employee>();
            emps.Add(emp1);
            emps.Add(emp2);
            emps.Add(emp3);
            emps.Sort(); // sort based on the salary cause we implemented IComparable
            emps.Reverse(); // reverse the sorting

            foreach (Employee emp in emps)
            {
                Console.WriteLine("Salary: " + emp.StartSalary);
            }



            Console.WriteLine("********* sorting by name using IComparer<ClassName> *********");
            SortByName s = new SortByName();
            emps.Sort(s);
            foreach (Employee emp in emps)
            {
                Console.WriteLine("Name: " + emp.FullName);
            }
            #endregion




            #region Stack<T> LIFO
            Stack<int> stackNumbers = new Stack<int>();
            stackNumbers.Push(5);
            stackNumbers.Push(50);
            stackNumbers.Push(500);
            foreach (var item in stackNumbers)
            {
                Console.Write($"{item}, "); // 500, 50, 5
            }
            Console.WriteLine(stackNumbers.Count); // 3
            Console.WriteLine(stackNumbers.Pop()); // get the last item (500) and remove it >> the rest is: 50, 5
            Console.WriteLine(stackNumbers.Peek()); // get the last item (50) but don't remove it >> the rest is 50, 5

            // stack of objects
            Stack<Employee> stackEmployees = new Stack<Employee>();
            stackEmployees.Push(emp1);
            stackEmployees.Push(emp2);
            foreach (var item in stackEmployees)
            {
                Console.WriteLine(item.FullName); // Wafaa, Abdallah
            }
            #endregion




            #region Queu<T>, PriorityQueue<TElement, TPriority> ::: Enquque(), Dequeue()
            Queue<Employee> employeeQueue = new Queue<Employee>();
            employeeQueue.Enqueue(emp1); // Abdallah
            employeeQueue.Enqueue(emp2); // Wafaa
            employeeQueue.Enqueue(emp3); // Doaa
            foreach(var item in employeeQueue) Console.Write($"{item.FullName}, "); // Abdallah, Wafaa, Doaa
            employeeQueue.Dequeue(); // remove the First element ( Abdallah )
            Console.WriteLine(employeeQueue.Peek().FullName); // Wafaa

            // PriorityQueue<TElement, TPriority>
            // element with highest priority (smallest number) will be executed first
            PriorityQueue<Employee, int> empPriorityQueue = new PriorityQueue<Employee, int>();
            empPriorityQueue.Enqueue(emp1, 10); // 3rd in Dequeue
            empPriorityQueue.Enqueue(emp2, 3); // 1st in Dequque
            empPriorityQueue.Enqueue(emp3, 7); // 2nd in Dequeue
            Console.WriteLine(empPriorityQueue.Dequeue().FullName); // Wafaa
            Console.WriteLine(empPriorityQueue.Dequeue().FullName); // Doaa
            Console.WriteLine(empPriorityQueue.Dequeue().FullName); // Abdallah

            #endregion




            #region HashSet<T> ::: Add(), Remove(), Count, IsSubsetOf(), IEquatable interface (HashSet<objects>), Union, UnionWith, Except, ExceptWith, Intersect
            // unique (removes duplication automatically), unordered
            // has-based collection: uses hash function to map each element to a unique index
            // efficient and allow for fast lookup
            HashSet<int> hashSetNumbers = new HashSet<int>();
            hashSetNumbers.Add(20);
            hashSetNumbers.Add(30);
            hashSetNumbers.Add(10);
            hashSetNumbers.Add(40);
            hashSetNumbers.Add(50);
            hashSetNumbers.Add(20); // duplication: will be removed automatically


            Console.WriteLine(hashSetNumbers.Count);
            foreach (var num in hashSetNumbers)
                Console.Write(num + ", "); // 20, 30, 10, 40, 50


            // numbers.Remove(10);


            // remove duplication from an array using HashSet<T>
            string[] citiesArray = new string[] { "Cairo", "Cairo", "Alex", "Alex", "Mans", "Mans" };
            foreach (var item in citiesArray)
                Console.Write(item + ", "); //  Cairo, Cairo, Alex, Alex, Mans, Mans

            HashSet<string> citiesHashSet = new HashSet<string>(citiesArray);
            foreach (var item in citiesHashSet) Console.Write(item + ", "); // Cairo, Alex, Mans


            // IsSubsetOf
            HashSet<string> visitedCities = new HashSet<string>() { "New York", "Cairo", "Mans" };
            HashSet<string> duplicatedCities = new HashSet<string>() { "Cairo", "Alex" };
            Console.WriteLine(visitedCities.IsSubsetOf(citiesHashSet)); // False
            Console.WriteLine(duplicatedCities.IsSubsetOf(citiesHashSet)); // True


            // Union, UnionWith
            var unionHashSet = visitedCities.Union(citiesHashSet); // cities in both HashSets without duplication
            foreach (var item in unionHashSet) Console.Write(item + ", "); // New York, Cairo, Mans, Alex
            //visitedCities.UnionWith(citiesHashSet); // modifies the original(visitedCities) HashSet


            // Difference: Except, ExceptWith(mutates the origian one)
            var NonVisitedCities = citiesHashSet.Except(visitedCities);
            foreach (var item in NonVisitedCities) Console.Write(item + ", "); // Alex


            // Intersect
            var intersectedCities = citiesHashSet.Intersect(visitedCities);
            foreach (var item in intersectedCities) Console.Write(item + ", "); // Cairo, Mans


            // HashSet<T> of objects
            City c1 = new City() { CityId = 1, CityName = "Cairo", Country = "Egypt" };
            City c2 = new City() { CityId = 2, CityName = "London", Country = "England" };
            City c3 = new City() { CityId = 3, CityName = "Rome", Country = "Italy" };
            City c4 = new City() { CityId = 4, CityName = "Madrid", Country = "Spain" };
            City c5 = new City() { CityId = 5, CityName = "Madrid", Country = "Spain222" };
            HashSet<City> citiesClassObjects = new HashSet<City>() { c1, c2, c3, c4, c5 }; // c5 will be removed (duplication) cause we implemented the iEquatable interface below

            Console.WriteLine("---------");
            foreach (var city in citiesClassObjects)
            {
                Console.Write($"{city.Country}, "); // Egypt, England, Italy, Spain
            }
            #endregion




            #region Dictionary<TKey, TValue> ::: Add(), looping, access, Remove(), TryGetValue(), ContainsKey(), ContainsValue()
            // key-value pair data structure
            // (((key can't be null))), must be unique (duplication error)
            Dictionary<string, string> cats = new Dictionary<string, string>();
            Dictionary<string, string> capitalsDictionary = new Dictionary<string, string>()
            {
                { "Russia", "Moscow"},
                { "Italy", "Rome" },
            };

            // Add
            capitalsDictionary.Add("England", "London");
            capitalsDictionary.Add("Spain", "Madrid");

            // looping
            Console.WriteLine("----------------Looping----------------");
            //foreach (KeyValuePair<string, string> capital in capitalsDictionary)
            foreach (var capital in capitalsDictionary)
            {
                Console.WriteLine($"Country: {capital.Key}, Capital: {capital.Value}");
            }

            // new dictionary from existing dictionary
            Console.WriteLine("--------------------------- new dictionary from existing dictionary ----------------");
            var newCapitalDictionary = new Dictionary<string, string>(capitalsDictionary);

            // access and modify
            Console.WriteLine("---------------- access and modify ----------------");
            Console.WriteLine(capitalsDictionary["Spain"]);
            capitalsDictionary["Spain"] = "New Madrid";
            Console.WriteLine(capitalsDictionary["Spain"]);

            // TryGetValue: if the key doesn't exist, it throws error
            Console.WriteLine("---------------- TryGetValue ----------------");
            capitalsDictionary.TryGetValue("USA", out string? searchResult);
            if (searchResult != null)
                Console.WriteLine(searchResult);
            else
                Console.WriteLine("Key not found");

            // Remove
            Console.WriteLine("---------------- Remove ----------------");
            Console.WriteLine(capitalsDictionary.Count);
            capitalsDictionary.Remove("Russia");
            Console.WriteLine(capitalsDictionary.Count);
            //capitals.Clear(); // remove all keys and values

            // ContainsKey, ContainsValue
            Console.WriteLine("---------------- ContainsKey ----------------");
            Console.WriteLine(capitalsDictionary.ContainsKey("Spain"));
            Console.WriteLine(capitalsDictionary.ContainsValue("Prague"));

            // Duplication: not allowed, key must be unique
            Console.WriteLine("---------------- Adding existing item ----------------");
            try
            {
                capitalsDictionary.Add("Spain", "Madrid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            #endregion




            #region ArrayList ::: Add, Remove, RemoveAt, Count, Insert
            // not type safe (different data types in the same list)
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Aly");
            arrayList.Add("Aly");
            arrayList.Add(true);
            arrayList.Add(2.2f);
            arrayList.Remove("Aly"); // remove the first occurence
            arrayList.RemoveAt(0);
            Console.WriteLine($"-----------, {arrayList.Count}"); // 3
            foreach (var i in arrayList) Console.Write($"{i}, "); // Aly, True, 2.2
            arrayList.Insert(2, "Hello"); // at index 2, value
            for (int i = 0; i < arrayList.Count; i++) Console.Write(arrayList[i] + ", "); // Aly, True, Hello, 2.2
            Console.WriteLine(arrayList.Contains("Abdallah Wahbah")); // False
            #endregion
        }
    }
}
