using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public GameObject lollipig, bosspig, feedbackText;
	public float speed, fspeed;
	public bool next = true;
	public float tmp;
	// Use this for initialization
	void Start () {
		bosspig.transform.position = new Vector3(-5f,-3f,-2f);
		speed = 0.03f;
		tmp = Vector3.Distance(bosspig.transform.position,lollipig.transform.position);
		print(tmp);
		fspeed = tmp * speed;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse = Input.mousePosition;
		mouse.z = 8;
		lollipig.transform.position = Camera.main.ScreenToWorldPoint(mouse);
		
		tmp = Vector3.Distance(bosspig.transform.position,lollipig.transform.position);
		// fspeed = tmp * fspeed;
		// if(tmp != 0)
		// 	tmp = fspeed / tmp;
		// else
		// 	tmp = 0;
		if(tmp != 0) {
			feedbackText.SetActive(false);
			speed = fspeed / tmp;
		}
		else {
			feedbackText.SetActive(true);
		}

		if(next){
			bosspig.transform.position = Vector3.Lerp(bosspig.transform.position ,lollipig.transform.position, speed);
			StartCoroutine(move());
			next = false;
		}
	}

	IEnumerator move() {
		yield return new WaitForSeconds(0.01f);
		next = true;
	}

	
}
