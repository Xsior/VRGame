
Shader "Effects/Toon shading (advanced)" 
{
   Properties 
   {
      _MainTex ("Main texture", 2D) = "white" {}
      _Color ("Diffuse Color", Color) = (1,1,1,1) 
      _ShadingMap ("ShadingMap", 2D) = "white" {}
      
      [Space]
      
      _OutlineColor ("Outline Color", Color) = (0,0,0,1)
      _OutlineThickness ("Outline thickness", Range(0, 0.5)) = 0.1

      [Space]

      _SpecColor ("Specular Color", Color) = (1,1,1,1) 
      _Shininess ("Shininess", Float) = 10
   }
   SubShader 
   {
      Pass
      {
            Cull Front
            Color[_OutlineColor]
      }
      
   
      Pass
       {      
         Tags { "LightMode" = "ForwardBase" } 
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
         uniform float4 _LightColor0; 
 
         uniform float4 _Color; 
         uniform float4 _OutlineColor;
         uniform float _OutlineThickness;
         uniform float4 _SpecColor; 
         uniform float _Shininess;
         
         sampler2D _ShadingMap;
         sampler2D _MainTex;
         half4 _MainTex_ST;
 
         struct vertexInput
         {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float2 uv : TEXCOORD0;
         };
         
         struct vertexOutput 
         {
            float4 pos : SV_POSITION;
            float4 posWorld : TEXCOORD0;
            float3 normalDir : TEXCOORD1;
            float2 uv : TEXCOORD2;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject; 
            
            input.vertex = input.vertex - _OutlineThickness * normalize(float4(input.normal, 0));
 
            output.posWorld = mul(modelMatrix, input.vertex);
            output.normalDir = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            output.pos = UnityObjectToClipPos(input.vertex);
            output.uv = TRANSFORM_TEX ( input.uv, _MainTex);
            
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
            float3 normalDirection = normalize(input.normalDir);
 
            float3 viewDirection = normalize(_WorldSpaceCameraPos - input.posWorld.xyz);
            float3 lightDirection;
            float attenuation;
 
            if (_WorldSpaceLightPos0.w == 0) { // directional light?
               attenuation = 1.0; // no attenuation
               lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            } 
            else { // point or spot light
               float3 vertexToLightSource = 
                  _WorldSpaceLightPos0.xyz - input.posWorld.xyz;
               float distance = length(vertexToLightSource);
               attenuation = 1.0 * distance;
               lightDirection = normalize(vertexToLightSource);
            }
  
            float3 fragmentColor; 
            float lightCosine = max(0.0, dot(normalDirection, lightDirection));
 
            //diffuse illumination
            fragmentColor = _LightColor0.rgb * _Color * tex2D(_ShadingMap, float2(lightCosine, 0)) * 
                                tex2D(_MainTex, input.uv) ;
 
            //highlights
            float3 lightReflection = reflect(-lightDirection, normalDirection);
            float reflectionCosine = max(0.0, dot(lightReflection, viewDirection));
            if (lightCosine > 0.0  &&
             attenuation * pow(reflectionCosine, _Shininess) > 0.5) {
               fragmentColor = _SpecColor.a 
                  * _LightColor0.rgb * _SpecColor.rgb
                  + (1.0 - _SpecColor.a) * fragmentColor;
            }
            
            return fixed4(fragmentColor, 0);
         }
         ENDCG
      }
   } 
   Fallback "Specular"
}