package LearnedAlgorithms;

public class SelectionSort {
    public void sort(String[] items) {
        int i = 0;
        for (i = 0; i < items.length; i++) {
            String min = items[i];
            int minIndex = i;
            for (int j = i + 1; j < items.length; j++) {
                min = items[minIndex];
                String current = items[j];
                if (current.compareTo(min) < 0) {
                    minIndex = j;
                }
            }
            String temp = items[i];
            items[i] = items[minIndex];
            items[minIndex] = temp;
        }
    }
}
