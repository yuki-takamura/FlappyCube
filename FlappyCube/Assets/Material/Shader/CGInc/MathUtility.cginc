
/* MathUtility.cginc */

#ifndef _MATH_UTILITY_
#define _MATH_UTILITY_

half random(half2 p)
{
	return frac(sin(dot(p, half2(12.9898, 78.233))) * 43758.5453);
}

half oneMinus(half value)
{
	return 1 - value;
}

#endif //_MATH_UTILITY_