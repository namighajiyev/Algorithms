package AlgorithmicToolbox.DynamicProgramming.Knapsack;

import java.util.*;

public class Knapsack {

    static int optimalWeight(int W, int[] w) {
        // write you code here
        int result = 0;
        int[][] T = new int[W + 1][w.length + 1];

        for (int i = 1; i <= w.length; i++) {
            for (int j = 1; j <= W; j++) {
                T[j][i] = T[j][i - 1];
                if (w[i - 1] <= j) {
                    int val = T[j - w[i - 1]][i - 1] + w[i - 1];
                    if (T[j][i] < val) {
                        T[j][i] = val;
                    }
                }
            }
        }
        result = T[W][w.length];
        backtrack(T, W, w);
        // for (int i = 0; i < W; i++) {
        //
        // for (int j = 0; j < w.length; j++) {
        // System.out.print(T[i][j] + " ");
        // }
        // System.out.println();
        // }
        return result;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int W, n;
        W = scanner.nextInt();
        n = scanner.nextInt();
        int[] w = new int[n];
        for (int i = 0; i < n; i++) {
            w[i] = scanner.nextInt();
        }
        System.out.println(optimalWeight(W, w));
    }

    private static void backtrack(int[][] T, int W, int[] w) {

        int n = w.length;
        boolean[] items = new boolean[n + 1];
        while (n > 0 && W > 0) {
            if (T[W][n] == T[W][n - 1]) {// not included
                n = n - 1;
            } else {
                // int val = T[j - w[i - 1]][i - 1] + w[i - 1];
                // m = m - T[m][n];
                // m =
                items[n] = true;
                // W = W - w[n];
                W = T[W - w[n - 1]][n - 1];
                n = n - 1;
            }

        }
        System.out.print(Arrays.toString(items));
    }
}
