using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    private const float FOV_MARGIN = 15.0f;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float aspectRatio;

    // Use this for initialization
    void Start () {

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        aspectRatio = Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {

        // Find the middle point between players.
        middlePoint = player1.transform.position + 0.5f * (player2.transform.position - player1.transform.position);

        // Position the camera in the center.
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
        Camera.main.transform.position = newCameraPos;

        // Calculate the new FOV.
        distanceBetweenPlayers = (player2.transform.position - player1.transform.position).magnitude;
        distanceFromMiddlePoint = (Camera.main.transform.position - middlePoint).magnitude;
        Camera.main.fieldOfView = 6.0f * Mathf.Rad2Deg * Mathf.Atan((0.25f * distanceBetweenPlayers) / (distanceFromMiddlePoint * aspectRatio));

        // Add small margin so the players are not on the viewport border.
        Camera.main.fieldOfView += FOV_MARGIN;

    }
}
