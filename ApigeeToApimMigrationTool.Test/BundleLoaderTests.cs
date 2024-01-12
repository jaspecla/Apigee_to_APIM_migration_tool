using ApigeeToAzureApimMigrationTool.Core;
using ApigeeToAzureApimMigrationTool.Core.Interface;
using ApigeeToAzureApimMigrationTool.Service;
using ApigeeToAzureApimMigrationTool.Service.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApigeeToApimMigrationTool.Test
{
    public class BundleLoaderTests
    {
        // The purpose of these tests is to test loading bundles from files.
        // We're using the test file loaders, but the process should be the same
        // with the real loaders, only we'll be loading from the filesystem instead 
        // of from the Apigee API.

        private AzureApimService _azureApimServiceUnderTest;
        private IBundleProvider _bundleProvider;
        public BundleLoaderTests()
        {
            _bundleProvider = new ApigeeFileBundleProvider("TestBundles");

            IApigeeXmlLoader apigeeXmlLoader = new ApigeeXmlFileLoader(_bundleProvider);
            IApigeeManagementApiService apigeeManagementApiService = new ApigeeManagementApiTestFileService(_bundleProvider, apigeeXmlLoader);
            IApimProvider apimProvider = new MockApimProvider();
            IPolicyTransformationFactory policyTransformationFactory = new PolicyTransformationFactory(apigeeManagementApiService, apimProvider, apigeeXmlLoader);

            _azureApimServiceUnderTest = new AzureApimService(
                apigeeXmlLoader: apigeeXmlLoader,
                apimProvider: apimProvider,
                policyTransformer: new ApigeeToApimPolicyTransformer(policyTransformationFactory));
        }
        [Fact]
        public async Task FileBundleLoader_WithSharedFlowPolicy_LoadsSharedFlow()
        {
            await _bundleProvider.LoadBundle("Test-API");
            await _azureApimServiceUnderTest.ImportApi("Test-Apim", "Test-API", null, null, null);

        }
    }
}
