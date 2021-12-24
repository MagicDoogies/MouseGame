﻿Shader "FlatKit/Stylized Surface With Outline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        
        /*--->*/
        [Space(10)]
        [KeywordEnum(None, Single, Steps, Curve)]_CelPrimaryMode("Cel Shading Mode", Float) = 1
        _ColorDim ("[_CELPRIMARYMODE_SINGLE]Color Shaded", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _ColorDimSteps ("[_CELPRIMARYMODE_STEPS]Color Shaded", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _ColorDimCurve ("[_CELPRIMARYMODE_CURVE]Color Shaded", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _SelfShadingSize ("[_CELPRIMARYMODE_SINGLE]Self Shading Size", Range(0, 1)) = 0.5
        _ShadowEdgeSize ("[_CELPRIMARYMODE_SINGLE]Shadow Edge Size", Range(0, 0.5)) = 0.05
        _Flatness ("[_CELPRIMARYMODE_SINGLE]Localized Shading", Range(0, 1)) = 1.0
        
        [IntRange]_CelNumSteps ("[_CELPRIMARYMODE_STEPS]Number Of Steps", Range(1, 10)) = 3.0
        _CelStepTexture ("[_CELPRIMARYMODE_STEPS][LAST_PROP_STEPS]Cel steps", 2D) = "black" {}
        _CelCurveTexture ("[_CELPRIMARYMODE_CURVE][LAST_PROP_CURVE]Ramp", 2D) = "black" {}
        
        [Space(10)]
        [Toggle(DR_CEL_EXTRA_ON)] _CelExtraEnabled("Enable Extra Cel Layer", Int) = 0
        _ColorDimExtra ("[DR_CEL_EXTRA_ON]Color Shaded", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _SelfShadingSizeExtra ("[DR_CEL_EXTRA_ON]Self Shading Size", Range(0, 1)) = 0.6
        _ShadowEdgeSizeExtra ("[DR_CEL_EXTRA_ON]Shadow Edge Size", Range(0, 0.5)) = 0.05
        _FlatnessExtra ("[DR_CEL_EXTRA_ON]Localized Shading", Range(0, 1)) = 1.0
        
        [Space(10)]
        [Toggle(DR_SPECULAR_ON)] _SpecularEnabled("Enable Specular", Int) = 0
        [HDR] _FlatSpecularColor("[DR_SPECULAR_ON]Specular Color", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _FlatSpecularSize("[DR_SPECULAR_ON]Specular Size", Range(0.0, 1.0)) = 0.1
        _FlatSpecularEdgeSmoothness("[DR_SPECULAR_ON]Specular Edge Smoothness", Range(0.0, 1.0)) = 0
        
        [Space(10)]
        [Toggle(DR_RIM_ON)] _RimEnabled("Enable Rim", Int) = 0
        [HDR] _FlatRimColor("[DR_RIM_ON]Rim Color", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _FlatRimLightAlign("[DR_RIM_ON]Light Align", Range(0.0, 1.0)) = 0
        _FlatRimSize("[DR_RIM_ON]Rim Size", Range(0, 1)) = 0.5
        _FlatRimEdgeSmoothness("[DR_RIM_ON]Rim Edge Smoothness", Range(0, 1)) = 0.5
        
        [Space(10)]
        [Toggle(DR_GRADIENT_ON)] _GradientEnabled("Enable Height Gradient", Int) = 0
        [HDR] _ColorGradient("[DR_GRADIENT_ON]Gradient Color", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _GradientCenterX("[DR_GRADIENT_ON]Center X", Float) = 0
        _GradientCenterY("[DR_GRADIENT_ON]Center Y", Float) = 0
        _GradientSize("[DR_GRADIENT_ON]Size", Float) = 10.0
        _GradientAngle("[DR_GRADIENT_ON]Gradient Angle", Range(0, 360)) = 0
        
        [Space(10)]
        [Toggle(DR_VERTEX_COLORS_ON)] _VertexColorsEnabled("Enable Vertex Colors", Int) = 0
        
        _LightContribution("[FOLDOUT(Advanced Lighting){1}]Light Color Contribution", Range(0, 1)) = 0
        
        [KeywordEnum(None, Multiply, Color)] _UnityShadowMode ("[FOLDOUT(Unity Built-in Shadows){4}]Mode", Float) = 0
        _UnityShadowPower("[_UNITYSHADOWMODE_MULTIPLY]Power", Range(0, 1)) = 0.2
        _UnityShadowColor("[_UNITYSHADOWMODE_COLOR]Color", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _UnityShadowSharpness("Sharpness", Range(1, 10)) = 1.0
        
        [Space(10)]
        _MainTex ("[FOLDOUT(Texture maps){4}]Albedo", 2D) = "white" {}
        [KeywordEnum(Multiply, Add)]_TextureBlendingMode("Blending Mode", Float) = 0
        _TextureImpact("Texture Impact", Range(0, 1)) = 1.0

        [Space(10)]
        _BumpMap ("Bump Map", 2D) = "bump" {}

        [Space(25)]
        _OutlineColor("Outline Color", Color) = (0.85023, 0.85034, 0.85045, 0.85056)
        _OutlineWidth("Outline Width", Float) = 0.01
        _OutlineDepthOffset("Outline Depth Offset", Range(0, 1)) = 0.0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Doc: https://docs.unity3d.com/Manual/SL-SurfaceShaders.html
        #include "DustyroomStylizedLighting.cginc"
        #pragma surface surfObject DustyroomStylized vertex:vertObject fullforwardshadows
        #pragma target 3.0
        #pragma require interpolators15
        #define Input InputObject

// #if UNITY_VERSION >= 201910
        #pragma shader_feature_local __ _CELPRIMARYMODE_SINGLE _CELPRIMARYMODE_STEPS _CELPRIMARYMODE_CURVE
        #pragma shader_feature_local DR_CEL_EXTRA_ON
        #pragma shader_feature_local DR_GRADIENT_ON
        #pragma shader_feature_local DR_SPECULAR_ON
        #pragma shader_feature_local DR_RIM_ON
        #pragma shader_feature_local DR_VERTEX_COLORS_ON
        #pragma shader_feature_local __ _UNITYSHADOWMODE_MULTIPLY _UNITYSHADOWMODE_COLOR
        #pragma shader_feature_local _TEXTUREBLENDINGMODE_MULTIPLY _TEXTUREBLENDINGMODE_ADD
// #else
//         #pragma shader_feature __ _CELPRIMARYMODE_SINGLE _CELPRIMARYMODE_STEPS _CELPRIMARYMODE_CURVE
//         #pragma shader_feature DR_CEL_EXTRA_ON
//         #pragma shader_feature DR_GRADIENT_ON
//         #pragma shader_feature DR_SPECULAR_ON
//         #pragma shader_feature DR_RIM_ON
//         #pragma shader_feature DR_VERTEX_COLORS_ON
//         #pragma shader_feature __ _UNITYSHADOWMODE_MULTIPLY _UNITYSHADOWMODE_COLOR
//         #pragma shader_feature _TEXTUREBLENDINGMODE_MULTIPLY _TEXTUREBLENDINGMODE_ADD
// #endif

        #pragma skip_variants POINT_COOKIE DIRECTIONAL_COOKIE

        ENDCG

        Pass {
            Cull Front

            CGPROGRAM

            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half4 _OutlineColor;
            half _OutlineWidth;
            half _OutlineDepthOffset;

            float4 VertexProgram(float4 position : POSITION, float3 normal : NORMAL) : SV_POSITION {
                float4 clipPosition = UnityObjectToClipPos(position);
                float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
                float2 offset = normalize(clipNormal.xy) / _ScreenParams.xy * _OutlineWidth * clipPosition.w * 2.0;
                clipPosition.xy += offset;
                clipPosition.z -= _OutlineDepthOffset;
                return clipPosition;
            }

            half4 FragmentProgram() : SV_TARGET {
                return _OutlineColor;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "StylizedSurfaceEditor"
}
