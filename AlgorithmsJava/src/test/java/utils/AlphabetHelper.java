package utils;

public class AlphabetHelper {
    private static final String englishAlphabetLower = "abcdefghijklmnopqrstuvwxyz";

    public static String[] getEnlishLowerLettersSortedAsc() {
        String[] alphabet = englishAlphabetLower.split("");
        return alphabet;
    }
}
