package AlgorithmicToolbox.DivideAndConquer.Inversions;


import java.util.*;

public class Inversions3 {

    private static long getNumberOfInversions(int[] a, int[] b, int left, int right) {
        long numberOfInversions = 0;
        if (right <= left + 1) {
            return numberOfInversions;
        }
        int ave = (left + right) / 2;
        numberOfInversions += getNumberOfInversions(a, b, left, ave);
        numberOfInversions += getNumberOfInversions(a, b, ave, right);
        //write your code here
        numberOfInversions += merge(a, b, left, ave, right);
        return numberOfInversions;
    }

    static long merge(int[] a, int[] b, int left, int ave, int right) {
        long numberOfInversions = 0;
        int leftIndex = left;
        int rightIndex = ave;
        if (leftIndex == rightIndex) {
            return numberOfInversions;
        }

        //&& leftIndex != rightIndex
        while (leftIndex < ave && rightIndex < right) {
            int current = (leftIndex - left) + (rightIndex - ave);
            if (a[leftIndex] <= a[rightIndex]) {
                b[current] = a[leftIndex];
                leftIndex++;
            } else {
                b[current] = a[rightIndex];
                rightIndex++;
                numberOfInversions++;
            }
        }

        if (leftIndex >= ave) {//if left endeed
            for (int i = rightIndex; i < right; i++) {
                b[i] = a[i];
                //numberOfInversions++;
            }
        } else {
            for (int i = leftIndex + rightIndex; i < right; i++) {
                b[i] = a[i];
            }
        }
        return numberOfInversions;
    }

    public static void main(String[] args) {
        int[] a = {8, 4, 2, 1};
        int[] b = new int[a.length];
        long invs = getNumberOfInversions(a, b, 0, a.length);
        System.out.println(invs);
        System.out.println(Arrays.toString(b));
    }
}
