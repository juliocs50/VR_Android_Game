using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HoverSizeChanger))]
public class HoverSizeChangerEditor : Editor
{
    //script to change the way the script look in the inspector

    HoverSizeChanger HCMan;

    SerializedProperty ttHeight;
    SerializedProperty ttWidth;
    SerializedProperty bgYSize;
    SerializedProperty bgXSize;
    SerializedProperty fontSize;
    SerializedProperty iconSize;
    SerializedProperty attributeTextPos;
    SerializedProperty typeRarityPos;
    SerializedProperty iconPos;

    SerializedProperty topBottomMargin;
    SerializedProperty rightLeftMargin;
    SerializedProperty boarderThickness;

    bool IsShowSprite = false;
    bool ShowMargins = false;

    private void OnEnable()
    {
        HCMan = target as HoverSizeChanger;
        //Find Properties of the object
        ttHeight = serializedObject.FindProperty("TooltipYSize");
        ttWidth = serializedObject.FindProperty("TooltipXSize");
        fontSize = serializedObject.FindProperty("FontSize");
        iconSize = serializedObject.FindProperty("IconSize");
        attributeTextPos = serializedObject.FindProperty("AttributeTextPos");
        typeRarityPos = serializedObject.FindProperty("TypeRarityPos");
        iconPos = serializedObject.FindProperty("IconPos");
        bgYSize = serializedObject.FindProperty("BGYSize");
        bgXSize = serializedObject.FindProperty("BGXSize");
        topBottomMargin = serializedObject.FindProperty("TopBottomMargin");
        rightLeftMargin = serializedObject.FindProperty("RightLeftMargin");
        boarderThickness = serializedObject.FindProperty("BoarderThickness");

        //default values
        ttHeight.floatValue = 1;
        ttWidth.floatValue = 1;
        fontSize.floatValue = 1;
        iconSize.floatValue = 1;

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        IsShowSprite=EditorGUILayout.Foldout(IsShowSprite,new GUIContent("Images"));
        if (IsShowSprite)
        {
            HCMan.BackgroundSprite = (Sprite)EditorGUILayout.ObjectField("Background Image:", HCMan.BackgroundSprite, typeof(Sprite), true);
            HCMan.BoarderSprite = (Sprite)EditorGUILayout.ObjectField("Boarder Image:", HCMan.BoarderSprite, typeof(Sprite), true);
        }

        //values changer (Slider)
        ttHeight.floatValue = EditorGUILayout.Slider("Tooltip Height:",ttHeight.floatValue, 0.25f, 2f);
        ttWidth.floatValue = EditorGUILayout.Slider("Tooltip Width:", ttWidth.floatValue, 0.25f, 2f);
        fontSize.floatValue = EditorGUILayout.Slider("Font Size:", fontSize.floatValue, 0.25f, 2f);
        iconSize.floatValue = EditorGUILayout.Slider("Icon Size:", iconSize.floatValue, 0.25f, 2f);

        boarderThickness.floatValue = EditorGUILayout.FloatField("Boarder Thickness:", boarderThickness.floatValue);
        typeRarityPos.floatValue = EditorGUILayout.FloatField("Type/Rarity X Position:", typeRarityPos.floatValue);
        iconPos.floatValue = EditorGUILayout.FloatField("Icon X Position:", iconPos.floatValue);
        attributeTextPos.floatValue = EditorGUILayout.FloatField("Attribute Text Y Position:", attributeTextPos.floatValue);
        bgYSize.floatValue = EditorGUILayout.FloatField("Background Height:", bgYSize.floatValue);
        bgXSize.floatValue = EditorGUILayout.FloatField("Background Width:", bgXSize.floatValue);

        ShowMargins = EditorGUILayout.Foldout(ShowMargins, new GUIContent("Margins"));

        if (ShowMargins) // margins
        {
            topBottomMargin.intValue = EditorGUILayout.IntField("Top/Bottom Margin:", topBottomMargin.intValue);
            rightLeftMargin.intValue = EditorGUILayout.IntField("Right/Left Margin:", rightLeftMargin.intValue);
        }

        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
        if (EditorGUI.EndChangeCheck())
        {
            HCMan.ApplyChangesToSizes(); // if the user changed value, start applying them
        }


        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
    }

}
