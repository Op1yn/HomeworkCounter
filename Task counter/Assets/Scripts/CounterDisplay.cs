using UnityEngine;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.AmountChanged += ShowValue;
    }

    private void OnDisable()
    {
        _counter.AmountChanged -= ShowValue;
    }

    private void ShowValue()
    {
        Debug.Log($"{_counter.Amount}");
    }
}
