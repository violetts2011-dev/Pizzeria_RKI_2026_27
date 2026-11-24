using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private TMP_Text _orderText;
    public List<string>  result = new List<string>();

    [SerializeField]
    private List<string> toppings = new List<string>
    {"пепперони", "грибами", "колбасками", "базиликом", "оливками", "луком"};

    private void Start()
    {
        ShowOrder();
    }

    public void ShowOrder()
    {
        var pool = new List<string>(toppings);
        result = new List<string>();
        int n = Random.Range(2, 2);

        for (int i = 0; i < n; i++)
        {
            int idx = Random.Range(0, pool.Count);
            result.Add(pool[idx]);
            pool.RemoveAt(idx);
        }

        _orderText.text = "Сделайте мне пиццу с \n" + string.Join(" и ", result);
    }
}
