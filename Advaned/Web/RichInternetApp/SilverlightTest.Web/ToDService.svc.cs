using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SilverlightTest.Web
{
    [ServiceContract(Namespace = "http://adsd.met.edu/2011/SilverlightTest")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ToDService
    {
        [OperationContract]
        public string GetServerTime(string format)
        {
            // Add your operation implementation here
            return DateTime.Now.ToString(format);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
