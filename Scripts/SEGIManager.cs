using UnityEngine;

// TODO: Clean all of that dirty Camera.main and GetComponent calls

using CurrentSEGI = SEGI;
using CurrentSEGIPreset = SEGIPreset;

namespace SEGIPlugin.Scripts
{
    public class SEGIManager : MonoBehaviour
    {
        private bool _showSegiConfig;

        private void Awake()
        {
        }

        private void Update()
        {
            var component = Camera.main.gameObject.GetComponent<CurrentSEGI>();

            if (!component)
            {
                Camera.main.gameObject.AddComponent<CurrentSEGI>();
                component = Camera.main.gameObject.GetComponent<CurrentSEGI>();
                var preset = ScriptableObject.CreateInstance<CurrentSEGIPreset>();
                component.ApplyPreset(preset);
            }

            component.sun = WorldManager.Instance.WorldSun.TargetLight;

            if (Input.GetKeyDown(KeyCode.F11)) 
                _showSegiConfig = !_showSegiConfig;
        }

        private void OnGUI()
        {
            var component = Camera.main.gameObject.GetComponent<CurrentSEGI>();

            if (component && _showSegiConfig)
            {
                component.enabled = GUILayout.Toggle(component.enabled, $"Enable SEGI ({ component.enabled})");

                if (component.enabled)
                {
                    var highResVoxels = component.voxelResolution == CurrentSEGI.VoxelResolution.high;
                    highResVoxels = GUILayout.Toggle(highResVoxels, "voxelResolution = " + component.voxelResolution);
                    component.voxelResolution = !highResVoxels ? CurrentSEGI.VoxelResolution.low : CurrentSEGI.VoxelResolution.high;

                    component.voxelAA = GUILayout.Toggle(component.voxelAA, "component.voxelAA = " + component.voxelAA);
                    GUILayout.Label("innerOcclusionLayers = " + component.innerOcclusionLayers);
                    component.innerOcclusionLayers = (int)GUILayout.HorizontalSlider(component.innerOcclusionLayers, 0, 2);
                    component.infiniteBounces = GUILayout.Toggle(component.infiniteBounces,
                        "infiniteBounces = " + component.infiniteBounces);
                    GUILayout.Label("temporalBlendWeight = " + component.temporalBlendWeight);
                    component.temporalBlendWeight = GUILayout.HorizontalSlider(component.temporalBlendWeight, 0.0f, 1.0f);
                    component.useBilateralFiltering = GUILayout.Toggle(component.useBilateralFiltering,
                        "useBilateralFiltering = " + component.useBilateralFiltering);
                    component.halfResolution = GUILayout.Toggle(component.halfResolution,
                        "halfResolution = " + component.halfResolution);
                    component.stochasticSampling = GUILayout.Toggle(component.stochasticSampling,
                        "stochasticSampling = " + component.stochasticSampling);
                    component.doReflections =
                        GUILayout.Toggle(component.doReflections, "doReflections = " + component.doReflections);
                    GUILayout.Label("cones = " + component.cones);
                    component.cones = (int)GUILayout.HorizontalSlider(component.cones, 1, 128);
                    GUILayout.Label("coneTraceSteps = " + component.coneTraceSteps);
                    component.coneTraceSteps = (int)GUILayout.HorizontalSlider(component.coneTraceSteps, 1, 32);
                    GUILayout.Label("coneLength = " + component.coneLength);
                    component.coneLength = GUILayout.HorizontalSlider(component.coneLength, 0.1f, 1.0f);
                    GUILayout.Label("coneWidth = " + component.coneWidth);
                    component.coneWidth = GUILayout.HorizontalSlider(component.coneWidth, 0.5f, 6.0f);
                    GUILayout.Label("coneTraceBias = " + component.coneTraceBias);
                    component.coneTraceBias = GUILayout.HorizontalSlider(component.coneTraceBias, 0f, 4f);
                    GUILayout.Label("occlusionStrength = " + component.occlusionStrength);
                    component.occlusionStrength = GUILayout.HorizontalSlider(component.occlusionStrength, 0f, 1f);
                    GUILayout.Label("nearOcclusionStrength = " + component.nearOcclusionStrength);
                    component.nearOcclusionStrength = GUILayout.HorizontalSlider(component.nearOcclusionStrength, 0f, 4f);
                    GUILayout.Label("occlusionPower = " + component.occlusionPower);
                    component.occlusionPower = GUILayout.HorizontalSlider(component.occlusionPower, 0.001f, 4f);
                    GUILayout.Label("nearLightGain = " + component.nearLightGain);
                    component.nearLightGain = GUILayout.HorizontalSlider(component.nearLightGain, 0f, 4f);
                    GUILayout.Label("giGain = " + component.giGain);
                    component.giGain = GUILayout.HorizontalSlider(component.giGain, 0f, 4f);
                    GUILayout.Label("secondaryBounceGain = " + component.secondaryBounceGain);
                    component.secondaryBounceGain = GUILayout.HorizontalSlider(component.secondaryBounceGain, 0f, 2f);
                    GUILayout.Label("reflectionSteps = " + component.reflectionSteps);
                    component.reflectionSteps = (int)GUILayout.HorizontalSlider(component.reflectionSteps, 0f, 128);
                    GUILayout.Label("reflectionOcclusionPower = " + component.reflectionOcclusionPower);
                    component.reflectionOcclusionPower =
                        GUILayout.HorizontalSlider(component.reflectionOcclusionPower, 0.001f, 4f);
                    GUILayout.Label("skyReflectionIntensity = " + component.skyReflectionIntensity);
                    component.skyReflectionIntensity =
                        GUILayout.HorizontalSlider(component.skyReflectionIntensity, 0f, 1.0f);
                    component.gaussianMipFilter = GUILayout.Toggle(component.gaussianMipFilter,
                        "gaussianMipFilter = " + component.gaussianMipFilter);
                    GUILayout.Label("farOcclusionStrength = " + component.farOcclusionStrength);
                    component.farOcclusionStrength = GUILayout.HorizontalSlider(component.farOcclusionStrength, 0.1f, 4f);
                    GUILayout.Label("farthestOcclusionStrength = " + component.farthestOcclusionStrength);
                    component.farthestOcclusionStrength =
                        GUILayout.HorizontalSlider(component.farthestOcclusionStrength, 0.1f, 4f);
                    GUILayout.Label("secondaryCones = " + component.secondaryCones);
                    component.secondaryCones = (int)GUILayout.HorizontalSlider(component.secondaryCones, 3, 16);
                    GUILayout.Label("secondaryOcclusionStrength = " + component.secondaryOcclusionStrength);
                    component.secondaryOcclusionStrength =
                        GUILayout.HorizontalSlider(component.secondaryOcclusionStrength, 0.1f, 4f);
                }
            }
        }
    }
}