using UnityEngine;

public class PlayerComponent : MonoBehaviour {
    
    [SerializeField]
    private ControllerComponent controller;
	
	void Update () {
        this.transform.Translate(controller.movement);
	}
}
