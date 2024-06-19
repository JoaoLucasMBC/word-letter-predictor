using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class LevenshteinModel
{

    private Dictionary<string, int> vocab;
    private int maxFreq;

    public LevenshteinModel(string filePath)
    {
        vocab = new Dictionary<string, int>();
        ReadVocab(filePath);
    }

    public Dictionary<string, int> Vocab
    {
        get { return vocab; }
        set { vocab = value; }
    }

    private void ReadVocab(string filePath)
    {
        try {
            string jsonText = File.ReadAllText(filePath);
            Vocab = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonText);

            if (Vocab == null)
            {
                throw new Exception("Error reading vocab file");
            }

            Console.WriteLine($"Read {Vocab.Count} words from vocab file");

            maxFreq = Vocab.Values.Max();  
        } catch (Exception e) {
            Console.WriteLine($"Error reading vocab file: {e.Message}");
        }
    }

    public List<string> FindTopKNearestWords(string query, int k) {
        var distances = new Dictionary<string, double>();
        foreach (var word in Vocab.Keys) {
            distances[word] = LevenshteinDistance(query, word) - Math.Log(Vocab[word] + 1) / Math.Log(maxFreq + 1); // testing new distance function
        }

        var topWords = GetTopNWords(distances, Math.Min(distances.Count, k));

        return topWords;
    }

    private int LevenshteinDistance(string s, string t) {
        int n = s.Length;
        int m = t.Length;
        int[,] dp = new int[n + 1, m + 1];

        for (int i = 0; i <= n; i++) {
            dp[i, 0] = i;
        }

        for (int j = 0; j <= m; j++) {
            dp[0, j] = j;
        }

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                dp[i, j] = Math.Min(dp[i - 1, j] + 1, Math.Min(dp[i, j - 1] + 1, dp[i - 1, j - 1] + cost));
            }
        }

        return dp[n, m];
    }

    private List<string> GetTopNWords(Dictionary<string, double> distances, int n) {
        return distances.OrderBy(x => x.Value).Take(n).Select(x => x.Key).ToList();
    }

}