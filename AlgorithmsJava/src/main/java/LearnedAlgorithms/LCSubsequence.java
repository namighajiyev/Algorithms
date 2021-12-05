package LearnedAlgorithms;

public class LCSubsequence {

    public static class Result {
        public int Length;
        public int[] FirstWordIndexes;
        public int[] SecondWordIndexes;
    }

    public Result getResult(String[] firstWord, String[] secondWord) {
        Result result = new Result();
        int[][] table = new int[firstWord.length + 1][secondWord.length + 1];
        for (int i = 0; i < firstWord.length + 1; i++) {
            for (int j = 0; j < secondWord.length + 1; j++) {
                table[i][j] = i == 0 || j == 0 ? 0
                        : firstWord[i - 1] == secondWord[j - 1] ? table[i - 1][j - 1] + 1
                                : Math.max(table[i][j - 1], table[i - 1][j]);
            }
        }
        result.Length = table[firstWord.length][secondWord.length];
        result.FirstWordIndexes = new int[result.Length];
        result.SecondWordIndexes = new int[result.Length];

        // backtracking
        int i = firstWord.length;
        int j = secondWord.length;
        int lastIndex = result.Length - 1;
        while (i > 0 && j > 0) {
            if (firstWord[i - 1] == secondWord[j - 1]) {
                i--;
                j--;
                result.FirstWordIndexes[lastIndex] = i;
                result.SecondWordIndexes[lastIndex] = j;
                lastIndex--;
            } else if (table[i - 1][j] > table[i][j - 1]) {
                i--;
            } else {
                j--;
            }
        }
        return result;
    }
}