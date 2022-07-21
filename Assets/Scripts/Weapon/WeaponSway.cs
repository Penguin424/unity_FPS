using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{

    private Quaternion originRotation;
    public float swayAmount = 8f;

    void Start()
    {
        originRotation = transform.localRotation;
    }


    void Update()
    {
        Sway();
    }

    void Sway()
    {
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");

        Quaternion xRotation = Quaternion.AngleAxis(mousex * -1.25f, Vector3.up);
        Quaternion yRotation = Quaternion.AngleAxis(mousey * -1.25f, Vector3.left);

        Quaternion finalRotation = originRotation * xRotation * yRotation;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, finalRotation, Time.deltaTime * swayAmount);
    }
}
