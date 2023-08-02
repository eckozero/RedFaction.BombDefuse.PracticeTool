using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedFaction.BombDefuse.PracticeTool
{
    internal class BombModel
    {
        public bool _isUpperPanelComplete { get; private set; } = false;
        public bool _isLowerPanelComplete { get; private set; } = false;

        private Dictionary<string, int> panelKeys = new Dictionary<string, int>()
        {
            {"panelKey1", 0 },
            {"panelKey2", 0 },
            {"panelKey3", 0 },
            {"panelKey4", 0 },
            {"panelKey5", 0 },
            {"panelKey6", 0 },
            {"panelKey7", 0 },
            {"panelKey8", 0 },
            {"panelKey9", 0 },
            {"panelKey10", 0 },
            {"panelKey11", 0 },
        };

        private Random _random;

        public BombModel()
        {
            _random = new Random();
            PopulateUpperPanel();
            PopulateLowerPanel();
        }

        public void ResetBomb()
        {
            _isUpperPanelComplete = false;
            _isLowerPanelComplete = false;

            foreach (var key in panelKeys.Keys)
            {
                panelKeys[key] = 0;
            }
        }

        private void PopulateUpperPanel()
        {
            for (int i = 1; i < 5; i++)
            {
                string key = "panelKey" + i.ToString();
                panelKeys[key] = _random.Next(1, 5);
            }
        }

        private void PopulateLowerPanel()
        {
            for (int i = 5; i < 12; i++)
            {
                string key = "panelKey" + i.ToString();
                panelKeys[key] = _random.Next(1, 5);
            }
        }

        public bool CheckKeyPress(KeyEventArgs e, int currentPanelKey)
        {
            return panelKeys["panelKey" + currentPanelKey.ToString()] == (int)Enum.Parse(typeof(BombKeys), e.KeyData.ToString());
        }

        public void SetUpperPanelComplete()
        {
            _isUpperPanelComplete = true;
        }

        public void SetLowerPanelComplete()
        {
            _isLowerPanelComplete = true;
        }

    }

    public enum BombKeys
    {
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }
}
