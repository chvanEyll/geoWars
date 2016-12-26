using UnityEngine;
using System.Collections;

public class squareEatCircle : MonoBehaviour {

	GameObject adv_cir;
	float diff_x;
	float diff_y;

	// Use this for initialization
	void Start () {

		if (name.Substring(0,6) == "red_sq") {

			adv_cir = GameObject.Find ("blu_cir");

		} else if (name.Substring(0,6) == "blu_sq") {

			adv_cir = GameObject.Find ("red_cir");

		}

	}
	
	// Update is called once per frame
	void Update () {

		if (adv_cir != null) {
			
			diff_x = Mathf.Abs(transform.position.x - adv_cir.transform.position.x);
			diff_y = Mathf.Abs(transform.position.y - adv_cir.transform.position.y);

			if ((diff_x < 0.3) && (diff_y < 0.3)) {

				//adv_cir.transform.position = new Vector3 (20, 20, 0);
				//adv_cir.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
				Destroy(adv_cir);

			}

		}

	}

}
