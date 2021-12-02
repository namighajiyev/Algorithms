package AlgorithmicToolbox.DynamicProgramming.LCS;

import java.util.*;

public class LCS2RecursiveMinSpace {
    static int[] T;

    private static int lcs2(int[] a, int[] b) {
        T = new int [b.length + 1];
        return lcs2(a, b, a.length, b.length);
    }

    private static int lcs2(int[] a, int[] b, int i, int j) {
        // Write your code here
        if (i <= 0 || j <= 0) {
            return 0;
        }
        if (T[j] > 0) {
            return T[j];
        }

        if (a[i - 1] == b[j - 1]) {
            T[j] = lcs2(a, b, i - 1, j - 1) + 1;
        } else {
            int upper = lcs2(a, b, i - 1, j);
            int lower = lcs2(a, b, i, j - 1);
            if (upper >= lower) {
                T[j] = upper;
            } else {
                T[j] = lower;
            }
        }

        return T[j];
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int[] a = new int[n];
        for (int i = 0; i < n; i++) {
            a[i] = scanner.nextInt();
        }

        int m = scanner.nextInt();
        int[] b = new int[m];
        for (int i = 0; i < m; i++) {
            b[i] = scanner.nextInt();
        }

        System.out.println(lcs2(a, b));
    }
}
