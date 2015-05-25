// Compiled shader for iPhone, iPod Touch and iPad, uncompressed size: 2.4KB

// Skipping shader variants that would not be included into build of current scene.

Shader "Mobile/UnlitColorAlpha" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }


 // Stats for Vertex shader:
 //        gles : 1 math
 //       gles3 : 1 math
 //       metal : 1 math
 // Stats for Fragment shader:
 //       metal : 1 math
 Pass {
  Tags { "RenderType"="Opaque" }
  GpuProgramID 29821
Program "vp" {
SubProgram "gles " {
// Stats: 1 math
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
uniform highp mat4 glstate_matrix_mvp;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _Color;
void main ()
{
  lowp vec4 col_1;
  col_1.xyz = _Color.xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}



#endif"
}
SubProgram "gles3 " {
// Stats: 1 math
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
uniform highp mat4 glstate_matrix_mvp;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _Color;
void main ()
{
  lowp vec4 col_1;
  col_1.xyz = _Color.xyz;
  col_1.w = 1.0;
  _glesFragData[0] = col_1;
}



#endif"
}
SubProgram "metal " {
// Stats: 1 math
Bind "vertex" ATTR0
ConstBuffer "$Globals" 64
Matrix 0 [glstate_matrix_mvp]
"metal_vs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
  float4 _glesVertex [[attribute(0)]];
};
struct xlatMtlShaderOutput {
  float4 gl_Position [[position]];
};
struct xlatMtlShaderUniform {
  float4x4 glstate_matrix_mvp;
};
vertex xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  _mtl_o.gl_Position = (_mtl_u.glstate_matrix_mvp * _mtl_i._glesVertex);
  return _mtl_o;
}

"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
SubProgram "metal " {
// Stats: 1 math
ConstBuffer "$Globals" 8
VectorHalf 0 [_Color] 4
"metal_fs
#include <metal_stdlib>
using namespace metal;
struct xlatMtlShaderInput {
};
struct xlatMtlShaderOutput {
  half4 _glesFragData_0 [[color(0)]];
};
struct xlatMtlShaderUniform {
  half4 _Color;
};
fragment xlatMtlShaderOutput xlatMtlMain (xlatMtlShaderInput _mtl_i [[stage_in]], constant xlatMtlShaderUniform& _mtl_u [[buffer(0)]])
{
  xlatMtlShaderOutput _mtl_o;
  half4 col_1;
  col_1.xyz = _mtl_u._Color.xyz;
  col_1.w = half(1.0);
  _mtl_o._glesFragData_0 = col_1;
  return _mtl_o;
}

"
}
}
 }
}
}