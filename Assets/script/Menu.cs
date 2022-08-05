using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject jouer;
    public GameObject credit;
    public GameObject quiter;
    public GameObject retour;
    public GameObject image_credit;
    // Start is called before the first frame update
    void Start()
    {
        retour.SetActive(false);
        image_credit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startjeu()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Menu");
        SceneManager.LoadScene("main",LoadSceneMode.Single);
    }

    public void exit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Echap");
        Application.Quit();
    }

    public void bouton_credit(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Echap");
        jouer.SetActive(false);
        credit.SetActive(false);
        quiter.SetActive(false);
        retour.SetActive(true);
        image_credit.SetActive(true);
    }

    public void bouton_retour(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton_Menu");
        jouer.SetActive(true);
        credit.SetActive(true);
        quiter.SetActive(true);
        retour.SetActive(false);
        image_credit.SetActive(false);
    }


}
