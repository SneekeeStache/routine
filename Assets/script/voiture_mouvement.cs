using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiture_mouvement : MonoBehaviour
{
    Renderer renderVoiture;
    public bool arret = false;
    public float max_speed;
    public float ralentisement;
    public float acceleration;
    float speed;
    public float duree_rotation_droite;

    public float duree_rotation_gauche;

    float limitTimer = 15f;
    public float distance_raycast;
    public float distance_raycast2;

    bool explode;

    bool explosionChain;

    public float force = 10f;

    public GameObject EXPLOSION;
    public GameObject origin_cast;

    public GameObject rendererGO;

    Rigidbody carBody;

    public bool timerStart;

    public float timer = 0f;

    float timerExplosion = 0f;

    float limitTimerExplosion = 0.1f;

    float random;

    GameObject arrive;

    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        arrive = GameObject.Find("arrivé");
        carBody = GetComponent<Rigidbody>();
        renderVoiture = rendererGO.GetComponent<Renderer>();
        renderVoiture.material.color = Random.ColorHSV(0f,1f,0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionChain)
        {
            timerExplosion += Time.deltaTime;
            if (timerExplosion >= limitTimerExplosion)
            {
                carBody.AddForce(new Vector3(Random.Range(-force, force), force, Random.Range(-force, force)), ForceMode.VelocityChange);
                Instantiate(EXPLOSION, transform.position, transform.rotation);
                FMODUnity.RuntimeManager.PlayOneShot("event:/EXPLOSION");
                timerExplosion = 0;
                explosionChain = false;
            }

        }
        if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
        if (!arret)
        {
            speed = Mathf.Lerp(speed, max_speed, acceleration);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0, ralentisement);
        }

        transform.position -= transform.forward * speed * Time.deltaTime;
        if (timerStart == true)
        {
            timer += Time.deltaTime;
            if (timer >= limitTimer)
            {
                iTween.RotateTo(gameObject, new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y - 90, transform.rotation.z), duree_rotation_gauche);
                timerStart = false;
                timer = 0;
            }
        }
        RaycastHit hit;
        RaycastHit hit2;
        if (Physics.Raycast(origin_cast.transform.position, origin_cast.transform.TransformDirection(Vector3.forward), out hit2, distance_raycast2))
        {
            if (hit2.collider.gameObject.CompareTag("trigger_feu"))
            {
                arret = false;
            }
        }
        else
        {
            if (Physics.Raycast(origin_cast.transform.position, origin_cast.transform.TransformDirection(Vector3.forward), out hit, distance_raycast))
            {
                print(hit.collider.gameObject);
                if (hit.collider.gameObject.CompareTag("trigger_feu"))
                {
                    arret = true;
                }
                else if (hit.collider.gameObject.CompareTag("voiture"))
                {
                    arret = hit.collider.gameObject.GetComponent<voiture_mouvement>().arret;
                }
                else if ((!hit.collider.gameObject.CompareTag("trigger_feu")) || (!hit.collider.gameObject.CompareTag("voiture")))
                {
                    arret = false;
                }



            }
            else
            {
                arret = false;
            }
        }
        Debug.DrawRay(origin_cast.transform.position, Vector3.forward * distance_raycast, Color.red);

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("triggerdroite"))
        {
            iTween.RotateTo(gameObject, new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 90, transform.rotation.z), duree_rotation_droite);
        }

        if (other.CompareTag("triggergauche"))
        {
            limitTimer = 0.05f;
            timerStart = true;
        }

        if (other.CompareTag("triggergauchedroite"))
        {
            random = Random.Range(0, 100);
            if (random <= 50)
            {
                iTween.RotateTo(gameObject, new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 90, transform.rotation.z), duree_rotation_droite);
            }
            else
            {
                limitTimer = 0.3f;
                timerStart = true;
            }
        }

        if (other.CompareTag("triggerdroitdroite"))
        {
            random = Random.Range(0, 100);
            if (random <= 50)
            {
                iTween.RotateTo(gameObject, new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 90, transform.rotation.z), duree_rotation_droite);
            }
            else
            {

            }
        }

        if (other.CompareTag("triggerdroitgauche"))
        {
            random = Random.Range(0, 100);
            if (random <= 50)
            {

            }
            else
            {
                limitTimer = 0.15f;
                timerStart = true;
            }
        }

        if (other.CompareTag("triggerpartout"))
        {
            random = Random.Range(0, 100);
            if (random <= 33)
            {
                limitTimer = 0.3f;
                timerStart = true;
            }
            else if (random >= 66)
            {
                iTween.RotateTo(gameObject, new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 90, transform.rotation.z), duree_rotation_droite);
            }
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.collider.tag == "map" || other.collider.tag == "voiture") && explode == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/EXPLOSION");
            explode = true;
            carBody.AddForce(new Vector3(Random.Range(-force, force), force, Random.Range(-force, force)), ForceMode.Impulse);
            Instantiate(EXPLOSION, transform.position, transform.rotation);
        }
        if (explode)
        {
            if (other.collider.tag == "voiture")
            {
                carBody.AddForce(new Vector3(Random.Range(-force, force), force, Random.Range(-force, force)), ForceMode.Impulse);
                FMODUnity.RuntimeManager.PlayOneShot("event:/EXPLOSION");
                Instantiate(EXPLOSION, transform.position, transform.rotation);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EXPLOSION" && explode == false)
        {
            explosionChain = true;
            explode = true;

        }
        if (other.tag == "tunnelDestroy")
        {
            Destroy(gameObject);
        }
    }
}
