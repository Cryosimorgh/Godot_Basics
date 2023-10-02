using Godot;
using System;
using static Godot.Input;
using static GameManagement.GameManager;

namespace UI
{
    public partial class InGameMenu_Handler : Node
    {
        [Export] Control controlNode;
        public override void _Ready()
        {
            controlNode.Visible = false;
            Instance.isPaused = false;
        }
        public override void _Input(InputEvent @event)
        {
            if (IsActionJustPressed("ui_cancel"))
            {
                controlNode.Visible = !controlNode.IsVisibleInTree();
                Instance.isPaused = controlNode.Visible;
                MouseMode = controlNode.Visible ? MouseModeEnum.Visible : MouseModeEnum.Captured;
            }
        }
    }
}
