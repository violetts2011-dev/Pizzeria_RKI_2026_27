using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    [SerializeField] private Transform _cam;

    [SerializeField] private List<int> posit = new List<int> { -22, -2, -18 };
    [SerializeField] private int t = 1;
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLevel(-1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLevel(1);
        }

        if (_cam == null) return;

        Vector3 target = new Vector3(posit[t], _cam.position.y, _cam.position.z);

        _cam.position = Vector3.MoveTowards(
            _cam.position,
            target,
            speed * Time.deltaTime
        );
    }

    private void ChangeLevel(int k)
    {
        int nI = t + k;

        if (nI < 0 || nI >= posit.Count)
        {
            return;
        }

        t = nI;
    }
}
