using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class AssetEndpointManager : EndpointManager<Asset>
    {
        // Explicitly pass hardware as the endpoint, ignoring what the client gives us
        public AssetEndpointManager(IRequestManager reqManager) : base(reqManager, "hardware")
        {
        }

        public IRequestResponse Checkout(ICommonEndpointModel item)
        {
            string response = this.ReqManager.Post(string.Format("{0}/{1}/checkout", this.EndPoint, item.Id), item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);

            return result;
        }

        public IRequestResponse Checkin(ICommonEndpointModel item)
        {
            string response = this.ReqManager.Post(string.Format("{0}/{1}/checkin", this.EndPoint, item.Id), item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);

            return result;
        }

        public Asset FindBySerial(string serial)
        {

            string query = string.Format("{0}/byserial/{1}", this.EndPoint, serial);
            string response = this.ReqManager.Get(query);
            var result = JsonConvert.DeserializeObject<ResponseCollection<Asset>>(response);

            if (result.Total == 0)
            {
                // No asset matching this serial found in database.
                return null;
            }
            else
            {
                Asset dbAsset = result?.Rows?[0];
                return dbAsset;
            }
        }
    }
}

