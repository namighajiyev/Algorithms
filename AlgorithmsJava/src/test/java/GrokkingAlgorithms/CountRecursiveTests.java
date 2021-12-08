package GrokkingAlgorithms;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class CountRecursiveTests {
    @Test
    public void testCountRecursive() {
        CountRecursive countRecursive = new CountRecursive();
        Object[] items = new Object[] { 1, 2, 3 };
        int result = countRecursive.count(items);
        assertEquals(result, items.length);

        items = new Object[] { 1 };
        result = countRecursive.count(items);
        assertEquals(result, items.length);

        items = new Object[0];
        result = countRecursive.count(items);
        assertEquals(result, items.length);
    }
}
