﻿using ApigeeToAzureApimMigrationTool.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApigeeToApimMigrationTool.Test
{
    public class MockApigeeXmlLoader : IApigeeXmlLoader
    {
        public Dictionary<string, XDocument> PolicyXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> ProxyEndpointXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> ProxyXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> SharedFlowBundleXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> SharedFlowPolicyXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> SharedFlowXml { get; set; } = new Dictionary<string, XDocument>();
        public Dictionary<string, XDocument> TargetXml { get; set; } = new Dictionary<string, XDocument>();

        public XDocument LoadPolicyXml(string path, string policyName)
        {
            if (PolicyXml.ContainsKey(policyName))
            {
                return PolicyXml[policyName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadProxyEndpointXml(string path, string proxyEndpointName)
        {
            if (ProxyEndpointXml.ContainsKey(proxyEndpointName))
            {
                return ProxyEndpointXml[proxyEndpointName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadProxyXml(string path, string proxyName)
        {
            if (ProxyXml.ContainsKey(proxyName))
            {
                return ProxyXml[proxyName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadSharedFlowBundleXml(string path, string sharedFlowName)
        {
            if (SharedFlowBundleXml.ContainsKey(sharedFlowName))
            {
                return SharedFlowBundleXml[sharedFlowName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadSharedFlowPolicyXml(string path, string policyName)
        {
            if (SharedFlowPolicyXml.ContainsKey(policyName))
            {
                return SharedFlowPolicyXml[policyName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadSharedFlowXml(string path, string sharedFlowName)
        {
            if (SharedFlowXml.ContainsKey(sharedFlowName))
            {
                return SharedFlowXml[sharedFlowName];
            }
            else
            {
                return new XDocument();
            }
        }

        public XDocument LoadTargetXml(string path, string targetEndpointName)
        {
            if (TargetXml.ContainsKey(targetEndpointName))
            {
                return TargetXml[targetEndpointName];
            }
            else
            {
                return new XDocument();
            }
        }
    }
}
