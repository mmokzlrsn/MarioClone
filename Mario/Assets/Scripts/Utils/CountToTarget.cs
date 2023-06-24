using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountToTarget : MonoBehaviour
{
    private float countDuration = 0.5f;
    TextMeshProUGUI numberText;
    float currentValue = 0, targetValue = 0;
    Coroutine _C2T;

    void Awake()
    {
        numberText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        currentValue = float.Parse(numberText.text);
        targetValue = currentValue;
    }

    IEnumerator CountTo(float targetValue, float maxValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
            numberText.text = ((int)currentValue).ToString() + "/" + maxValue.ToString();
            yield return null;
        }
    }

    IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
            numberText.text = ((int)currentValue).ToString();
            yield return null;
        }
    }

    public void SetTarget(float target, float totalValue)
    {
        targetValue = target;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue, totalValue));
    }

    public void SetTarget(float target)
    {
        targetValue = target;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }



}
