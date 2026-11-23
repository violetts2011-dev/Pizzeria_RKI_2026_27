using System.Collections.Generic;
using System.Linq;   
using TMPro;
using UnityEngine;

public class FinalCook : MonoBehaviour
{
    [SerializeField] private TMP_Text tmoney;
    [SerializeField] private TMP_Text tzakac;
    [SerializeField] private GameObject cookpizza;
    [SerializeField] private GameObject controlt;
    [SerializeField] private int money = 0;
    public List<GameObject> ingr = new List<GameObject>();
    [SerializeField] private GameObject pizza;
    [SerializeField] private Vector3 vpizza;

    private void Start()
    {
        vpizza = pizza.transform.position;
    }

    public void Final1()
    {
        var cook = cookpizza.GetComponent<CookPizza>();
        if (cook == null) return;

        foreach (var ingredient in cook.allIngredients)
        {
            if (ingredient != null)
                ingredient.SetActive(false);
        }
        cookpizza.GetComponent<CookPizza>().sousper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().testoper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().sheeseper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().peperper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().gribper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().kolbasper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().basilper1.GetComponent<peremobject>().speed = 20f;

        Invoke(nameof(ps), 3f);
        tzakac.text = "Заказ выполнен!";
        money += 100;
        tmoney.text = "Денег: " + money;
        controlt.GetComponent<TextController>().ShowOrder();
        Invoke(nameof(DeletText), 5f);
    }

    public void Final2()
    {
        var cook = cookpizza.GetComponent<CookPizza>();
        if (cook == null) return;

        foreach (var ingredient in cook.allIngredients)
        {
            if (ingredient != null)
                ingredient.SetActive(false);
        }

        cookpizza.GetComponent<CookPizza>().sousper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().testoper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().sheeseper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().peperper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().gribper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().kolbasper1.GetComponent<peremobject>().speed = 20f;
        cookpizza.GetComponent<CookPizza>().basilper1.GetComponent<peremobject>().speed = 20f;

        Invoke(nameof(ps), 3f);
        tzakac.text = "Заказ не выполнен!";
        money -= 50;
        tmoney.text = "Денег: " + money;
        Invoke(nameof(DeletText), 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ingr.Clear();

        GameObject testo = other.transform.Find("pz_crust")?.gameObject;
        GameObject sous = other.transform.Find("sauce_bub5")?.gameObject;
        GameObject cheese = other.transform.Find("cheese_b2")?.gameObject;
        GameObject bazil = other.transform.Find("Toppings/basil2_l_ol")?.gameObject;
        GameObject grib = other.transform.Find("Toppings/mush1_stem_ol")?.gameObject;
        GameObject peper = other.transform.Find("Toppings/pep10_p_ol")?.gameObject;
        GameObject kolbas = other.transform.Find("Toppings/saus4_s_ol")?.gameObject;

        var orderList = controlt.GetComponent<TextController>().result; 

        if (orderList.Any(s => s.Contains("пепперони"))) ingr.Add(peper);
        if (orderList.Any(s => s.Contains("базиликом"))) ingr.Add(bazil);
        if (orderList.Any(s => s.Contains("грибами"))) ingr.Add(grib);
        if (orderList.Any(s => s.Contains("колбасками"))) ingr.Add(kolbas);

        bool allToppingsActive = true;
        foreach (var t in ingr)
        {
            if (t == null || !t.activeSelf)
            {
                allToppingsActive = false;
                break;
            }
        }

        if (testo.activeSelf && sous.activeSelf && cheese.activeSelf && allToppingsActive)
        {
            Final1();
        }
        else if (testo.activeSelf && sous.activeSelf && cheese.activeSelf)
        {
            Final2();
        }
    }

    private void DeletText()
    {
        tzakac.text = "";
    }

    private void ps()
    {
        pizza.transform.position = vpizza;
    }
}
