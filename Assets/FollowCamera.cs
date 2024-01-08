using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    void LateUpdate()
    {
        // Moves the camera to thingToFollow
        // Sets it back -10 on the Z axis
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
    }
}
