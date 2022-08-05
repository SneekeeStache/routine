using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement_route : MonoBehaviour
{

    // Start is called before the first frame update

    public GameObject GameObject_prefab_call;
    public GameObject GameObject_call;
    public GameObject particules;

    GameObject_Call GOCscript;

    public string albedo;

    

    GameObject voitureInstance;

    public GameObject NUKE;
    ui_select ui_script;
    GameObject_Prefab GOPCscript;

    int select;
    Vector3 position_route;
    Vector3 rotation_object = new Vector3(0, 180, 0);
    void Start()
    {
        GOCscript = GameObject_call.GetComponent<GameObject_Call>();
        GOPCscript = GameObject_prefab_call.GetComponent<GameObject_Prefab>();
        ui_script = GOCscript.UI_construct.GetComponent<ui_select>();

    }

    // Update is called once per frame
    void Update()
    {
        
        select = ui_script.select;

        if (Input.GetButtonDown("rotation"))
        {
            if (rotation_object.y >= 270)
            {
                rotation_object.y = 0;
            }
            else
            {
                rotation_object.y += 90;
            }

        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            position_route = new Vector3(Mathf.Round(hit.point.x), 0.11f, Mathf.Round(hit.point.z));


            GOCscript.ShadowRoute.transform.position = position_route;
            GOCscript.ShadowRoute.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowRouteEnT.transform.position = position_route;
            GOCscript.ShadowRouteEnT.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowRouteCroix.transform.position = position_route;
            GOCscript.ShadowRouteCroix.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowRouteVirage.transform.position = position_route;
            GOCscript.ShadowRouteVirage.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowVoiture.transform.position = hit.point;
            GOCscript.ShadowVoiture.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowTunnel.transform.position = position_route;
            GOCscript.ShadowTunnel.transform.rotation = Quaternion.Euler(rotation_object);

            GOCscript.ShadowImmeuble.transform.position = position_route;
            GOCscript.ShadowImmeuble.transform.rotation = Quaternion.Euler(rotation_object);

            //Debug.Log(hit.collider.gameObject.transform.rotation.eulerAngles);
            //Debug.Log(hit.collider.tag);
            //Debug.Log(hit.collider.gameObject.transform.parent);


            if (Input.GetMouseButton(0))
            {
                float random= Random.Range(1f,6f);
                switch (select)
                {

                    case 2:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            Instantiate(GOPCscript.Route, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                        }
                        break;

                    case 3:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            Instantiate(GOPCscript.RouteEnT, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                        }
                        break;

                    case 4:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            Instantiate(GOPCscript.RouteCroix, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                        }
                        break;

                    case 5:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            Instantiate(GOPCscript.RouteVirage, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                        }
                        break;
                    case 6:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            Instantiate(GOPCscript.Tunnel, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                        }
                        break;
                    case 7:
                        if ((!hit.collider.gameObject.CompareTag("Route") && !hit.collider.gameObject.CompareTag("RouteSens1") && !hit.collider.gameObject.CompareTag("RouteSens2")) && !GOCscript.is_mouse_over_ui())
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/RouteConstru");
                            if(random<=2){
                                Instantiate(GOPCscript.maison1, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                            }else if(random>2 && random<=4){
                                Instantiate(GOPCscript.maison2, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                            }else if(random>4){
                                Instantiate(GOPCscript.maison3, position_route, Quaternion.Euler(rotation_object), GOCscript.road.transform);
                            }
                        }
                        break;
                }

            }
            if (Input.GetMouseButton(1) && !hit.collider.gameObject.CompareTag("map"))
            {
                if (hit.collider.tag == "RouteSens1" || hit.collider.tag == "RouteSens2")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/RouteDestruction");
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                    Instantiate(particules,hit.point,Quaternion.identity);
                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/RouteDestruction");
                    Destroy(hit.collider.gameObject);
                    Instantiate(particules,hit.point,Quaternion.identity);
                    
                }

            }
            if (Input.GetMouseButtonDown(0))
            {
                if (select == 1)
                {
                    if (!hit.collider.gameObject.CompareTag("voiture") && !GOCscript.is_mouse_over_ui())
                    {
                        FMODUnity.RuntimeManager.PlayOneShot("event:/VoitureConstru");
                        if ((hit.collider.gameObject.tag == "RouteSens1" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 0, 0)) || (hit.collider.gameObject.tag == "RouteSens2" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 180, 0)))
                        {
                            voitureInstance = Instantiate(GOPCscript.voiture, hit.transform.position + new Vector3(0,0.2f,0), Quaternion.Euler(0, 0, 0), GOCscript.cars.transform);
                            
                        }
                        else if ((hit.collider.gameObject.tag == "RouteSens1" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 180, 0)) || (hit.collider.gameObject.tag == "RouteSens2" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 0, 0)))
                        {
                            Instantiate(GOPCscript.voiture, hit.transform.position + new Vector3(0,0.2f,0), Quaternion.Euler(0, 180, 0), GOCscript.cars.transform);
                            
                        }
                        else if ((hit.collider.gameObject.tag == "RouteSens1" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 90, 0)) || (hit.collider.gameObject.tag == "RouteSens2" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 270, 0)))
                        {
                            Instantiate(GOPCscript.voiture, hit.transform.position + new Vector3(0,0.2f,0), Quaternion.Euler(0, 90, 0), GOCscript.cars.transform);
                            
                        }
                        else if ((hit.collider.gameObject.tag == "RouteSens1" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 270, 0)) || (hit.collider.gameObject.tag == "RouteSens2" && hit.collider.gameObject.transform.rotation.eulerAngles == new Vector3(0, 90, 0)))
                        {
                            Instantiate(GOPCscript.voiture, hit.transform.position + new Vector3(0,0.2f,0), Quaternion.Euler(0, 270, 0), GOCscript.cars.transform);
                            
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Instantiate(NUKE, new Vector3(hit.point.x, 100f, hit.point.z), Quaternion.Euler(0, 0, 0));
            }

        }

    }
}
