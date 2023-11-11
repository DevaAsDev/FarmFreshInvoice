using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;

public partial class FirebaseHandler
{
    private IFirebaseClient client;

    public FirebaseHandler()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "4pqnoWNoNxs9DUnCzzaHT0kxpekX32Ei9XwHT98d",
            BasePath = "https://my-calculator-f2f5c-default-rtdb.firebaseio.com/"
        };

        client = new FirebaseClient(config);
    }

    public async Task<Dictionary<string, string>> GetDataAsync(string nodeName)

    {

        FirebaseResponse response = await client.GetAsync(nodeName);
        Dictionary<string, string> vegetableData = new Dictionary<string, string>();

        if (response != null)
        {
            dynamic data = response.ResultAs<dynamic>(); // Parsing the response to dynamic data
           
            // Iterate through the list and retrieve the vegetable names
            foreach (var item in data)
            {
                var jProperty = item as JProperty;  // Retrieve the JProperty from the dynamic object

                if (jProperty != null)
                {
                    string vegetableName = jProperty.Name; // This will get the vegetable name
                    string vegetableValue = jProperty.Value.ToString(); // This will get the value associated with the vegetable

                    // Store in Dictionary
                    vegetableData[vegetableName] = vegetableValue;
                }
            }
            return vegetableData;
        }
        return vegetableData;
    }

}
