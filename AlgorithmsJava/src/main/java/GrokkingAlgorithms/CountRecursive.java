package GrokkingAlgorithms;

public class CountRecursive {

    public int count(Object[] items, int startIndex) {
        if (items.length == 0) {
            return 0;
        }
        if (startIndex >= items.length) {
            return 0;
        }
        return 1 + count(items, startIndex + 1);
    }

    public int count(Object[] items) {
        return count(items, 0);
    }
}
