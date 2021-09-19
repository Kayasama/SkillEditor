﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace ZZBLib
{
    [Flags]
    public enum ViewType
    {
        None = 0b0000_0000,
        GlobalAction = 0b0000_0001,
        State = 0b0000_0010,
        StateSet = 0b0000_0100,
        Action = 0b0000_1000,
        Tool = 0b0001_0000,
        Other = 0b0010_0000,
        Frame = 0b0100_0000

    }

    /// <summary>
    /// 编辑器配置
    /// </summary>
    public partial class ActionEditorSetting
    {
        public int stateSelectIndex = -1;
        public int attackRangeSelectIndex = -1;
        public int bodyRangeSelectIndex = -1;
        public int actionSelectIndex = -1;
        public int globalActionSelectIndex = -1;
        public int frameSelectIndex = -1;
        public bool enableAllControl = false;
        public bool enableQuickKey = false;

        public ViewType viewType;

        public float frameRate => 0.033f;

        public Vector2 otherScrollViewPos = Vector2.zero;

        public float frameWidth = 40f;
        public float frameListViewRectHeight = 200f;
    }


    public class ActionEditorWindow : EditorWindow
    {
        [MenuItem("ZZBLib/动作编辑")]
        public static void ShowEditor()
        {
            EditorWindow.GetWindow<ActionEditorWindow>();

        }

        public static void ShowEditor(GameObject target, TextAsset textAsset)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                Debug.LogWarning("编辑器不能在运行时打开");
                return;
            }

            var win = EditorWindow.GetWindow<ActionEditorWindow>();
            if (win.configAsset != null)
            {
                win.Focus();
                return;
            }

            win.UpdateTarget(target);
            win.UpdateConfig(config);

        }

        [NonSerialized] public readonly ActionListView actionListView;
        [NonSerialized] public readonly ActionSetView actionSetView;
        [NonSerialized] public readonly GlobalActionListView globalActionListView;
        [NonSerialized] public readonly GlobalActionSetView globalActionSetView;
        [NonSerialized] public readonly AttackRangeListView attackRangeListView;
        [NonSerialized] public readonly BodyRangeListView bodyRangeListView;
        [NonSerialized] public readonly FrameListView frameListView;
        [NonSerialized] public readonly StateListView stateListView;
        [NonSerialized] public readonly StateSetView stateSetView;
        [NonSerialized] public readonly MenuView menuView;
        [NonSerialized] public readonly ToolView toolView;

        public List<View> views { get; private set; }

        private readonly SceneGUIDDrawer guiDrawer;
        private readonly QuickButtonHandler quickButtonHandler;

        #region style

        #endregion style
    }

}
