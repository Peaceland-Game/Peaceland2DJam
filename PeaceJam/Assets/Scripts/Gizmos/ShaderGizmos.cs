using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShaderGizmos : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    [SerializeField] List<ShaderGizmosSettings> shaderGizmos;
    [SerializeField] Shader shader;
    [SerializeField] ShaderProperties properties;

    // Start is called before the first frame update
    void Start()
    {
        properties = new ShaderProperties();

        int propertyCount = shader.GetPropertyCount();
        for (int i = 0; i < propertyCount; i++)
        {
            if( (shader.GetPropertyFlags(i) & UnityEngine.Rendering.ShaderPropertyFlags.HideInInspector) != UnityEngine.Rendering.ShaderPropertyFlags.HideInInspector)
            {
                print(shader.GetPropertyName(i) +": " + shader.GetPropertyType(i));

                ShaderPropertyType shaderPropertyType = shader.GetPropertyType(i);

                switch (shaderPropertyType)
                {
                    case ShaderPropertyType.Color:
                        properties.colors.Add(shader.GetPropertyDefaultVectorValue(i));
                        break;
                    case ShaderPropertyType.Vector:
                        properties.vectors.Add(shader.GetPropertyDefaultVectorValue(i));
                        break;
                    case ShaderPropertyType.Float:
                        properties.floats.Add(shader.GetPropertyDefaultFloatValue(i));
                        break;
                    case ShaderPropertyType.Range:
                        properties.ranges.Add(new SFloatRange(shader.GetPropertyDefaultFloatValue(i), shader.GetPropertyRangeLimits(i)));
                        break;
                    case ShaderPropertyType.Texture:
                        break;
                    case ShaderPropertyType.Int:
                        properties.ints.Add(shader.GetPropertyDefaultIntValue(i));  
                        break;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    private class ShaderGizmosSettings
    {
        [SerializeField] public string varName;
        [SerializeField] public GizmosType gizmoType;
        [SerializeField] public Space space;

        public enum GizmosType
        {
            SPHERE
        }

        public enum Space
        {
            WORLD,
            OBJECT
        }
    }


    [Serializable]
    private class ShaderProperties
    {
        public List<Tuple<string, ShaderPropertyFlags>> nameAndType;
        public Dictionary<string, ShaderPropertyFlags> nameToType;
        public Dictionary<string, int> nameToIndex;

        [SerializeField] public List<Color> colors = new List<Color>();
        [SerializeField] public List<Vector4> vectors = new List<Vector4>();
        [SerializeField] public List<float> floats = new List<float>();
        [SerializeField] public List<SFloatRange> ranges = new List<SFloatRange>();
        [SerializeField] public List<Texture> texs = new List<Texture>();
        [SerializeField] public List<int> ints = new List<int>();

    }

    [Serializable]
    private struct SFloatRange
    {
        [SerializeField] private float min, max;
        [SerializeField] private float value;
        
        public SFloatRange(float value, float min, float max)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }

        public SFloatRange(float value, Vector2 range)
        {
            this.value = value;
            this.min = range.x;
            this.max = range.y;
        }
    }

}
