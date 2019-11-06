using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
	public float maxSpeed = 5;
	public float acceleration = .1f;
	public float steeringSpeed = 10f;
	public float maxDisplayedSpeed = 200f;
	public Text	speedText;
	public Image speedBarFront;

	private float currentSpeed = 0;
	private float speedBarFrontInitWidth;

	void Start()
	{
		speedBarFrontInitWidth = speedBarFront.rectTransform.sizeDelta.x;
	}

	void Update()
	{
		if (Input.GetAxis("Vertical") > 0)
		{
			currentSpeed += acceleration * Time.deltaTime;

			if (currentSpeed > maxSpeed)
				currentSpeed = maxSpeed;
		}
		else if (Input.GetAxis("Vertical") == 0)
		{
			if (currentSpeed > 0)
			{
				currentSpeed -= acceleration*.75f * Time.deltaTime;

				if (currentSpeed < 0)
					currentSpeed = 0;
			}
			else if (currentSpeed < 0)
			{
				currentSpeed += acceleration*.75f * Time.deltaTime;

				if (currentSpeed > 0)
					currentSpeed = 0;
			}
		}
		else
		{
			currentSpeed -= acceleration*1.5f * Time.deltaTime;

			if (currentSpeed < -maxSpeed/3f)
				currentSpeed = -maxSpeed/3f;
		}

		transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
		transform.Rotate(0, Input.GetAxis("Horizontal") * steeringSpeed * Time.deltaTime, 0);

		speedText.text = "Speed: " + Mathf.Floor(currentSpeed*maxDisplayedSpeed/maxSpeed);
		speedBarFront.rectTransform.sizeDelta = new Vector2(speedBarFrontInitWidth * currentSpeed / maxSpeed, 50);
	}
}
