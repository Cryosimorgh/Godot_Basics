using Godot;
using System;

namespace UI
{
    public partial class QuitButton : Button
    {
        // Called when the node enters the scene tree for the first time.
        public override void _Ready() => ButtonDown += GameQuit;
        private void GameQuit() => GetTree().Quit();
    }
}
