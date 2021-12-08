package GrokkingAlgorithms;

public class SumRecursive {

    public int sum(int[] numbers) {
        return sum(numbers, 0);
    }

    public int sum(int[] numbers, int startIndex) {
        if (numbers.length == 0) {
            return 0;
        }

        if (numbers.length == 0) {
            return numbers[0];
        }
        if (startIndex >= numbers.length) {
            return 0;
        }
        return numbers[startIndex] + sum(numbers, startIndex + 1);
    }
}
