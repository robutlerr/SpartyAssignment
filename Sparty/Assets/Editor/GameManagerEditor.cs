using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{   // extends the editor class
    // called when Unity Editor Inspector is updated
    public override void OnInspectorGUI() {
        // show the default inspector stuff for this component
        DrawDefaultInspector();

        // get a reference to the GameManger script on this target gameObject
        GameManager myGM = (GameManager)target;

        // add a custom button to the Inspector component
        if (GUILayout.Button("Reset Player State")) {
            // if button pressed, then call function in script
            PlayerPrefManager.ResetPlayerState(myGM.startLives, false);
        }

        // add a custom button to the Inspector component
        if (GUILayout.Button("Rest Highscore")) {
            // if button pressed, then call function in script
            PlayerPrefManager.SetHighscore(0);
        }

        // add a cusom button to the Inspector component
        if (GUILayout.Button("Output Player State")) {
            // if button pressed, then call function in script
            PlayerPrefManager.ShowPlayerPrefs();
        }
    }
}
