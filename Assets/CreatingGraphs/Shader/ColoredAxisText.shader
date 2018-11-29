Shader "GUI/Text Shader DepthTest" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "red" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader{
		Tags{ "Queue" = "Transparent" }
		Lighting Off Cull Off ZWrite Off Fog{ Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		Pass{
			Color[_Color]
			SetTexture[_MainTex]{
				combine primary, texture * primary
			}
		}
	}
}
