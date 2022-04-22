using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementSlider : MonoBehaviour
{
    [SerializeField] GameObject toSlide;
    [SerializeField] float slideStartToEndLength;
    [SerializeField] bool leftToRight = true;
    [SerializeField] bool SlideAxisIsX = true;
    Slider slider;
    GameObject currentToSlide;
    Vector3 currentToSlidePosition;
    
    public void resetSlider()
    {
        GetComponent<Slider>().value = 0;
    }
    public void sliderValueChanged(float value)
    {
        if(currentToSlide != toSlide)
        {
            currentToSlide = toSlide;
            currentToSlidePosition = currentToSlide.transform.localPosition;
        }

        if(SlideAxisIsX)
            sliderValueChangedX(value);
        else
            sliderValueChangedY(value);
    }
    private void sliderValueChangedX(float value)
    {
        slider = GetComponent<Slider>();
        Debug.Log("Slider value changed to " + value);
        //Slide toSlide from start to end position depending on the length
        toSlide.transform.localPosition = new Vector3(currentToSlidePosition.x + (leftToRight?1:-1) * (slideStartToEndLength+currentToSlide.GetComponent<RectTransform>().rect.width) * ((value - slider.minValue)/(slider.maxValue - slider.minValue)), currentToSlidePosition.y, currentToSlidePosition.z);
    }
    private void sliderValueChangedY(float value)
    {
        slider = GetComponent<Slider>();
        Debug.Log("Slider value changed to " + value);
        //Slide toSlide from start to end position depending on the length
        toSlide.transform.localPosition = new Vector3(currentToSlidePosition.x, currentToSlidePosition.y + (leftToRight?1:-1) * (slideStartToEndLength+currentToSlide.GetComponent<RectTransform>().rect.height) * ((value - slider.minValue)/(slider.maxValue - slider.minValue)), currentToSlidePosition.z);
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(toSlide.transform.position, toSlide.transform.position + transform.right * (slideStartToEndLength+toSlide.GetComponent<RectTransform>().rect.width) * (leftToRight?1:-1));
    }
}
