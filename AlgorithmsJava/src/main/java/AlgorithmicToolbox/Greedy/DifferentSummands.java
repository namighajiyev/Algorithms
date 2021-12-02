package AlgorithmicToolbox.Greedy;

import java.util.*;

public class DifferentSummands {
    private static List<Integer> optimalSummands(int n) {
        List<Integer> summands = new ArrayList<Integer>();
        // write your code here
        int i = 1;
        int k = n;
        while (k > 0) {
            if (k <= 2 * i) {
                summands.add(k);
                return summands;
            }
            summands.add(i);
            k -= i;
            i++;
        }
        return summands;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        List<Integer> summands = optimalSummands(n);
        System.out.println(summands.size());
        for (Integer summand : summands) {
            System.out.print(summand + " ");
        }
    }
}
