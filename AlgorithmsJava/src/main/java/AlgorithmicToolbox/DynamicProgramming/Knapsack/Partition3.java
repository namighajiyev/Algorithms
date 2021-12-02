package AlgorithmicToolbox.DynamicProgramming.Knapsack;

import java.util.*;
import java.io.*;

@SuppressWarnings("unused")
public class Partition3 {

    private static int partition3(int[] A) {
        // write your code here
        int sum = 0;
        for (int i = 0; i < A.length; i++) {
            sum += A[i];
        }
        if (sum % 3 != 0) {
            return 0;
        }
        int W = sum / 3;
        for (int i = 0; i < 3; i++) {
            int[] result = optimalWeight(W, A);
            if (result[0] != W) {
                return 0;
            }
            A = reduce(result, A);

        }
        return 1;
    }

    static int[] optimalWeight(int W, int[] w) {
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
        int[] items = backtrack(T, W, w); // backtrack(T, W, w.length);
        items[0] = result;
        return items;
    }

    private static int[] backtrack(int[][] T, int W, int[] w) {

        int n = w.length;
        int[] items = new int[n + 1];
        while (n > 0 && W > 0) {
            if (T[W][n] == T[W][n - 1]) {// not included
                n = n - 1;
            } else // included
            {
                items[n] = 1;
                W = T[W - w[n - 1]][n - 1];
                n = n - 1;
            }

        }
        return items;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int[] A = new int[n];
        for (int i = 0; i < n; i++) {
            A[i] = scanner.nextInt();
        }
        System.out.println(partition3(A));
    }

    private static int[] reduce(int[] result, int[] A) {
        ArrayList<Integer> reducedList = new ArrayList<Integer>();
        for (int i = 0; i < A.length; i++) {
            if (result[i + 1] == 1) {
                reducedList.add(A[i]);
            }
        }

        int[] arr = new int[reducedList.size()];
        for (int i = 0; i < reducedList.size(); i++) {
            arr[i] = reducedList.get(i);
        }
        return arr;
    }
}
