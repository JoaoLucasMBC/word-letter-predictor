class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "../../data/out/vocab.json";
        LevenshteinModel model = new LevenshteinModel(jsonFilePath);
        int N = 3;

        while (true)
        {
            Console.Write("Word: ");
            string curr = Console.ReadLine();

            if (string.IsNullOrEmpty(curr))
            {
                break;
            }

            // Call the GetTop3Weights method
            List<string> top3 = model.FindTopKNearestWords(curr, N);

            // Print results
            Console.WriteLine($"Best 3 words are: {string.Join(", ", top3)}\n");

        }
    }
}