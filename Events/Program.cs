class Program
{
    static void Main(String[] args)
    {
        var room = new Room(3);
        room.RoomSoldOutEvent += OnRoomSoldOut;
    }


    static void OnRoomSoldOut(object sender, EventArgs e)
    {
        Console.WriteLine("Sala lotada.");
    }

}

public class Room
{
    public Room(int seats) 
    { 
        Seats = seats;
        seatsInUse = 0;
    }

    private int seatsInUse = 0;
    public int Seats { get; set; }

    public void ReserveSeat()
    {
        seatsInUse++;

        if (seatsInUse >= Seats)
        {
            OnRoomSoldOut(EventArgs.Empty); 
        }
        else
        {
            Console.WriteLine("Assento reservado");
        }
    }
    
    public event EventHandler RoomSoldOutEvent;

    protected virtual void OnRoomSoldOut(EventArgs e)
    {
        EventHandler handler = RoomSoldOutEvent;
        handler?.Invoke(null, e);
    }
}