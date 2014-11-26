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
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
namespace Kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        sales_invoice salesInvoice = new sales_invoice();
        List<product_sales> ProductSales = new List<product_sales>();
        private void Button_Add_sales_ivoice(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            Invoices.Visibility = System.Windows.Visibility.Visible;
            sailing.Visibility = Visibility.Visible;
            date_of_sales_invoice.SelectedDate = DateTime.Now;
            workshop_number.Text = "";
        }

        private void agree_sailing(object sender, RoutedEventArgs e)
        {

            int workshop;
            if (!Int32.TryParse(workshop_number.Text, out workshop))
            {
                MessageBox.Show("Номер цеха должен состоять из цифр!!!");
                return;
            }
            sales_invoice si = new sales_invoice() { date_of_sale = Convert.ToDateTime(date_of_sales_invoice.SelectedDate), id_workshop=workshop };//ваще хз че так
            salesInvoice = si;
            sailing.Visibility = Visibility.Hidden;
            sailing_list.Visibility = Visibility.Visible;
            Button_contract_ready2.Visibility = Visibility.Hidden;
            Button_contract_ready2.IsEnabled = false;
            var k = (from asd in model.raw
                     select asd).ToList();
            if (Combo_raw2.Items.Count > 0) Combo_raw2.Items.Clear();
            foreach (raw t in k)
                Combo_raw2.Items.Add(t.name_raw); 
           // Combo_raw2.SelectedItem = Combo_raw2.Items[0];
        }
        private void Order_Next_sailing(object sender, RoutedEventArgs e)
        {
            if ((string)Combo_raw2.SelectedItem == null)
            {
                MessageBox.Show("Выберите сырье!!!");
                return;
            }
            string raw_name = Combo_raw2.SelectedItem.ToString();
            int am;
            if (!Int32.TryParse(Amount_of_raw2.Text, out am))
            {
                MessageBox.Show("Количество должно состоять из цифр!!!");
                return;
            }


            var z = (from asd in model.raw
                     where asd.name_raw == raw_name
                     select asd).ToList();
            if ((from asd in ProductSales
                 where asd.id_raw == z[0].id_raw
                 select asd).LongCount() > 0 == true)
            {
                MessageBox.Show("Такой вид сырья уже был выбран!!!");
                return;
            }



            product_sales ps = new product_sales() { id_raw = z[0].id_raw, amount = am, id_of_sailing = salesInvoice.id_of_sailing };
            ProductSales.Add(ps);
            Button_contract_ready2.Visibility = Visibility.Visible;
            Button_contract_ready2.IsEnabled = true;
            Combo_raw2.SelectedItem = null;
            Amount_of_raw2.Text = "";
        }

        private void contract_ready_sailing(object sender, RoutedEventArgs e)
        {
            sailing_list.Visibility = Visibility.Hidden;
            sailing_report.Visibility = Visibility.Visible;
            AgreeText2.Text =
            "Цех: " + salesInvoice.id_workshop + Environment.NewLine +
            "Дата отгрузки:" + salesInvoice.date_of_sale + Environment.NewLine +
            "Cыръе и материалы:" + Environment.NewLine;
            foreach (product_sales pr in ProductSales)
            {
                AgreeText2.Text += "Вид : " + (from asd in model.raw
                                               where asd.id_raw == pr.id_raw
                                               select asd).First().name_raw + Environment.NewLine +
                    "Количество: " + pr.amount + Environment.NewLine;
            }
        }
        private void Agree_order_sailing(object sender, RoutedEventArgs e)
        {
            model.product_sales.AddRange(ProductSales);
            model.sales_invoice.Add(salesInvoice);
            try
            {
                model.SaveChanges();
                MessageBox.Show("Запись была успешно добавлена");
                ShowClientTable(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Menu.Visibility = Visibility.Visible;
            sailing_report.Visibility = Visibility.Hidden;
            salesInvoice = null;
            ProductSales.Clear();
        }

        private void cancel_order_sailing(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
            sailing_report.Visibility = Visibility.Hidden;
            salesInvoice = null;
            ProductSales.Clear();
        }

        private void Add_Order_Create_report_sailing(object sender, RoutedEventArgs e)
        {
            Agree_order_sailing(null, null);
            Create_Report_Order(AgreeText2.Text);
            salesInvoice = null;
            ProductSales.Clear();
        }


    }
}
