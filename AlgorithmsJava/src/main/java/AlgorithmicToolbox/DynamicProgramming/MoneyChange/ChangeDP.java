package AlgorithmicToolbox.DynamicProgramming.MoneyChange;

import java.util.Scanner;

public class ChangeDP {

    static int coins[] = { 1, 3, 4 };
    static int T[];

    private static int getChange(int m) {
        // write your code here
        if (T == null) {
            T = new int[m + 1];
        }
        if (m <= 0) {
            return 0;
        }
        if (T[m] > 0) {
            return T[m];
        }

        int result = Integer.MAX_VALUE;
        int money = m;

        for (int i = 1; i <= m; i++) {
            for (int j = 0; j < coins.length; j++) {
                int coin = coins[j];
                if (money >= coin) {
                    int number = 1 + getChange(m - coin);
                    if (number < result) {
                        result = number;
                    }
                }
            }
        }
        if (result != Integer.MAX_VALUE) {
            T[m] = result;
            return result;
        }
        return m / 4;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int m = scanner.nextInt();
        System.out.println(getChange(m));

    }
}
