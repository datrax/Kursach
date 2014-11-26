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
        List<product_order> prod_order = new List<product_order>();
        contract contrac = new contract();
        bool MakeReport = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Add_Order(object sender, RoutedEventArgs e)
        {

            Menu.Visibility = System.Windows.Visibility.Hidden;
            OrderGuy.Visibility = Visibility.Visible;
            Orders.Visibility = System.Windows.Visibility.Visible;

            ComboSupp.Items.Clear();
            Order_id.Text = "";
            Date_order.SelectedDate = DateTime.Now; ;
            var z = (from asd in model.supplier
                     select asd).ToList();
            List<string> g = new List<string>();
            foreach (supplier t in z)
                ComboSupp.Items.Add(t.name_supp);
            //ComboSupp.SelectedItem = ComboSupp.Items[0];

        }

        private void Construct(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Visible;
            Orders.Visibility = System.Windows.Visibility.Hidden;
            OrderList.Visibility = System.Windows.Visibility.Hidden;
            Order_Report.Visibility = Visibility.Hidden;

            Raw_insert.Visibility = Visibility.Hidden;
            Raw_delete.Visibility = Visibility.Hidden;
            Contract_insert.Visibility = Visibility.Hidden;
            Contract_delete.Visibility = Visibility.Hidden;
            Supp_insert.Visibility = Visibility.Hidden;
            Supp_delete.Visibility = Visibility.Hidden;
            Product_order_insert.Visibility = Visibility.Hidden;
            Product_order_delete.Visibility = Visibility.Hidden;
            Product_purchase_insert.Visibility = Visibility.Hidden;
            Product_purchase_delete.Visibility = Visibility.Hidden;
            Product_sales_insert.Visibility = Visibility.Hidden;
            Product_sales_delete.Visibility = Visibility.Hidden;
            purchase_invoice_insert.Visibility = Visibility.Hidden;
            purchase_invoice_delete.Visibility = Visibility.Hidden;
            sales_invoice_invoice.Visibility = Visibility.Hidden;
            sales_invoice_delete.Visibility = Visibility.Hidden;
            Raw_update.Visibility = System.Windows.Visibility.Hidden;
            Contract_update.Visibility = System.Windows.Visibility.Hidden;
            Supp_update.Visibility = System.Windows.Visibility.Hidden;
            Product_order_update.Visibility = System.Windows.Visibility.Hidden;
            purchase_invoice_update.Visibility = System.Windows.Visibility.Hidden;
            Product_purchase_update.Visibility = System.Windows.Visibility.Hidden;
            sales_invoice_update.Visibility = System.Windows.Visibility.Hidden;
            Product_sales_update.Visibility = System.Windows.Visibility.Hidden;
            user_insert.Visibility = System.Windows.Visibility.Hidden;
            user_delete.Visibility = System.Windows.Visibility.Hidden;
            user_update.Visibility = System.Windows.Visibility.Hidden;

            OrderGuy.Visibility = Visibility.Hidden;
            ComboTables.Items.Add("Сырье");
            ComboTables.Items.Add("Поставщик");
            ComboTables.Items.Add("Договор");
            ComboTables.Items.Add("Продукция договоров");
            ComboTables.Items.Add("Приходная накладная");
            ComboTables.Items.Add("Продукция приходной накладной");
            ComboTables.Items.Add("Расходная накладная");
            ComboTables.Items.Add("Продукция расходной накладной");
            ComboTables.Items.Add("Пользователи");
    //----------------------
            model = new KursachEntities();
            Tables_Client.Items.Add("Заказы");
            Tables_Client.Items.Add("Приход");
            Tables_Client.Items.Add("Расход");
            Tables_Client.SelectedItem = Tables_Client.Items[0];
            Visibiles();
        }
        private void Visibiles()
        {
            model = new KursachEntities();
            General.Visibility = Visibility.Hidden;
            Registration.Visibility = Visibility.Hidden;
            Menu.Visibility = System.Windows.Visibility.Visible;
            Orders.Visibility = System.Windows.Visibility.Hidden;
            OrderList.Visibility = System.Windows.Visibility.Hidden;
            purchase_list.Visibility = Visibility.Hidden;
            purchase_report.Visibility = Visibility.Hidden;
            sailing_list.Visibility = Visibility.Hidden;
            sailing_report.Visibility = Visibility.Hidden;
            sailing.Visibility = Visibility.Hidden;
            purchase.Visibility = Visibility.Hidden;
            Order_Report.Visibility = Visibility.Hidden;
            OrderGuy.Visibility = Visibility.Hidden;
            Admin.Visibility = Visibility.Hidden;
            Invoices.Visibility = System.Windows.Visibility.Hidden;
            SaleButton.Visibility = Visibility.Hidden;
            PurchaseButton.Visibility = Visibility.Hidden;
            OrderButton.Visibility = Visibility.Hidden;
        }

        private void AgreeOrder(object sender, RoutedEventArgs e)
        {


            //int id_of_order = Int32.Parse(Order_id.Text);
            int id_of_order;
            if (!Int32.TryParse(Order_id.Text, out id_of_order))
            {
                MessageBox.Show("Номер должен состоять из цифр!!!");
                return;
            }
            if ((string)ComboSupp.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика!!!");
                return;
            }
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

            /*if (z.Count == 0)
            {
                MessageBox.Show("Такого поставщика нет!!!");
                return;
            }*/
            contract st = new contract() { id_contract = id_of_order, id_supp = z[0].id_supp, number_month = Date_order.SelectedDate };
            //model.contract.Add(st);
            contrac = st;

            Orders.Visibility = Visibility.Hidden;
            OrderList.Visibility = Visibility.Visible;
            Button_contract_ready.Visibility = Visibility.Hidden;
            Button_contract_ready.IsEnabled = false;
            ComboSupp.Items.Clear();
            var k = (from asd in model.raw
                     select asd).ToList();
            if (Combo_raw.Items.Count > 0) Combo_raw.Items.Clear();
            foreach (raw t in k)
                Combo_raw.Items.Add(t.name_raw);
            //Combo_raw.SelectedItem = Combo_raw.Items[0];
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
            if ((string)Combo_raw.SelectedItem == null)
            {
                MessageBox.Show("Выберите сырье!!!");
                return;
            }
            string raw_name = Combo_raw.SelectedItem.ToString();
            int am;
            if (!Int32.TryParse(Amount_of_raw.Text, out am))
            {
                MessageBox.Show("Количество должно состоять из цифр!!!");
                return;
            }


            var z = (from asd in model.raw
                     where asd.name_raw == raw_name
                     select asd).ToList();
            if ((from asd in prod_order
                 where asd.id_raw == z[0].id_raw
                 select asd).LongCount() > 0 == true)
            {
                MessageBox.Show("Такой вид сырья уже был выбран!!!");
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
            doc.Add(new Phrase(text, font));
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
                ShowClientTable(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Menu.Visibility = Visibility.Visible;
            Order_Report.Visibility = Visibility.Hidden;
            contrac = null;
            prod_order.Clear();
        }

        private void Add_Order_Create_report(object sender, RoutedEventArgs e)
        {
            Agree_order(null, null);
            Create_Report_Order(AgreeText.Text);
            contrac = null;
            prod_order.Clear();
        }

        private void ShowClientTable(object sender, SelectionChangedEventArgs e)
        {
            int workshop;
            int amount;
            int contract;
            int.TryParse(ContractBox.Text, out contract);
            DateTime date;
            int.TryParse(AmountBox.Text, out amount);
            DateTime.TryParse(DateBox.Text, out date);
            int.TryParse(SuppBox.Text, out workshop);
            if (Tables_Client.SelectedItem.ToString() == "Заказы")
            {
                Sort1.Content = "Контракт";
                Sort2.Content = "Поставщик";
                Sort3.Content = "Дата";
                Sort4.Content = "Сырье";
                Sort5.Content = "Количество";
                ContractBox.Visibility = Visibility.Visible;
                OrderButton.Visibility = Visibility.Visible;
                SaleButton.Visibility = Visibility.Hidden;
                PurchaseButton.Visibility = Visibility.Hidden;
                var pp =
                    from asd in model.contract
                    join ast in model.product_order on asd.id_contract equals ast.id_contaract
                    join asv in model.supplier on asd.id_supp equals asv.id_supp
                    join ask in model.raw on ast.id_raw equals ask.id_raw
                    where asv.name_supp == ((SuppBox.Text == "") ? asv.name_supp : SuppBox.Text)
                    where asd.number_month == ((DateBox.Text == "") ? asd.number_month : date)
                    where ask.name_raw == ((RawBox.Text == "") ? ask.name_raw : RawBox.Text)
                    where ast.amount == ((AmountBox.Text == "") ? ast.amount : amount)
                    where asd.id_contract == ((ContractBox.Text == "") ? asd.id_contract : contract)
                    select new
                    {

                        ast.id,
                        asd.id_contract,
                        asv.name_supp,
                        asd.number_month,
                        ask.name_raw,
                        ast.amount
                    };

                Table_Grid.ItemsSource = pp.ToList();
                if (MakeReport)
                {
                    var doc = new Document();
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + @"\Document.pdf", FileMode.Create));
                    }
                    catch
                    {
                        MessageBox.Show("Закройте предыдущий файл отчета");
                    }
                    doc.Open();

                    PdfPTable table = new PdfPTable(6);
                    Create_Report_From_List(table, "ID");
                    Create_Report_From_List(table, "№ контракта");
                    Create_Report_From_List(table, "Поставщик");
                    Create_Report_From_List(table, "Дата поставки");
                    Create_Report_From_List(table, "Вид Сырья");
                    Create_Report_From_List(table, "Количество");
                    for (int i = 0; i < pp.ToList().Count; i++)
                    {
                        Create_Report_From_List(table, pp.ToList()[i].id.ToString());
                        Create_Report_From_List(table, pp.ToList()[i].id_contract.ToString());
                        Create_Report_From_List(table, pp.ToList()[i].name_supp.ToString());
                        Create_Report_From_List(table, pp.ToList()[i].number_month.ToString().Substring(0, pp.ToList()[i].number_month.ToString().LastIndexOf(" ")));
                        Create_Report_From_List(table, pp.ToList()[i].name_raw.ToString());
                        Create_Report_From_List(table, pp.ToList()[i].amount.ToString());
                    }
                    doc.Add(table);
                    doc.Close();
                    System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Document.pdf");
                }
            }
            else
                if (Tables_Client.SelectedItem.ToString() == "Приход")
                {
                    Sort1.Content = "";
                    Sort2.Content = "Поставщик";
                    Sort3.Content = "Дата";
                    Sort4.Content = "Сырье";
                    Sort5.Content = "Количество";
                    ContractBox.Visibility = Visibility.Hidden;
                    PurchaseButton.Visibility = Visibility.Visible;
                    SaleButton.Visibility = Visibility.Hidden;
                    OrderButton.Visibility = Visibility.Hidden;
                    var pp =
                    from asd in model.purchase_invoice
                    join asv in model.supplier on asd.id_of_supp equals asv.id_supp
                    join ast in model.product_purchase on asd.id_of_purchasing equals ast.id_of_purchasing
                    join ask in model.raw on ast.id_raw equals ask.id_raw
                    where asv.name_supp == ((SuppBox.Text == "") ? asv.name_supp : SuppBox.Text)
                    where asd.date_of_purchasing == ((DateBox.Text == "") ? asd.date_of_purchasing : date)
                    where ask.name_raw == ((RawBox.Text == "") ? ask.name_raw : RawBox.Text)
                    where ast.amount == ((AmountBox.Text == "") ? ast.amount : amount)
                    select new
                    {
                        ast.id,
                        asv.name_supp,
                        asd.date_of_purchasing,
                        ask.name_raw,
                        ast.amount

                    };
                    Table_Grid.ItemsSource = pp.ToList();

                    if (MakeReport)
                    {
                        var doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + @"\Document.pdf", FileMode.Create));
                        doc.Open();

                        PdfPTable table = new PdfPTable(5);
                        Create_Report_From_List(table, "ID");
                        Create_Report_From_List(table, "Поставщик");
                        Create_Report_From_List(table, "Дата прихода");
                        Create_Report_From_List(table, "Вид Сырья");
                        Create_Report_From_List(table, "Количество");
                        for (int i = 0; i < pp.ToList().Count; i++)
                        {
                            Create_Report_From_List(table, pp.ToList()[i].id.ToString());
                            Create_Report_From_List(table, pp.ToList()[i].name_supp.ToString());
                            Create_Report_From_List(table, pp.ToList()[i].date_of_purchasing.ToString().Substring(0, pp.ToList()[i].date_of_purchasing.ToString().LastIndexOf(" ")));
                            Create_Report_From_List(table, pp.ToList()[i].name_raw.ToString());
                            Create_Report_From_List(table, pp.ToList()[i].amount.ToString());
                        }
                        doc.Add(table);
                        doc.Close();
                        System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Document.pdf");
                    }
                }
                else
                    if (Tables_Client.SelectedItem.ToString() == "Расход")
                    {
                        Sort1.Content = "";
                        Sort2.Content = "№ Цеха";
                        Sort3.Content = "Дата";
                        Sort4.Content = "Сырье";
                        Sort5.Content = "Количество";
                        ContractBox.Visibility = Visibility.Hidden;
                        SaleButton.Visibility = Visibility.Visible;
                        PurchaseButton.Visibility = Visibility.Hidden;
                        OrderButton.Visibility = Visibility.Hidden;
                        var pp =
                        from asd in model.sales_invoice
                        join ast in model.product_sales on asd.id_of_sailing equals ast.id_of_sailing
                        join ask in model.raw on ast.id_raw equals ask.id_raw
                        where asd.id_workshop == ((SuppBox.Text == "") ? asd.id_workshop : workshop)
                        where asd.date_of_sale == ((DateBox.Text == "") ? asd.date_of_sale : date)
                        where ask.name_raw == ((RawBox.Text == "") ? ask.name_raw : RawBox.Text)
                        where ast.amount == ((AmountBox.Text == "") ? ast.amount : amount)
                        select new
                            {
                                ast.id,
                                asd.id_workshop,
                                asd.date_of_sale,
                                ask.name_raw,
                                ast.amount

                            };
                        Table_Grid.ItemsSource = pp.ToList();

                        if (MakeReport)
                        {
                            var doc = new Document();
                            PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + @"\Document.pdf", FileMode.Create));
                            doc.Open();

                            PdfPTable table = new PdfPTable(5);
                            Create_Report_From_List(table, "ID");
                            Create_Report_From_List(table, "№ Цеха");
                            Create_Report_From_List(table, "Дата отправки");
                            Create_Report_From_List(table, "Вид Сырья");
                            Create_Report_From_List(table, "Количество");
                            for (int i = 0; i < pp.ToList().Count; i++)
                            {
                                Create_Report_From_List(table, pp.ToList()[i].id.ToString());
                                Create_Report_From_List(table, pp.ToList()[i].id_workshop.ToString());
                                Create_Report_From_List(table, pp.ToList()[i].date_of_sale.ToString().Substring(0, pp.ToList()[i].date_of_sale.ToString().LastIndexOf(" ")));                       
                                Create_Report_From_List(table, pp.ToList()[i].name_raw.ToString());
                                Create_Report_From_List(table, pp.ToList()[i].amount.ToString());
                            }
                            doc.Add(table);
                            doc.Close();
                            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Document.pdf");
                        }
                    }
            MakeReport = false;
        }

        private void Create_Report_From_List(PdfPTable table, string t)
        {
            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPCell cell = new PdfPCell(new Phrase(t, font));
            cell.BorderWidth = 1;
            cell.PaddingTop = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(cell);

        }

        private void UpdateTable(object sender, RoutedEventArgs e)
        {
            ShowClientTable(null, null);
        }

        private void Entering(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length == 0 || Password.Password.Length == 0)
            {
                MessageBox.Show("Логин или пароль не были введены");
                return;
            }

            var z = ((from asd in model.Users
                      where asd.Login == Login.Text
                      where asd.Password == Password.Password
                      select asd));
            if (z.LongCount() > 0)
            {
                if (z.First().IsAdmin == 1)
                {
                    Logining.Visibility = Visibility.Hidden;

                    General.Visibility = Visibility.Visible;
                    Admin.Visibility = Visibility.Visible;
                    Menu.Visibility = Visibility.Hidden;
                    OrderGuy.Visibility = Visibility.Hidden;
                    Invoices.Visibility = Visibility.Hidden;
                }
                else
                {
                    Visibiles();
                    ShowClientTable(null, null);
                    Logining.Visibility = Visibility.Hidden;
                    General.Visibility = Visibility.Visible;
                    Admin.Visibility = Visibility.Hidden;


                }
            }
            else
            {
                MessageBox.Show("Логин или пароль были введены некоректно");
                return;
            }
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Logining.Visibility = Visibility.Hidden;
            Registration.Visibility = Visibility.Visible;
        }

        private void MakeRegistre(object sender, RoutedEventArgs e)
        {
            if (NewLogin.Text.Length == 0 || NewPassword.Password.Length == 0 || ConfirmPassword.Password.Length == 0)
            {
                MessageBox.Show("Введите все поля");
                return;
            }
            if (NewPassword.Password != ConfirmPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Users users = new Users() { Login = NewLogin.Text, Password = NewPassword.Password, IsAdmin = 0 };
            model.Users.Add(users);
            try
            {
                model.SaveChanges();
                MessageBox.Show("Вы были успешно зарегестрированы");
                Logining.Visibility = Visibility.Visible;
                Registration.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            NewLogin.Text = "";
            NewPassword.Password = "";
            ConfirmPassword.Password = "";
        }

        private void logout(object sender, RoutedEventArgs e)
        {

            General.Visibility = Visibility.Hidden;
            Logining.Visibility = Visibility.Visible;
            Login.Text = "";
            Password.Password = "";

        }

        private void Selected_order(object sender, RoutedEventArgs e)
        {
            MakeReport = true;
            ShowClientTable(null, null);
        }



    }
}

