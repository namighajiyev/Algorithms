package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class LCSubsequenceTests {
    @Test
    public void testLCSubsequence() {
        LCSubsequence lcSubsequence = new LCSubsequence();
        String[] firstWord = new String[] { "f", "o", "s", "h" };
        String[] secondWord = new String[] { "f", "i", "s", "h" };
        LCSubsequence.Result result = lcSubsequence
                .getResult(firstWord, secondWord);
        assertEquals(result.Length, 3);
        assertResult(result, firstWord, secondWord);

        firstWord = new String[] { "a", "g", "g", "t", "a", "b" };
        secondWord = new String[] { "g", "x", "t", "x","a","y","b" };
        result = lcSubsequence
                .getResult(firstWord, secondWord);
        assertEquals(result.Length, 4);
        assertResult(result, firstWord, secondWord);
    }

    private void assertResult(LCSubsequence.Result result, String[] firstWord, String[] secondWord) {
        for (int i = 0; i < result.Length; i++) {
            assertEquals(firstWord[result.FirstWordIndexes[i]], secondWord[result.SecondWordIndexes[i]]);
        }
    }
}
