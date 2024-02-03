 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShopManager))]
public class ShopManagerEditor : Editor
{
    //script to change the way the script look in the inspector

    ShopManager ShopMan;

    SerializedProperty rows;
    SerializedProperty columns;
    SerializedProperty slotSize;
    SerializedProperty spacingBetweenSlots;
    SerializedProperty topBottomMargin;
    SerializedProperty rightLeftMargin;
    SerializedProperty topBottomSpace;
    SerializedProperty rightLeftSpace;

    bool ShowMargins = false;
    bool ShowImages = false;

    private void OnEnable()
    {
        ShopMan = target as ShopManager;

        //Find Properties of the object

        rows = serializedObject.FindProperty("Rows");
        columns = serializedObject.FindProperty("Columns");
        slotSize = serializedObject.FindProperty("SlotSize");
        spacingBetweenSlots = serializedObject.FindProperty("SpacingBetweenSlots");
        topBottomMargin = serializedObject.FindProperty("TopBottomMargin");
        rightLeftMargin = serializedObject.FindProperty("RightLeftMargin");
        topBottomSpace = serializedObject.FindProperty("TopBottomSpace");
        rightLeftSpace = serializedObject.FindProperty("RightLeftSpace");


    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //main variables
        rows.intValue = EditorGUILayout.IntField("Rows:", rows.intValue);
        columns.intValue = EditorGUILayout.IntField("Columns:", columns.intValue);
        slotSize.intValue = EditorGUILayout.IntField("Slot Size:", slotSize.intValue);
        spacingBetweenSlots.intValue = EditorGUILayout.IntField("Spacing:", spacingBetweenSlots.intValue);
        topBottomSpace.intValue = EditorGUILayout.IntField("Height:", topBottomSpace.intValue);
        rightLeftSpace.intValue = EditorGUILayout.IntField("Width:", rightLeftSpace.intValue);

        ShowMargins = EditorGUILayout.Foldout(ShowMargins, new GUIContent("Margins"));

        if (ShowMargins) //margins
        {
            topBottomMargin.intValue = EditorGUILayout.IntField("Top/Bottom Margin:", topBottomMargin.intValue);
            rightLeftMargin.intValue = EditorGUILayout.IntField("Right/Left Margin:", rightLeftMargin.intValue);
        }

        ShowImages = EditorGUILayout.Foldout(ShowImages, new GUIContent("Images"));

        if (ShowImages)
        {
            ShopMan.BackgroundSprite = (Sprite)EditorGUILayout.ObjectField("Background Image:", ShopMan.BackgroundSprite, typeof(Sprite), true);
            ShopMan.SlotSprite = (Sprite)EditorGUILayout.ObjectField("Slot Image:", ShopMan.SlotSprite, typeof(Sprite), true);
        }

        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
        if (GUILayout.Button("Create Shop"))// if the user pressed the button, start applying the changes
        {
            ShopMan.ChangeSizes();
            ShopMan.CreateSlots();
            ShopMan.ChangeSprites();
        }

        serializedObject.ApplyModifiedProperties();
        SceneView.RepaintAll();
    }

}
