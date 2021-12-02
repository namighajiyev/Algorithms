package AlgorithmicToolbox.DivideAndConquer.Others;

import java.util.*;
import java.io.*;

public class MajorityElement {

    private static int getMajorityElement(int[] a, int left, int right) {
        if (left == right) {
            return -1;
        }
        if (left + 1 == right) {
            return a[left];
        }
        // write your code here
        int avg = (left + right) / 2;
        int majority = getMajorityElement(a, left, avg);
        boolean isMajor = majority == -1 ? false : isMajority(a, left, right, majority);
        if (isMajor) {
            return majority;
        }
        majority = getMajorityElement(a, avg, right);
        isMajor = majority == -1 ? false : isMajority(a, left, right, majority);
        if (isMajor) {
            return majority;
        }

        return -1;
    }

    static boolean isMajority(int[] a, int left, int right, int majority) {
        int count = 0;
        int avg = (right - left) / 2;
        for (int i = left; i < right; i++) {
            if (a[i] == majority) {
                count++;
            }
        }
        return count > avg;
    }

    public static void main(String[] args) {
        FastScanner scanner = new FastScanner(System.in);
        int n = scanner.nextInt();
        int[] a = new int[n];
        for (int i = 0; i < n; i++) {
            a[i] = scanner.nextInt();
        }
        if (getMajorityElement(a, 0, a.length) != -1) {
            System.out.println(1);
        } else {
            System.out.println(0);
        }
    }

    static class FastScanner {

        BufferedReader br;
        StringTokenizer st;

        FastScanner(InputStream stream) {
            try {
                br = new BufferedReader(new InputStreamReader(stream));
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        String next() {
            while (st == null || !st.hasMoreTokens()) {
                try {
                    st = new StringTokenizer(br.readLine());
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            return st.nextToken();
        }

        int nextInt() {
            return Integer.parseInt(next());
        }
    }
}
