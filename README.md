# TheNextCar
Aplikasi ini adalah simulasi mobil pintar / mobil yg menggunakan teknologi modern yang kita harapkan di masa mendatang.
# Scope & Functionalities
- User hanya cukup menyentuh layar untuk menutup pintu 
- Mobil tidak akan menyala jika pintu masih terbuka
- User mendapat petunjuk jika mesin belum dapat dinyalakan

## How Does it Works?
Diawali dengan method main window pada class `MainWindow.xaml.cs` kita mendeklarasikan dengan

```
 public partial class MainWindow : Window , OnPowerChanged, OnDoorChanged, OnCarEngineStateChanged
    {
        private Car nextCar;

        public MainWindow()
        {
            InitializeComponent();
            AccubattreyController accubattreyController = new AccubattreyController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(doorController, accubattreyController , this);
        }
``` 

Logika Controller terdapat 2 class yaitu class `AccubatteryController.cs` dan `DoorController.cs`.kelas ini berfungsi untuk mengontrol pintu untuk membuka,menutup dan mengunci.

Logika `DoorController.cs` di awali dengan deklarasikan

```
 class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }
        
        public void close ()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door is opened");
        }

        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "door is locked");
        }

        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "door is unlocked");
        }

        public bool isClose()
        {
            return this.door.isClosed();
        }

        public bool isLocked()
        {
            return this.door.isLocked();
        }

    }

    interface OnDoorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string valude, string message);
    }
    
```
  
   
  Sedangkan class `Door.cs` ini berfungsi untuk mendeklarasikan untuk class `DoorController.cs`.dengan source code seperti berikut

```
 class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.locked = true;
        }

        public void activateLock()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }

        public bool isLocked()
        {
            return this.locked;
        }

        public bool isClosed()
        {
            return this.closed;
        }
    }
    
    ```
