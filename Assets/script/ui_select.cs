using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_select : MonoBehaviour
{
    // Start is called before the first frame update
    public int select;
    bool construct=false;
    public GameObject ui_cars;
    public GameObject ui_route;
    public GameObject ui_T;
    public GameObject ui_croix;
    public GameObject ui_virage;
    public GameObject ui_maison;

    public GameObject ui_tunnel;
    public GameObject GameObject_call;
    GameObject_Call GOCscript;
    
    void Start()
    {
        GOCscript=GameObject_call.GetComponent<GameObject_Call>();
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(construct){
            ui_cars.SetActive(true);
            ui_route.SetActive(true);
            ui_croix.SetActive(true);
            ui_T.SetActive(true);
            ui_croix.SetActive(true);
            ui_virage.SetActive(true);
            ui_tunnel.SetActive(true);
            ui_maison.SetActive(true);
        }else{
            ui_cars.SetActive(false);
            ui_route.SetActive(false);
            ui_croix.SetActive(false);
            ui_T.SetActive(false);
            ui_croix.SetActive(false);
            ui_virage.SetActive(false);
            ui_tunnel.SetActive(false);
            ui_maison.SetActive(false);
        }
        
    }
    public void bouton_construction(){
        if(construct){
            FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Fermeture");
            construct=false;
        }else{
            FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
            construct=true;
        }
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=0;
    }
    public void bouton_voiture(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(true);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=1;
    }

    public void bouton_Route(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(true);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=2;
    }
    public void bouton_Route_T(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(true);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=3;
    }
    public void bouton_Route_croix(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(true);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=4;
    }
    public void bouton_Route_virage(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(true);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=5;
    }

    public void bouton_tunnel(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(true);
        GOCscript.ShadowImmeuble.SetActive(false);
        select=6;
    }

    public void bouton_maison(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Interagir");
        GOCscript.ShadowVoiture.SetActive(false);
        GOCscript.ShadowRoute.SetActive(false);
        GOCscript.ShadowRouteCroix.SetActive(false);
        GOCscript.ShadowRouteEnT.SetActive(false);
        GOCscript.ShadowRouteVirage.SetActive(false);
        GOCscript.ShadowTunnel.SetActive(false);
        GOCscript.ShadowImmeuble.SetActive(true);
        select=7;
    }
}
