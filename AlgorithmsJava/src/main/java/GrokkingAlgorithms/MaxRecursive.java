package GrokkingAlgorithms;

public class MaxRecursive {
    public int max(int[] numbers, int startIndex) {
        if (numbers.length == 0 || startIndex >= numbers.length) {
            return Integer.MIN_VALUE;
        }

        if (startIndex == numbers.length - 1) {
            return numbers[startIndex];
        }

        int current = numbers[startIndex];
        int maxRest = startIndex + 1 == numbers.length - 1
                ? numbers[startIndex + 1]
                : max(numbers, startIndex + 1);

        if (current > maxRest) {
            return current;
        } else {
            return maxRest;
        }
    }

    public int max(int[] numbers) {
        return max(numbers, 0);
    }
}
