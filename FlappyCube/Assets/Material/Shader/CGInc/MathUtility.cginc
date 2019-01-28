
/* MathUtility.cginc */

half random(half2 p)
{
	return frac(sin(dot(p, half2(12.9898, 78.233))) * 43758.5453);
}

half oneMinus(half value)
{
	return 1 - value;
}