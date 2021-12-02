package AlgorithmicToolbox.DivideAndConquer.Inversions;


import java.util.*;

@SuppressWarnings("unused")
public class Inversions {

    private static long getNumberOfInversions(int[] a, int[] b, int left, int right) {
        long numberOfInversions = 0;
        if (right <= left + 1) {
            return numberOfInversions;
        }
        int ave = (left + right) / 2;
        numberOfInversions += getNumberOfInversions(a, b, left, ave);
        numberOfInversions += getNumberOfInversions(a, b, ave, right);
        numberOfInversions += merge(a, b, left, right, ave);
        //write your code here
        return numberOfInversions;
    }

    private static long merge(int[] a, int[] b, int left, int right, int ave) {

        int k = left;
        int m = ave;
        long invs = 0;
        for (int i = left; i < ave; i++) {
            if (a[k] <= a[m]) {
                b[i] = a[k];
                k++;
            } else {
                b[i] = a[m];
                m++;
                invs++;
            }
        }
        if (m == right) {
            for (int i = m; i < ave; i++) {
                b[i] = a[i];
                invs++;
            }
        } else if (k == ave) {
            for (int i = m; i < right; i++) {
                b[i] = a[i];
                invs++;
            }
        }

        return invs;
    }

    public static void main(String[] args) {
        int[] a = {8, 4, 2, 1};
        int[] b = new int[a.length];
        long result = getNumberOfInversions(a, b, 0, a.length);
        System.out.println(6 == result);
    }
}
