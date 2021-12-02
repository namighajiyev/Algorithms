package AlgorithmicToolbox.DynamicProgramming.LCS;

import java.util.*;

public class LCS1 {

    static int[] T;

    private static int lcs1(int[] a) {
        // Write your code here
        T = new int[a.length];
        return lcs1(a, a.length - 1);
    }

    private static int lcs1(int[] a, int n) {
        if (n < 0) {
            return 0;
        }

        if (T[n] > 0) {
            return T[n];
        }

        int m = n - 1;
        T[n] = 1;
        while (m >= 0) {
            if (a[n] > a[m]) {
                T[n] = Math.max(T[n], lcs1(a, m) + 1);
            }
            m--;
        }

        return T[n];
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int[] a = new int[n];
        for (int i = 0; i < n; i++) {
            a[i] = scanner.nextInt();
        }
        System.out.println(lcs1(a));
    }
}
