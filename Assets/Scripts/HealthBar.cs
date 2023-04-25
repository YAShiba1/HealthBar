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
        StopBarCoroutine();

        _player.TakeDamage(_graduationInterval);

        _changeValueOfBarJob = StartCoroutine(ChangeBarValue(_player.CurrentHealth));
    }

    public void IncreaseBar()
    {
        StopBarCoroutine();

        _player.Healing(_graduationInterval);

        _changeValueOfBarJob = StartCoroutine(ChangeBarValue(_player.CurrentHealth));
    }

    private IEnumerator ChangeBarValue(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void StopBarCoroutine()
    {
        if (_changeValueOfBarJob != null)
        {
            StopCoroutine(_changeValueOfBarJob);
        }
    }
}