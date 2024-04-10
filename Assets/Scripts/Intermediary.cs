using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intermediary : MonoBehaviour
{
    [SerializeField] private List<GameObject> _rootBrightList;
    [SerializeField] private GameObject _ScoreTextOBJ;

    private List<BrightnessRegulator> _brightnessRegulatorList = new List<BrightnessRegulator>();
    private Score _scoreText;
    private bool _isFirst;

    private void Awake()
    {

        foreach (GameObject rootBright in _rootBrightList)
        {
            _brightnessRegulatorList.Add(rootBright.GetComponent<BrightnessRegulator>());
        }
        _scoreText = _ScoreTextOBJ.GetComponent<Score>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _isFirst = false;
    }

    // Update is called once per frame
    void Update()
    {

        foreach (BrightnessRegulator brightness in _brightnessRegulatorList)
        {

            GetFire(brightness.SetTag());
        }


    }

    public void GetFire(OBJECT_TAG _tag)
    {
        int score = 0;
        switch (_tag)
        {
            case OBJECT_TAG.SmallStar:
                score = 1;
                break;

            case OBJECT_TAG.LargeStar:
                score = 10;
                break;

            case OBJECT_TAG.SmallCloud:
                score = 2;
                break;

            case OBJECT_TAG.LargeCloud:
                score = 20;
                break;

            default:
                break;
        }
        _scoreText.SetScore(score);

    }
}
