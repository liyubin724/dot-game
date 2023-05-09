using UnityEngine;

namespace DotEngine.Avatar
{
    public class AvatarPartInstance
    {
        public string category;

        public Renderer[] rendererInstances = new Renderer[0];
        public GameObject[] prefabInstances = new GameObject[0];
    }
}
