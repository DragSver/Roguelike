using System.Collections.Generic;
using UnityEngine;

namespace RPGCardRoguelike.Utils
{
    public static class WaitUtils
    {
        public static IEnumerable<WaitForSeconds> Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}