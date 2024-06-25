import multiprocessing as mp
from collections import defaultdict
import sys
import time
import json

def generate_defaultdict():
    return defaultdict(int)

def generate_probs_chunk(chunk, n):
    num_transitions = defaultdict(generate_defaultdict)
    
    print(f'Processing chunk with {len(chunk)} words')

    for word in chunk:
        word = str(word)
        for idx in range(1, len(word)):
            if idx < n:
                prev = "%" * (n - idx) + word[:idx]  # if there aren't enough letters to form an n-gram, adds % to complete it
            else:
                prev = word[idx - n:idx]  # get the n-gram behind

            nxt = word[idx]  # get the curr letter
            # then updates the count of that n-gram with the following letter by 1
            num_transitions[prev][nxt] += 1

    print(f'Chunk processed with {len(chunk)} words')
    
    return num_transitions

def merge_dicts(dicts):
    merged = defaultdict(generate_defaultdict)
    for d in dicts:
        for prev, nxt_dict in d.items():
            for nxt, count in nxt_dict.items():
                merged[prev][nxt] += count
    return merged

def generate_probs_parallel(n, words):
    num_cores = mp.cpu_count()
    chunk_size = len(words) // num_cores

    print(f'Using {num_cores} cores and chunk size of {chunk_size}')

    # Split words into chunks for parallel processing
    chunks = [words[i:i + chunk_size] for i in range(0, len(words), chunk_size)]

    # Create a pool of workers and distribute the work
    with mp.Pool(num_cores) as pool:
        results = pool.starmap(generate_probs_chunk, [(chunk, n) for chunk in chunks])

    # Merge results from all chunks
    num_transitions = merge_dicts(results)

    # Compute probabilities
    prev_counts = {prev: sum(num_transitions[prev].values()) for prev in num_transitions}
    probs = defaultdict(dict)
    for prev, nxt_dict in num_transitions.items():
        for nxt in nxt_dict:
            probs[prev][nxt] = num_transitions[prev][nxt] / prev_counts[prev]

    # returns relative frequency (prob) and absolute frequency for each n-gram and following word on the corpus
    return probs, prev_counts

if __name__ == '__main__':
    # get the file path from the command line
    file_path = sys.argv[1]
    N = int(sys.argv[2])

    prepro = '--prepro' in sys.argv

    out_path = f'../data/out/'
    if '-o' in sys.argv:
        out_path += sys.argv[sys.argv.index('-o') + 1]
    else:
        out_path += f'test'

    t1 = time.time()

    # read the file
    with open(file_path, 'r', encoding='utf-8') as f:
        data = f.read().splitlines()
 
    if prepro:
        def flatmap(lst):
            return [item for sublist in lst for item in sublist.split()]

        data = list(
                filter(
                    lambda x: x and x.isalpha() and x.islower(),
                    flatmap(data)
                )
            )

    # generate the probabilities
    probs, prev_counts = generate_probs_parallel(N, data)

    t2 = time.time()

    print(f'Elapsed time: {t2 - t1:.2f}s')

    # save the probabilities
    with open(out_path+'_probs.json', 'w') as f:
        json.dump(probs, f)
    
    with open(out_path+'_prefix-count.json', 'w') as f:
        json.dump(prev_counts, f)
