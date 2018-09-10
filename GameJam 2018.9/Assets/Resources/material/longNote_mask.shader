Shader "Custom/longNote_mask"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		[IntRange] _StencilRef ("Stencil Reference", Range(0, 255)) = 1
		[Enum(CompareFunction)] _StencilComp ("Stencil Compare Function", Float) = 0
	}
	SubShader
	{
		Tags { "Queue" = "Geometry-1" }
		ColorMask 0
		Cull Off ZWrite Off ZTest Always
		Stencil
		{
			Ref [_StencilRef]
            Comp [_StencilComp]
			Pass replace
		}

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

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
	}
}
