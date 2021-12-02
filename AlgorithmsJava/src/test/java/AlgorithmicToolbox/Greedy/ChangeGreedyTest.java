package AlgorithmicToolbox.Greedy;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class ChangeGreedyTest {

    @Test
    public void getChange() {
        int money = 525;
        int sum = 0;
        Object[] resultArr = ChangeGreedy.getChange(money);
        for (Object change : resultArr) {
            int changeInt = (int) change;
            sum += changeInt;
        }
        assertEquals(money, sum);
    }
}
