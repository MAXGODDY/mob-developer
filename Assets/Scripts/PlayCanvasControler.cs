using TMPro;
using UnityEngine;

public class PlayCanvasControler : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Start()
    {
        SingletonScoreManager._text = text;
    }


}
