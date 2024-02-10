Shader "Unlit/FanShapeMask"
{
    Properties
    {
        _Center("Center", Vector) = (0.5, 0.5, 0, 0)
        _Radius("Radius", Float) = 0.5
        _AngleRange("Angle Range", Vector) = (0, 360, 0, 0)
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

            float2 _Center;
            float _Radius;
            float2 _AngleRange;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * 2 - 1;
                float angle = atan2(uv.y, uv.x) * 57.29578; // Convert to degrees
                if(angle < 0) angle += 360;
                float dist = length(uv);

                bool inAngle = angle >= _AngleRange.x && angle <= _AngleRange.y;
                bool inRadius = dist <= _Radius;

                if(inAngle && inRadius)
                    return fixed4(1,1,1,1); // White, visible
                else
                    discard; // Discard pixel

                return fixed4(0,0,0,0); // Should never reach here
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
