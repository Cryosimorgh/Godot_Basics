using static Godot.GD;
using Godot;

namespace Code
{
    public partial class Test : Node2D
    {
        public override void _Ready()
        {
            Awake();
            Start();
        }
        private static void Awake()
        {

        }
        private static void Start()
        {

        }
        public override void _Input(InputEvent Event)
        {
            if (Input.IsActionJustPressed("L", false))
            {
                Print("L");
            }
        }
    }
}
