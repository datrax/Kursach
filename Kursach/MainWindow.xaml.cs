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
        KursachEntities model;
        object temp;
        List<product_order> prod_order = new List<product_order>();
        contract contrac = new contract();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Add_Order(object sender, RoutedEventArgs e)
        {
            
            Menu.Visibility = System.Windows.Visibility.Hidden;
            OrderGuy.Visibility = Visibility.Visible;
            Orders.Visibility = System.Windows.Visibility.Visible;
            var z = (from asd in model.supplier
                     select asd).ToList();
            List<string> g = new List<string>();
            foreach (supplier t in z)
                ComboSupp.Items.Add(t.name_supp);

        }

        private void Construct(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Visible;
            Orders.Visibility = System.Windows.Visibility.Hidden;
            OrderList.Visibility = System.Windows.Visibility.Hidden;
            Order_Report.Visibility = Visibility.Hidden;
            OrderGuy.Visibility = Visibility.Hidden;
            model = new KursachEntities();
            temp = null;
        }

        private void AgreeOrder(object sender, RoutedEventArgs e)
        {


            int id_of_order = Int32.Parse(Order_id.Text);
            string number_of_month = Order_Month.Text;
            string name_of_supp = ComboSupp.SelectedItem.ToString();
            var z = (from asd in model.supplier
                     where asd.name_supp == name_of_supp
                     select asd).ToList();
            if ((from asd in model.contract
                 where asd.id_contract == id_of_order
                 select asd).LongCount() > 0 == true)
            {
                MessageBox.Show("Такой договор уже есть!!!");
                return;
            }

            if (z.Count == 0)
            {
                MessageBox.Show("Такого поставщика нет!!!");
                return;
            }
            contract st = new contract() { id_contract = id_of_order, id_supp = z[0].id_supp, number_month = number_of_month };
            //model.contract.Add(st);
            contrac = st;
            temp = id_of_order;

            Orders.Visibility = Visibility.Hidden;
            OrderList.Visibility = Visibility.Visible;
            Button_contract_ready.Visibility = Visibility.Hidden;
            Button_contract_ready.IsEnabled = false;

            var k = (from asd in model.raw
                     select asd).ToList();
            foreach (raw t in k)
                Combo_raw.Items.Add(t.name_raw);
            
        }



        private void contract_ready(object sender, RoutedEventArgs e)
        {

            OrderList.Visibility = Visibility.Hidden;
            Order_Report.Visibility = Visibility.Visible;
            AgreeText.Text = "Договор: " + contrac.id_contract + Environment.NewLine +
            "Поставщик: " + (from asd in model.supplier
                             where asd.id_supp == contrac.id_supp
                             select asd).First().name_supp + Environment.NewLine +
            "Дата прихода:" + contrac.number_month + Environment.NewLine +
            "Ожидаемое сыръе и материалы:" + Environment.NewLine;
            foreach (product_order pr in prod_order)
            {
                AgreeText.Text += "Вид Сыръя: " + (from asd in model.raw
                                                  where asd.id_raw == pr.id_raw
                                                  select asd).First().name_raw + Environment.NewLine +
                    "Количество: " + pr.amount + Environment.NewLine;
            }
        }

        private void Order_Next(object sender, RoutedEventArgs e)
        {

            string raw_name = Combo_raw.SelectedItem.ToString();
            int am = Int32.Parse(Amount_of_raw.Text);

            var z = (from asd in model.raw
                     where asd.name_raw == raw_name
                     select asd).ToList();
            /*  if ((from asd in model.product_order
                   where asd.id_contract == 
                   select asd).LongCount() > 0 == true)
              {
                  MessageBox.Show("Такой договор уже есть!!!");
                  return;
              }*/
            if (z.Count == 0)
            {
                MessageBox.Show("Данный вид сырья отсутствует!!!");
                return;
            }

            product_order rw = new product_order() { id_raw = z[0].id_raw, amount = am, id_contaract = contrac.id_contract };
            //model.product_order.Add(rw);
            prod_order.Add(rw);
            Button_contract_ready.Visibility = Visibility.Visible;
            Button_contract_ready.IsEnabled = true;
            Combo_raw.SelectedItem = null;
            Amount_of_raw.Text = "";
        }
        void Create_Report_Order(string text)
        {
            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + @"\Document.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Phrase(text,font));
            doc.Close();
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Document.pdf");
        }

        private void cancel_order(object sender, RoutedEventArgs e)
        {
            contrac = null;
            prod_order.Clear();
            Menu.Visibility = Visibility.Visible;
            Order_Report.Visibility = Visibility.Hidden;
        }

        private void Agree_order(object sender, RoutedEventArgs e)
        {
            model.product_order.AddRange(prod_order);
            model.contract.Add(contrac);
            try
            {
                model.SaveChanges();
                MessageBox.Show("Запись была успешно добавлена");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Menu.Visibility = Visibility.Visible;
            Order_Report.Visibility = Visibility.Hidden;
        }

        private void Add_Order_Create_report(object sender, RoutedEventArgs e)
        {
            Agree_order(null, null);
            Create_Report_Order(AgreeText.Text);
            contrac = null;
            prod_order.Clear();
        }
    }
}

