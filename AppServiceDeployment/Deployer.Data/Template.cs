using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployer.Data
{
    public class Template
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "$schema")]
        public string schema { get; set; }
        public string contentVersion { get; set; }
        public Parameters parameters { get; set; }
        public Variables variables { get; set; }
        public IList<Resource> resources { get; set; }
    }

    public class Parameters
    {
        public int Id { get; set; }
        public Planname planName { get; set; }
    }

    public class Planname
    {
        public int Id { get; set; }
        public string type { get; set; }
    }

    public class Variables
    {
        public int Id { get; set; }
        public string workerSize { get; set; }
        public string sku { get; set; }
        public string location { get; set; }
    }

    public class Resource
    {
        public int Id { get; set; }
        public string apiVersion { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public Tags tags { get; set; }
        public Properties properties { get; set; }

        [JsonIgnore]
        public IList<Dependency> internalDependsOn { get; set; }
        public string[] dependsOn
        {
            get
            {
                return internalDependsOn.Select(i => i.Name).ToArray<string>();
            }
        }
    }


    public class Dependency
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Tags
    {
        public int Id { get; set; }
        public string displayName { get; set; }
        public string concathiddenrelatedresourceGroupidprovidersMicrosoftWebserverfarmsparametersplanName { get; set; }
    }

    public class Properties
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string workerSize { get; set; }
        public int numberOfWorkers { get; set; }
        public string serverFarm { get; set; }
    }

}
