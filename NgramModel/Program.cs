class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "../data/probs.json";
        NgramModel model = new NgramModel(jsonFilePath);
        int N = 4;

        while (true)
        {
            Console.Write("Next Letter: ");
            string curr = Console.ReadLine();

            if (string.IsNullOrEmpty(curr))
            {
                break;
            }

            if (curr == " ")
            {
                model.Text = "%%%";
                continue;
            }

            model.Text += curr;

            // Call the GetTop3Weights method
            Dictionary<string, double> top3 = model.GetTop3Weights(N);

            // Print results
            Console.WriteLine($"\n{model.Text.Substring(3)}\nBest 3 letters are: {string.Join(", ", top3.Keys)}");

        }
    }
}