package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class SelectionSortTests {

    @Test
    public void testSelectionSort() {
        String[] items = new String[] { "i", "t", "e", "m", "s" };
        SelectionSort selectionSort = new SelectionSort();
        selectionSort.sort(items);
        assertEquals(items[0], "e");
        assertEquals(items[1], "i");
        assertEquals(items[2], "m");
        assertEquals(items[3], "s");
        assertEquals(items[4], "t");

        items = new String[0];
        selectionSort.sort(items);

        items = new String[] { "a" };
        selectionSort.sort(items);
        assertEquals(items.length, items.length);
        assertEquals(items[0], "a");

        items = new String[] { "w", "x", "f", "f", "w" };
        selectionSort.sort(items);
        assertEquals(items[0], "f");
        assertEquals(items[1], "f");
        assertEquals(items[2], "w");
        assertEquals(items[3], "w");
        assertEquals(items[4], "x");

    }
}
