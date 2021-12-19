package LearnedAlgorithms;

public class QuickSort {

    public interface IPivotSelectionStrategy {
        int getPivotIndex(String[] items, int startIndex, int endIndex);
    }

    public static class StartIndexPivotSelectionStrategy implements IPivotSelectionStrategy {
        public int getPivotIndex(String[] items, int startIndex, int endIndex) {
            return startIndex;
        }
    }

    public static class EndIndexPivotSelectionStrategy implements IPivotSelectionStrategy {
        public int getPivotIndex(String[] items, int startIndex, int endIndex) {
            return endIndex;
        }
    }

    public static class RandomIndexPivotSelectionStrategy implements IPivotSelectionStrategy {
        public int getPivotIndex(String[] items, int startIndex, int endIndex) {
            return new java.util.Random().nextInt(endIndex - startIndex) + startIndex;
        }
    }

    private IPivotSelectionStrategy pivotSelectionStrategy;

    public QuickSort() {
        this.pivotSelectionStrategy = new StartIndexPivotSelectionStrategy();
    }

    public QuickSort(IPivotSelectionStrategy pivotSelectionStrategy) {
        this.pivotSelectionStrategy = pivotSelectionStrategy;
    }

    public void sort(String[] items, int startIndex, int endIndex) {
        if (startIndex >= endIndex) {
            return;
        }

        int paritionIndex = partition(items, startIndex, endIndex);
        sort(items, startIndex, paritionIndex - 1);
        sort(items, paritionIndex + 1, endIndex);
    }

    private int partition(String[] items, int startIndex, int endIndex) {
        int pivotIndex = pivotSelectionStrategy.getPivotIndex(items, startIndex, endIndex);
        String pivot = items[pivotIndex];
        swap(items, pivotIndex, endIndex);
        int leftIndex = startIndex - 1;
        for (int i = startIndex; i < endIndex; i++) {
            if (items[i].compareTo(pivot) < 0) {
                leftIndex++;
                swap(items, i, leftIndex);
            }
        }
        leftIndex++;
        swap(items, leftIndex, endIndex);
        return leftIndex;
    }

    private void swap(String[] items, int xIndex, int yIndex) {
        if (xIndex == yIndex) {
            return;
        }
        String tmp = items[xIndex];
        items[xIndex] = items[yIndex];
        items[yIndex] = tmp;
    }

}