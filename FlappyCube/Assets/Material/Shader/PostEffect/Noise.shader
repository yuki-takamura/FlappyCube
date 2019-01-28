Shader "PostEffect/Noise"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
			#include "../CGInc/MathUtility.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
				half2 st = i.uv - 0.5;
				st *= 1.0 + 8 * pow(length(i.uv - 0.5), 2);
				st += 0.5;

				half4 col = 1;
				col.r = random(i.uv *     (sin(_Time.y)));
				col.g = random(i.uv * (sin(_Time.y * 2)));
				col.b = random(i.uv * (sin(_Time.y * 3)));
				half d = oneMinus(distance(0.5, i.uv));
				half strip = sin(st.y * 400 + _Time.y * 3) * oneMinus(d);
				col *= d;
				col *= oneMinus(strip);

                return col * 0.75;
            }
            ENDCG
        }
    }
}
