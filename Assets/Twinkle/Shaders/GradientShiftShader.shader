Shader "Custom/Shader" {
	Properties {
		_SoundMap ("Albedo (RGB)", 2D) = "white" {}
		_SoundCount("Sounds", Int) = 0
		_Exponent("Exponent", Float) = 8
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200
			Cull Front
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float3 worldNormal;
		};

		sampler2D _SoundMap;
		int _SoundCount;
		float _Exponent;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float3 color = float3(0, 0, 0);
			for (int i = 0; i < _SoundCount; ++i) {
				float u = (0.5 + i) / _SoundCount;
				fixed4 worldSpaceDirection = tex2D(_SoundMap, float2(u, 0.25));
				worldSpaceDirection *= 2;
				worldSpaceDirection -= fixed4(1, 1, 1, 0);
				fixed4 lightColor = tex2D(_SoundMap, float2(u, 0.75));

				color += lightColor * pow(max(dot(worldSpaceDirection, IN.worldNormal), 0), _Exponent);
			}
			o.Albedo = color;
			o.Emission = color;
			// Metallic and smoothness come from slider variables
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
