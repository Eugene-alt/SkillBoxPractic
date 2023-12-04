namespace practic8ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1 (лист)
            //MyList myList = new MyList(10, 0, 100);

            //myList.Print();
            //Console.WriteLine();

            //myList.MyCompareSort(50, 25);
            //myList.Print();
            #endregion

            #region Задание 2 (словарь)
            //MyDict myDict = new MyDict();
            #endregion

            #region Задание 3 (множество)
            //MyHashSet myHashSet = new MyHashSet();
            #endregion

            #region Задание 4 (XML)
            RepositoryXml repositoryXml = new RepositoryXml(@"practic8.xml");
            #endregion
        }
    }
}