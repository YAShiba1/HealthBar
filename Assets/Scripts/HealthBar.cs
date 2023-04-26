using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private Coroutine _changeValueOfBarJob;
    private float _graduationInterval = 10f;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.minValue = _player.MinHealth;
        _slider.value = _player.CurrentHealth;
    }

    public void DecreaseBar()
    {
        ChangeBarValue(-_graduationInterval);
    }

    public void IncreaseBar()
    {
        ChangeBarValue(_graduationInterval);
    }

    private IEnumerator ChangeSliderValue(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void ChangeBarValue(float valueDelta)
    {
        if (_changeValueOfBarJob != null)
        {
            StopCoroutine(_changeValueOfBarJob);
        }

        if(valueDelta < 0) 
        {
            _player.TakeDamage(Mathf.Abs(_graduationInterval));
        }
        else
        {
            _player.Healing(_graduationInterval);
        }

        _changeValueOfBarJob = StartCoroutine(ChangeSliderValue(_player.CurrentHealth));
    }
}