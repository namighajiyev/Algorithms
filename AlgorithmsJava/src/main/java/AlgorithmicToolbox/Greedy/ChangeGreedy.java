package AlgorithmicToolbox.Greedy;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ChangeGreedy {

    static int coins[] = { 1, 3, 4 };

    public static Object[] getChange(int m) {
        int amount = m;
        ArrayList<Integer> changes = new ArrayList<Integer>();
        int currentCoinIndex = coins.length - 1;
        while (amount > 0) {
            if (amount - coins[currentCoinIndex] >= 0) {
                amount -= coins[currentCoinIndex];
                changes.add(coins[currentCoinIndex]);
            } else {
                currentCoinIndex--;
            }
        }
        return changes.toArray();
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int m = scanner.nextInt();
        Object[] changes = getChange(m);
        System.out.println(Arrays.toString(changes));
    }
}
