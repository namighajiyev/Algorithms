package LearnedAlgorithms;

import java.util.ArrayList;

public class KnapsackDP {

    public static class Input {
        public int knapsackWeight;
        public int[] itemsValues;
        public int[] itemsWeights;
        public int itemsCount;
    }

    public class Result {
        public int[][] knapSackTable;
        public int[] selectedItemsIndexes;
    }

    public Result getResult(Input input) {
        // int knapsackWeight, int[] itemValues, int[] itemsWeights, int itemNumber) {
        int knapsackWeight = input.knapsackWeight;
        int[] itemsValues = input.itemsValues;
        int[] itemsWeights = input.itemsWeights;
        int itemsCount = input.itemsCount;

        Result result = new Result();
        int[][] table = new int[itemsCount + 1][knapsackWeight + 1];
        int currentItemIndex = 0;
        int currentWeight = 0;
        for (currentItemIndex = 0; currentItemIndex < itemsCount + 1; currentItemIndex++) {
            for (currentWeight = 0; currentWeight < knapsackWeight + 1; currentWeight++) {
                if (currentItemIndex == 0 || currentWeight == 0) {
                    table[currentItemIndex][currentWeight] = 0;
                } else if (itemsWeights[currentItemIndex - 1] <= currentWeight) {
                    table[currentItemIndex][currentWeight] = Math.max(table[currentItemIndex - 1][currentWeight],
                            itemsValues[currentItemIndex - 1]
                                    + table[currentItemIndex - 1][currentWeight - itemsWeights[currentItemIndex - 1]]);
                } else {
                    table[currentItemIndex][currentWeight] = table[currentItemIndex - 1][currentWeight];
                }
            }
        }
        result.knapSackTable = table;
        // backracking
        ArrayList<Integer> selectedItemsIndexes = new ArrayList<Integer>();
        currentWeight = knapsackWeight;
        for (currentItemIndex = itemsCount; currentItemIndex > 0 && currentWeight > 0; currentItemIndex--) {
            if (table[currentItemIndex][currentWeight] == table[currentItemIndex - 1][currentWeight]) {
                continue;
            } else {
                selectedItemsIndexes.add(currentItemIndex - 1);
                currentWeight -= itemsWeights[currentItemIndex - 1];
            }

        }
        result.selectedItemsIndexes = selectedItemsIndexes.stream().mapToInt(i -> i).toArray();
        return result;
    }

}
