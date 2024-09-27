using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;
    public Vector2EventChannelSO gameOver;
    private bool isFollowing = false;
    private Vector2 winnerPos;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void OnEnable()
    {
        gameOver.OnEventRaised += SetWinnerCam;
    }
    private void OnDisable()
    {
        gameOver.OnEventRaised -= SetWinnerCam;
    }
    private void Update()
    {
        if (isFollowing)
        {
            cam.transform.position = new Vector3(winnerPos.x, winnerPos.y, -10f);
        }
    }
    public void SetWinnerCam(Vector2 winnerPos)
    {
        isFollowing = true;
        this.winnerPos = winnerPos;
        cam.orthographicSize = 1f;
    }
}
