using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public GameObject player;
    public Vector3 offset; //offset = (0, 55, -55)
    public float lerpRate;
    private bool gameOver;
    void Start()
    {
        gameOver = false;
    }
    void Update()
    {
        CheckGameOver();
    }
    protected virtual void CheckGameOver()
    {
        if (gameOver) return;
        FollowPlayer();
    }

    protected virtual void FollowPlayer()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = player.transform.position + offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
