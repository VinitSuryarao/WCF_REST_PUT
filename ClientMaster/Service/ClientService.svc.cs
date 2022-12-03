using ClientMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ClientMaster.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ClientService
    {
        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<ClientModel> GetAllClients() // Get All Record
        {
            return ClientData.Data;
        }

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Client/{Id}")]
        public ClientModel GetSingleClient(string Id) // Get Single Record With Cust URL
        {
            return ClientData.Data.Find(x => x.Id == Convert.ToInt32(Id));
        }

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateClient", Method = "PUT")]
        public ClientModel AddClient(ClientModel obj, string Id) // Add Record
        {
            ClientModel client = ClientData.Data.Find(x => x.Id == Convert.ToInt32(Id));

            client.Code = obj.Code;
            client.Name = obj.Name;
            client.Exchange = obj.Exchange;
            
            return client;
        }

    }
}
