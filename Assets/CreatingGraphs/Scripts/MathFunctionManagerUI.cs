using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathFunctionManagerUI : MonoBehaviour {

    public Image parameterListContainer;
    public Button parameterSelectButton;
    public Image parameterUpdaterViewport; //IT must have a Text , a InputField and a Slider

    private Text _PARAMETER_TEXT;
    private InputField _PARAMETER_INPUTFIELD;
    private Slider _PARAMETER_SLIDER;

    private static MathematicalFunction sceneMathFunction;

    public GameObject _vectorialspace;

    private VectorialSpace _VS_SCRIPT;
    //private GameObject currentGraph;
    private bool areParametersButtons = false;

    // Use this for initialization
    void Awake()
    {
        setSceneMathFunction( ContextFunctions.SelectedFunction );

        _PARAMETER_TEXT = parameterUpdaterViewport.transform.Find("ParameterDescriptionText").GetComponent<Text>();
        _PARAMETER_INPUTFIELD = parameterUpdaterViewport.transform.Find("CurrentValueInputField").GetComponent<InputField>();
        _PARAMETER_SLIDER = parameterUpdaterViewport.transform.Find("ValuesSlider").GetComponent<Slider>();

        _VS_SCRIPT = _vectorialspace.GetComponent<VectorialSpace>();

    }

    public static void setSceneMathFunction(MathematicalFunction m)
    {
        sceneMathFunction = m;
    }

    public static MathematicalFunction getSceneMathFunction() {
        return sceneMathFunction;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_VS_SCRIPT.currentSelectedGraph != null && areParametersButtons == false)
        {
            
            Text _TextButton;
            Button _buttonTemp;

            foreach (Parameter a in sceneMathFunction.getParameters())
            {
                _buttonTemp = Instantiate(parameterSelectButton, parameterListContainer.transform);
                _buttonTemp.name = a.Name;
                _TextButton = _buttonTemp.GetComponentInChildren<Text>();
                _TextButton.text = _buttonTemp.name;
                _buttonTemp.onClick.AddListener(() => setUpParameterUpdaterViewport(sceneMathFunction, _PARAMETER_TEXT, _PARAMETER_INPUTFIELD, _PARAMETER_SLIDER));
            }
            areParametersButtons = true;
        }
    }

    /*
    private void cleanParameterListContainer()
    {
        Button[] buttons = parameterListContainer.GetComponentsInChildren<Button>();
        if (buttons.Length > 0 || buttons != null)
        {
            foreach (Button button in buttons)
            {
                Destroy(button);
            }
        }
    }
    */

    public void setUpParameterUpdaterViewport( MathematicalFunction mathFunction, Text _text, InputField _input, Slider _slider)
    {
        string PARAMETERNAME = EventSystem.current.currentSelectedGameObject.name;

        Parameter chosenParameter = mathFunction.getParameterByName(PARAMETERNAME);
        //Updating the elements: Text, Slider and InputField
        _text.text = chosenParameter.Name;
        _input.text = chosenParameter.Value.ToString();
        _slider.name = chosenParameter.Name;
        _slider.minValue = chosenParameter.MinValue;
        _slider.maxValue = chosenParameter.MaxValue;
        _slider.value = chosenParameter.Value;

        _slider.onValueChanged.AddListener(delegate {
            updateParameter( _slider, _input);
        });
    }

    public void updateParameter(Slider eventSlider, InputField _updatedinput)
    {
        sceneMathFunction.updateParameter(eventSlider.name, eventSlider.value);
        _updatedinput.text = eventSlider.value.ToString();
    }



	
	
}
