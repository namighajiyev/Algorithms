package LearnedAlgorithms;

public class BinarySearch {

    public int search(String[] items, String toBeFound) {
        int startIndex = 0;
        int endIndex = items.length - 1;
        while (endIndex >= startIndex) {
            int midIndex = Math.floorDiv(startIndex + endIndex, 2);
            String midItem = items[midIndex];
            int compResult = midItem.compareTo(toBeFound);
            if (compResult == 0) {
                return midIndex;
            }
            if (compResult < 0) {
                startIndex = midIndex + 1;
            }
            if (compResult > 0) {
                endIndex = midIndex - 1;
            }
        }
        return -1;
    }
}
