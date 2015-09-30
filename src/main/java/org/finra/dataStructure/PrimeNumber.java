package org.finra.dataStructure;

import java.util.LinkedList;
import java.util.List;

/**
 * Created by xiaodongli on 9/30/15.
 */
public class PrimeNumber {
    public static List<Integer> getAllPrimeNumbersWithin(int input){
        List<Integer> primeNumbers = new LinkedList();
        for(int i = 2; i<=input; i++) {
            if(isPrimeNumber(i)){
                primeNumbers.add(i);
            }
        }
        return primeNumbers;
    }

    public static boolean isPrimeNumber(int input) {
        for(int x =2; x<= Math.sqrt(input); x++) {
            if(input % x ==0)
                return false;
        }
        return true;
    }
}
