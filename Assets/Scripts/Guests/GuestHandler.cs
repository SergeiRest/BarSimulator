namespace Guests
{
    public class GuestHandler
    {
        public AbstractGuestTemplate Guest { get; private set; }

        public void Add(AbstractGuestTemplate guestTemplate)
        {
            Guest = guestTemplate;
        }
    }
}