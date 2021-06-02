using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Interfaces;
using UnityEngine;

public class BombView : CollectableView
{
    private ICollectableViewModel _BombViewModel;

    public void Initialize(ICollectableViewModel BombViewModel)
    {
        _BombViewModel = BombViewModel;
    }

    public override void Collect(int points)
    {
        _BombViewModel.AddScore(points);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _BombViewModel.SubtractLive();
            Destroy(gameObject);
        }
    }
}
