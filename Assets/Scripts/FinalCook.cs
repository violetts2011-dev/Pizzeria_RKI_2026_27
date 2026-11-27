using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalCook : MonoBehaviour
{
    public TMP_Text tmoney;
    [SerializeField] private TMP_Text tzakac;
    [SerializeField] private GameObject cookpizza;
    [SerializeField] private GameObject controlt;
    protected static int money = 0;
    public List<GameObject> ingr = new List<GameObject>();
    [SerializeField] private GameObject pizza;
    [SerializeField] private Vector3 vpizza;

    [Header("Очередь из трёх объектов")]
    [SerializeField] private List<GameObject> lineObjects = new List<GameObject>();
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private Vector3 pos3;

    private CookPizza cook;
    private TextController textController;

    [Header("Счетчик")]
    public TMP_Text tchet;
    protected static int chet;

    private void Start()
    {
        vpizza = pizza.transform.position;
        cook = cookpizza.GetComponent<CookPizza>();
        textController = controlt.GetComponent<TextController>();
        pos1 = lineObjects[0].transform.position;
        pos2 = lineObjects[1].transform.position;
        pos3 = lineObjects[2].transform.position;
    }

    private void MoveLine()
    {
        lineObjects[0].transform.position = pos3;
        lineObjects[1].transform.position = pos1;
        lineObjects[2].transform.position = pos2;

        GameObject first = lineObjects[0];
        lineObjects[0] = lineObjects[1];
        lineObjects[1] = lineObjects[2];
        lineObjects[2] = first;
    }

    public void Final1()
    {
        if (cook == null)
        {
            return;
        }

        foreach (var ingredient in cook.allIngredients)
        {
            if (ingredient != null)
            {
                ingredient.SetActive(false);
            }
        }

        ResetSpeeds();
        MoveLine();
        Shet();

        Invoke(nameof(ps), 3f);
        tzakac.text = "Заказ выполнен!";
        money += 100;
        tmoney.text = "Денег: " + money;
        textController.ShowOrder();
        Invoke(nameof(DeletText), 5f);
    }

    public void Final2()
    {
        if (cook == null)
        {
            return;
        }

        foreach (var ingredient in cook.allIngredients)
        {
            if (ingredient != null)
            {
                ingredient.SetActive(false);
            }
        }

        ResetSpeeds();

        Invoke(nameof(ps), 3f);
        tzakac.text = "Заказ не выполнен!";
        money -= 50;
        tmoney.text = "Денег: " + money;
        Invoke(nameof(DeletText), 5f);
    }

    private void ResetSpeeds()
    {
        cook.sousper1.GetComponent<peremobject>().speed = 20f;
        cook.testoper1.GetComponent<peremobject>().speed = 20f;
        cook.sheeseper1.GetComponent<peremobject>().speed = 20f;
        cook.peperper1.GetComponent<peremobject>().speed = 20f;
        cook.gribper1.GetComponent<peremobject>().speed = 20f;
        cook.kolbasper1.GetComponent<peremobject>().speed = 20f;
        cook.basilper1.GetComponent<peremobject>().speed = 20f;
        cook.onionper1.GetComponent<peremobject>().speed = 20f;
        cook.olivkaper1.GetComponent<peremobject>().speed = 20f;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ingr.Clear();

        GameObject testo = null;
        GameObject sous = null;
        GameObject cheese = null;
        GameObject bazil = null;
        GameObject grib = null;
        GameObject peper = null;
        GameObject kolbas = null;
        GameObject onion = null;
        GameObject olivka = null;

        Transform testoTransform = other.transform.Find("pz_crust");
        if (testoTransform != null)
        {
            testo = testoTransform.gameObject;
        }

        Transform sousTransform = other.transform.Find("sauce_bub5");
        if (sousTransform != null)
        {
            sous = sousTransform.gameObject;
        }

        Transform cheeseTransform = other.transform.Find("cheese_b2");
        if (cheeseTransform != null)
        {
            cheese = cheeseTransform.gameObject;
        }

        Transform bazilTransform = other.transform.Find("Toppings/basil2_l_ol");
        if (bazilTransform != null)
        {
            bazil = bazilTransform.gameObject;
        }

        Transform gribTransform = other.transform.Find("Toppings/mush1_stem_ol");
        if (gribTransform != null)
        {
            grib = gribTransform.gameObject;
        }

        Transform peperTransform = other.transform.Find("Toppings/pep10_p_ol");
        if (peperTransform != null)
        {
            peper = peperTransform.gameObject;
        }

        Transform kolbasTransform = other.transform.Find("Toppings/saus4_s_ol");
        if (kolbasTransform != null)
        {
            kolbas = kolbasTransform.gameObject;
        }

        Transform onionTransform = other.transform.Find("Toppings/good_pizza_single_scene1");
        if (onionTransform != null)
        {
            onion = onionTransform.gameObject;
        }

        Transform olivkaTransform = other.transform.Find("Toppings/good_pizza_single_scene2");
        if (olivkaTransform != null)
        {
            olivka = olivkaTransform.gameObject;
        }

        List<string> orderList = textController.result;

        if (ContainsWord(orderList, "пепперони"))
        {
            ingr.Add(peper);
        }

        if (ContainsWord(orderList, "базиликом"))
        {
            ingr.Add(bazil);
        }

        if (ContainsWord(orderList, "грибами"))
        {
            ingr.Add(grib);
        }

        if (ContainsWord(orderList, "колбасками"))
        {
            ingr.Add(kolbas);
        }

        if (ContainsWord(orderList, "луком"))
        {
            ingr.Add(onion);
        }

        if (ContainsWord(orderList, "оливками"))
        {
            ingr.Add(olivka);
        }

        bool allToppingsActive = true;

        foreach (var t in ingr)
        {
            if (t == null)
            {
                allToppingsActive = false;
                break;
            }

            if (t.activeSelf == false)
            {
                allToppingsActive = false;
                break;
            }
        }

        if (testo == null || sous == null || cheese == null)
        {
            Final2();
        }
        else
        {
            if (testo.activeSelf && sous.activeSelf && cheese.activeSelf && allToppingsActive)
            {
                Final1();
            }
            else
            {
                Final2();
            }
        }
    }

    private bool ContainsWord(List<string> orderList, string word)
    {
        if (orderList == null)
        {
            return false;
        }

        foreach (string s in orderList)
        {
            if (s != null)
            {
                if (s.Contains(word))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void DeletText()
    {
        tzakac.text = "";
    }

    private void ps()
    {
        pizza.transform.position = vpizza;
    }

    private void Shet()
    {
        chet += 1;
        tchet.text = "Выполнено заказов: " + chet;
    }
}
