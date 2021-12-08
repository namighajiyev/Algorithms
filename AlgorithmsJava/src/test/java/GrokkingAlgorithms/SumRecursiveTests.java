package GrokkingAlgorithms;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class SumRecursiveTests {
    @Test
    public void testSumRecursive() {
        int[] items = new int[] { 1, 2, 3 };
        SumRecursive sumRecursive = new SumRecursive();
        int result = sumRecursive.sum(items);
        assertEquals(result, 6);
        
        items = new int[] { 1 };
        result = sumRecursive.sum(items);
        assertEquals(result, 1);

        items = new int[0];
        result = sumRecursive.sum(items);
        assertEquals(result, 0);

    }
}
