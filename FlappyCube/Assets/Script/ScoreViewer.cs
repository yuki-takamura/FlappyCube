using UnityEngine;

public class ScoreViewer : MonoBehaviour, IAddScoreEventReceiver
{
    int score = 0;

    GUIStyle style;
    public GUIStyleState styleState;

    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.BoldAndItalic;
        styleState.textColor = Color.white;
        style.normal = styleState;
    }

    private void OnGUI()
    {
        var s_w = Screen.width;
        var r_w = 80;
        GUI.Label(new Rect(s_w - r_w * 2, 20, r_w, 20), "Score : " + score, style);
    }

    public void OnExecuteAddEvent() => score++;

    public void ResetScore() => score = 0;
}
