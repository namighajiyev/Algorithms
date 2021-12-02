package AlgorithmicToolbox.DynamicProgramming.EditDistance;

import java.util.*;

class EditDistance {

    public static int editDistance(String s, String t) {
        // write your code here
        int n = s.length() + 1;
        int m = t.length() + 1;
        int T[][] = new int[n][m];
        for (int i = 0; i < n; i++) {
            T[i][0] = i;
        }
        for (int j = 0; j < m; j++) {
            T[0][j] = j;
        }

        for (int i = 1; i < n; i++) {
            for (int j = 1; j < m; j++) {
                int diff = s.charAt(i - 1) == t.charAt(j - 1) ? 0 : 1;
                T[i][j] = Math.min(T[i - 1][j] + 1, Math.min(T[i][j - 1] + 1, T[i - 1][j - 1] + diff));
            }
        }

        return T[n - 1][m - 1];
    }

    public static void main(String args[]) {
        Scanner scan = new Scanner(System.in);

        String s = scan.next();
        String t = scan.next();

        System.out.println(editDistance(s, t));
    }

}
