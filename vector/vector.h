#ifndef VECTOR_H
#define VECTOR_H

#include "common.h"

typedef struct {
    double x;
    double y;
} point_t
;

point_t* make_regular_poligon(int number);
point_t* make_poligon(int number, double theta, double cx, double cy, float radius);

#endif