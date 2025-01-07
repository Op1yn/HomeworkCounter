using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _amount = 0;
    private float _delayTime = 0.5f;
    private bool _isWork = false;
    public event Action AmountChanged;
    private Coroutine _coroutineTimer;

    public int Amount => _amount;

    public void Start()
    {
        _coroutineTimer = StartCoroutine(TimerAdding());
    }

    private void Update()
    {
        SwitchTimer();
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutineTimer);
    }

    private void AddValue()
    {
        if (_isWork)
        {
            _amount++;
            AmountChanged?.Invoke();
        }
    }

    private IEnumerator TimerAdding()
    {
        var wait = new WaitForSeconds(_delayTime);

        while (true)
        {
            AddValue();
            yield return wait;
        }
    }

    private void SwitchTimer()
    {
        if (Input.GetMouseButtonDown(0) && _isWork == true)
        {
            _isWork = false;
        }
        else if (Input.GetMouseButtonDown(0) && _isWork == false)
        {
            _isWork = true;
        }
    }
}
