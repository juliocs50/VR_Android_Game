using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BarManager))]
public class BarManagerEditor : Editor
{

    //script to change the way the script look in the inspector


    BarManager BarMan;
    SerializedProperty textFontSize;
    SerializedProperty barColor;
    SerializedProperty backgroundColor;
    SerializedProperty outlineColor;
    SerializedProperty outlineSize;
    SerializedProperty textColor;
    SerializedProperty barSize;
    SerializedProperty testMax;
    SerializedProperty testMin;
    SerializedProperty testIsPrecentage;
    SerializedProperty testValue;
    SerializedProperty percentageRoundingToNearest;
    SerializedProperty isShowText;

    bool IsTestBar = false;
    bool ShowTest = false;


    private void OnEnable()
    {
        BarMan = target as BarManager;

        textFontSize = serializedObject.FindProperty("TextFontSize");
        barColor = serializedObject.FindProperty("BarColor");
        backgroundColor = serializedObject.FindProperty("BackgroundColor");
        outlineColor = serializedObject.FindProperty("OutlineColor");
        outlineSize = serializedObject.FindProperty("OutlineSize");
        textColor = serializedObject.FindProperty("TextColor");
        barSize = serializedObject.FindProperty("BarSize");
        testMax = serializedObject.FindProperty("TestMax");
        testMin = serializedObject.FindProperty("TestMin");
        testIsPrecentage = serializedObject.FindProperty("TestIsPrecentage");
        testValue = serializedObject.FindProperty("TestValue");
        percentageRoundingToNearest = serializedObject.FindProperty("PercentageRoundingToNearest");
        isShowText = serializedObject.FindProperty("IsShowText");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUI.BeginChangeCheck();

        //main variables
        barColor.colorValue = EditorGUILayout.ColorField("Bar Color:", barColor.colorValue);
        barSize.vector2Value = EditorGUILayout.Vector2Field("Bar Size: ", barSize.vector2Value);

        backgroundColor.colorValue= EditorGUILayout.ColorField("Background Color:", backgroundColor.colorValue);
        outlineColor.colorValue = EditorGUILayout.ColorField("Outline Color:", outlineColor.colorValue);
        outlineSize.floatValue = EditorGUILayout.FloatField("Outline Size:", outlineSize.floatValue);

        textColor.colorValue = EditorGUILayout.ColorField("Text Color:", textColor.colorValue);
        textFontSize.intValue = EditorGUILayout.IntField("Font Size:", textFontSize.intValue);

        percentageRoundingToNearest.intValue = EditorGUILayout.IntField("Percentage Rounding:", percentageRoundingToNearest.intValue);
        isShowText.boolValue = EditorGUILayout.Toggle("Is Show Text:", isShowText.boolValue);


        ShowTest = EditorGUILayout.Foldout(ShowTest, new GUIContent("Testing Functionality"));

        if (ShowTest)
        {
            testMax.floatValue = EditorGUILayout.FloatField("Max Value:", testMax.floatValue);
            testMin.floatValue = EditorGUILayout.FloatField("Min Value:", testMin.floatValue);
            testIsPrecentage.boolValue = EditorGUILayout.Toggle("Is Percentage:", testIsPrecentage.boolValue);

            testValue.floatValue = EditorGUILayout.Slider("Move Slider To Test:", testValue.floatValue, testMin.floatValue, testMax.floatValue);
        }

        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();

        if (EditorGUI.EndChangeCheck()) // if the user pressed the button, start applying the changes
        {
            BarMan.ChangeLookOfTheBar();
            if (ShowTest)
            {
                BarMan.ChangeBarSize(testValue.floatValue, testMax.floatValue, testIsPrecentage.boolValue);
            }
        }

        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
    }

}
