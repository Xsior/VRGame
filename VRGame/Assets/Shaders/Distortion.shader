
Shader "Effects/Heat haze" 
{
    Properties {
        _BumpAmt  ("Distortion", range (0,128)) = 10
        _BumpMap ("Normalmap", 2D) = "bump" {}
    }

	SubShader {
	
		Tags { "Queue"="Transparent" "RenderType"="Opaque" }

		GrabPass 
		{
			Name "BASE"
			Tags { "LightMode" = "Always" }
		}
		
	    Pass 
	    {
			Name "BASE"
			Tags { "LightMode" = "Always" }
			
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata_t 
            {
                float4 vertex : POSITION;
                float2 texcoord: TEXCOORD0;
            };
            
            struct v2f 
            {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
                float2 uvbump : TEXCOORD1;
            };
            
            float _BumpAmt;
            float4 _BumpMap_ST;
            float4 _MainTex_ST;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uvgrab = ComputeGrabScreenPos(o.vertex);
                o.uvbump = TRANSFORM_TEX( v.texcoord, _BumpMap );
                return o;
            }
            
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            sampler2D _BumpMap;
            
            half4 frag (v2f i) : SV_Target
            {
                //Transforms screen space coordinates for single pass stereo rendering in VR
                #if UNITY_SINGLE_PASS_STEREO
                i.uvgrab.xy = TransformStereoScreenSpaceTex(i.uvgrab.xy, i.uvgrab.w);
                #endif
            
                // calculate perturbed coordinates
                half2 bump = UnpackNormal(tex2D( _BumpMap, i.uvbump )).rg;
                float2 offset = bump * _BumpAmt * _GrabTexture_TexelSize.xy;
                i.uvgrab.xy = offset + i.uvgrab.xy;
            
                half4 col = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(i.uvgrab));
                return col;
            }
            ENDCG
		}
	}
}
