using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : Selectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Select()
    {
        base.Select();

        PlayerController.instance.SwitchCarOn();
    }
}
