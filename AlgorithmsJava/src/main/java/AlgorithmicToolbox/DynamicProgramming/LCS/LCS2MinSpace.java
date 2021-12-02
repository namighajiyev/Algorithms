package AlgorithmicToolbox.DynamicProgramming.LCS;

import java.util.*;

public class LCS2MinSpace {

    private static int lcs2(int[] a, int[] b) {
        // Write your code here
        int m = a.length + 1;
        int n = b.length + 1;
        int[] T = new int[n];

        for (int i = 1; i < m; i++) {
            int prev = 0;
            for (int j = 1; j < n; j++) {
                int temp = T[j];
                if (a[i - 1] == b[j - 1]) {
                    T[j] = prev + 1;
                } else if (T[j] < T[j - 1]) {
                    T[j] = T[j - 1];
                }
                prev = temp;
            }
        }
        return T[n - 1];
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
