using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moletuto : MonoBehaviour {
    public float visibleHeight = 0.2f;
    public float hiddeneHeight = -0.3f;
    public float speed = 4f;
    public float disappearDuration = 0.5f;

    private Vector3 targetPosition;
    private float disappearTimer = 0f;
    bool rided = false;

    // Use this for initialization
    void Awake () {
        targetPosition = new Vector3(
            transform.localPosition.x,
            visibleHeight,
            transform.localPosition.z
            );
        transform.localPosition = targetPosition;

    }
	
	// Update is called once per frame
	void Update () {
        disappearTimer -= Time.deltaTime;
        if (rided)
        {
            if (disappearTimer <= 0.0f)
            {
                Hide();
            }
        }
      

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime*speed);
	}

    public void Rise()
    {

        targetPosition = new Vector3(
          transform.localPosition.x,
          visibleHeight,
          transform.localPosition.z
          );

        disappearTimer = disappearDuration;

    }



    public void Hide()
    {
        targetPosition = new Vector3(
          transform.localPosition.x,
          hiddeneHeight,
          transform.localPosition.z
          );
        rided = true;
    }
    public void OnHit() {
        Hide();
    }
}
