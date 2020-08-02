// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Sprites/Outline"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0

        // Add values to determine if outlining is enabled and outline color.
        _OutlineSize ("Outline", Float) = 0
        [HDR]_OutlineColor ("Outline Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
            };

            fixed4 _Color;
   	        sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize; //magic var
            float _OutlineSize; //outline size
            fixed4 _OutlineColor; // outlie color

            fixed GetOutlineAlpha(float2 texcoord, float2 offset, fixed4 color) {
                return saturate(tex2D(_MainTex, (texcoord + offset)).a - color.a);
            }

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = TRANSFORM_TEX(IN.texcoord, _MainTex);
                OUT.color = IN.color * _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap(OUT.vertex);
                #endif

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 orig = tex2D(_MainTex, IN.texcoord);
                float offsetX = _MainTex_TexelSize.x * _OutlineSize;
                float offsetY = _MainTex_TexelSize.y * _OutlineSize;
                // Four sides
                fixed downA = GetOutlineAlpha(IN.texcoord, float2(0, offsetY), orig);
                fixed upA = GetOutlineAlpha(IN.texcoord, float2(0, -offsetY), orig);
                fixed leftA = GetOutlineAlpha(IN.texcoord, float2(offsetX, 0), orig);
                fixed rightA = GetOutlineAlpha(IN.texcoord, float2(-offsetX, 0), orig);
                // Four corners
                fixed topRightA = GetOutlineAlpha(IN.texcoord, float2(-offsetX, -offsetY), orig);
                fixed topLeftA = GetOutlineAlpha(IN.texcoord, float2(offsetX, -offsetY), orig);
                fixed btmRightA = GetOutlineAlpha(IN.texcoord, float2(-offsetX, offsetY), orig);
                fixed btmLeftA = GetOutlineAlpha(IN.texcoord, float2(offsetX, offsetY), orig);
                fixed outlineA = saturate(downA + upA + leftA + rightA + topRightA + topLeftA + btmRightA + btmLeftA);

               	fixed4 texColor = orig * IN.color + (orig.a < 0.2 ? outlineA * _OutlineColor : 0);
                return texColor;
            }
            ENDCG
        }
    }
}