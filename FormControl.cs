namespace BusBooking
{
    public class FormControl
    {
        public void TripFormular(string email)
        {
            Trips trips = new Trips(email);
            trips.ShowDialog();
        } 
        public void BussesFormular(string email)
        {
        Busses busses = new Busses(email);  
        busses.ShowDialog();
        }
        public void DriversFormular(string email)
        {
            Drivers drivers = new Drivers(email);
            drivers.ShowDialog();
        }
        public void MyAccountFormular(string email)
        {
            MyAccount myAccount = new MyAccount(email);
            myAccount.ShowDialog();
        }

        public void PassengersFormular(string email)
        {
            Passengers passengers = new Passengers(email);
            passengers.ShowDialog();
        }
        public void StationFormular(string email)
        {
           Station station = new Station(email);
            station.ShowDialog();
        }
    }
}
