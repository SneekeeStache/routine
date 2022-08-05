using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feu_en_4 : MonoBehaviour
{
    public GameObject feu1;
    public GameObject feu2;
    public GameObject feu3;
    public GameObject feu4;

    public GameObject feuVert1;
    public GameObject feuVert2;
    public GameObject feuVert3;
    public GameObject feuVert4;

    public GameObject feuRouge1;
    public GameObject feuRouge2;
    public GameObject feuRouge3;
    public GameObject feuRouge4;


    public bool feu1_bool;
    public bool feu2_bool;
    public bool feu3_bool;
    public bool feu4_bool;

    public float timer;
    float time_timer;
    // Start is called before the first frame update
    void Start()
    {
        time_timer=timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(time_timer > 0){
            time_timer -= Time.deltaTime;
        }else if (time_timer <= 0){
            if(feu1_bool){
                feuRouge1.SetActive(false);
                feuVert1.SetActive(true);
                feu1_bool=false;
            }else{
                feuRouge1.SetActive(true);
                feuVert1.SetActive(false);
                feu1_bool=true;
            }
            if(feu2_bool){
                feuRouge2.SetActive(false);
                feuVert2.SetActive(true);
                feu2_bool=false;
            }else{
                feuRouge2.SetActive(true);
                feuVert2.SetActive(false);
                feu2_bool=true;
            }
            if(feu3_bool){
                feuRouge3.SetActive(false);
                feuVert3.SetActive(true);
                feu3_bool=false;
            }else{
                feuRouge3.SetActive(true);
                feuVert3.SetActive(false);
                feu3_bool=true;
            }
            if(feu4_bool){
                feuRouge4.SetActive(false);
                feuVert4.SetActive(true);
                feu4_bool=false;
            }else{
                feuRouge4.SetActive(true);
                feuVert4.SetActive(false);
                feu4_bool=true;
            }
            time_timer=timer;
        }

        if(!feu1_bool){
            feu1.SetActive(false);
        }else{
            feu1.SetActive(true);
        }
        if(!feu2_bool){
            feu2.SetActive(false);
        }else{
            feu2.SetActive(true);
        }
        if(!feu3_bool){
            feu3.SetActive(false);
        }else{
            feu3.SetActive(true);
        }
        if(!feu4_bool){
            feu4.SetActive(false);
        }else{
            feu4.SetActive(true);
        }
    }
}
