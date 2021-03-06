using UnityEngine;
using System.Collections;

public class FlightControls : MonoBehaviour
{
	public float moveHorizantal;
	public float moveStraif;
	public float moveVertical;
	public float moveZAxis;

	public float speed = 50f;
	public float currentSpeed = 0f;
	public float maxSpeed = 50f;
	public float deceleration = 0.95f;
	public float horizantalRotationSpeed = 50f;
	public float verticalRotationSpeed = 50f;
	public float heightSpeed = 16f;
	public float straifSpeed = 20f;
	public float rollSpeed = 50f;
	public bool invertFlightControls = false;
	public bool invincibility = false;
	//public bool pause = false;

	//Add any projectile here if you want them
	//public BulletScript bullet;

	//Add health if applicable
	//public int health = 5;
	//public GUIText healthText;

	//If there are options that alter these controls, add it here
	//public GameObject settings;
	//public GameObject runTimeSettings;

	//Use this for initialization
	void Start()
	{
		//Do misc. things here

		//Do option settings here
	}

	void Update ()
	{
		//Get the axises
		moveHorizantal = Input.GetAxis ("Horizontal");
		moveStraif = Input.GetAxis ("Straif");
		moveZAxis = Input.GetAxis ("VerticalZ");
		moveVertical = Input.GetAxis ("VerticalY");
		

		//----------------------HEIGHT CONTROLS----------------------------------
		//Option to invert controls (true or false)
		if(!invertFlightControls)
		{
			//Height controls (up)
			if(Input.GetKey("up"))
			{
				transform.Translate(Vector3.up * (Time.deltaTime * heightSpeed));
				transform.Rotate(Vector3.right * (Time.deltaTime * -verticalRotationSpeed));
			}
	
			//Height controls (down)
			if(Input.GetKey("down"))
			{
				transform.Translate(Vector3.up * (Time.deltaTime * -heightSpeed));
				transform.Rotate(Vector3.right * (Time.deltaTime * verticalRotationSpeed));
			}
		}
		else if(invertFlightControls)
		{
			//Height controls (up)
			if(Input.GetKey("up"))
			{
				transform.Translate(Vector3.up * (Time.deltaTime * -heightSpeed));
				transform.Rotate(Vector3.right * (Time.deltaTime * verticalRotationSpeed));
			}
	
			//Height controls (down)
			if(Input.GetKey("down"))
			{
				transform.Translate(Vector3.up * (Time.deltaTime * heightSpeed));
				transform.Rotate(Vector3.right * (Time.deltaTime * -verticalRotationSpeed));
			}
		}

		//Reset the vertical movement
		moveVertical = 0;

		//--------------------------RESTART-------------------------------------
		//If the reset key ("R") is pressed, normalize the object (used for debugging)
		if(Input.GetKey("r"))
		{
			//Reset/normalize the object
			transform.rotation = Quaternion.identity;
		}

		//----------------------STRAIF CONTROLS----------------------------------
		//If the turn left key ("Q") is pressed, turn left
		if(Input.GetKey("q"))
		{
			//Straif left
			transform.Translate(Vector3.right * (Time.deltaTime * -straifSpeed));
		}

		//If the turn right key ("E") is pressed, turn right
		if(Input.GetKey("e"))
		{
			//Striaf right
			transform.Translate(Vector3.right * (Time.deltaTime * straifSpeed));
		}

		//If the straif up key ("F") is pressed, striaf up
		if(Input.GetKey("f"))
		{
			//Striaf up
			transform.Translate(Vector3.up * (Time.deltaTime * straifSpeed));
		}

		//If the straif down key ("V") is pressed, striaf down
		if(Input.GetKey("v"))
		{
			//Striaf down
			transform.Translate(Vector3.up * (Time.deltaTime * -straifSpeed));
		}

		//----------------------ROLL CONTROLS----------------------------------
		//If the left roll button ("Z") is pressed, Roll left on Z-axis
		if(Input.GetKey("z"))
		{
			transform.Rotate(Vector3.forward * (Time.deltaTime * rollSpeed));
		}

		//If the right roll button ("C") is pressed, Roll right on Z-axis
		if(Input.GetKey("c"))
		{
			transform.Rotate(Vector3.forward * (Time.deltaTime * -rollSpeed));
		}

		//----------------------FIRE CONTROLS----------------------------------
		//If the fire button ("Spacebar") is pressed, Fire bullets
		if(Input.GetButtonDown("Fire1"))
		{
			//Include anything that you want to fire here

			//Include sound if needed here
		}

		//---------------------HEALTH (if applicable)---------------------------
		//If the object lost too much health
		//if(health <= 0)
		//{
			//It is a gameover (or what you want to do here)
			//Application.LoadLevel("Menu");
		//}

		//---------------------PAUSE (if applicable)----------------------------
		//if(Input.GetButtonDown("Pause") /*&& !pause*/ && Time.timeScale != 0f)
		//{
			//Pause the game
			//Time.timeScale = 0.0f;
			//pause = true;

			//Get the pause menu
			//gameObject.GetComponent<PauseMenu>().enabled = true;
		//}

		//Another option to quickly pause
		//else if(Input.GetKey("p") && pause)
		//{
			//Unpause the game
			//Time.timeScale = 1.0f;
			//pause = false;
		//}

		//---------------------EXIT (if applicable)-----------------------------
		//if(Input.GetKey("l"))
		//{
			//Exit to main menu
			//Application.LoadLevel("Menu");
		//}

		//---------------------RESET LEVEL (if applicable)----------------------
		//if(Input.GetKey("o"))
		//{
			//Reset level
			//Application.LoadLevel("MainGame");
		//}
	}
	
	void FixedUpdate ()
	{
		//Variables
		//Make the movement variable
		Vector3 movement = new Vector3 (0.0f, 0.0f, moveZAxis);
		
		//----------------------MOVEMENT CONTROLS----------------------------------
		//If the current speed is lower than max speed AND there is input (forward or backward)
		if (currentSpeed < maxSpeed && (moveZAxis != 0))
		{
			//Do nothing
		}
		//Else, do not exceed maxSpeed
		else if (currentSpeed >= maxSpeed)
		{
			//Reset the current speed to the maximum speed
			currentSpeed = maxSpeed;

			//If the speed is lower than 0, resent the current speed to 0
			if (currentSpeed < 0)
			{
				currentSpeed = 0;
			}
		}

		//Constent slowdown of speed when there is no input (forward or backward) AND speed is greater than 0
		if (moveZAxis == 0 && currentSpeed > 0)
		{
			//Slowly reduce the current speed
			currentSpeed = currentSpeed * deceleration; //deceleration = 1 for now

			//If the speed is lower than 0, resent the current speed to 0
			if (currentSpeed < 0)
			{
				currentSpeed = 0;
			}

			//Add (the negative) force to the ship to make it gradually slow down
			rigidbody.velocity *= deceleration;
		}
		//Else if there is movement (forward or backward), reset the current speed
		else if (moveZAxis != 0)
		{
			//Reset the speed value
			currentSpeed = speed;
		}

		//Add force to the object
		rigidbody.AddRelativeForce (movement * currentSpeed * Time.deltaTime, ForceMode.Impulse);

		//----------------------ROTATION CONTROLS----------------------------------
		//Rotation controls (right)
		if(moveHorizantal > 0)
		{
			transform.Rotate(Vector3.up * (Time.deltaTime * horizantalRotationSpeed));
		}

		//Rotation controls (left)
		if(moveHorizantal < 0)
		{
			transform.Rotate(Vector3.up * (Time.deltaTime * -horizantalRotationSpeed));
		}
	}

	//When the object takes damage (if applicable)
	//void OnCollisionEnter(Collision other)
	//{
		//if(other.gameObject.tag == "somethingElse" && !invincibility)
		//{
			//Decrement the health of the ship (change the particle colors)
			//health--;

			//Play Bump Sound
			//bump.GetComponent<AudioSource>().Play();
	
			//If the amount 
			//healthText.text = "Health: " + health;
		//}
	//}

	//Used for updating options for this object (if applicable)
	//public void UpdateObject()
	//{
		//update the object variables
	//}
}