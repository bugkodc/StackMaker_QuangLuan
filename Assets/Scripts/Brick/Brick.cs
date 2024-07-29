using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject BrickPrefab;
    private Transform PlayerPos;
    private GameObject listBrick;
    private Player player;
    private bool isCollect;
    private Vector3 pos;
    private GameObject topBrick;
    private void Awake()
    {
        // fix find
        PlayerPos = GameObject.FindGameObjectWithTag(CONST.TAG_POSE_PLAYER).transform;
        player = LevelManager.Instance.player;
        listBrick = player.ListBrick;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CONST.TAG_PLAYER))
        {
            gameObject.SetActive(false);
            AddBrick();
        }
    }
    public void AddBrick()
    {
        pos = PlayerPos.position;
        topBrick = Instantiate(BrickPrefab, pos, Quaternion.Euler(90, 0, -180), listBrick.transform); //Tao gach
        pos.y = topBrick.transform.position.y + 0.3f; //Position moi cho player
        PlayerPos.position = pos;
        player.score++;
        player.ani.Play(CONST.ANI_ADDBIRCK, 0, 0.5f);
    }
}
