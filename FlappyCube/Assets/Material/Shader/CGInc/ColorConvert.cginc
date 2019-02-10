
/* ColorConvert.cginc */

#ifndef _COLOR_CONVERT_
#define _COLOR_CONVERT_

#include "MathUtility.cginc"

#define _H hsv.x
#define _S hsv.y
#define _V hsv.z

half3 HSV2RGB(half3 hsv)
{
	half r = _V;
	half g = _V;
	half b = _V;

	//_H *= 6.0f;
	int i = fmod(floor(_H / 60.0f), 6.0f);
	half f = _H / 60.0f - i;

	//_S�̕␔
	half comS = oneMinus(_S);
	//f�̕␔
	half comF = oneMinus(f);

	if (i == 0)
	{
		g *= oneMinus(_S * comF);
		b *= comS;
	}
	else if (i == 1)
	{
		r *= oneMinus(_S * f);
		b *= comS;
	}
	else if (i == 2)
	{
		r *= comS;
		b *= oneMinus(_S * comF);
	}
	else if (i == 3)
	{
		r *= comS;
		g *= oneMinus(_S * f);
	}
	else if (i == 4)
	{
		r *= oneMinus(_S * comF);
		g *= comS;
	}
	else if (i == 5)
	{
		g *= comS;
		b *= oneMinus(_S * f);
	}

	return half3(r, g, b);
}

#endif //_COLOR_CONVERT_