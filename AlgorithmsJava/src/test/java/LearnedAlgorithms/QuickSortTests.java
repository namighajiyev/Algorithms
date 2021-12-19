package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;
import org.junit.Test;

import utils.AlphabetHelper;
import utils.ShuffleHelper;
import static utils.AssertHelper.assertNotEqualSequentially;
import static utils.AssertHelper.assertEqualSequentially;

public class QuickSortTests {

    @Test
    public void testSelectionSort() {
        QuickSort quickSort = new QuickSort(new QuickSort.StartIndexPivotSelectionStrategy());
        test(quickSort);
        quickSort = new QuickSort(new QuickSort.EndIndexPivotSelectionStrategy());
        test(quickSort);
        quickSort = new QuickSort(new QuickSort.RandomIndexPivotSelectionStrategy());
        test(quickSort);
    }

    private void test(QuickSort quickSort) {
        String[] items = new String[] { "i", "t", "e", "m", "s" };

        quickSort.sort(items, 0, items.length - 1);
        assertEquals(items[0], "e");
        assertEquals(items[1], "i");
        assertEquals(items[2], "m");
        assertEquals(items[3], "s");
        assertEquals(items[4], "t");

        items = new String[0];
        quickSort.sort(items, 0, items.length - 1);

        items = new String[] { "a" };
        quickSort.sort(items, 0, items.length - 1);
        assertEquals(items.length, items.length);
        assertEquals(items[0], "a");

        items = new String[] { "w", "x", "f", "f", "w" };
        quickSort.sort(items, 0, items.length - 1);
        assertEquals(items[0], "f");
        assertEquals(items[1], "f");
        assertEquals(items[2], "w");
        assertEquals(items[3], "w");
        assertEquals(items[4], "x");

        String[] alphabet = AlphabetHelper.getEnlishLowerLettersSortedAsc();
        String[] shuffledArr = AlphabetHelper.getEnlishLowerLettersSortedAsc();
        assertEqualSequentially(alphabet, shuffledArr);
        ShuffleHelper.shuffle(shuffledArr);
        assertNotEqualSequentially(alphabet, shuffledArr);
        quickSort.sort(shuffledArr, 0, shuffledArr.length - 1);
        assertEqualSequentially(alphabet, shuffledArr);
    }
}
