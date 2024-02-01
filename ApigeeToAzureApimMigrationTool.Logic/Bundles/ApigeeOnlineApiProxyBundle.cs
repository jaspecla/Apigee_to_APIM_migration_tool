using ApigeeToAzureApimMigrationTool.Core;
using ApigeeToAzureApimMigrationTool.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApigeeToAzureApimMigrationTool.Service.Bundles
{
    public class ApigeeOnlineApiProxyBundle : IBundle
    {
        private readonly IApigeeManagementApiService _apigeeManagementApiService;
        private readonly string _basePath;
        private string? _bundlePath;

        public ApigeeOnlineApiProxyBundle(string basePath, IApigeeManagementApiService apigeeManagementApiService)
        {
            _basePath = basePath;
            _apigeeManagementApiService = apigeeManagementApiService;
        }

        public async Task LoadBundle(string proxyOrProductName)
        {
            //get api metadata
            var apiProxyMetadata = await _apigeeManagementApiService.GetApiProxyByName(proxyOrProductName);
            //get the latest revision
            int maxRevision = apiProxyMetadata.revision.Select(x => int.Parse(x)).Max();
            //download api proxy bundle 
            _bundlePath = await _apigeeManagementApiService.DownloadApiProxyBundle(_basePath, proxyOrProductName, maxRevision);
        }
        public string GetBundlePath()
        {
            if (string.IsNullOrEmpty(_bundlePath))
            {
                throw new Exception("Bundle not loaded. Please load the bundle first");
            }

            return _bundlePath;
        }
    }
}
