namespace practic7ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository(@"workers.csv");
            //foreach (Worker worker in rep.GetAllWorkers())
            //{
            //    worker.Print();
            //}

            //foreach( Worker worker in rep.GetWorkersBetweenTwoDates(new DateTime(2023, 11, 30), new DateTime(2023, 12, 1, 21, 0, 0)))
            //{
            //    worker.Print();
            //}

            //rep.GetWorkerById(1).Print();

            //rep.AddWorker();

            //rep.DeleteWorker(1);

            //foreach (Worker worker in rep.GetAllWorkers())
            //{
            //    worker.Print();
            //}
        }
    }
}