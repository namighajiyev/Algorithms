package utils;

import java.util.Collections;
import java.util.List;
import java.util.Arrays;

public class ShuffleHelper {

    public static void shuffle(String[] arr) {
        List<String> strList = Arrays.asList(arr);
        Collections.shuffle(strList);
    }

}
