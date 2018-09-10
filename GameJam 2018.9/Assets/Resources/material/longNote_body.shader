Shader "Custom/longNote_body"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
		_RimTex ("RimTexture", 2D) = "white" {}
		_RimColor("RimColor", Color) = (1, 1, 1, 1)

		[IntRange] _StencilRef ("Stencil Reference", Range(0, 255)) = 1
		[Enum(CompareFunction)] _StencilComp ("Stencil Compare Function", Float) = 0

		_TileX ("TileX", Float) = 1
		_OffsetX("OffsetX", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Tags
		{ 
			"Queue" = "Transparent"
			"RenderType" = "Fade"
		}

		Stencil
		{
			Ref [_StencilRef]
            Comp [_StencilComp]
		}

		Blend SrcAlpha OneMinusSrcAlpha

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
			sampler2D _RimTex;
			half _TileX;
			half _OffsetX;
			half4 _Color;
			half4 _RimColor;

			fixed4 frag (v2f i) : SV_Target
			{
				i.uv.x *= _TileX;
				i.uv.x += _OffsetX;
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				fixed4 rim = tex2D(_RimTex, i.uv) * _RimColor;
				return col + rim;
			}
			ENDCG
		}
	}
}
