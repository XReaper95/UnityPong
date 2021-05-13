using System;
using UnityEngine;

public class CrtPostProcess : MonoBehaviour
{
    public Shader shader;
    
    [Range(1.0f, 8.0f)]
    public float bend;
    [Range(10.0f, 300.0f)]
    public float scanlineSize1;
    [Range(-30.0f, 30.0f)]
    public float scanlineSpeed1;
    [Range(1.0f, 40.0f)]
    public float scanlineSize2;
    [Range(-10.0f, 10.0f)]
    public float scanlineSpeed2;
    [Range(0.01f, 0.1f)]
    public float scanlineAmount;
    [Range(0.1f, 3.0f)]
    public float vignetteSize;
    [Range(0.1f, 3.0f)]
    public float vignetteSmoothness;
    [Range(1.0f, 20.0f)]
    public float vignetteEdgeRound;
    [Range(10.0f, 300.0f)]
    public float noiseSize;
    [Range(0.01f, 0.5f)]
    public float noiseAmount;

    // Chromatic aberration amounts
    public Vector2 redOffset = new Vector2(0, -0.001f);
    public Vector2 blueOffset = new Vector2(-0.001f, 0);
    public Vector2 greenOffset = new Vector2(0, 0.01f);

    private Material _material;
    private static readonly int UVignetteSmoothness = Shader.PropertyToID("u_vignette_smoothness");
    private static readonly int UVignetteSize = Shader.PropertyToID("u_vignette_size");
    private static readonly int UScanlineAmount = Shader.PropertyToID("u_scanline_amount");
    private static readonly int UScanlineSpeed2 = Shader.PropertyToID("u_scanline_speed_2");
    private static readonly int UScanlineSize2 = Shader.PropertyToID("u_scanline_size_2");
    private static readonly int UScanlineSpeed1 = Shader.PropertyToID("u_scanline_speed_1");
    private static readonly int UScanlineSize1 = Shader.PropertyToID("u_scanline_size_1");
    private static readonly int UBend = Shader.PropertyToID("u_bend");
    private static readonly int UTime = Shader.PropertyToID("u_time");
    private static readonly int UVignetteEdgeRound = Shader.PropertyToID("u_vignette_edge_round");
    private static readonly int UNoiseSize = Shader.PropertyToID("u_noise_size");
    private static readonly int UNoiseAmount = Shader.PropertyToID("u_noise_amount");
    private static readonly int URedOffset = Shader.PropertyToID("u_red_offset");
    private static readonly int UBlueOffset = Shader.PropertyToID("u_blue_offset");
    private static readonly int UGreenOffset = Shader.PropertyToID("u_green_offset");

    private bool _enableShader;

    // Use this for initialization
    void Start()
    {
        _material = new Material(shader);
        _enableShader = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _enableShader = !_enableShader;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_enableShader)
        {
            _material.SetFloat(UTime, Time.fixedTime);
            _material.SetFloat(UBend, bend);
            _material.SetFloat(UScanlineSize1, scanlineSize1);
            _material.SetFloat(UScanlineSpeed1, scanlineSpeed1);
            _material.SetFloat(UScanlineSize2, scanlineSize2);
            _material.SetFloat(UScanlineSpeed2, scanlineSpeed2);
            _material.SetFloat(UScanlineAmount, scanlineAmount);
            _material.SetFloat(UVignetteSize, vignetteSize);
            _material.SetFloat(UVignetteSmoothness, vignetteSmoothness);
            _material.SetFloat(UVignetteEdgeRound, vignetteEdgeRound);
            _material.SetFloat(UNoiseSize, noiseSize);
            _material.SetFloat(UNoiseAmount, noiseAmount);
            _material.SetVector(URedOffset, redOffset);
            _material.SetVector(UBlueOffset, blueOffset);
            _material.SetVector(UGreenOffset, greenOffset);
            
            Graphics.Blit(source, destination, _material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
        
        
    }
}