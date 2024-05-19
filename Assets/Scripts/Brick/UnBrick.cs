using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    [SerializeField] Material UnBrickmaterial;
    [SerializeField] GameObject RenBrick;
    private Collider unbrickCollider;

    private Player player;
    private GameObject ListBrick;
    private Transform PlayerPos;
    private GameObject buttomBrick;

    private void Awake() 
    {
       PlayerPos = GameObject.FindGameObjectWithTag(CONST.TAG_POSE_PLAYER).transform;
       ListBrick = GameObject.Find(CONST.GO_LISTBRICK);
       player = FindObjectOfType<Player>();
       unbrickCollider = GetComponent<Collider>();
    }

    //Phat hien va cham voi Player va bo gach di
    private void OnTriggerEnter(Collider other) 
    {
        Vector3 pos = PlayerPos.position;
        
        if(other.CompareTag(CONST.TAG_PLAYER) && ListBrick.transform.childCount>1)
        {
            Renderer brickRender = RenBrick.GetComponent<Renderer>(); //Get render gach duoi dat de doi material

            int id_buttom = ListBrick.transform.childCount -1; //index gach cuoi trong list gach gan tren player
            buttomBrick = ListBrick.transform.GetChild(id_buttom).gameObject;
            pos.y = buttomBrick.transform.position.y; //get new position cho Player
            Destroy(buttomBrick);    //Destroy gach

            brickRender.transform.position += Vector3.up*0.3f;  //Xu ly render gach duoi nen dat
            brickRender.material = UnBrickmaterial;

            player.score--;;//giam diem
            // up score 

            player.ani.Play(CONST.ANI_UNBRICK, 0, 0.5f); //Xu ly anin

        }
        PlayerPos.position = pos;

    }
    //Xu ly sau khi va cham
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            unbrickCollider.enabled= false;  //Set collider = false de khong va cham lai
        }
    }
}
