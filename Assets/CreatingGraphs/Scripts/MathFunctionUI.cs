using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathFunctionUI : MonoBehaviour {

    private MathematicalFunction mathFunction;
    private Image parameterListContainer;

    private Button parameterSelectButton;

    private Image parameterUpdaterViewport; //IT must have a Text , a InputField and a Slider

    public MathFunctionUI() {

    }

    public Image ParameterListContainer {
        set { parameterListContainer = value; }
        get { return parameterListContainer; }
    }

    public Button ParameterSelectButton
    {
        set { parameterSelectButton = value; }
        get { return parameterSelectButton; }
    }

    public Image ParameterUpdaterViewport
    {
        set { parameterUpdaterViewport = value; }
        get { return parameterUpdaterViewport; }
    }

    public MathematicalFunction MathFunction {
        set { mathFunction = value; }
        get { return mathFunction; }
    }

    public Vector3 graph(float u, float v, float t) {
        return mathFunction.graph(u, v, t);
    }

    public void putParameterButtonInContainer() {

        if(mathFunction != null)
        {
            Text _TextButton;
            Button _buttonTemp;
            foreach (Parameter a in mathFunction.getParameters())
            {
                _buttonTemp = Instantiate(parameterSelectButton, parameterListContainer.transform);
                parameterSelectButton.name = a.Name;
                _TextButton = _buttonTemp.GetComponentInChildren<Text>();
                _TextButton.text = a.Name;       
            }

            Button[] buttons = parameterListContainer.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(() => setUpParameterUpdaterViewport());
            }

        }
    }

    private void cleanParameterListContainer() {
        Button[] buttons = parameterListContainer.GetComponentsInChildren<Button>();
        if(buttons.Length > 0 || buttons != null)
        {
            foreach (Button button in buttons)
            {
                Destroy(button);
            }
        }        
    }

    public void setUpParameterUpdaterViewport()
    {
        string NAME = EventSystem.current.currentSelectedGameObject.name;

        Text _PARAMETER_TEXT = parameterUpdaterViewport.GetComponentInChildren<Text>();
        InputField _PARAMETER_INPUTFIELD = parameterUpdaterViewport.GetComponentInChildren<InputField>();
        Slider _PARAMETER_SLIDER = parameterUpdaterViewport.GetComponentInChildren<Slider>();

        Parameter chosenParameter = mathFunction.getParameterByName(NAME);
        _PARAMETER_TEXT.text = chosenParameter.Name;
        _PARAMETER_INPUTFIELD.text = chosenParameter.Value.ToString() ;
        _PARAMETER_SLIDER.name = chosenParameter.Name;
        _PARAMETER_SLIDER.minValue = chosenParameter.MinValue;
        _PARAMETER_SLIDER.maxValue = chosenParameter.MaxValue;
        _PARAMETER_SLIDER.value = chosenParameter.Value;

        _PARAMETER_SLIDER.onValueChanged.AddListener(delegate {
            updateParameter();
        });
    }

    public void updateParameter() {
        Slider _PARAMETER_SLIDER = parameterUpdaterViewport.GetComponentInChildren<Slider>();
        InputField _PARAMETER_INPUTFIELD = parameterUpdaterViewport.GetComponentInChildren<InputField>();
        mathFunction.updateParameter(_PARAMETER_SLIDER.name, _PARAMETER_SLIDER.value);
        _PARAMETER_INPUTFIELD.text = _PARAMETER_SLIDER.value.ToString();
    }



}
