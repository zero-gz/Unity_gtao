Shader "Hidden/GroundTruthAmbientOcclusion"
{
	CGINCLUDE
		#include "GTAO_Pass.cginc"
	ENDCG

	SubShader
	{
		ZTest Always
		Cull Off
		ZWrite Off

		Pass 
		{ 
			Name"ResolveGTAO"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment ResolveGTAO_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"SpatialGTAO_X"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment SpatialGTAO_X_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"SpatialGTAO_Y"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment SpatialGTAO_Y_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"TemporalGTAO"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment TemporalGTAO_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"CombienGTAO"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment CombienGTAO_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"DeBugGTAO"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment DeBugGTAO_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"DeBugGTRO"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment DeBugGTRO_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

		Pass 
		{ 
			Name"BentNormal"
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment DeBugBentNormal_frag
				#pragma enable_d3d11_debug_symbols
			ENDCG 
		}

	}
}

