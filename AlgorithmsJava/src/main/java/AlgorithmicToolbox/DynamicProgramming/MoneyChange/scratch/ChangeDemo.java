package AlgorithmicToolbox.DynamicProgramming.MoneyChange.scratch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ChangeDemo {

    static int coins[] = { 1, 3, 4 };
    static int[] T;
    static ArrayList<Integer> items;

    private static Object[] getChange(int m) {
        T = new int[m + 1];
        items = new ArrayList<Integer>();
        calculateDP(m);
        backtrack(m);
        return items.toArray();
    }

    private static void backtrack(int m) {
        for (int coin : coins) {
            if (m - coin >= 0 && T[m] - 1 == T[m - coin]) {
                items.add(coin);
                backtrack(m - coin);
                break;
            }
        }
    }

    private static int calculateDP(int m) {
        if (m < 1) {
            return 0;
        }

        if (T[m] > 0) {
            return T[m];
        }
        int result = Integer.MAX_VALUE;
        for (int i = 0; i < coins.length; i++) {
            if (m - coins[i] >= 0) {
                result = Math.min(result, calculateDP(m - coins[i]) + 1);
            }
        }
        T[m] = result;
        return result;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int m = scanner.nextInt();
        Object[] changes = getChange(m);
        System.out.println("Result:");
        System.out.println(changes.length);
        System.out.println(Arrays.toString(changes));
    }
}
