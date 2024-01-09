using ApigeeToAzureApimMigrationTool.Core;
using ApigeeToAzureApimMigrationTool.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApigeeToAzureApimMigrationTool.Service
{
    public class ApigeeFileBundleProvider : IBundleProvider
    {
        private readonly string _bundleDirectory;
        private string _proxyOrProductName;

        public ApigeeFileBundleProvider(string bundleDirectory)
        {
            _bundleDirectory = bundleDirectory;
            _proxyOrProductName = string.Empty;
        }

        public string GetBaseBundlePath()
        {
            return _bundleDirectory;
        }

        public string GetBundlePath()
        {
            return Path.Combine(_bundleDirectory, _proxyOrProductName);
        }

        public Task LoadBundle(string proxyOrProductName)
        {   
            _proxyOrProductName = proxyOrProductName;
            // Nothing to return, the bundle is already in the filesystem
            return Task.CompletedTask;
        }
    }
}
