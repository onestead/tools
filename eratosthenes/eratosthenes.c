#include "eratosthenes.h"

prime_list_t make_prime_numbers(const unsigned long greater_than_value) {
	const unsigned long TRUE = 1L, FALSE = 0L;
	unsigned long i = 0L, n = 0L, squareroot = 0L;
	unsigned long* numbers;
	prime_list_t result;
	
	if (greater_than_value <= 2)
		return result;

	numbers = (unsigned long*)malloc(sizeof(unsigned long) * (greater_than_value));
	if (numbers != NULL) {
		for (i = 0; i < greater_than_value; i++)
			*(numbers + i) = TRUE;
		{/** eratosthenes' sieve **/
			squareroot = (long)sqrt((double)(greater_than_value - 1));
			for (i = 2; i <= squareroot; i++) {
				int number = i * 2;
				for (; number < greater_than_value; number += i)
					numbers[number] = FALSE;
			}
		}
		{/** set array length **/
			result.length = 0L;
			for (i = 2; i < greater_than_value; i++)
				if (numbers[i] == TRUE)
					result.length++;
		}
		{/** set array data **/
			result.data = (unsigned long*)malloc(sizeof(unsigned long) * result.length);
			if (result.data != NULL) {
				for (i = 0; i < result.length; i++)
					*(result.data + i) = 0L;
				for (n = 0,i = 2; i < greater_than_value && n < result.length; i++)
					if (numbers[i] == TRUE)
						*(result.data + n++) = i;
			} else {
				result.length = 0L;
				result.data = NULL;
			}
		}
		free(numbers);
	} else {
		result.length = 0L;
		result.data = NULL;
	}
	return result;
}