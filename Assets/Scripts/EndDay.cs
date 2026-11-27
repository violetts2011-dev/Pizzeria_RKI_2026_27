using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class EndDay : FinalCook
{
    [SerializeField] private GameObject _bookPanel;
    [SerializeField] private GameObject _Panel;
    [SerializeField] private TMP_Text _textTime;
    [SerializeField] private TMP_Text _ordersText;
    [SerializeField] private TMP_Text _moneyText;
    private float _tl = 600f;
    [SerializeField] private GameObject _camera;
    void Start()
    {
       _bookPanel.SetActive(false);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (_tl > 0)
        {
            int minutes = Mathf.FloorToInt(_tl / 60);
            int seconds = Mathf.FloorToInt(_tl % 60);
            string formattedTime = $"Осталось рабочего времени: {minutes:D2}:{seconds:D2}";
            _textTime.text = formattedTime;
            yield return new WaitForSeconds(1);
            _tl -= 1;
        }
        _bookPanel.SetActive(true);
        _Panel.SetActive(false);
        _ordersText.text = chet.ToString();
        _moneyText.text = money.ToString();

        _camera.GetComponent<ControllPlayer>().enabled = false;
    } 
    
}
