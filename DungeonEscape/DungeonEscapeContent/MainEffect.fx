float4x4 world;
float4x4 view;
float4x4 projection;

float4 color = (1, 1, 1, 1);
float4 ambient = (0.7, 0.7, 0.7, 1);
float4 fogColor = (0, 0, 0, 0);

float fogStart = 3.0;
float fogEnd = 6.0;

texture tex;

sampler2D sam = sampler_state
{
	texture = <tex>;
};

void VS(float4 inPosition: POSITION, float2 inTexCoord: TEXCOORD, out float4 position: POSITION, out float2 texCoord: TEXCOORD0, out float2 distance: TEXCOORD1)
{
	float4 worldPosition = mul(inPosition, world);
	float4 viewPosition = mul(worldPosition, view);

	position = mul(viewPosition, projection);

	distance.x = position.z;

	texCoord = inTexCoord;
}

float4 PS(float2 texCoord: TEXCOORD0, float2 distance: TEXCOORD1): COLOR
{
	float4 objectColor = saturate(color * ambient * tex2D(sam, texCoord));
	float fogFactor = saturate((fogEnd - distance.x) / (fogEnd - fogStart));

	if(objectColor.a != 0)
		return objectColor * fogFactor + (1.0 - fogFactor) * fogColor;
	else
		return objectColor;
}

technique t1
{
	pass p0
	{
		VertexShader = compile vs_2_0 VS();
		PixelShader = compile ps_2_0 PS();
	}
}

