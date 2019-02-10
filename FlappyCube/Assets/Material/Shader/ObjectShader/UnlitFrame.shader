Shader "Unlit/UnlitFrame"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_EdgeThickness("Edge Thickness", Range(0, 1)) = 0.1

		_Hue("Hue", Range(0.0, 359.9)) = 0.0
		_Saturation("Saturation", Range(0, 1)) = 1
		_Value("Value", Range(0, 1)) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

			#define PI 3.14159265359
            #include "UnityCG.cginc"
			#include "../CGInc/ColorConvert.cginc"

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

            sampler2D _MainTex;
            float4 _MainTex_ST;

			half _EdgeThickness;

			half _Hue;
			half _Saturation;
			half _Value;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				/*
				if (i.uv.x >  _EdgeThickness 
				 && i.uv.x <= 1 - _EdgeThickness 
				 && i.uv.y >  _EdgeThickness 
				 && i.uv.y <= 1 - _EdgeThickness)
					discard;*/

				//half3 hsvCol = HSV2RGB(half3(_Hue, _Saturation, _Value));
				
				float2 st = 0.5 - i.uv;
				float a = atan2(st.y, st.x);
				a = (a + PI) / (PI * 2) * 360;
				half3 hsvCol = HSV2RGB(half3(_Hue, _Saturation, _Value));
                return half4(hsvCol, col.a);
            }
            ENDCG
        }
    }
}
