package LearnedAlgorithms;

public class BinarySearchRecursive {
    public int search(String[] items, String toBeFound, int startIndex, int endIndex) {
        if (startIndex > endIndex) {
            return -1;
        }
        int mid = Math.floorDiv(startIndex + endIndex, 2);
        int compareResult = items[mid].compareTo(toBeFound);
        if (compareResult == 0) {
            return mid;
        } else {
            return compareResult > 0
                    ? search(items, toBeFound, startIndex, mid - 1)
                    : search(items, toBeFound, mid + 1, endIndex);
        }
    }

    public int search(String[] items, String toBeFound) {
        return search(items, toBeFound, 0, items.length - 1);
    }
}
