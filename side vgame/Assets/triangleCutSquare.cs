using UnityEngine;
using System.Collections;

public class triangleCutSquare : MonoBehaviour {

	// triangle separates the square into two triangles, useful to force the other to multiply your clouds

	GameObject adv_sq;
	GameObject adv_tri;
	float diff_x;
	float diff_y;
	Vector3 current_pos;

	// Use this for initialization
	void Start () {

		if (name.Substring(0,7) == "red_tri") {

			adv_sq = GameObject.Find ("blu_sq");
			adv_tri = GameObject.Find ("blu_tri");

		} else if (name.Substring(0,7) == "blu_tri") {

			adv_sq = GameObject.Find ("red_sq");
			adv_tri = GameObject.Find ("red_tri");

		}

	}

	// Update is called once per frame
	void Update () {

		if ((adv_sq != null) && (adv_tri != null)) { // cree evidemment un bug si je mange le square de l autre?

			diff_x = Mathf.Abs(transform.position.x - adv_sq.transform.position.x);
			diff_y = Mathf.Abs(transform.position.y - adv_sq.transform.position.y);

			if ((diff_x < 0.5) && (diff_y < 0.5)) {

				Destroy(adv_sq);
				current_pos = transform.position;

				//instantiate two triangles at the encounter spot
				GameObject newTriangle1 = (GameObject) Instantiate(adv_tri,current_pos,Quaternion.identity);
				setStartingSpot newTriScript1 = newTriangle1.GetComponent ("setStartingSpot") as setStartingSpot;

				GameObject newTriangle2 = (GameObject) Instantiate(adv_tri,current_pos,Quaternion.identity);
				setStartingSpot newTriScript2 = newTriangle2.GetComponent ("setStartingSpot") as setStartingSpot;

				newTriScript1.splitByTriangle = true;
				newTriScript2.splitByTriangle = true;

				newTriangle1.transform.position = current_pos;
				newTriangle2.transform.position = current_pos;

				// give them opposite velocity
				Vector2 attackerVelocity = GetComponent<Rigidbody2D>().velocity;
				newTriangle1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (attackerVelocity.x, attackerVelocity.y * -1);
				newTriangle2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (attackerVelocity.x * -1, attackerVelocity.y);

			}

		}

	}
}
