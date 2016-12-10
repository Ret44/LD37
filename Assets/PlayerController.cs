using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Vehicles.Car;
using DG.Tweening;

public enum PlayerState 
{
    Driving,
    Walking
}

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    public PlayerState state;
    public FirstPersonController FPSController;
    public Camera drivingCamera; 
    public Camera FPSCamera;
    public CarController CarController;
    public UnityEngine.UI.Text uiTooltip;

    public GameObject selectedObj;
   

    void Awake() {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
    public void SwitchCarOn()
    {
        FPSCamera.tag = "Untagged";
  //      FPSController.transform.parent = CarController.transform;
        FPSController.gameObject.SetActive(false);
        CarController.drive = true;
        CarController.enabled = true;
        drivingCamera.enabled = true;
        state = PlayerState.Driving;
        drivingCamera.tag = "MainCamera";
    }

    public void SwitchCarOff()
    {
        CarController.drive = false;
        CarController.enabled = false;
        drivingCamera.enabled = false;
        FPSCamera.tag = "MainCamera";
        drivingCamera.tag = "Untagged";
        FPSController.gameObject.SetActive(true);
   //     FPSController.transform.parent = null;
        state = PlayerState.Walking;
    }

    // Update is called once per frame
    void Update() {
        if (state == PlayerState.Walking)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // Physics.Raycast(ray, hit);
            selectedObj = null;

            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.tag == "Selectables")
                    selectedObj = hit.collider.gameObject;
            }

            //    Debug.DrawRay(FPSCamera.gameObject.transform.position, Vector3.forward, Color.red, 5f);

            if (selectedObj != null)
                uiTooltip.text = selectedObj.name;
            else
                uiTooltip.text = "";

            if (Input.GetKey(KeyCode.E) && selectedObj != null)
            {
                selectedObj.GetComponent<Selectable>().Select();
            }
        }
        else if (state == PlayerState.Driving)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                SwitchCarOff();
            }
        }
	}
}
