
Shader "Effects/Toon shading" 
{
   Properties 
   {
      _Color ("Diffuse Color", Color) = (1,1,1,1) 
      _UnlitColor ("Unlit Diffuse Color", Color) = (0.5,0.5,0.5,1) 
      _DiffuseThreshold ("Threshold for Diffuse Colors", Range(0,1)) 
         = 0.1 
      _OutlineColor ("Outline Color", Color) = (0,0,0,1)
      _LitOutlineThickness ("Lit Outline Thickness", Range(0,1)) = 0.1
      _UnlitOutlineThickness ("Unlit Outline Thickness", Range(0,1)) 
         = 0.4
      _SpecColor ("Specular Color", Color) = (1,1,1,1) 
      _Shininess ("Shininess", Float) = 10
   }
   SubShader 
   {
      Pass
       {      
         Tags { "LightMode" = "ForwardBase" } 
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
         uniform float4 _LightColor0; 
 
         uniform float4 _Color; 
         uniform float4 _UnlitColor;
         uniform float _DiffuseThreshold;
         uniform float4 _OutlineColor;
         uniform float _LitOutlineThickness;
         uniform float _UnlitOutlineThickness;
         uniform float4 _SpecColor; 
         uniform float _Shininess;
 
         struct vertexInput
         {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         
         struct vertexOutput 
         {
            float4 pos : SV_POSITION;
            float4 posWorld : TEXCOORD0;
            float3 normalDir : TEXCOORD1;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject; 
 
            output.posWorld = mul(modelMatrix, input.vertex);
            output.normalDir = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            output.pos = UnityObjectToClipPos(input.vertex);
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
            else {// point or spot light
               float3 vertexToLightSource = 
                  _WorldSpaceLightPos0.xyz - input.posWorld.xyz;
               float distance = length(vertexToLightSource);
               attenuation = 1.0 / distance;
               lightDirection = normalize(vertexToLightSource);
            }
  
            float3 fragmentColor = _UnlitColor.rgb; 
            float lightCosine = max(0.0, dot(normalDirection, lightDirection));
 
            //diffuse illumination
            if (attenuation * lightCosine >= _DiffuseThreshold) {
               fragmentColor = _LightColor0.rgb * _Color.rgb; 
            }
 
            //outline
            float viewCosine = dot(viewDirection, normalDirection);
            if (viewCosine < lerp(_UnlitOutlineThickness, _LitOutlineThickness, lightCosine)) {
               fragmentColor = _LightColor0.rgb * _OutlineColor.rgb; 
            }
 
            //highlights
            float3 lightReflection = reflect(-lightDirection, normalDirection);
            float reflectionCosine = max(0.0, dot(lightReflection, viewDirection));
            if (lightCosine > 0.0  &&
             attenuation * pow(reflectionCosine, _Shininess) > 0.5) {
               fragmentColor = _SpecColor.a 
                  * _LightColor0.rgb * _SpecColor.rgb
                  + (1.0 - _SpecColor.a) * fragmentColor;
            }
            
            return float4(fragmentColor, 1.0);
         }
         ENDCG
      }
   } 
   Fallback "Specular"
}