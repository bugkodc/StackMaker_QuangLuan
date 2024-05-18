using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class xu ly player: Move, AddBrick, RemoveBrick
public class Player : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private float speed;
    [SerializeField] private GameObject ListBrick;
    private MovePlayer movePlayer;
    private Vector3 dir;
    public Animator ani;
    public float score =0f;
    public bool isWin;
    public EDirection eDirection;
    public bool isPlay= false;
    private void Awake() 
    {
        movePlayer = GetComponent<MovePlayer>();
        ani = playerModel.GetComponent<Animator>();
        ListBrick = GameObject.Find(CONST.GO_LISTBRICK);

    }
    private void Start() 
    {
        OnInit();
    }
    private void Update() 
    {
        CheckPlay();
       /* CheckWin();*/
    }
    //Ham khoi tao cac tham so cho Player khi bat dau 1 level
    public void OnInit()
    {
        isPlay= false; 
        isWin = false;
        eDirection= EDirection.None;
        ClearChildren();
        playerModel.transform.position = transform.position;
        ani.Play(CONST.ANI_IDLE, 0, 0.25f);
    }
    protected virtual void CheckPlay()
    {
        if (isPlay && !isWin) //Da an play va chua den dich
        {
            MouseInput.Instance.Swipe();
            eDirection = MouseInput.Instance.GetEDirection(); //Get huong di chuyen tu mouse
            Vector3 target = movePlayer.GetTargetPosition(eDirection); //Tim diem dich can di chuyen den
            movePlayer.MoveToTargetPosition(target, speed); //Di chuyen den diem dich
        }
    }
   /* private void CheckWin()
    {
        if (isWin) //Neu den diem dich
        {
            //ani.Play(CONST.ANI_WIN); //Thay doi Anin
            //LevelManager.Instance.OnFinish(); // Quan ly level show UI Finish
        }

    }*/
    public void ClearChildren()
    {
        foreach (Transform child in ListBrick.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
