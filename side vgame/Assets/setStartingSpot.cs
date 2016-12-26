using UnityEngine;
using System.Collections;

public class setStartingSpot : MonoBehaviour {

	// define my constant coords
	const float blu_y = -10.24F;
	const float red_y = 3.12F;
	float[] shape_positions = new float[] {-5.5F,-3.1F,-0.71F,1.72F};
	bool thisIsClicked;
	string shape;
	public bool splitByTriangle;

	Vector3 InitialPosition () {
		
		float obj_y = 0F;
		float obj_x = 0F;
		int x_idx = 0;

		//determine x
		switch (shape) {

			case "cl":
				x_idx = 0;
					break;

			case "sq":
				x_idx = 1;
					break;

			case "ci":
				x_idx = 2;
					break;

			case "tr":
				x_idx = 3;
					break;

		}

		//determine y
		switch (this.tag) {

			case "redTag":
				obj_y = red_y;
					break;

			case "bluTag":
				x_idx = (x_idx * -1) + 3; //invert x_idx for shape_positions
				obj_y = blu_y;
					break;

			}

		obj_x = shape_positions[x_idx];
		return new Vector3 (obj_x, obj_y, -1);

		}

	bool isInStartingSpot () {

		if (this.tag == "redTag") {

			if (this.transform.position.y > 2.50) {

				return true;

			} 
		} else if (this.tag == "bluTag") {

			if (this.transform.position.y < -10) {

				return true;

			}
		} return false;
	}

	void OnMouseDown() {

		thisIsClicked  = true;
		StartCoroutine(wait());

	}

	IEnumerator wait() {
		yield return new WaitForSeconds(2);
		thisIsClicked  = false;
	}

	void Start () {

		if (!splitByTriangle) {
			
			transform.position = InitialPosition ();

		}

		shape = name.Substring (4, 2);

	}

	void Update () {
		
		if (isInStartingSpot()) {

			if (!thisIsClicked) {
				
				transform.position = InitialPosition ();

				// redresser le triangle
				if (shape == "tr") {

					transform.eulerAngles  = new Vector3 (0, 0, 0);

				}
			
			}

		}

	}
}