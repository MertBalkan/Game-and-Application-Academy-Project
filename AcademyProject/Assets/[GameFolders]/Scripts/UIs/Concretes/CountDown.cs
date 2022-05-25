using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Image _time;
    [SerializeField] private Text _timeText;
    [SerializeField]private float _currentTime;
    [SerializeField] private float _duration;
    void Start()
    {
        _currentTime = _duration;
        float minute = Mathf.FloorToInt(_currentTime / 60);
        float seconds = Mathf.FloorToInt(_currentTime % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minute, seconds);
        StartCoroutine(CountdownTime());
        
    }

    private IEnumerator CountdownTime()
    {
        while (_currentTime >= 0)
        {
            _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            float minute = Mathf.FloorToInt(_currentTime / 60);
            float seconds = Mathf.FloorToInt(_currentTime % 60);
            _timeText.text = string.Format("{0:00}:{1:00}", minute, seconds);
            yield return new WaitForSeconds(1f);
            _currentTime--;
            _time.fillAmount = _currentTime;
        }
        yield return null;
    }
}
