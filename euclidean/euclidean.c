#include "euclidean.h"

unsigned long make_gcd(const unsigned long a, const unsigned long b) {
	unsigned long remainder = 0L;
	unsigned long value = b;
	unsigned long result = a;
    if (result < value)
        return make_gcd(value, result);
    do {
        remainder = result % value;
        result = value;
        value = remainder;
    } while (remainder != 0);
    return result;
}