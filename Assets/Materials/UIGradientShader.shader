Shader "Custom/UIGradient"
{
    Properties
    {
        _Color1 ("Top Color", Color) = (1,1,1,1)
        _Color2 ("Bottom Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color1;
            fixed4 _Color2;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                return lerp(_Color2, _Color1, i.uv.y);
            }
            ENDCG
        }
    }
}
