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
        player = LevelManager.Instance.player;
    }
    void Update()
    {
        CheckPlayAnimation();
    }
    protected virtual void CheckPlayAnimation()
    {
        if (isPlay)
        {
            EndAnimation();
        }
        else
        {
            StopEndAnimation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.score < scoreWin) return;
        if (other.CompareTag(CONST.TAG_PLAYER))
        {
            // win game call toi
            /* isPlay= true;                      
             player.isWin = true;*/
            player.ani.Play(CONST.ANI_WIN); //Thay doi Anin
            LevelManager.Instance.OnFinish();
        }
    }
    protected virtual void EndAnimation()
    {
        win.SetActive(true);
        foreach (ParticleSystem particle in particleSystems)
        {
            particle.gameObject.SetActive(true);
            particle.Play();

        }
    }
    protected virtual void StopEndAnimation()
    {
        win.SetActive(false);
        foreach (ParticleSystem particle in particleSystems)
        {
            particle.Pause();
            particle.gameObject.SetActive(false);
        }
    }
}
