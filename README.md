# Word and Letter Predictor - Ngram Model Project

This project includes scripts and instructions for working with an N-gram model in both Python and C# to predict the most probable next letters in a word given the past `n` letters.

## Generating JSON Data

To generate the JSON data for the N-gram model and test it in a simple way, you must run the Python Notebook [`n-gram-model`](/letter-prediction/letter-n-gram.ipynb).

To be ready to go, follow theese steps:

1. Open a text editor or an IDE
1. Install the required Python packages listed in `requirements.txt`:

        pip install -r requirements.txt

3. Open the notebook file that contains the code utilizing the Ngram model.
4. Adjust the file path to `wordFrequency.xlsx`* in the notebook as needed.
5. Run the notebook cells to execute the N-gram model code and generate `probs.json`.

**This file contains the 5k most frequent english words. You can download it **[here](https://www.wordfrequency.info/samples.asp)***

## C# API Instructions

As soon as you have the probabilities generated, you can use the N-gram model in a C# project with the API found in [`/NgramModel`](/letter-prediction/NgramModel/). Follow these steps:

1. Import `NgramModel.cs` into your C# project.
2. Ensure that the correct path to the JSON file is provided when creating an instance of `NgramModel`.
3. Build the C# project using the .NET CLI:

         dotnet build

4. Run the `C#` program:

        dotnet run


## Additional Notes

- **NgramModel Usage**: You can import `NgramModel.cs` anywhere in your C# project and create instances by providing the path to the JSON file to the constructor.

---

# References

- [Word Frequency Samples](https://www.wordfrequency.info/samples.asp)
- [Basic N-gram Model Implementation in Python](https://gist.github.com/radomirbosak/3e8d052788257e7bd1a74380ff0adfdd)
- [Eye typing using word and letter prediction and a fixation algorithm](https://dl.acm.org/doi/abs/10.1145/1344471.1344484)
- [SkiMR: Dwell-free Eye Typing in Mixed Reality](https://ieeexplore.ieee.org/document/10494160/authors#authors)
- [Enhancing Hybrid Eye Typing Interfaces with Word and Letter Prediction: A Comprehensive Evaluation](https://arxiv.org/abs/2312.08731)
- [Speech and Language Processing (Chapter 3: N-gram Models)](https://web.stanford.edu/~jurafsky/slp3/3.pdf)
- [Introduction to Markov Chains](https://brilliant.org/wiki/markov-chains/)

- [An Inflected-Sensitive Letter and Word Prediction System](https://www.researchgate.net/profile/Carlo-Aliprandi/publication/228527942_An_Inflected-Sensitive_Letter_and_Word_Prediction_System/links/54608f210cf2c1a63bfdfaef/An-Inflected-Sensitive-Letter-and-Word-Prediction-System.pdf)
- [Improving Dwell-Based Gaze Typing with Dynamic, Cascading Dwell Times](https://www.microsoft.com/en-us/research/wp-content/uploads/2017/01/cascading_dwell.pdf)

- [100k most frequent words](https://gist.github.com/h3xx/1976236)