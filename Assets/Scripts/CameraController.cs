using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform player;
    public Vector2 maxPosition;
	public Vector2 minPosition;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y,transform.position.z);
    }
	

}
