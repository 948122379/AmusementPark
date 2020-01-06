// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33450,y:32668,varname:node_4013,prsc:2|diff-2264-OUT,spec-9223-OUT,gloss-8102-OUT,normal-4504-RGB,transm-7408-OUT,lwrap-6115-OUT,clip-5106-A,voffset-3184-OUT;n:type:ShaderForge.SFN_Tex2d,id:5106,x:32590,y:32688,ptovrint:False,ptlb:vvvv,ptin:_vvvv,varname:node_5106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:66321cc856b03e245ac41ed8a53e0ecc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:8706,x:32237,y:32669,varname:node_8706,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector3,id:5619,x:32237,y:32722,varname:node_5619,prsc:2,v1:0.96,v2:0.82,v3:0.3;n:type:ShaderForge.SFN_Lerp,id:1391,x:32416,y:32669,varname:node_1391,prsc:2|A-8706-OUT,B-5619-OUT,T-8051-B;n:type:ShaderForge.SFN_VertexColor,id:8051,x:32237,y:32805,varname:node_8051,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2264,x:32818,y:32668,varname:node_2264,prsc:2|A-1391-OUT,B-5106-RGB;n:type:ShaderForge.SFN_Tex2d,id:4504,x:32848,y:32820,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_4504,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cb6c5165ed180c543be39ed70e72abc8,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalVector,id:135,x:32414,y:32939,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector3,id:4787,x:32283,y:32967,varname:node_4787,prsc:2,v1:1,v2:0.5,v3:0.5;n:type:ShaderForge.SFN_Add,id:4403,x:32584,y:32966,varname:node_4403,prsc:2|A-4787-OUT,B-135-OUT;n:type:ShaderForge.SFN_Normalize,id:1025,x:32761,y:32966,varname:node_1025,prsc:2|IN-4403-OUT;n:type:ShaderForge.SFN_VertexColor,id:4909,x:32370,y:33113,varname:node_4909,prsc:2;n:type:ShaderForge.SFN_Pi,id:1562,x:32403,y:33265,varname:node_1562,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3392,x:32660,y:33161,varname:node_3392,prsc:2|A-1562-OUT,B-4909-B;n:type:ShaderForge.SFN_Time,id:1683,x:32638,y:33333,varname:node_1683,prsc:2;n:type:ShaderForge.SFN_Add,id:9424,x:32820,y:33265,varname:node_9424,prsc:2|A-3392-OUT,B-1683-T;n:type:ShaderForge.SFN_Sign,id:9003,x:32966,y:33217,varname:node_9003,prsc:2|IN-9424-OUT;n:type:ShaderForge.SFN_Multiply,id:3184,x:33098,y:33023,varname:node_3184,prsc:2|A-1025-OUT,B-4909-R,C-1047-OUT,D-9597-OUT;n:type:ShaderForge.SFN_Vector1,id:9597,x:32881,y:33023,varname:node_9597,prsc:2,v1:0.015;n:type:ShaderForge.SFN_ValueProperty,id:9223,x:33202,y:32711,ptovrint:False,ptlb:specular,ptin:_specular,varname:node_9223,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_ValueProperty,id:8102,x:33031,y:32732,ptovrint:False,ptlb:gloss,ptin:_gloss,varname:node_8102,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Vector3,id:7408,x:33202,y:32790,varname:node_7408,prsc:2,v1:0.28,v2:0.31,v3:0.15;n:type:ShaderForge.SFN_Vector3,id:6115,x:33202,y:32893,varname:node_6115,prsc:2,v1:0.3,v2:0.3,v3:0.3;n:type:ShaderForge.SFN_Sin,id:1047,x:33152,y:33306,varname:node_1047,prsc:2|IN-9424-OUT;proporder:5106-4504-9223-8102;pass:END;sub:END;*/

Shader "Shader Forge/arrows" {
    Properties {
        _vvvv ("vvvv", 2D) = "white" {}
        _normal ("normal", 2D) = "bump" {}
        _specular ("specular", Float ) = 0.2
        _gloss ("gloss", Float ) = 0.5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _vvvv; uniform float4 _vvvv_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _specular;
            uniform float _gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_1683 = _Time + _TimeEditor;
                float node_9424 = ((3.141592654*o.vertexColor.b)+node_1683.g);
                v.vertex.xyz += (normalize((float3(1,0.5,0.5)+v.normal))*o.vertexColor.r*sin(node_9424)*0.015);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _vvvv_var = tex2D(_vvvv,TRANSFORM_TEX(i.uv0, _vvvv));
                clip(_vvvv_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_specular,_specular,_specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(0.3,0.3,0.3)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(0.28,0.31,0.15);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_8706 = 0.0;
                float3 diffuseColor = (lerp(float3(node_8706,node_8706,node_8706),float3(0.96,0.82,0.3),i.vertexColor.b)*_vvvv_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _vvvv; uniform float4 _vvvv_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _specular;
            uniform float _gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_1683 = _Time + _TimeEditor;
                float node_9424 = ((3.141592654*o.vertexColor.b)+node_1683.g);
                v.vertex.xyz += (normalize((float3(1,0.5,0.5)+v.normal))*o.vertexColor.r*sin(node_9424)*0.015);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _vvvv_var = tex2D(_vvvv,TRANSFORM_TEX(i.uv0, _vvvv));
                clip(_vvvv_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_specular,_specular,_specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(0.3,0.3,0.3)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(0.28,0.31,0.15);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float node_8706 = 0.0;
                float3 diffuseColor = (lerp(float3(node_8706,node_8706,node_8706),float3(0.96,0.82,0.3),i.vertexColor.b)*_vvvv_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _vvvv; uniform float4 _vvvv_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1683 = _Time + _TimeEditor;
                float node_9424 = ((3.141592654*o.vertexColor.b)+node_1683.g);
                v.vertex.xyz += (normalize((float3(1,0.5,0.5)+v.normal))*o.vertexColor.r*sin(node_9424)*0.015);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _vvvv_var = tex2D(_vvvv,TRANSFORM_TEX(i.uv0, _vvvv));
                clip(_vvvv_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
