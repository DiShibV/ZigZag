Shader "SurfaceBlock" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Opacity("Opacity", Range(0, 1)) = 1
    }

    SubShader {
        Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry" }
        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
            #pragma surface surf Lambert keepalpha
            #pragma target 2.0

            struct Input {
                fixed empty;
            };
            fixed4 _Color;
            fixed _Opacity;
            // UNITY_INSTANCING_BUFFER_START(Props)
            //     UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)
            // UNITY_INSTANCING_BUFFER_END(Props)

            void surf (Input IN, inout SurfaceOutput o) {
                //o.Albedo = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
                o.Albedo = _Color.rgb;
                o.Alpha = _Opacity;
            }
        ENDCG
    }
    FallBack "Diffuse"
}