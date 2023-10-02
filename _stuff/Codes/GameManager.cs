using Godot;
using System;

namespace GameManagement
{
    public partial class GameManager : Node
    {
        public bool isPaused;
        public float GlobalSpeedMod { get; private set; }
        public float CameraSensitivityY { get; private set; }
        public float CameraSensitivityX { get; private set; }

        public GmStats stats = GD.Load<GmStats>("res://_stuff/Codes/SOs/Base_Scripts/GameManagerSettingsSO.tres");

        #region Singleton

        public static GameManager Instance;
        void Singlify()
        {            
            if (Instance == null)
            {
                Instance = this;
                ReadData();
                return;
            }
            QueueFree();
        }

        private void ReadData()
        {
            GlobalSpeedMod = stats.GlobalSpeedMod;
            CameraSensitivityY = stats.CameraSensitivityY;
            CameraSensitivityX = stats.CameraSensitivityX;
        }
        #endregion
        public override void _EnterTree()
        {
            Singlify();
        }
        
    }

}