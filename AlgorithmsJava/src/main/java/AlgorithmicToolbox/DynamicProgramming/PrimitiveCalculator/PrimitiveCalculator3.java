package AlgorithmicToolbox.DynamicProgramming.PrimitiveCalculator;

import java.util.*;

public class PrimitiveCalculator3 {

    static Object T[];

    @SuppressWarnings({ "unchecked" })
    private static List<Integer> optimal_sequence(int n) {
        if (T == null) {
            T = new Object[n + 1];
        }

        if (T[n] != null) {
            return new ArrayList<Integer>((ArrayList<Integer>) T[n]);
        }

        List<Integer> sequence = new ArrayList<Integer>();
        if (n == 0) {
            return sequence;
        }

        List<Integer> sequence1 = optimal_sequence(n - 1);
        List<Integer> sequence2 = n % 2 == 0 ? optimal_sequence(n / 2) : sequence1;
        List<Integer> sequence3 = n % 3 == 0 ? optimal_sequence(n / 3) : sequence1;

        if (sequence1.size() <= Math.min(sequence2.size(), sequence3.size())) {
            sequence = sequence1;
        } else if (sequence2.size() <= Math.min(sequence1.size(), sequence3.size())) {
            sequence = sequence2;
        } else if (sequence3.size() <= Math.min(sequence1.size(), sequence2.size())) {
            sequence = sequence3;
        }
        sequence.add(n);
        Collections.reverse(sequence);
        T[n] = new ArrayList<Integer>(sequence);
        return (ArrayList<Integer>) T[n];
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
