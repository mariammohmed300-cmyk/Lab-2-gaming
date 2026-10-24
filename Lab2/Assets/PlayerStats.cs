using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health =3;
    public int lives=3;
    private float flickerTime =0f;
    public float flickerDuration=0.1f;
    private SpriteRenderer sr;
    public bool isImmue=false;
    private float immunityTime=0f;
    public float immunityDuration=1.5f;
    void Start()
    {
      sr=GetComponent<SpriteRenderer> () ;
    }
    void SpriteFlicker(){
        if(flickerTime < flickerDuration){
            flickerTime = flickerTime+Time.deltaTime;
        }
        else if(flickerTime>=flickerDuration)
        {
            sr.enabled=!(sr.enabled);
            flickerTime=0;
        }
    }
    public void TakeDamge(int damage){
        if(isImmue==false){
            health=health-damage;
            if(health<0)
            health=0;
            if(lives > 0 && health==0) {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health=3;
                lives--;

            }
            else if (lives==0 && health ==0){
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:"+health.ToString());
            Debug.Log("Player Lives:"+lives.ToString());

        }
        isImmue=true;
        immunityTime=0f;
    }
    // Update is called once per frame
    void Update()
    {
       if(isImmue==true) {
        SpriteFlicker();
        immunityTime=immunityTime+Time.deltaTime;
        if(immunityTime>=immunityDuration){
            isImmue=false;
            sr.enabled=true;
        }
       }
    }
}
