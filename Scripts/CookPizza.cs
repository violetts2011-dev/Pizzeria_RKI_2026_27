using UnityEngine;
using System.Collections.Generic;

public class CookPizza : MonoBehaviour
{
    [Header("Объекты, которые соприкасаются")]
    public GameObject sousper1;
    public GameObject testoper1;
    public GameObject sheeseper1;
    public GameObject peperper1;
    public GameObject gribper1;
    public GameObject kolbasper1;
    public GameObject basilper1;

    [Header("Объекты, которые включатся при касании")]
    public GameObject sous1;
    public GameObject sous2;
    public GameObject testo1;
    public GameObject testo2;
    public GameObject sheese1;
    public GameObject sheese2;
    public GameObject peper1;
    public GameObject peper2;
    public GameObject grib1;
    public GameObject grib2;
    public GameObject kolbas1;
    public GameObject kolbas2;
    public GameObject basil1;
    public GameObject basil2;

    [Header("Куда телепортируется этот объект")]
    public Vector3 teleportPosition1;
    public Vector3 teleportPosition2;
    public Vector3 teleportPosition3;
    public Vector3 teleportPosition4;
    public Vector3 teleportPosition5;
    public Vector3 teleportPosition6;
    public Vector3 teleportPosition7;

    public List<GameObject> allIngredients = new List<GameObject>();

    void Awake()
    {
        allIngredients.AddRange(new[]
        {
            sous1, sous2,
            testo1, testo2,
            sheese1, sheese2,
            peper1, peper2,
            grib1, grib2,
            kolbas1, kolbas2,
            basil1, basil2
        });
    }

    private void Start()
    {
        teleportPosition1 = sousper1.transform.position;
        teleportPosition2 = testoper1.transform.position;
        teleportPosition3 = sheeseper1.transform.position;
        teleportPosition4 = peperper1.transform.position;
        teleportPosition5 = gribper1.transform.position;
        teleportPosition6 = kolbasper1.transform.position;
        teleportPosition7 = basilper1.transform.position;
    }
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject per = other.gameObject;

        if (per == sousper1)
        {
            Process(sousper1, teleportPosition1, sous1, sous2);
        }

        if (per == testoper1)
        {
            Process(testoper1, teleportPosition2, testo1, testo2);
        }

        if (per == sheeseper1)
        {
            Process(sheeseper1, teleportPosition3, sheese1, sheese2);
        }

        if (per == peperper1)
        {
            Process(peperper1, teleportPosition4, peper1, peper2);
        }

        if (per == gribper1)
        {
            Process(gribper1, teleportPosition5, grib1, grib2);
        }

        if (per == kolbasper1)
        {
            Process(kolbasper1, teleportPosition6, kolbas1, kolbas2);
        }

        if (per == basilper1)
        {
            Process(basilper1, teleportPosition7, basil1, basil2);
        }
    }

    private void Process(GameObject per, Vector3 teleport, GameObject obj1, GameObject obj2)
    {
        obj1.SetActive(true);
        obj2.SetActive(true);
        per.transform.position = teleport;
        peremobject mover = per.GetComponent<peremobject>();
        mover.speed = 0f;
    }
}
