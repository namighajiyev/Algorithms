package utils;

import static org.junit.Assert.fail;

public class AssertHelper {

    public static void assertNotEqualSequentially(String[] arr1, String[] arr2) {
        if (arr1.length != arr2.length) {
            fail("length of both arrays must be equal");
        }

        for (int i = 0; i < arr1.length; i++) {
            if (arr1[i].compareTo(arr2[i]) != 0) {
                return;
            }
        }
        fail("elements of both array are equal sequentially");
    }

    public static void assertEqualSequentially(String[] arr1, String[] arr2) {
        if (arr1.length != arr2.length) {
            fail("length of both arrays must be equal");
        }

        for (int i = 0; i < arr1.length; i++) {
            if (arr1[i].compareTo(arr2[i]) != 0) {
                fail("elements of both array are not equal sequentially");
            }
        }
    }

}
