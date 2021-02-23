
namespace StoreModels
{
    /// <summary>
    /// This class contains all the fields and properties that define a store Location
    /// </summary>
    public class Location
    {
        //Fields
        private int locationID;
        private string address;
        private string state;
        private string locationName;

        //Constructor(s)
        public Location(int locationID, string address, string state, string locationName)
        {
            this.locationID = locationID;
            this.address = address;
            this.state = state;
            this.locationName = locationName;
        }

        //Properties
        public int LocationID
        {
            get {return locationID;}
            set {locationID = value;}
        }
        public string Address
        {
            get {return address;}
            set {address = value;}
        }
        public string State
        {
            get {return state;}
            set {state = value;}
        }
        public string LocationName
        {
            get {return locationName;}
            set{locationName = value;}
        }
        //Methods
        public override string ToString()
        {
            return $"Store Information: \n\t Store Name: {this.LocationName} \n\t State: {this.State} \n\t Address: {this.Address}";
        }
    }
}