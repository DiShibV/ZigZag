Shader "SurfaceBlock" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
    }

    SubShader {
        Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry" }
        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
            #pragma surface surf Lambert
            #pragma target 2.0

            struct Input {
                fixed empty;
            };
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                o.Albedo = _Color.rgb;
            }
        ENDCG
    }
    FallBack "Diffuse"
}