package LearnedAlgorithms;

public class LCSubstring {
    public static class Result {
        public int Length;
        public int FirstStartIndex;
        public int SecondStartIndex;
    }

    public Result getResult(String[] firstWord, String[] secondWord) {
        Result result = new Result();
        int[][] table = new int[firstWord.length + 1][secondWord.length + 1];
        for (int i = 0; i < firstWord.length + 1; i++) {
            for (int j = 0; j < secondWord.length + 1; j++) {
                table[i][j] = i == 0 || j == 0 ? 0
                        : firstWord[i - 1] == secondWord[j - 1] ? table[i - 1][j - 1] + 1 : 0;
                if (table[i][j] > result.Length) {
                    result.Length = table[i][j];
                    result.FirstStartIndex = i - result.Length;
                    result.SecondStartIndex = j - result.Length;
                }
            }
        }
        return result;
    }
}