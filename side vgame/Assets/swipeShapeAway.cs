using UnityEngine;
using System.Collections;

public class swipeShapeAway : MonoBehaviour {
	Vector3 speedVec;
	bool thisIsClicked = false;
	Rigidbody2D this_item;
	string shape;
	Vector3 tri_velocity;

	// Use this for initialization
	void Start () {

		this_item = GetComponent<Rigidbody2D>();
		shape = name.Substring (4, 2);
	
	}

	//waiting
	void OnMouseDown() {

		thisIsClicked  = true;
		StartCoroutine(wait());

	}

	IEnumerator wait() {
		yield return new WaitForSeconds(1);
		thisIsClicked  = false;
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

	// Update is called once per frame
	void Update () {

		// move on swipe
		if (Input.GetMouseButton(0) && (thisIsClicked)) {

			if (isInStartingSpot()) {
				
				float x = Input.GetAxis ("Mouse X");
				float y = Input.GetAxis ("Mouse Y");
				speedVec = new Vector3(x,y,0).normalized * 4;

				GetComponent<Rigidbody2D> ().velocity = speedVec;

			}
		}

		//correction de déplacement
		if ((!isInStartingSpot())) {

			//Avoid horizontal loop (theres an important bug here, red square compensates downwards)
			if ((this_item.velocity.y < 2) && (this_item.velocity.y > 0)) {

				this_item.velocity = new Vector2 (this_item.velocity.x, 2);

			} else if ((this_item.velocity.y > -2) && (this_item.velocity.y < 2)) {

				this_item.velocity = new Vector2 (this_item.velocity.x, -2);

			} else {

				// maintain speed
				this_item.velocity = (this_item.velocity.normalized) * 6;  

			}

		}

		// rotate the triangle to the direction it's facing
		if (shape == "tr") {
			
			tri_velocity = this_item.velocity;

			Vector3 rot = Vector3.Lerp (transform.rotation.eulerAngles, tri_velocity, 0.002F*Time.deltaTime);
			float rotZ = Mathf.Atan2(rot.y,rot.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,0,rotZ-90);


		}

	}
}