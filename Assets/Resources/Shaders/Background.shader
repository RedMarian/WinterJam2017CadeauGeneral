
Shader "Unlit/Background"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Utils.cginc"

			struct attribute
			{
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct varying
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			fixed4 _Color;
			
			varying vert (attribute v)
			{
				varying o;
				o.position = float4(0,0,0,1);
				o.uv = v.uv*2.-1.;
				o.position.xy = o.uv;
				return o;
			}
			
			fixed4 frag (varying i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				float2 p = i.uv;
				p.x *= _ScreenParams.x/_ScreenParams.y;
				float angle = 10. * atan2(p.y,p.x);
				float radius = sin(length(p)*3.-_Time.y);
				p = float2(radius, sin(angle));
				col.rgb *= smoothstep(.0,.01, frac(p.x)+p.y);
				// float dist = length(p)*10.;
				// col.rgb *= smoothstep(.0,.1, sin(dist-_Time.y));

				p = i.uv;
				p.x *= _ScreenParams.x/_ScreenParams.y;
				float x = sin(10.*noiseIQ(p.xxx*10.)+_Time.y*10.);
				float should = step((sin(_Time.y)*.5+.5)*3., abs(p.x));
				float thin = lerp(.2, .01, should);
				x = lerp(x, p.y, should);
				col.rgb *= 1.-clamp(thin/abs(x-p.y*4.), 0., 1.);

				return col;
			}
			ENDCG
		}
	}
}
