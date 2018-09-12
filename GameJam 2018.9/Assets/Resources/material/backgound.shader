Shader "Hidden/backgound"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
		_Offset("OffsetX", Vector) = (0, 0, 0)

		_BlendTex ("BlendTexture", 2D) = "white" {}
		_BlendColor("BlendColor", Color) = (1, 1, 1, 1)
		_BlendOffset("BlendOffset", Vector) = (0, 0, 0)
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
			sampler2D _BlendTex;
			float4 _Color;
			float4 _BlendColor;
			float2 _Offset;
			float2 _BlendOffset;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv + _Offset) * _Color;
				fixed4 blend = tex2D(_BlendTex, i.uv + _BlendOffset) * _BlendColor;
				return (col + blend) / 2;
			}
			ENDCG
		}
	}
}
