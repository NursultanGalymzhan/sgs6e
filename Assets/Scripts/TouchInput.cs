using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public GameObject target;
	public float rotationRate = 0.5f;
	
	RaycastHit hit;
	LayerMask layerMask = (1 << 8) | (1 << 2);
	bool toggleInfo = false;
	GUIStyle style;

	// Use this for initialization
	void Start () {
		layerMask =~ layerMask;

		style.normal.textColor = Color.white;
		style.fontSize = 40;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Ray ray = Camera.main.ScreenPointToRay(touch.position);

			if(Physics.Raycast(ray, out hit, 50, layerMask))
			{
				if(Input.touchCount == 1)
				{
					if(touch.phase == TouchPhase.Began)
					{
						toggleInfo = !toggleInfo;
					}

					if(touch.phase == TouchPhase.Moved)
					{
						target.transform.Rotate(0, -touch.deltaPosition.x * rotationRate, 0, Space.World);
					}

				}
			}
		}
	}

	void OnGUI()
	{
		if(!toggleInfo)
		{
			GUI.TextArea(new Rect(5, 5, 50, 100), "Samsung Galaxy S6 Edge - the next is here!", style);
		}

	}
}
