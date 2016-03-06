using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private bool hasStarted = false;
    float xmin;
    float xmax;

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftLimit.x;
        xmax = rightLimit.x;
    }
	
	// Update is called once per frame
	void Update () {
        ShipControl();
        ShipAnimate();
	}

    void ShipAnimate()
    {
        if(Input.GetAxis("Mouse X") < 0)
        {
            print("Mouse left");
        }else if (Input.GetAxis("Mouse X") > 0)
        {
            print("Mouse right");
        }else if (Input.GetAxis("Mouse X") == 0)
        {
            print("Mouse Still");
        }   
    }

    void ShipControl()
    {
        Vector3 ShipPos = new Vector3(0.29f, this.transform.position.y, 0f);
        float MousePosBlocks = (Input.mousePosition.x / Screen.width) * 11;
        ShipPos.x = Mathf.Clamp(MousePosBlocks, xmin, xmax);
        this.transform.position = ShipPos;

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
    }
}
