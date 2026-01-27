Shader "Custom/SphereAnimation"
{
    Properties
    {
        _Speed ("Speed", Float) = 1.0
        _Amplitude ("Amplitude", Float) = 0.5
        _Variant ("Variant", Range(0, 8)) = 0
        _Color ("Color", Color) = (1,1,1,1)
        _TimeOffset ("Time Offset", Float) = 0.0 // Unique time offset per sphere
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float3 worldPos : TEXCOORD1;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float _Speed;
            float _Amplitude;
            int _Variant;
            float4 _Color;
            float _TimeOffset; // Delay for each sphere

            float3 AnimatePosition(float3 pos, float time)
            {
                float offset = (time + _TimeOffset) * _Speed; // Apply time offset + speed
                float3 movement = float3(0, 0, 0);

                if (_Variant == 1) movement.y += sin(offset) * _Amplitude;
                if (_Variant == 2) movement.y -= sin(offset) * _Amplitude;
                if (_Variant == 3) movement.x += sin(offset) * _Amplitude;
                if (_Variant == 4) movement.xy += sin(offset) * _Amplitude;
                if (_Variant == 5) movement.x -= sin(offset) * _Amplitude;
                if (_Variant == 6) movement.x += sin(offset) * _Amplitude;
                if (_Variant == 7) movement.xy -= sin(offset) * _Amplitude;
                if (_Variant == 8) movement.x += sin(offset);
                if (_Variant == 8) movement.y += cos(offset * 2) * _Amplitude;
                if (_Variant == 9) movement.y += sin(offset + pos.x) * _Amplitude;

                return pos + movement;
            }

            v2f vert (appdata v)
            {
                v2f o;
                float time = _Time.y;
                float3 animatedPos = AnimatePosition(v.vertex.xyz, time);
                o.pos = UnityObjectToClipPos(float4(animatedPos, 1.0));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
