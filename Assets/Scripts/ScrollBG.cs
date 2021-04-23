﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    private MeshRenderer _mRenderer;
    
    void Start()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        if (_mRenderer == null)
        {
            Debug.LogError("The MeshRenderer is NULL");
        }
    }

    void Update()
    {
        Material mat = _mRenderer.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
