using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCloseController : MonoBehaviour
{
    public Animator animator;

    public string thumbParam = "CloseThumb_L";
    private int _thumbId = -1;

    public string indexParam = "CloseIndex_L";
    private int _indexId = -1;

    public string middleParam = "CloseMiddle_L";
    private int _middleId = -1;

    public string ringParam = "CloseRing_L";
    private int _ringId = -1;

    public string pinkyParam = "ClosePinky_L";
    private int _pinkyId = -1;

    private void OnEnable()
    {
        _thumbId = Animator.StringToHash(thumbParam);
        _indexId = Animator.StringToHash(indexParam);
        _middleId = Animator.StringToHash(middleParam);
        _ringId = Animator.StringToHash(ringParam);
        _pinkyId = Animator.StringToHash(pinkyParam);
    }

    public void CloseThumb(float value)
    {
        animator.SetFloat(_thumbId, value);
    }

    public void CloseIndex(float value)
    {
        animator.SetFloat(_indexId, value);
    }

    public void CloseMiddle(float value)
    {
        animator.SetFloat(_middleId, value);
    }

    public void CloseRing(float value)
    {
        animator.SetFloat(_ringId, value);
    }

    public void ClosePinky(float value)
    {
        animator.SetFloat(_pinkyId, value);
    }
}
