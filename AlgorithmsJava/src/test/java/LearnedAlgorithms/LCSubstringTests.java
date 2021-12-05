package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class LCSubstringTests {
    @Test
    public void testLCSubstring() {
        LCSubstring lcSubstring = new LCSubstring();
        LCSubstring.Result result = lcSubstring
                .getResult(new String[] { "h", "i", "s", "h" }, new String[] { "f", "i", "s", "h" });
        assertEquals(result.Length, 3);
        assertEquals(result.FirstStartIndex, 1);
        assertEquals(result.SecondStartIndex, 1);
        
        result = lcSubstring
                .getResult(new String[] { "h", "i", "s", "h" }, new String[] { "v", "i", "s", "t","a" });
        assertEquals(result.Length, 2);
        assertEquals(result.FirstStartIndex, 1);
        assertEquals(result.SecondStartIndex, 1);
        
         result = lcSubstring
                .getResult(new String[] { "a", "b", "c", "d","x","y","z" }, new String[] { "x", "y", "z", "a","b","c","d" });
        assertEquals(result.Length, 4);
        assertEquals(result.FirstStartIndex, 0);
        assertEquals(result.SecondStartIndex, 3);
    }
}
