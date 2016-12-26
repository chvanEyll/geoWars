using UnityEngine;
using System.Collections;

public class circleEatTriangle : MonoBehaviour {

	GameObject adv_tri;
	float diff_x;
	float diff_y;

	// Use this for initialization
	void Start () {

		if (name.Substring(0,7)== "red_cir") {

			adv_tri = GameObject.Find ("blu_tri");

		} else if (name.Substring(0,7) == "blu_cir") {

			adv_tri = GameObject.Find ("red_tri");

		}

	}

	// Update is called once per frame
	void Update () {

		if (adv_tri != null) {

			diff_x = Mathf.Abs(transform.position.x - adv_tri.transform.position.x);
			diff_y = Mathf.Abs(transform.position.y - adv_tri.transform.position.y);

			if ((diff_x < 0.3) && (diff_y < 0.3)) {

				//adv_cir.transform.position = new Vector3 (20, 20, 0);
				//adv_cir.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
				Destroy(adv_tri);

			}

		}

	}

}
