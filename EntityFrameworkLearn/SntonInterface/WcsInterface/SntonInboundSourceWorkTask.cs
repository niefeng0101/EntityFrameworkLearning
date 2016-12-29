using System;
using Kengic.Was.CrossCutting.Common;
using Kengic.Was.Domain.Entity.WorkTask;
using Kengic.Was.Domain.Entity.WorkTask.WorkTasks;
using Newtonsoft.Json.Linq;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class SntonInboundSourceWorkTask : SourceWorkTask<string>
    {
        public string ContainerCode { get; set; }
        public string SourceAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string NodeId { get; set; }

        public override void FormateWorkTask(JObject jObject)
        {
            ContainerCode = JSonHelper.GetValue<string>(jObject, StaticParameterForWorkTask.ContainerCode);
            SourceAddress = JSonHelper.GetValue<string>(jObject, StaticParameterForWorkTask.SourceAddress);
            CurrentAddress = JSonHelper.GetValue<string>(jObject, StaticParameterForWorkTask.CurrentAddress);

            DestinationAddress = JSonHelper.GetValue<string>(jObject, StaticParameterForWorkTask.DestinationAddress);
            base.FormateWorkTask(jObject);
        }
    }
}
