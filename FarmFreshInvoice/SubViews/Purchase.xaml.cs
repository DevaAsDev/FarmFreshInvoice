using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmFreshInvoice.SubViews
{
    
    public partial class Purchase : Window
    {
        connection conn = new connection();

        private FirebaseHandler handler;
        List<string> allNames;
        Dictionary<string, string> vegetableData = new Dictionary<string, string>();

        float amountSum = 0;

        string billId;
        string billTime;
        string billDateOf;
        string billNum;

        public Purchase(string billId, string billTime, string billDate, int billNum)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            BillId.Text = billId;
            BillTime.Text = billTime;
            BillDate.Text = billDate;

            this.billId = billId;
            this.billTime = billTime;
            this.billDateOf = billDate;
            this.billNum = billNum.ToString();

            Loaded += Window_Loaded;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await GetDataFromFirebaseAsync();
        }

        private async Task GetDataFromFirebaseAsync()
        {
            try
            {
                handler = new FirebaseHandler();

                // Fetch data asynchronously
                var data = await handler.GetDataAsync("wholesale/");

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
            allNames = new List<string>();
            foreach (var key in data.Keys)
            {
                allNames.Add(key);
                vegetableData[key] = data[key];
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from TextBoxes
            string productName = names.Text;
            string price = prices.Text;
            string quantity = quantitys.Text;
            string amount = amounts.Text;

            // Create a new row for the DataGrid
            Product newProduct = new Product
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                Amount = amount
            };

            if (!string.IsNullOrEmpty(productName))
            {
                // Add the new row to the DataGrid
                dataGrid.Items.Add(newProduct);
                float currentAmount;
                float currentDiscount;

                if (float.TryParse(amounts.Text, out currentAmount))
                {
                    amountSum += currentAmount;
                    total.Text = amountSum.ToString();
                    if (float.TryParse(discount.Text, out currentDiscount))
                    {

                        subtotal.Text = (amountSum - currentDiscount).ToString();
                        final_amount.Text = (amountSum - currentDiscount).ToString();
                    }
                    else
                    {
                        subtotal.Text = amountSum.ToString();
                        final_amount.Text = amountSum.ToString();
                    }
                }
                names.Text = "";
                prices.Text = "";
                quantitys.Text = "";
                amounts.Text = "";
            }

        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (float.TryParse(quantitys.Text, out float quantity) && float.TryParse(prices.Text, out float price))
            {
                float amount = quantity * price;
                amounts.Text = amount.ToString();
            }
        }

        private void NamesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string enteredText = textBox.Text;

            if (!string.IsNullOrEmpty(enteredText))
            {
                // Fetch the previously fed names from your data source or collection
                List<string> autoSuggestList = GetSuggestedNames(enteredText);

                // Clear the items of the auto-suggest control (e.g., ListBox or ComboBox)
                // and populate it with the suggested names
                suggestedNames.ItemsSource = autoSuggestList;

                if (autoSuggestList.Any())
                {
                    suggestionsPopup.IsOpen = true;
                }
                else
                {
                    suggestionsPopup.IsOpen = false;
                }
            }

        }

        private List<string> GetSuggestedNames(string enteredText)
        {
            return allNames.Where(name => name.StartsWith(enteredText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void suggestedNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestedNames.SelectedItem != null)
            {
                names.Text = suggestedNames.SelectedItem.ToString();
                suggestionsPopup.IsOpen = false;
                string val = vegetableData[names.Text];
                prices.Text = val.ToString().Trim();
            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            names.Text = "";
            prices.Text = "";
            quantitys.Text = "";
            amounts.Text = "";
        }

        private void discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            float currentDiscount;
            try
            {
                if (float.TryParse(discount.Text, out currentDiscount))
                {

                    subtotal.Text = (amountSum - currentDiscount).ToString();
                    final_amount.Text = (amountSum - currentDiscount).ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void on_exit(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Find the parent window and close it
                Window window = Window.GetWindow(button);
                window?.Close(); // Close the window
            }
        }

        private void save_btn(object sender, RoutedEventArgs e)
        {
            // Create an array or list of radio buttons
            List<RadioButton> radioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3 }; // Include all your radio buttons

            string paymentMethod = "";
            // Loop through the radio buttons to find the checked one
            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.IsChecked == true)
                {
                    string checkedRadioButtonContent = radioButton.Content.ToString();
                    paymentMethod = checkedRadioButtonContent;
                    break; // Exit loop once the checked radio button is found
                }
            }


            Bill newBill = new Bill
            {
                BillId = billId,
                BillDate = billDateOf,
                BillTime = billTime,
                CustomerName = customer_name.Text,
                Mobile = mobile_num.Text,
                Remark = remark.Text,
                PaymentMethod = paymentMethod,
                TotalAmount = total.Text,
                Discount = discount.Text,
                Subtotal = subtotal.Text,
                FinalAmount = final_amount.Text
            };


            // Extract data from the DataGrid
            foreach (var row in dataGrid.Items)
            {

                var product = (Product)row;


                if (row is Product)
                {
                    //var product = (Product)row;

                    BillItem items = new BillItem
                    {
                        ProductName = product.ProductName,
                        Prices = product.Price,
                        Quantitys = product.Quantity,
                        Amounts = product.Amount
                    };

                    newBill.Items.Add(items);
                }

            }

            try
            {
                var todo = new Num
                {
                    latest = billNum
                };

                if (paymentMethod == "Cash")
                {
                    var SetData = conn.client.Set("billCollection/user/purchase/cash/" + billDateOf + "/" + billId, newBill);
                    conn.client.Update("Settings/billNumber/", todo);
                }
                else if (paymentMethod == "From Office")
                {
                    var SetData = conn.client.Set("billCollection/user/purchase/upi/" + billDateOf + "/" + billId, newBill);
                    conn.client.Update("Settings/billNumber/", todo);
                }
                else
                {
                    var SetData = conn.client.Set("billCollection/user/purchase/pending/" + billDateOf + "/" + billId, newBill);
                    conn.client.Update("Settings/billNumber/", todo);
                }

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                Console.WriteLine("Error : Failed to upload bill");
                MessageBox.Show("Data saving failed!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void print_btn(object sender, RoutedEventArgs e)
        {

        }

        public class Num
        {
            public string latest { get; set; }
        }

        public class Bill
        {
            public string BillId { get; set; }
            public string BillDate { get; set; }
            public string BillTime { get; set; }
            public string CustomerName { get; set; }
            public string Mobile { get; set; }
            public string Remark { get; set; }
            public string PaymentMethod { get; set; }
            public List<BillItem> Items { get; set; }
            public string TotalAmount { get; set; }
            public string Discount { get; set; }
            public string Subtotal { get; set; }
            public string FinalAmount { get; set; }
            // Other properties as needed

            public Bill()
            {
                Items = new List<BillItem>();
            }
        }

        public class BillItem
        {
            public string ProductName { get; set; }
            public string Prices { get; set; }
            public string Quantitys { get; set; }
            public string Amounts { get; set; }
        }



        class connection
        {
            //firebase connection Settings
            public IFirebaseConfig fc = new FirebaseConfig()
            {
                AuthSecret = "4pqnoWNoNxs9DUnCzzaHT0kxpekX32Ei9XwHT98d",
                BasePath = "https://my-calculator-f2f5c-default-rtdb.firebaseio.com/"
            };

            public IFirebaseClient client;
            //Code to warn console if class cannot connect when called.
            public connection()
            {
                try
                {
                    client = new FireSharp.FirebaseClient(fc);
                }
                catch (Exception)
                {
                    Console.WriteLine("sunucuya bağlanılamadı");
                }
            }
        }
    }
}
