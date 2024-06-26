# Word and Letter Predictor

This project tries to experiment different methods to accomplish word and letter prediction. The main goal is to test and compare, starting from the simplest models, and find an efficient way to predict the next word or letter based on different types of context and algorithms.

Currently, the repo includes scripts and instructions for working with:

* **N-gram Model for Letter Prediction** to predict the most probable next letters in a word given the past `n` letters.

* **Levenshtein Distance for Word Prediction** to predict the most probable words by minimizing the edit distance between the current query and a vocabulary.

*Note: all models are implemented in Python Notebooks, but also have C# API's to be implemented in Unity, as the focus of the project is to use the models for gaze typing in VR and AR.*

## Setting Up the Environment

### 1. General 

To be ready to go, follow these steps:

1. Open a text editor or an IDE
1. Install the required Python packages listed in `requirements.txt`:

        pip install -r requirements.txt

### 2. Letter Prediction - N-gram Model

3. Open the first notebook file [`n-gram-model`](/letter-prediction/letter-n-gram.ipynb) that contains the code utilizing the Ngram model.

4. Make sure to ensure the paths to `/data` and all its subfolders and files in the notebook as needed.

5. All the data files are either in the `/data` folder or can be downloaded from the links provided in the notebook. If you are using the *wikinews* dataset, you will find more details about how to create and pre-process it in the [`/data/scripts/build_corpus.py`](/data/scripts/build_corpus.py) file.

5. Run the notebook cells to execute the N-gram model code and generate json files. All files will be saved in the `/data/out` folder.

7. Different analysis, graphs, and tests can be found in the other notebooks in the same folder to evaluate the model's performance.

**OBS: some notebooks run a separate script to train the n-gram that parallelizes the work. If you want to analyze how it works, you can find it [HERE](/letter-prediction/parallel_generate_probs.py)**

### 3. Word Prediction - Levenshtein Distance

3. Open the notebook file [`word-levenshtein`](/word-prediction/word-levenshtein.ipynb) that contains the code.

4. Make sure to ensure the paths to `/data` and all its subfolders and files in the notebook as needed. This model combines different files to create a large vocabulary.

5. All the data files are either in the `/data` folder or can be downloaded from the links provided in the notebook. If you are using the *wikinews* dataset, you will find more details about how to create and pre-process it in the [`/data/scripts/build_corpus.py`](/data/scripts/build_corpus.py) file.

5. Run the notebook cells to test the model!


****

## C# API Instructions

As soon as you have the probabilities generated for the n-gram model or the vocab for the edit distance model, you can use them in a C# project with the API found in [`/NgramModel`](/letter-prediction/NgramModel/) and [`/LevenshteinModel`](/word-prediction/LevenshteinModel/).Follow these steps:

1. Import the `.cs` file into your C# project (and the `Program.cs`, if you want to test it).

2. Ensure that the correct path to the JSON file is provided when creating an instance of the model. Each model has a constructor that receives the path to the JSON file as a parameter.

3. Build the C# project using the .NET CLI:

         dotnet build

4. Run the `C#` program:

        dotnet run


## Additional Notes

- **Usage**: You can import `NgramModel.cs` or `LevenshteinModel.cs` anywhere in your C# or *Unity* project and create instances by providing the path to the JSON file to the constructor.

---

# References

- [Basic N-gram Model Implementation in Python](https://gist.github.com/radomirbosak/3e8d052788257e7bd1a74380ff0adfdd)
- [Eye typing using word and letter prediction and a fixation algorithm](https://dl.acm.org/doi/abs/10.1145/1344471.1344484)
- [SkiMR: Dwell-free Eye Typing in Mixed Reality](https://ieeexplore.ieee.org/document/10494160/authors#authors)
- [Enhancing Hybrid Eye Typing Interfaces with Word and Letter Prediction: A Comprehensive Evaluation](https://arxiv.org/abs/2312.08731)
- [Speech and Language Processing (Chapter 3: N-gram Models)](https://web.stanford.edu/~jurafsky/slp3/3.pdf)
- [Introduction to Markov Chains](https://brilliant.org/wiki/markov-chains/)
- [An Inflected-Sensitive Letter and Word Prediction System](https://www.researchgate.net/profile/Carlo-Aliprandi/publication/228527942_An_Inflected-Sensitive_Letter_and_Word_Prediction_System/links/54608f210cf2c1a63bfdfaef/An-Inflected-Sensitive-Letter-and-Word-Prediction-System.pdf)
- [Improving Dwell-Based Gaze Typing with Dynamic, Cascading Dwell Times](https://www.microsoft.com/en-us/research/wp-content/uploads/2017/01/cascading_dwell.pdf)


## Data

- [Word Frequency Samples](https://www.wordfrequency.info/samples.asp)
- [100k most frequent words](https://gist.github.com/h3xx/1976236)
- Wikinews dataset links can be found in the [`/data/scripts`](/data/scripts/) folder.
- Wordnet dataset can be downloaded with the `nltk` package. [Wordnet](https://www.nltk.org/howto/wordnet.html)
- [Kaggle Unigram Dataset](https://www.kaggle.com/datasets/rtatman/english-word-frequency)
- [Kaggle Movie Lines Dataset](https://www.kaggle.com/datasets/Cornell-University/movie-dialog-corpus)
- [Grown-ups Movie Scripts](https://www.scripts.com/script/grown_ups_2_9371)


### Other repos

- [Neural Network for Word Prediction](https://github.com/Kyubyong/word_prediction)