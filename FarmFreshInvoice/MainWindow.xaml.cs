using FarmFreshInvoice.SubViews;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace FarmFreshInvoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int billNum = 0;
        int billNumPurchase = 0;
        private FirebaseHandler handler;
        private bool isDragging = false;
        private bool wantDrag = true;
        private Point clickPosition;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += Window_Loaded;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            MessageBox.Show("Hi from Test");
        }

        private void open_retail()
        {
            GetDataFromFirebaseAsync();
        }


       

        private void on_exit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Perform any cleanup or additional actions before exiting if needed
            Application.Current.Shutdown();
        }

        // Subscribe to the KeyDown event when the MainWindow is loaded
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += MainWindow_KeyDown;

        }


        private void Grid_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = false;
            wantDrag = false;
            GetDataFromFirebaseAsync();
        }

        private void wholesale_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
           
            isDragging = false;
            wantDrag = false;
            SecondHandler();
        }

        private void mouseTracker(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                // Check the name of the grid that triggered the event
                if (grid.Name == "retail")
                {
                    isDragging = false;
                    wantDrag = false;
                    GetDataFromFirebaseAsync();
                }
                if (grid.Name == "wholesale")
                {
                    isDragging = false;
                    wantDrag = false;
                    SecondHandler();
                }
                if (grid.Name == "actionBar")
                {

                    if (e.ChangedButton == MouseButton.Left)
                    {
                        isDragging = true;
                        clickPosition = e.GetPosition(this);
                    }

                }
                if (grid.Name == "purchase")
                {
                    PurchaseHandler();
                }


            }
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (wantDrag)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    isDragging = true;
                    clickPosition = e.GetPosition(this);
                }
            }
            else
            {
                wantDrag = true;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(this);
                Left = Left + (currentPosition.X - clickPosition.X);
                Top = Top + (currentPosition.Y - clickPosition.Y);
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
            }
        }


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for Ctrl + N key combination
            if (e.Key == Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                GetDataFromFirebaseAsync();
            }

            if (e.Key == Key.R && Keyboard.Modifiers == ModifierKeys.Control)
            {
                SecondHandler();
            }

        }

        private async Task PurchaseHandler()
        {
            try
            {
                handler = new FirebaseHandler();

                // Fetch data asynchronously
                var data = await handler.GetDataAsync("Settings/billNumPurchase/");

                // Once data retrieval is completed, you can update UI or perform other actions
                foreach (var key in data.Keys)
                {
                    billNumPurchase = Convert.ToInt32(data[key]) + 1;
                }

                string billId = $"{billNumPurchase}" + "-" + $"{DateTime.Now:ddMMyyyy}";
                string billTime = $"{DateTime.Now:HH/mm/ss}";
                string billDate = $"{DateTime.Now:dd/MM/yyyy}";
                Purchase newBillWindow = new Purchase(billId, billTime, billDate, billNum);
                newBillWindow.Show();

            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: Failed to retrieve data from server");
            }
        }

        private async Task SecondHandler() {
            try
            {
                handler = new FirebaseHandler();

                // Fetch data asynchronously
                var data = await handler.GetDataAsync("Settings/billNumber/");

                // Once data retrieval is completed, you can update UI or perform other actions
                foreach (var key in data.Keys)
                {
                    billNum = Convert.ToInt32(data[key]) + 1;
                }

                string billId = $"{billNum}" + "-" + $"{DateTime.Now:ddMMyyyy}";
                string billTime = $"{DateTime.Now:HH/mm/ss}";
                string billDate = $"{DateTime.Now:dd/MM/yyyy}";
                Wholesale newBillWindow = new Wholesale(billId, billTime, billDate, billNum);
                newBillWindow.Show();

            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: Failed to retrieve data from server");
            }
        }

        private async Task GetDataFromFirebaseAsync()
        {
            try
            {
                handler = new FirebaseHandler();

                // Fetch data asynchronously
                var data = await handler.GetDataAsync("Settings/billNumber/");

                // Once data retrieval is completed, you can update UI or perform other actions
                UpdateUIWithData(data);
                
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: Failed to retrieve data from server");
            }

        }

        private void UpdateUIWithData(Dictionary<string, string> data)
        {
            
            foreach (var key in data.Keys)
            {
                billNum = Convert.ToInt32(data[key]) + 1;
            }
            OpenNewBill();


        }
        private void OpenNewBill()
        {
            // Open the second window
            string billId = $"{billNum}" + "-" + $"{DateTime.Now:ddMMyyyy}";
            string billTime = $"{DateTime.Now:HH/mm/ss}";
            string billDate = $"{DateTime.Now:dd/MM/yyyy}";
            Window1 newBillWindow = new Window1(billId, billTime, billDate, billNum);
            newBillWindow.Show();
        }
    }
}