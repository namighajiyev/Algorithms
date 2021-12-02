package AlgorithmicToolbox.DynamicProgramming.LCS;

import java.util.*;

public class LCS2 {

    private static int lcs2(int[] a, int[] b) {
        // Write your code here
        int m = a.length + 1;
        int n = b.length + 1;
        int[][] T1 = new int[m][n];

        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {

                if (a[i - 1] == b[j - 1]) {
                    T1[i][j] = T1[i - 1][j - 1] + 1;
                } else {
                    if (T1[i - 1][j] >= T1[i][j - 1]) {
                        T1[i][j] = T1[i - 1][j];
                    } else {
                        T1[i][j] = T1[i][j - 1];
                    }
                }

            }
        }

        return T1[m - 1][n - 1];
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
