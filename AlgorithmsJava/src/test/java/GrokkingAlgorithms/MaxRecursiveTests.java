package GrokkingAlgorithms;

import static org.junit.Assert.assertEquals;
import java.util.Arrays;

import org.junit.Test;

public class MaxRecursiveTests {

    @Test
    public void testMaxRecursive() {
        MaxRecursive maxRecursive = new MaxRecursive();
        int[] numbers = new int[] { 1, 2, 3 };
        int result = maxRecursive.max(numbers);
        assertEquals(result, max(numbers));

        numbers = new int[0];
        result = maxRecursive.max(numbers);
        assertEquals(result, Integer.MIN_VALUE);

        numbers = new int[] { 1 };
        result = maxRecursive.max(numbers);
        assertEquals(result, numbers[0]);
    }

    private int max(int[] numbers) {
        int max = Arrays.stream(numbers).max().getAsInt();
        return max;
    }
}
