#pragma strict

//define texture as webcamtexture
var webcamtex : WebCamTexture;

//initialize
function Start()
{

	//start webcam tex
	webcamtex = new WebCamTexture();
	renderer.material.mainTexture = webcamtex; //apply webcam tex
	webcamtex.Play(); //update webcam tex

}



