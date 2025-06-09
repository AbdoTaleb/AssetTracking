using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class AssetManager
    {
        private List<Asset> assets = new List<Asset>();

        public void AddAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset), "Asset cannot be null");
            }
            assets.Add(asset);
        }

    }
}
