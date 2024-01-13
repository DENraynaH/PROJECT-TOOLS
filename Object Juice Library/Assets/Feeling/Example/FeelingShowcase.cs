using System;
using JE.Feeling;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FeelingShowcase : MonoBehaviour
{
    [SerializeField] private Vector3 vectorToModify;
    [SerializeField] private int _intToModify;
    [SerializeField] private float _floatToModify;
    [SerializeField] private Color _colorToModify;

    [SerializeField] private Image _imageToModify;
    [SerializeField] private GameObject _objectToModify;
    [SerializeField] private GameObject _objectToModify2;

    private FeelingSequencerOld _feelingSequencerOld;


    private void Start()
    {
        _feelingSequencerOld = new FeelingSequencerOld()
            .Append(() => { Debug.Log("Starting Sequence"); })
            .Append(_objectToModify.transform.ModifyScale(new Vector3(3, 3, 3), 1f))
            .Delay(2f)
            .Append(_objectToModify2.transform.ModifyScale(new Vector3(6, 6, 6), 1f))
            .IterateMode(FeelingDirectionType.Rewind);

        _feelingSequencerOld.Append(() => { _feelingSequencerOld.Stop(); });

        _feelingSequencerOld.Append(() => { Debug.Log("Don't run this event"); });

        _feelingSequencerOld.Append(_objectToModify.transform.ModifyScale(new Vector3(7, 7, 7), 1f));
    }

    public void Showcase()
    {
        /*Feeling.ModifyVector3(vectorToModify, 
            new Vector3(10, 10, 10), 
            (v) => vectorToModify = v, 2).Start();
        Feeling.ModifyInt(0, 10, (v) => _intToModify = v, 2).Start();
        Feeling.ModifyFloat(0.0f, 10.0f, (v) => _floatToModify = v, 2).Start();*/

        //Feeling.ModifyColor(Color.white, Color.green, (v) => _imageToModify.color = v, 2.0f).Start();
        
        //_imageToModify.color = Color.white;
        //_imageToModify.ModifyColor(Color.green, 5).Start();
        //_imageToModify.rectTransform.ModifyPosition(new Vector3(312, 11, 0), 10).Start();
        //_imageToModify.rectTransform.ModifyPosition(new Vector3(0, 0, 10), 3).Start();
        //_objectToModify.transform.ModifyScale(new Vector3(3, 3, 3), 5).Start();
        /*_objectToModify.transform.localScale = new Vector3(1, 1, 1);
        _objectToModify2.transform.localScale = new Vector3(1, 1, 1);
        
        _objectToModify.transform.DOScale(new Vector3(3, 3, 3), 1).SetEase(Ease.InOutCubic);
        _objectToModify2.transform.ModifyScale(new Vector3(3, 3, 3), 1).SetEase(FeelingEase.EaseInOutCubic);

        FeelingRuntimeHandler<Vector3> feelingRuntimeHandler = _imageToModify.rectTransform
            .ModifyRotation(new Vector3(0, 0, 360), 3)
            .SetIterations(5)
            .SetDelay(2.0f)
            .AppendCompleteAction(() => { Debug.Log("Complete Action"); })
            .AppendIterateAction(() => { Debug.Log("Iterate Action"); })
            .AppendStartAction(() => { Debug.Log("Start Action"); })
            .SetEase(FeelingEase.EaseInBack);*/

        //feelingRuntimeHandler.Start(0.2f);
        //_imageToModify.rectTransform.ModifyScale(new Vector3(5, 5, 5), 10).SetLoops(2).Start();

        //_feelingSequencer.Run();

        _objectToModify.transform.ModifyScale(new Vector3(5, 5, 5), 5).SetDirectionType(FeelingDirectionType.Rewind).Start();
    }

    public void Showcase2()
    {
        //_feelingSequencer.Restart();
    }
}



#if UNITY_EDITOR 

[CustomEditor(typeof(FeelingShowcase))]
public class FeelingShowcaseEditor : Editor
{
    private const string BUTTON_TEXT = "Debug Feelings";
    private const string RESTART_SEQUENCE = "Restart Sequence";
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FeelingShowcase feelingShowcase = target as FeelingShowcase;

        if (GUILayout.Button(BUTTON_TEXT))
            feelingShowcase!.Showcase();
        
        if (GUILayout.Button(RESTART_SEQUENCE))
            feelingShowcase!.Showcase2();
    }
}
#endif
