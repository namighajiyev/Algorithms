package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;

import org.junit.Test;

public class BinarySearchTests {
    @Test
    public void testBinarySearch() {
        String[] items = new String[] { "1", "2", "3", "4", "5" };
        BinarySearch binarySearch = new BinarySearch();
        int result = binarySearch.search(items, "1");
        assertEquals(result, 0);
        result = binarySearch.search(items, "2");
        assertEquals(result, 1);
        result = binarySearch.search(items, "3");
        assertEquals(result, 2);
        result = binarySearch.search(items, "4");
        assertEquals(result, 3);
        result = binarySearch.search(items, "5");
        assertEquals(result, 4);
        result = binarySearch.search(items, "6");
        assertFalse(result >= 0);

        items = new String[] { "1", "2", "3", "4", "5", "6" };
        result = binarySearch.search(items, "1");
        assertEquals(result, 0);
        result = binarySearch.search(items, "2");
        assertEquals(result, 1);
        result = binarySearch.search(items, "3");
        assertEquals(result, 2);
        result = binarySearch.search(items, "4");
        assertEquals(result, 3);
        result = binarySearch.search(items, "5");
        assertEquals(result, 4);
        result = binarySearch.search(items, "6");
        assertEquals(result, 5);
        result = binarySearch.search(items, "7");
        assertFalse(result >= 0);

        items = new String[] { "sometext" };
        result = binarySearch.search(items, "sometext");
        assertEquals(result, 0);

        items = new String[] { "sometext" };
        result = binarySearch.search(items, "dummy");
        assertEquals(result, -1);

        items = new String[0];
        result = binarySearch.search(items, "dummy");
        assertEquals(result, -1);

    }
}
