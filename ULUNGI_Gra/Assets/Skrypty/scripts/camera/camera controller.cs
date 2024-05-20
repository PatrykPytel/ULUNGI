using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    public Transform player;
    public float offsety = 0;
    public float offsetx = 0;
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);


        transform.position = new Vector3(player.position.x + offsetx, player.position.y + offsety , transform.position.z);
    }
    public void MoveTONewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
