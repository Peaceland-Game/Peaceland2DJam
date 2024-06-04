using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShaderPropertyEdit : MonoBehaviour
{
    [SerializeField] Shader shader;
    [SerializeField] ShaderProperties propertiesBP;
    [SerializeField] RangeProperties propertiesRanges;
    [SerializeField] List<ShaderProperties> generatedProperties;

    // Start is called before the first frame update
    void Start()
    {
        propertiesBP = new ShaderProperties();

        int propertyCount = shader.GetPropertyCount();
        for (int i = 0; i < propertyCount; i++)
        {
            // Make sure accessible 
            if ((shader.GetPropertyFlags(i) & UnityEngine.Rendering.ShaderPropertyFlags.HideInInspector) != UnityEngine.Rendering.ShaderPropertyFlags.HideInInspector)
            {
                string name = shader.GetPropertyName(i);
                ShaderPropertyType type = shader.GetPropertyType(i);


                print(shader.GetPropertyName(i) + ": " + shader.GetPropertyType(i));


                Tuple<string, ShaderPropertyType> nameAndType =
                    new Tuple<string, ShaderPropertyType>(shader.GetPropertyName(i), shader.GetPropertyType(i));

                propertiesBP.nameAndType.Add(nameAndType);
                propertiesBP.nameToType.Add(name, type);

                // Add value to given type list and name to nameToIndex array 
                switch (type)
                {
                    case ShaderPropertyType.Color:
                        propertiesBP.nameToIndex.Add(name, propertiesBP.colors.Count);
                        propertiesBP.colors.Add(shader.GetPropertyDefaultVectorValue(i));
                        break;
                    case ShaderPropertyType.Vector:
                        propertiesBP.nameToIndex.Add(name, propertiesBP.vectors.Count);
                        propertiesBP.vectors.Add(shader.GetPropertyDefaultVectorValue(i));
                        break;
                    case ShaderPropertyType.Float:
                        propertiesBP.nameToIndex.Add(name, propertiesBP.floats.Count);
                        propertiesBP.floats.Add(shader.GetPropertyDefaultFloatValue(i));
                        break;
                    case ShaderPropertyType.Range:
                        propertiesBP.nameToIndex.Add(name, propertiesBP.ranges.Count);
                        propertiesBP.ranges.Add(new SFloatRange(shader.GetPropertyDefaultFloatValue(i), shader.GetPropertyRangeLimits(i)));
                        break;
                    case ShaderPropertyType.Texture:
                        break;
                    case ShaderPropertyType.Int:
                        propertiesBP.nameToIndex.Add(name, propertiesBP.ints.Count);
                        propertiesBP.ints.Add(shader.GetPropertyDefaultIntValue(i));
                        break;
                }
            }
        }

        // Create ranges object 
        propertiesRanges = new RangeProperties(propertiesBP);
    }



    [Serializable]
    private class ShaderProperties
    {
        public List<Tuple<string, ShaderPropertyType>> nameAndType = new List<Tuple<string, ShaderPropertyType>>();
        public Dictionary<string, ShaderPropertyType> nameToType = new Dictionary<string, ShaderPropertyType>();
        public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();

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

        public Vector2 GetRange()
        {
            return new Vector2(min, max);
        }

        public float GetValue()
        {
            return value;
        }

        public void SetValue(float v)
        {
            value = Mathf.Clamp(value, min, max);
        }
    }



    [Serializable]
    private class RangeProperties
    {
        [SerializeField] public List<ColorRange> colors = new List<ColorRange>();
        [SerializeField] public List<VectorRange> vectors = new List<VectorRange>();
        [SerializeField] public List<FloatRange> floats = new List<FloatRange>();
        [SerializeField] public List<RangeRange> ranges = new List<RangeRange>();
        [SerializeField] public List<Texture> texs = new List<Texture>();
        [SerializeField] public List<IntRange> ints = new List<IntRange>();

        /// <summary>
        /// Generate the random range structures using the
        /// given properties object as a blueprint 
        /// </summary>
        /// <param name="properties"></param>
        public RangeProperties(ShaderProperties properties)
        {
            foreach (Tuple<string, ShaderPropertyType> tuple in properties.nameAndType)
            {
                string name = tuple.Item1;
                int index = properties.nameToIndex[name];

                switch (tuple.Item2)
                {
                    case ShaderPropertyType.Color:
                        colors.Add(new ColorRange(name));
                        break;
                    case ShaderPropertyType.Vector:
                        vectors.Add(new VectorRange(name));
                        break;
                    case ShaderPropertyType.Float:
                        floats.Add(new FloatRange(name));
                        break;
                    case ShaderPropertyType.Range:
                        ranges.Add(new RangeRange(name, properties.ranges[index].GetRange()));
                        break;
                    case ShaderPropertyType.Texture:
                        // Just copy over the whole list at once later 
                        break;
                    case ShaderPropertyType.Int:
                        ints.Add(new IntRange(name));
                        break;
                    default:
                        Debug.LogWarning("Invalid ShaderPropertyType: " + tuple.Item2);
                        break;
                }
            }
            texs = properties.texs;
        }


        /// <summary>
        /// Generates a ShaderProperties object with random values
        /// based on the ranges in this object 
        /// </summary>
        /// <returns></returns>
        public ShaderProperties GenerateSP()
        {
            return null;
        }
    }

    [Serializable]
    private class ColorRange
    {
        [SerializeField] public string colorName;
        [SerializeField] public Gradient gradient;

        public ColorRange(string name)
        {
            colorName = name;
        }
    }

    [Serializable]
    private class VectorRange
    {
        [SerializeField] public string vectorName;
        [SerializeField] public Vector4 minRange, maxRange;

        public VectorRange(string name)
        {
            vectorName = name;
        }
    }

    [Serializable]
    private class FloatRange
    {
        [SerializeField] public string floatName;
        [SerializeField] public Vector2 range;

        public FloatRange(string name)
        {
            floatName = name;
        }
    }

    [Serializable]
    private class RangeRange // :3 
    {
        [SerializeField] public string rangeName;
        [SerializeField] public Vector2 range;

        public RangeRange(string name, Vector2 range)
        {
            rangeName = name;
            this.range = range;
        }
    }

    [Serializable]
    private class IntRange
    {
        [SerializeField] public string intName;
        [SerializeField] public Vector2Int range;

        public IntRange(string name)
        {
            intName = name;
        }
    }


}
