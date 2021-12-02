package AlgorithmicToolbox.DivideAndConquer.Inversions;


import java.util.*;

@SuppressWarnings("unused")
public class Inversions2 {

    private static long getNumberOfInversions(int[] a, int[] b, int left, int right) {
        long numberOfInversions = 0;
        //if single
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
        int fromLeft = left;
        int fromRight = ave;
        int inversions = 0;
        int rightOrLen = Math.min(right, a.length - 1);
        while (fromLeft <= ave && fromRight <= rightOrLen) {
            if (a[fromLeft] <= a[fromRight]) {
                b[fromLeft] = a[fromLeft];
                if (fromLeft != fromRight && a[fromLeft] == a[fromRight]) {
                    inversions++;
                }
                fromLeft++;
            } else {
                b[fromRight] = a[fromRight];
                fromRight++;
                inversions++;
            }
        }

        return inversions;
    }

    public static void main(String[] args) {

        int[] a = {2, 4, 1, 3, 5};
        int[] b = new int[a.length];
        System.out.println(getNumberOfInversions(a, b, 0, a.length));

        //  2, 3, 9, 2, 9    2
        //  1, 2, 3, 4, 5    0
        //  8, 4, 2, 1       6
        //  3, 1, 2          2
        //  2, 4, 1, 3, 5    3
    }
}
