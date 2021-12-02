package AlgorithmicToolbox.DynamicProgramming.LCS;

import java.util.*;

public class LCS2RecursiveWithBacktrack {
    static int[][] T;

    private static int lcs2(int[] a, int[] b) {
        T = new int[a.length + 1][b.length + 1];
        return lcs2(a, b, a.length, b.length);
    }

    private static int lcs2(int[] a, int[] b, int i, int j) {
        // Write your code here
        if (i <= 0 || j <= 0) {
            return 0;
        }
        if (T[i][j] > 0) {
            return T[i][j];
        }

        if (a[i - 1] == b[j - 1]) {
            T[i][j] = lcs2(a, b, i - 1, j - 1) + 1;
        } else {
            int upper = lcs2(a, b, i - 1, j);
            int lower = lcs2(a, b, i, j - 1);
            if (upper >= lower) {
                T[i][j] = upper;
            } else {
                T[i][j] = lower;
            }
        }

        return T[i][j];
    }

    static void backtrack(int[] a, int[] b, int i, int j) {
        if (i == 0 || j == 0) {
            return;
        }

        if (a[i - 1] == b[j - 1]) {
            backtrack(a, b, i - 1, j - 1);
            System.out.print(a[i - 1] + " ");
        } else if (T[i - 1][j] >= T[i][j - 1]) {
            backtrack(a, b, i - 1, j);
        } else {
            backtrack(a, b, i, j - 1);
        }
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
        System.out.println("backtracking .....");
        backtrack(a, b, a.length, b.length);
    }
}
