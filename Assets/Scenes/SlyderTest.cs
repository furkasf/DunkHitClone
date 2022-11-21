using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SlyderTest : MonoBehaviour
{
    public Slider slider;

    public float _timer;
    public float _currentRemainTime;
    public int _ComboCounter;
    private const float _maxTime = 5f;

   

    //tests
    [Button]
    private void Test1() => slider.value += 0.05f;

    [Button]
    private void Test2() => slider.value -= 0.05f;
}