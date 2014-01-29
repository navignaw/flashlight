#pragma strict

//wiimote boolean
var wiimote: boolean;

//get flashlight
private var gotFlashlight: boolean;
gotFlashlight = false;
var pedestal: Transform;
var getFlashlight: GameObject;

//audio 
var off : AudioClip;
var on : AudioClip;

//set player variables
var player : GameObject;
var horizontalRotator: GameObject;
var moveCube: Transform;

//set torque and force variables
var forceFactor : float;
var torqueFactor : float;
var moveFactor : float;
var accFactor : float;
private var xAngle : float;

//control flashlight
var flashlight : GameObject;
var mainCamera : GameObject;
var flashlightPositionRange : Vector2;
private var height : float;
height = Screen.height;
private var width : float;
width = Screen.width;

private var flashlightVector : Vector3;

//center the mouse
Screen.showCursor = false;

//function start
function Start()
{
}

//game update loop
function FixedUpdate () 
{
	
	//get flashlight
	if(Vector3.Distance(pedestal.position,transform.position)<2.0 && gotFlashlight == false)
	{
		gotFlashlight = true;
		pedestal.audio.Play();
		Destroy(getFlashlight);
	}
	
	//use wasd to control player
	
		//lock move cube's position and rotation
		moveCube.position = player.transform.position;
		moveCube.rotation = player.transform.rotation;
		
		//forward
		if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{moveCube.Translate(0,0,-1);}
		
		//backward
		if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{moveCube.Translate(0,0,1);}
		
		//left
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{moveCube.Translate(1,0,0);}
		
		//right
		if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{moveCube.Translate(-1,0,0);}
		
		//diagonals
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{moveCube.Translate(1/Mathf.Sqrt(2),0,-1/Mathf.Sqrt(2));}
		
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
		{moveCube.Translate(-1/Mathf.Sqrt(2),0,-1/Mathf.Sqrt(2));}
	
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{moveCube.Translate(1/Mathf.Sqrt(2),0,1/Mathf.Sqrt(2));}
		
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
		{moveCube.Translate(-1/Mathf.Sqrt(2),0,1/Mathf.Sqrt(2));}
	
		//now move the player
		var moveDirection = moveFactor*(player.transform.position-moveCube.position);
		player.rigidbody.velocity.x = Mathf.Lerp(player.rigidbody.velocity.x,moveDirection.x*forceFactor,accFactor*Time.deltaTime);
		player.rigidbody.velocity.z = Mathf.Lerp(player.rigidbody.velocity.z,moveDirection.z*forceFactor,accFactor*Time.deltaTime);


		//play walk sound
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
		if (player.audio.isPlaying == false) {player.audio.Play();}
		}
		else
<<<<<<< HEAD
		{player.audio.Stop();}
=======
			player.audio.Stop();
>>>>>>> e6ce310fb8da6cc1206c3d56820f66b8641dd9d4


	//wiimote true
	if (wiimote==true)
	{
		//ijkl to control rotation
		if (Input.GetKey(KeyCode.J))
			{player.transform.Rotate(0,-torqueFactor,0);}
		if (Input.GetKey(KeyCode.L))
			{player.transform.Rotate(0,torqueFactor,0);}
		if (Input.GetKey(KeyCode.I) )
			{xAngle -= torqueFactor;}
		if (Input.GetKey(KeyCode.K) )
			{xAngle += torqueFactor;}
			
	}
	//just mouse and keyboard
	else
	{
		//mouse 
		if(Input.GetMouseButton(0)==false)
		{
		player.transform.Rotate(0,torqueFactor*Input.GetAxis("Mouse X"),0);
		xAngle -= torqueFactor*Input.GetAxis("Mouse Y");
		}
	}
	
	//clamp rotation	
	xAngle = Mathf.Clamp(xAngle,-80,80);
	horizontalRotator.transform.localEulerAngles.x = xAngle;

	


	//move flashlight based on mouse
	if(Input.GetMouseButton(0)==true && gotFlashlight == true)
		{
		flashlight.transform.localPosition.x = Mathf.Lerp( flashlight.transform.localPosition.x,
															(Input.mousePosition.x-width/2.0)/width*flashlightPositionRange.x,
															Time.deltaTime*8);
		flashlight.transform.localPosition.y = Mathf.Lerp( flashlight.transform.localPosition.y,
															(Input.mousePosition.y-height/2.0)/height*flashlightPositionRange.y,
															Time.deltaTime*8);
<<<<<<< HEAD
=======
		flashlight.transform.localPosition.z = Mathf.Lerp( flashlight.transform.localPosition.z,1.5,Time.deltaTime*8);
>>>>>>> e6ce310fb8da6cc1206c3d56820f66b8641dd9d4
		}
	else
		{
		flashlight.transform.localPosition.x = Mathf.Lerp( flashlight.transform.localPosition.x,0,Time.deltaTime*4);
		flashlight.transform.localPosition.y = Mathf.Lerp( flashlight.transform.localPosition.y,-4,Time.deltaTime*4);
<<<<<<< HEAD
=======
		flashlight.transform.localPosition.z = Mathf.Lerp( flashlight.transform.localPosition.z,-4,Time.deltaTime*4);
>>>>>>> e6ce310fb8da6cc1206c3d56820f66b8641dd9d4
		}
		
	//rotate flashlight
	flashlightVector = -flashlight.transform.position+mainCamera.transform.position;
	flashlight.transform.rotation = Quaternion.Lerp(flashlight.transform.rotation,
									Quaternion.LookRotation(flashlightVector),
									Time.deltaTime*10);
	
	//flashlight sounds 
	if(gotFlashlight == true){	
		if(Input.GetMouseButtonDown(0) == true)
		{
			flashlight.audio.clip = on;
			flashlight.audio.Play();
		}
		if(Input.GetMouseButtonUp(0) == true)
		{
			flashlight.audio.clip = off;
			flashlight.audio.Play();
		}
	}	
	
	//exit
	if (Input.GetKey ("escape")) {
	Application.Quit();
	}
																														
																																																																																				
}