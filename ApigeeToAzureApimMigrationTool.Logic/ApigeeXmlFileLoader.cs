using ApigeeToAzureApimMigrationTool.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApigeeToAzureApimMigrationTool.Service
{
    public class ApigeeXmlFileLoader : IApigeeXmlLoader
    {
        private readonly IBundleProvider _bundleProvider;
        public ApigeeXmlFileLoader(IBundleProvider bundle)
        {
            _bundleProvider = bundle;
        }
        public XDocument LoadProxyXml(string proxyName)
        {
            var bundle = _bundleProvider.GetApiProxyBundle(proxyName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), $"{proxyName}.xml"));
        }

        public XDocument LoadTargetXml(string targetEndpointName)
        {
            var bundle = _bundleProvider.GetApiProxyBundle(targetEndpointName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), "targets", $"{targetEndpointName}.xml"));
        }

        public XDocument LoadProxyEndpointXml(string proxyEndpointName)
        {
            var bundle = _bundleProvider.GetApiProxyBundle(proxyEndpointName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), "proxies", $"{proxyEndpointName}.xml"));
        }

        public XDocument LoadPolicyXml(string policyName)
        {
            var bundle = _bundleProvider.GetApiProxyBundle(policyName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), "policies", $"{policyName}.xml"));
        }

        public XDocument LoadSharedFlowBundleXml(string sharedFlowName)
        {
            var bundle = _bundleProvider.GetSharedFlowBundle(sharedFlowName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), $"{sharedFlowName}.xml"));
        }

        public XDocument LoadSharedFlowXml(string sharedFlowName)
        {
            var bundle = _bundleProvider.GetSharedFlowBundle(sharedFlowName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), "sharedflows", $"{sharedFlowName}.xml"));
        }

        public XDocument LoadSharedFlowPolicyXml(string policyName)
        {
            var bundle = _bundleProvider.GetSharedFlowBundle(policyName);
            return XDocument.Load(Path.Combine(bundle.GetBundlePath(), "policies", $"{policyName}.xml"));
        }
    }
}
