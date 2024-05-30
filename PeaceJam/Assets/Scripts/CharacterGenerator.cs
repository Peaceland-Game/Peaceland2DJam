using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] GameObject gooberCharacter;
    [SerializeField] int characterCount;
    [SerializeField] Vector2 spacing;
    [Header("Overall GoopSettings")]
    [SerializeField] Vector2 timeScaleRange;
    [SerializeField] Vector2 dirA;
    [SerializeField] Vector2 dirB;
    [Header("SimpleNoise")]
    [SerializeField] Vector2 SimpleNoiseScaleRange;
    [SerializeField] Vector2 SimpleGradientThresholdARange;
    [SerializeField] Vector2 SimpleGradientThresholdBRange;
    [SerializeField] Vector2 SimpleCenterXRange;
    [SerializeField] Vector2 SimpleCenterYRange;
    [SerializeField] Vector2 SimpleSizeXRange;
    [SerializeField] Vector2 SimpleSizeYRange;
    [Header("Voronoi")]
    [SerializeField] Vector2 RescaleRange;
    [SerializeField] Vector2 AngleOffsetRange;
    [SerializeField] Vector2 CellDensityRange;
    [SerializeField] Vector2 VoronoiGradientThresholdARange;
    [SerializeField] Vector2 VoronoiGradientThresholdBRange;
    [SerializeField] Vector2 VoronoiCenterXRange;
    [SerializeField] Vector2 VoronoiCenterYRange;
    [SerializeField] Vector2 VoronoiSizeXRange;
    [SerializeField] Vector2 VoronoiSizeYRange;
    [Header("Color")]
    [SerializeField] Gradient PrimaryColorRange;
    [SerializeField] Gradient SecondaryColorRange;
    [SerializeField] Gradient HighlightColorRange;
    [SerializeField] Vector2 SaturationRange;
    [SerializeField] Vector2 PrimaryMetallicRange;
    [SerializeField] Vector2 PrimarySmoothnessRange;
    [SerializeField] Vector2 SecondaryMetallicRange;
    [SerializeField] Vector2 SecondarySmoothnessRange;
    [Header("VertexDisplacement")]
    [SerializeField] Vector2 DisScaleRange;
    [SerializeField] Vector2 DisAngleOffsetRange;
    [SerializeField] Vector2 DisCellDensityRange;
    [SerializeField] Vector2 DisTimeScaleRange;

    private void SpawnCharacters()
    {

    }

    private void SetCharacter(Renderer renderer, GooberMaterial material)
    {

    }

    
    private class GooberMaterial
    {
        // Pattern Settings 
        public float timeScaleRange;
        public Vector2 direction;

        // SimpleNoise
        public float SimpleNoiseScale;
        public float SimpleGradientThresholdA;
        public float SimpleGradientThresholdB;
        public Vector2 SimpleCenter;
        public Vector2 SimpleSize;

        // Voronoi
        public float Rescale;
        public float AngleOffset;
        public float CellDensity;
        public float VoronoiGradientThresholdA;
        public float VoronoiGradientThresholdB;
        public Vector2 VoronoiCenter;
        public Vector2 VoronoiSize;

        // Color
        public Color PrimaryColor;
        public Color SecondaryColor;
        public Color HighlightColor;
        public float Saturation;
        public float PrimaryMetallic;
        public float PrimarySmoothness;
        public float SecondaryMetallic;
        public float SecondarySmoothness;

        // VertexDisplacement
        public float DisScale;
        public float DisAngleOffset;
        public float DisCellDensity;
        public float DisTimeScale;

        public GooberMaterial(
            float timeScaleRange,
            Vector2 direction,
            float SimpleNoiseScale,
            float SimpleGradientThresholdA,
            float SimpleGradientThresholdB,
            Vector2 SimpleCenter,
            Vector2 SimpleSize,
            float Rescale,
            float AngleOffset,
            float CellDensity,
            float VoronoiGradientThresholdA,
            float VoronoiGradientThresholdB,
            Vector2 VoronoiCenter,
            Vector2 VoronoiSize,
            Color PrimaryColor,
            Color SecondaryColor,
            Color HighlightColor,
            float Saturation,
            float PrimaryMetallic,
            float PrimarySmoothness,
            float SecondaryMetallic,
            float SecondarySmoothness,
            float DisScale,
            float DisAngleOffset,
            float DisCellDensity,
            float DisTimeScale)
        {
            this.timeScaleRange = timeScaleRange;
            this.direction = direction;
            this.SimpleNoiseScale = SimpleNoiseScale;
            this.SimpleGradientThresholdA = SimpleGradientThresholdA;
            this.SimpleGradientThresholdB = SimpleGradientThresholdB;
            this.SimpleCenter = SimpleCenter;
            this.SimpleSize = SimpleSize;
            this.Rescale = Rescale;
            this.AngleOffset = AngleOffset;
            this.CellDensity = CellDensity;
            this.VoronoiGradientThresholdA = VoronoiGradientThresholdA;
            this.VoronoiGradientThresholdB = VoronoiGradientThresholdB;
            this.VoronoiCenter = VoronoiCenter;
            this.VoronoiSize = VoronoiSize;  
            this.PrimaryColor = PrimaryColor;
            this.SecondaryColor = SecondaryColor;
            this.HighlightColor = HighlightColor;
            this.Saturation = Saturation;
            this.PrimaryMetallic = PrimaryMetallic;
            this.PrimarySmoothness = PrimarySmoothness;
            this.SecondaryMetallic = SecondaryMetallic;
            this.SecondarySmoothness = SecondarySmoothness;
            this.DisScale = DisScale;
            this.DisAngleOffset = DisAngleOffset;
            this.DisCellDensity = DisCellDensity;
            this.DisTimeScale = DisTimeScale;
        }
    }
}
