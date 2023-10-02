using Godot;
using System;
using static GameManagement.GameManager;

namespace UI
{
    public partial class Resume_Button : Button
    {
        public override void _Ready()
        {
            ButtonDown += Resume;
        }

        private void Resume()
        {
            GetNode<Control>($"%GUI").Visible = false;
            Instance.isPaused = false;
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
    }
}
