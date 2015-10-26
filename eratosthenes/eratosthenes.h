#ifndef PRIME_LIST_H
#define PRIME_LIST_H

#include "common.h"

typedef struct {
    unsigned long* data;
    unsigned long length;
} prime_list_t
;

prime_list_t make_prime_numbers(long greatest_value);

#endif