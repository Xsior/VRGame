Shader "Effects/Outline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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

			sampler2D _MainTex;
			sampler2D _CameraDepthTexture;
			float4 _MainTex_TexelSize;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			float sampleDepth(float2 uv)
			{
			    float depth = UNITY_SAMPLE_DEPTH(tex2D(_CameraDepthTexture, uv));
                 depth = pow(Linear01Depth(depth), 2);
                 return depth;
			}
			
			float sobelHorizontal (float2 uv)
			{
			    fixed4 g = fixed4(0, 0, 0, 0);
				
				g += -1 * sampleDepth(uv + float2(-_MainTex_TexelSize.x, _MainTex_TexelSize.y));
				g += -2 * sampleDepth(uv + float2(0, _MainTex_TexelSize.y));
				g += -1 * sampleDepth(uv + float2(_MainTex_TexelSize.x, _MainTex_TexelSize.y));
				
				g += 1 * sampleDepth(uv + float2(-_MainTex_TexelSize.x, -_MainTex_TexelSize.y));
				g += 2 * sampleDepth(uv + float2(0, -_MainTex_TexelSize.y));
				g += 1 * sampleDepth(uv + float2(_MainTex_TexelSize.x, -_MainTex_TexelSize.y));
				
				return g;
			}
			
			float sobelVertical (float2 uv)
			{
			    float g = fixed4(0, 0, 0, 0);
				
				g += -1 * sampleDepth(uv + float2(-_MainTex_TexelSize.x, _MainTex_TexelSize.y));
				g += -2 * sampleDepth(uv + float2(-_MainTex_TexelSize.x, 0));
				g += -1 * sampleDepth(uv + float2(-_MainTex_TexelSize.x, -_MainTex_TexelSize.y));
				
				g += 1 * sampleDepth(uv + float2(_MainTex_TexelSize.x, -_MainTex_TexelSize.y));
				g += 2 * sampleDepth(uv + float2(_MainTex_TexelSize.x, 0));
				g += 1 * sampleDepth(uv + float2(_MainTex_TexelSize.x, _MainTex_TexelSize.y));
				
				return g;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				 float h = sobelHorizontal(i.uv);
				 float v = sobelVertical(i.uv);
				 
				 float a = 1 - sqrt(h * h + v * v);
				 return a;
			}
			ENDCG
		}
		
		Pass
		{
		    Blend DstAlpha OneMinusDstAlpha
		    
		    CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
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
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				 return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
}
