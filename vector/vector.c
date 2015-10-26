#include "vector.h"

point_t* make_regular_poligon(int number)
{
	double radian = 360 / number;
    double theta = 2 * M_PI * radian / 360;
	point_t* points;
	if ((number & 1) == 1) {
		points = make_poligon(number, theta, 0.5L, 0.5L, 0.5f);
	} else {
		points = (point_t*)malloc(sizeof(point_t) * (number));
		if (points != NULL) {
			int i = 0;
			for (i = 0; i < number; i++) {
				points[i].x = 1L - cos(theta * i);
				points[i].y = 1L - sin(theta * i);
			}
		}
	}
	return points;
}

point_t* make_poligon(int number, double theta, double cx, double cy, float radius)
{
	point_t* points;
	points = (point_t*)malloc(sizeof(point_t) * (number));
	if (points != NULL) {
		int half = number >> 1;
		int i = 0;
		int k = 0;
		points[i].x = cx;
		points[i].y = cy - radius;
		for (i = 1, k = 1; i < number; i++) {
			if (i <= half) {
				points[i].x = cx + radius * sin(k * theta);
				points[i].y = cy - radius * cos(k * theta);
				k++;
			} else {
				k--;
				points[i].x = cx - radius * sin(k * theta);
				points[i].y = cy - radius * cos(k * theta);
			}
		}
	}
	return points;
}
