package AlgorithmicToolbox.DynamicProgramming.PrimitiveCalculator;

import java.util.*;

public class PrimitiveCalculator {

    private static List<Integer> optimal_sequence(int n) {
        List<Integer> sequence = new ArrayList<>();
        int[] T = new int[n + 1];
        for (int i = 1; i < T.length; i++) {
            T[i] = T[i - 1] + 1;
            if (i % 2 == 0) {
                T[i] = Math.min(1 + T[i / 2], T[i]);
            }
            if (i % 3 == 0) {
                T[i] = Math.min(1 + T[i / 3], T[i]);
            }
        }

        for (int i = n; i > 1;) {
            sequence.add(i);
            if (T[i - 1] == T[i] - 1) {
                i = i - 1;
            } else if (i % 2 == 0 && (T[i / 2] == T[i] - 1)) {
                i = i / 2;
            } else if (i % 3 == 0 && (T[i / 3] == T[i] - 1)) {
                i = i / 3;
            }
        }
        sequence.add(1);
        Collections.reverse(sequence);
        return sequence;
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
