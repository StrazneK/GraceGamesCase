using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public static class SceneChangeManager
    {
        public static void ChangeScene(bool isMain)
        {
            SceneManager.LoadScene(isMain ? "main" : "game");
        }
    }
}