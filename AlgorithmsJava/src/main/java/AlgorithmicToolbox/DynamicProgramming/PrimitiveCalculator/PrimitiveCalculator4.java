package AlgorithmicToolbox.DynamicProgramming.PrimitiveCalculator;


import java.util.*;
//https://stackoverflow.com/questions/37019999/primitive-calculator-dynamic-approach/37021214

public class PrimitiveCalculator4 {

    static Object T[];

    @SuppressWarnings({ "unchecked" })
    private static List<Integer> optimal_sequence(int n) {
        if (T == null) {
            T = new Object[n + 1];
        }

        if (n <= 0) {
            return new ArrayList<Integer>();
        }
        if (T[n] != null) {
            return (ArrayList<Integer>) T[n];
        }

        int money = n;
        List<Integer> result = null;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j < 3; j++) {
                int coin = 0;
                if (j == 0) {
                    coin = 1;
                } else if (j == 1 && i % 2 == 0) {
                    coin = n / 2;
                } else if (j == 2 && i % 3 == 0) {
                    coin = n / 3;
                }
                if (money >= coin && coin > 0) {
                    List<Integer> sequence = optimal_sequence(n - coin);
                    int resultSize = result == null ? Integer.MAX_VALUE : result.size();
                    if (sequence.size() + 1 < resultSize) {
                        result = sequence;
                        //result.add(n);
                    }
                }
            }
        }
        if (result != null && result.size() > 0) {
            result.add(n);
        }
//         result.add(n);
        Collections.reverse(result);
        T[n] = result;
        return result;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        List<Integer> sequence = optimal_sequence(n);
        System.out.println(sequence.size() - 1);
        for (Integer x : sequence) {
            System.out.print(x + " ");
        }
    }
}
