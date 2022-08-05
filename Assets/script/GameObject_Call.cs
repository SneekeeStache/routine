using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GameObject_Call : MonoBehaviour
{
    public GameObject ShadowRoute;
    public GameObject ShadowRouteEnT;
    public GameObject ShadowRouteCroix;
    public GameObject ShadowRouteVirage;
    public GameObject ShadowVoiture;
    public GameObject ShadowTunnel;
    public GameObject ShadowImmeuble;
    
    public GameObject UI_construct;
    

    public GameObject road;
    public GameObject cars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool is_mouse_over_ui()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
