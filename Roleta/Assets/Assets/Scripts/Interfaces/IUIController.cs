using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Assets.Scripts
{
    public interface IUIController
    {
        void MainMenu();
        void PlayGame();
        void StopRoulette();
        void EndGame();
        void EndGame(SelectedColor selectedColor);
    }
}
