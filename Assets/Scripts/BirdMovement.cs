using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    private bool Cooldown;
    private bool jump=false;
    private GameObject LookAt;
    public GameObject Cube1,Cube2;
    public GameObject DeathPanel;
    private int Speed;
    public GameObject dieSound,WingFlapSound;
    public Animator BirdAnimator;
    public static bool Crashed = false;

    public TextMeshProUGUI ScoreText;
    public static int Score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Score")
        {
            Score++;
            AudioSource scoreSound = other.gameObject.GetComponentInChildren<AudioSource>();
            scoreSound.Play();
        }

        if(other.tag == "Obstacle")
        {
            Instantiate(dieSound,transform.position,transform.rotation);
            Crashed = true;
            BirdAnimator.SetBool("Dead", true);
            StartCoroutine(CooldownRefresh(1));
            LevelSpawner.StartGame = false;
            foreach(var go in GameObject.FindGameObjectsWithTag("slurs"))
            {
                go.SetActive(false);
            }
            foreach(var go in GameObject.FindGameObjectsWithTag("Tubes"))
            {
                go.SetActive(false);
            }
            this.gameObject.SetActive(false);
            DeathPanel.SetActive(true);
        }
    }
    
    private void Start()
    {
        Crashed = false;
        this.gameObject.SetActive(true);
        Score = 0;
        DeathPanel.SetActive(false);
        Controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(!LevelSpawner.StartGame){
            return;
        }
        ScoreText.text = "Score: " + Score.ToString();
        Velocity.y += -15 * Time.deltaTime;

        if ((Input.GetKey("space") || jump) && Cooldown == false && Crashed==false)
        {
            jump = false;
            Instantiate(WingFlapSound,transform.position,transform.rotation);
            Cooldown = true;
            Velocity.y = 0;
            Velocity.y = Mathf.Sqrt(15);
            BirdAnimator.SetBool("Fly", true);
            StartCoroutine(CooldownRefresh(0.3f));
        }

        if(Velocity.y > 0)
        {
            LookAt = Cube1;
            Speed = 4;
        }
        else
        {
            LookAt = Cube2;
            Speed = 2;
        }

        Quaternion lookOnLook = Quaternion.LookRotation(LookAt.transform.position - transform.position);

        transform.rotation =
        Quaternion.Slerp(transform.rotation, lookOnLook, Speed * Time.deltaTime);

        Controller.Move(Velocity * Time.deltaTime);
    }

    private IEnumerator CooldownRefresh(float time)
    {
        yield return new WaitForSeconds(time);
        Cooldown = false;
        BirdAnimator.SetBool("Fly", false);
        BirdAnimator.SetBool("Dead",false);
    }
    public void Jump()
    {
        jump=true;
    }
}