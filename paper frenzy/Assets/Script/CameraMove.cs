using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Speed = 3f;
    public Transform Player;

    public Vector3 offset;

    private void FixedUpdate()
    {
        if (Player != null)
        {
            Vector3 TargetPos = Player.position + offset;
            Vector3 SmoothMove = Vector3.Lerp(transform.position, TargetPos, Speed * Time.fixedDeltaTime);

            transform.position = SmoothMove;
        }
    }
}
