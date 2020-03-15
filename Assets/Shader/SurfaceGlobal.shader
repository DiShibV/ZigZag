Shader "SurfaceGlobal" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Opacity("Opacity", Range(0, 1)) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }

    SubShader {
        Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry" }
        Blend SrcAlpha OneMinusSrcAlpha
        CGPROGRAM
            #pragma surface surf Standard keepalpha
            #pragma target 2.0

            struct Input {
                fixed empty;
            };
            fixed4 _Color;
            fixed _Opacity;
            fixed _Glossiness;
            fixed _Metallic;

            void surf (Input IN, inout SurfaceOutputStandard o){
                o.Albedo = _Color.rgb;
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;
                o.Alpha = _Opacity;
            }
        ENDCG
    }
    FallBack "Diffuse"
}