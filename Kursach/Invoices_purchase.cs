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
        purchase_invoice purchasInvoice = new purchase_invoice();
        List<product_purchase> ProductPurchase = new List<product_purchase>();
        private void Button_Add_purchase_ivoice(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            Invoices.Visibility = System.Windows.Visibility.Visible;
            purchase.Visibility = Visibility.Visible;
            Suppliers_invoice.Items.Clear();
            date_of_purchase_invoice.SelectedDate = DateTime.Now;
            var z = (from asd in model.supplier
                     select asd).ToList();
            List<string> g = new List<string>();
            foreach (supplier t in z)
                Suppliers_invoice.Items.Add(t.name_supp);
            //Suppliers_invoice.SelectedItem = Suppliers_invoice.Items[0];
        }
        private void agree_purchase(object sender, RoutedEventArgs e)
        {
            if ((string)Suppliers_invoice.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика!!!");
                return;
            }
            string name_of_supp = Suppliers_invoice.SelectedItem.ToString();
            var z = (from asd in model.supplier
                     where asd.name_supp == name_of_supp
                     select asd).ToList();


            /*if (z.Count == 0)
            {
                MessageBox.Show("Такого поставщика нет!!!");
                return;
            }*/

            purchase_invoice pi = new purchase_invoice() { date_of_purchasing=date_of_purchase_invoice.SelectedDate, id_of_supp= z[0].id_supp};
            //model.contract.Add(st);
            purchasInvoice = pi;
            purchase.Visibility = Visibility.Hidden;
            purchase_list.Visibility = Visibility.Visible;
            Button_contract_ready1.Visibility = Visibility.Hidden;
            Button_contract_ready1.IsEnabled = false;
            ComboSupp.Items.Clear();
            var k = (from asd in model.raw
                     select asd).ToList();
            if (Combo_raw1.Items.Count > 0) Combo_raw1.Items.Clear();
            foreach (raw t in k)
                Combo_raw1.Items.Add(t.name_raw);
            //Combo_raw1.SelectedItem = Combo_raw1.Items[0];
        }
        private void Order_Next_purchase(object sender, RoutedEventArgs e)
        {
            if ((string)Combo_raw1.SelectedItem == null)
            {
                MessageBox.Show("Выберите сырье!!!");
                return;
            }
            string raw_name = Combo_raw1.SelectedItem.ToString();
            int am;
            if (!Int32.TryParse(Amount_of_raw1.Text, out am))
            {
                MessageBox.Show("Количество должно состоять из цифр!!!");
                return;
            }


            var z = (from asd in model.raw
                     where asd.name_raw == raw_name
                     select asd).ToList();
            if( (from asd in ProductPurchase
                     where asd.id_raw == z[0].id_raw
                     select asd).LongCount() > 0 == true)
                 {
                  MessageBox.Show("Такой вид сырья уже был выбран!!!");
                  return;
              }
            /*  if ((from asd in model.product_order
                   where asd.id_contract == 
                   select asd).LongCount() > 0 == true)
              {
                  MessageBox.Show("Такой договор уже есть!!!");
                  return;
              }*/


            product_purchase rw = new product_purchase() { id_raw = z[0].id_raw, amount = am,id_of_purchasing=purchasInvoice.id_of_purchasing };
            ProductPurchase.Add(rw);
            Button_contract_ready1.Visibility = Visibility.Visible;
            Button_contract_ready1.IsEnabled = true;
            Combo_raw1.SelectedItem = null;
            Amount_of_raw1.Text = "";
        }

        private void contract_ready_purchase(object sender, RoutedEventArgs e)
        {
            purchase_list.Visibility = Visibility.Hidden;
            purchase_report.Visibility = Visibility.Visible;
            AgreeText1.Text = 
            "Поставщик: " + (from asd in model.supplier
                             where asd.id_supp == purchasInvoice.id_of_supp
                             select asd).First().name_supp + Environment.NewLine +
            "Дата поставки:" + purchasInvoice.date_of_purchasing + Environment.NewLine +
            "Ожидаемое сыръе и материалы:" + Environment.NewLine;
            foreach (product_purchase pr in ProductPurchase)
            {
                AgreeText1.Text += "Вид : " + (from asd in model.raw
                                                   where asd.id_raw == pr.id_raw
                                                   select asd).First().name_raw + Environment.NewLine +
                    "Количество: " + pr.amount + Environment.NewLine;
            }
        }
        private void Agree_order_purchase(object sender, RoutedEventArgs e)
        {
            model.product_purchase.AddRange(ProductPurchase);
            model.purchase_invoice.Add(purchasInvoice);
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
            purchase_report.Visibility = Visibility.Hidden;
            purchasInvoice = null;
            ProductPurchase.Clear();
        }

        private void cancel_order_purchase(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
            purchase_report.Visibility = Visibility.Hidden;
            purchasInvoice = null;
            ProductPurchase.Clear();
        }

        private void Add_Order_Create_report_purchase(object sender, RoutedEventArgs e)
        {
            Agree_order_purchase(null, null);
            Create_Report_Order(AgreeText1.Text);
            purchasInvoice = null;
            ProductPurchase.Clear();
        }
    }
}
