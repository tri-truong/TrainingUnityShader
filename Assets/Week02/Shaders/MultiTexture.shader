Shader "Unlit/MultiTexture"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture", 2D) = "white" {}
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
			
			sampler2D _MainTex;
			sampler2D _MaskTex;
			float4 _MainTex_ST;
			float4 _MaskTex_ST;

			struct appdata 
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uvmask : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v) 
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				o.uvmask = v.uv;
				o.uv =  TRANSFORM_TEX(v.uv, _MainTex);
				o.uvmask = TRANSFORM_TEX(v.uv,_MaskTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				 half opacity = tex2D(_MaskTex, i.uvmask).r;
				 col *= opacity;
				return col;
			}
			ENDCG
		}
	}
}
