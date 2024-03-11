﻿using System;
using System.Threading.Tasks;

namespace Assets
{
    public class CompositeAssetService : IAssetService
    {
        private readonly IAssetService[] _assetServices;

        public CompositeAssetService(params IAssetService[] assetServices) =>
            _assetServices = assetServices ?? throw new ArgumentNullException(nameof(assetServices));

        public async Task LoadAsync()
        {
            foreach (IAssetService assetService in _assetServices)
                await assetService.LoadAsync();
        }

        public void Release()
        {
            foreach (IAssetService assetService in _assetServices)
                assetService.Release();
        }
    }
}