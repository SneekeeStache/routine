using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_echap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bouton_quitter;
    public GameObject bouton_reset;
    public GameObject logo;
    public GameObject lightmusique;
    bool affiché=false;
    void Start()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        lightmusique.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(affiché==true){
                affiché=false;
            }else if(affiché == false){
                affiché=true;
            }
        }
        if(affiché){
            bouton_quitter.SetActive(true);
            bouton_reset.SetActive(true);
            logo.SetActive(true);
        }
        else{
            bouton_quitter.SetActive(false);
            bouton_reset.SetActive(false);
            logo.SetActive(false);
        }
    }
    public void quitter(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Echap");
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        lightmusique.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
    public void restart(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Menu");
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        lightmusique.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        SceneManager.LoadScene("main",LoadSceneMode.Single);
        
    }
}
