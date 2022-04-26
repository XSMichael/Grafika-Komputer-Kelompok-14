#version 330

out vec4 outputColor;
uniform vec3 uniformColor;
uniform float alphaColor;
void main(){

    outputColor = vec4(uniformColor,alphaColor);
}
