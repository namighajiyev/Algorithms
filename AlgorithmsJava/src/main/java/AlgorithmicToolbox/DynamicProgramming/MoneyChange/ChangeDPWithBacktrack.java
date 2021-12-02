package AlgorithmicToolbox.DynamicProgramming.MoneyChange;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ChangeDPWithBacktrack {

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
        return result;
    }

    private static void backtrack() {
        System.out.println("T : ");
        System.out.println(Arrays.toString(T));
        int m = T.length - 1;
        ArrayList<Integer> items = new ArrayList<Integer>();
        while (m > 0) {
            for (int coin : coins) {
                if (m - coin >= 0 && T[m - coin] == T[m] - 1) {
                    m -= coin;
                    items.add(coin);
                    continue;
                }
            }

        }
        System.out.println("Backtrack result : ");
        System.out.println(Arrays.toString(items.toArray()));
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int m = scanner.nextInt();
        System.out.println(getChange(m));
        backtrack();

    }
}
