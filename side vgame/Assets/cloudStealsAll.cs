using UnityEngine;
using System.Collections;

public class cloudStealsAll : MonoBehaviour {

	GameObject adv_sq;
	GameObject adv_cir;
	GameObject frd_sq;
	GameObject frd_cir;
	float diff_x;
	float diff_y;
	Vector3 current_pos;

	// Use this for initialization
	void Start () {

		if (name.Substring(0,7) == "red_clo") {

			adv_sq = GameObject.Find ("blu_sq");
			adv_cir = GameObject.Find ("blu_cir");
			frd_sq = GameObject.Find ("red_sq");
			frd_cir = GameObject.Find ("red_cir");

		} else if (name.Substring(0,7) == "blu_clo") {

			adv_sq = GameObject.Find ("red_sq");
			adv_cir = GameObject.Find ("red_cir");
			frd_sq = GameObject.Find ("blu_sq");
			frd_cir = GameObject.Find ("blu_cir");

		}

	}

	// Update is called once per frame
	void Update () { // i think it will bug when im out of the stolen shape! and i think the game should end when im out of squares and circles

		if ((adv_sq != null)) { // lets start with the square

			diff_x = Mathf.Abs(transform.position.x - adv_sq.transform.position.x);
			diff_y = Mathf.Abs(transform.position.y - adv_sq.transform.position.y);

			if ((diff_x < 0.5) && (diff_y < 0.5)) {

				Destroy(adv_sq);

				//instantiate a friend of the stolen shape
				Instantiate(frd_sq,Vector3.zero,Quaternion.identity);

			}

		}

	}
}