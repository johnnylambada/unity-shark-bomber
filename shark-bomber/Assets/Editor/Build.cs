using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;

public class Build : MonoBehaviour {
    
    
    [MenuItem ("Build/iOS")]
    static void iOS ()
    {
        string OutputDirName = "shark-bomber-ios";

        string pwd = Directory.GetCurrentDirectory();
        string workspace = Directory.GetParent(pwd).ToString();        
        string buildOutputPath = Path.Combine (workspace, OutputDirName);

        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.iPhone) {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.iPhone);
        }
        BuildOptions customBuildOptions = BuildOptions.AcceptExternalModificationsToPlayer;
        EditorUserBuildSettings.SetBuildLocation (BuildTarget.iPhone, buildOutputPath);
        BuildPipeline.BuildPlayer (getScenes(), buildOutputPath, BuildTarget.iPhone, customBuildOptions);
        
        Debug.Log (BuildTarget.iPhone.ToString ());
    }

    private static string[] getScenes() {
        List<string> scenes = new List<string>();
        scenes.Add("Assets/Scenes/LevelScene.unity");
        return scenes.ToArray();
    }

}
