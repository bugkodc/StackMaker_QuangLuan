using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private int scoreWin;
    private bool isPlay;
    public GameObject win;
    public ParticleSystem[] particleSystems;
    private Player player;
    private void Awake() 
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(isPlay)
        {
            EndAnimation(); 
        }
        else
        {
            StopEndAnimation(); 
        }
    }
    void OnTriggerEnter(Collider other)  
    {
        if (player.score < scoreWin) return;
        if(other.CompareTag(CONST.TAG_PLAYER))
        {
            isPlay= true;                      
            player.isWin = true;              
        }
    }
    void EndAnimation()
    {
        win.SetActive(true);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
           
        }
    }
    void StopEndAnimation()
    {
        win.SetActive(false);
        foreach( ParticleSystem particle in particleSystems)
        {
            particle.Pause();
            particle.gameObject.SetActive(false);
        }
    }
}
