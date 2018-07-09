Shader "Custom/MotionBlur"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		blursize("Blure Size",Range(0,1)) = 0.3
		
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

			
			
			float blursize;
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

			float4 frag (v2f i) : SV_Target
            {
				float samples[10] = {-0.08,-0.05,-0.03,-0.02,-0.01,0.01,0.02,0.03,0.05,0.08};
				float2 dir = float2(0.5,0.5) - i.uv; //Piksel wzgledem srodka
				float4 sum = tex2D(_MainTex,i.uv);
				float2 pos = float2(0.0,0.0);	//Tymczasowa pozycja
				
				for(int n = 0; n<10; n++)
				{
					pos.x = i.uv.x + dir.x * samples[n] * blursize;
					pos.y = i.uv.y + dir.y * samples[n] * blursize;
					if(pos.x > 1.0)
					{
						pos.x = 1.0;
					}
					if(pos.y > 1.0)
					{
						pos.y = 1.0;
					}
					if(pos.x < 0.0)
					{
						pos.x = 0.0;
					}
					if(pos.y < 0.0)
					{
						pos.y = 0.0;
					}
					sum += tex2D(_MainTex,pos);
				}
				sum /= 11.0;
				return sum;
            }
			ENDCG
		}
	}
}
