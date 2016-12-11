using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour {

    public GameObject[] lights;
    int index = 0;
    public float timer;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < lights.Length; i++)
            lights[i].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 0.25f)
        {
            lights[index].SetActive(false);
            index++;
            if (index == lights.Length) index = 0;
            lights[index].SetActive(true);
            timer = 0f;
        }
	}
}
