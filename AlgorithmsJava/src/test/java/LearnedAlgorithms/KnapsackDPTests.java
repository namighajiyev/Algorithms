package LearnedAlgorithms;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertArrayEquals;
import org.junit.Test;

/**
 * KnapsackDPTests
 */
public class KnapsackDPTests {

    @Test
    public void testKnapsack() {
        KnapsackDP knapsackDP = new KnapsackDP();
        KnapsackDP.Input input = new KnapsackDP.Input() {
            {
                knapsackWeight = 4;
                itemsValues = new int[] { 1500, 3000, 2000 };
                itemsWeights = new int[] { 1, 4, 3 };
                itemsCount = 3;
            }
        };
        KnapsackDP.Result result = knapsackDP
                .getResult(input);
        int maxValue = result.knapSackTable[3][4];
        assertEquals(maxValue, 3500);
        assertArrayEquals(result.selectedItemsIndexes, new int[] { 2, 0 });

        input = new KnapsackDP.Input() {
            {
                knapsackWeight = 6;
                itemsValues = new int[] { 10, 3, 9, 5, 6 };
                itemsWeights = new int[] { 3, 1, 2, 2, 1 };
                itemsCount = 5;
            }
        };
        result = knapsackDP.getResult(input);
        maxValue = result.knapSackTable[5][6];
        assertEquals(maxValue, 25);
        assertArrayEquals(result.selectedItemsIndexes, new int[] {4, 2, 0 });

    }
}