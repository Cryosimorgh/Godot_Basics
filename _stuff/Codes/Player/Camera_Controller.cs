using Godot;
using System;
using static GameManagement.GameManager;

namespace Player
{
    public partial class Camera_Controller : Camera3D
    {
        Camera3D cam;
        Transform3D tran;
        InputEventMouseMotion mouseMvmnt = new();

        [Export] Node3D player;
        [Export] Node3D camParent;



        public override void _Input(InputEvent inputEvent)
        {
            if (inputEvent is InputEventMouseMotion mouseMvmnt && !Instance.isPaused)
            {
                camParent.RotateY(-mouseMvmnt.Relative.X * Instance.CameraSensitivityX);
                cam.RotateX(-mouseMvmnt.Relative.Y * Instance.CameraSensitivityY);
            }
        }
        public override void _EnterTree()
        {
            cam = this;
            tran = player.Transform;
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
        public override void _Ready() => cam.MakeCurrent();
    }
}
