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
        private void ShowTablesItems(object sender, SelectionChangedEventArgs e)
        {
            Raw_delete.Visibility = System.Windows.Visibility.Hidden;
            Contract_delete.Visibility = System.Windows.Visibility.Hidden;
            Supp_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_order_delete.Visibility = System.Windows.Visibility.Hidden;
            purchase_invoice_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_purchase_delete.Visibility = System.Windows.Visibility.Hidden;
            sales_invoice_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_sales_delete.Visibility = System.Windows.Visibility.Hidden;
            Raw_insert.Visibility = System.Windows.Visibility.Hidden;
            Contract_insert.Visibility = System.Windows.Visibility.Hidden;
            Supp_insert.Visibility = System.Windows.Visibility.Hidden;
            Product_order_insert.Visibility = System.Windows.Visibility.Hidden;
            purchase_invoice_insert.Visibility = System.Windows.Visibility.Hidden;
            Product_purchase_insert.Visibility = System.Windows.Visibility.Hidden;
            sales_invoice_invoice.Visibility = System.Windows.Visibility.Hidden;
            Product_sales_insert.Visibility = System.Windows.Visibility.Hidden;
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
            Start_buttons.Visibility = System.Windows.Visibility.Visible;
            field_raw1.Text = "";
            field_raw2.Text = "";
            field_contract1.Text = "";
            if (combo_contract.Items.Count != 0) combo_contract.Items.Clear();
            data_contract.SelectedDate = null;
            field_supp1.Text = "";
            field_supp2.Text = "";
            if (product_order_combo1.Items.Count != 0) product_order_combo1.Items.Clear();
            if (product_order_combo2.Items.Count != 0) product_order_combo2.Items.Clear();
            product_order_field1.Text = "";
            product_order_field2.Text = "";
            if (purchase_invoice_combo.Items.Count != 0) purchase_invoice_combo.Items.Clear();
            purchase_invoice_field1.Text = "";
            purchase_invoice_data.SelectedDate = null;
            if (Product_purchase_combo1.Items.Count != 0) Product_purchase_combo1.Items.Clear();
            if (Product_purchase_combo2.Items.Count != 0) Product_purchase_combo2.Items.Clear();
            Product_purchase_field1.Text = "";
            Product_purchase_field3.Text = "";
            sales_invoice_field1.Text = "";
            sales_invoice_field2.Text = "";
            sales_invoice_data.SelectedDate = null;
            if (Product_sales_combo1.Items.Count != 0) Product_sales_combo1.Items.Clear();
            if (Product_sales_combo2.Items.Count != 0) Product_sales_combo2.Items.Clear();
            Product_sales_field1.Text = "";
            Product_sales_field2.Text = "";
            field_raw3.Text = "";
            field_contract2.Text = "";
            field_supp3.Text = "";
            product_order_field3.Text = "";
            purchase_invoice_field2.Text = "";
            Product_purchase_field4.Text = "";
            sales_invoice_field3.Text = "";
            Product_sales_field3.Text = "";
            field_raw4.Text = "";
            if (raw_combo.Items.Count != 0) raw_combo.Items.Clear();
            field_supp4.Text = "";
            if (supp_combo.Items.Count != 0) supp_combo.Items.Clear();
            if (contract_combo1.Items.Count != 0) contract_combo1.Items.Clear();
            contract_data.SelectedDate = null;
            if (contract_combo2.Items.Count != 0) contract_combo2.Items.Clear();
            if (product_order_combo3.Items.Count != 0) product_order_combo3.Items.Clear();
            if (product_order_combo4.Items.Count != 0) product_order_combo4.Items.Clear();
            if (product_order_combo5.Items.Count != 0) product_order_combo5.Items.Clear();
            product_order_field4.Text = "";
            if (purchase_invoice_combo1.Items.Count != 0) purchase_invoice_combo1.Items.Clear();
            if (purchase_invoice_combo2.Items.Count != 0) purchase_invoice_combo2.Items.Clear();
            purchase_invoice_data1.SelectedDate = null;
            if (product_purchase_combo3.Items.Count != 0) product_purchase_combo3.Items.Clear();
            if (product_purchase_combo4.Items.Count != 0) product_purchase_combo4.Items.Clear();
            if (product_purchase_combo5.Items.Count != 0) product_purchase_combo5.Items.Clear();
            product_purchase_field5.Text = "";
            if (sales_invoice_combo1.Items.Count != 0) sales_invoice_combo1.Items.Clear();
            sales_invoice_field4.Text = "";
            sales_invoice_data1.SelectedDate = null;
            if (product_sales_combo3.Items.Count != 0) product_sales_combo3.Items.Clear();
            if (product_sales_combo4.Items.Count != 0) product_sales_combo4.Items.Clear();
            if (product_sales_combo5.Items.Count != 0) product_sales_combo5.Items.Clear();
            product_sales_field4.Text = "";
            if (user_combo1.Items.Count != 0) user_combo1.Items.Clear();
            if (user_combo2.Items.Count != 0) user_combo2.Items.Clear();
            if (user_combo3.Items.Count != 0) user_combo3.Items.Clear();
            user_field1.Text = user_field2.Text = user_field3.Text = user_field4.Text = "";
            switch ((string)ComboTables.SelectedItem)
            {
                case "Сырье":
                    var raw =
                    from asd in model.raw
                    select new
                    {
                        asd.id_raw,
                        asd.name_raw
                    };
                    Table.ItemsSource = raw.ToList();
                    break;
                case "Договор":
                    var con =
                    from asd in model.contract
                    select new
                    {
                        asd.id_contract,
                        asd.number_month,
                        asd.id_supp
                    };
                    Table.ItemsSource = con.ToList();
                    break;
                case "Поставщик":
                    var supp =
                    from asd in model.supplier
                    select new
                    {
                        asd.id_supp,
                        asd.name_supp
                    };
                    Table.ItemsSource = supp.ToList();
                    break;
                case "Продукция договоров":
                    var product_order =
                    from asd in model.product_order
                    select new
                    {
                        asd.id,
                        asd.id_raw,
                        asd.id_contaract,
                        asd.amount
                    };
                    Table.ItemsSource = product_order.ToList();
                    break;
                case "Приходная накладная":
                    var purchase =
                    from asd in model.purchase_invoice
                    select new
                    {
                        asd.id_of_purchasing,
                        asd.date_of_purchasing,
                        asd.id_of_supp
                    };
                    Table.ItemsSource = purchase.ToList();
                    break;
                case "Продукция приходной накладной":
                    var product_purchase =
                    from asd in model.product_purchase
                    select new
                    {
                        asd.id,
                        asd.id_of_purchasing,
                        asd.amount,
                        asd.id_raw
                    };
                    Table.ItemsSource = product_purchase.ToList();
                    break;
                case "Расходная накладная":
                    var sales =
                    from asd in model.sales_invoice
                    select new
                    {
                        asd.id_of_sailing,
                        asd.date_of_sale,
                        asd.id_workshop
                    };
                    Table.ItemsSource = sales.ToList();
                    break;
                case "Продукция расходной накладной":
                    var product_sales =
                    from asd in model.product_sales
                    select new
                    {
                        asd.id,
                        asd.id_of_sailing,
                        asd.amount,
                        asd.id_raw
                    };
                    Table.ItemsSource = product_sales.ToList();
                    break;
                case "Пользователи":
                    var users =
                    from asd in model.Users
                    select new
                    {
                        asd.Login,
                        asd.Password,
                        asd.IsAdmin
                    };
                    Table.ItemsSource = users.ToList();
                    break;
            }
        }

        private void return_butt_Click(object sender, RoutedEventArgs e)
        {
            Raw_delete.Visibility = System.Windows.Visibility.Hidden;
            Contract_delete.Visibility = System.Windows.Visibility.Hidden;
            Supp_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_order_delete.Visibility = System.Windows.Visibility.Hidden;
            purchase_invoice_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_purchase_delete.Visibility = System.Windows.Visibility.Hidden;
            sales_invoice_delete.Visibility = System.Windows.Visibility.Hidden;
            Product_sales_delete.Visibility = System.Windows.Visibility.Hidden;
            Raw_insert.Visibility = System.Windows.Visibility.Hidden;
            Contract_insert.Visibility = System.Windows.Visibility.Hidden;
            Supp_insert.Visibility = System.Windows.Visibility.Hidden;
            Product_order_insert.Visibility = System.Windows.Visibility.Hidden;
            purchase_invoice_insert.Visibility = System.Windows.Visibility.Hidden;
            Product_purchase_insert.Visibility = System.Windows.Visibility.Hidden;
            sales_invoice_invoice.Visibility = System.Windows.Visibility.Hidden;
            Product_sales_insert.Visibility = System.Windows.Visibility.Hidden;
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
            Start_buttons.Visibility = System.Windows.Visibility.Visible;
            field_raw1.Text = "";
            field_raw2.Text = "";
            field_contract1.Text = "";
            if (combo_contract.Items.Count != 0) combo_contract.Items.Clear();
            data_contract.SelectedDate = null;
            field_supp1.Text = "";
            field_supp2.Text = "";
            if (product_order_combo1.Items.Count != 0) product_order_combo1.Items.Clear();
            if (product_order_combo2.Items.Count != 0) product_order_combo2.Items.Clear();
            product_order_field1.Text = "";
            product_order_field2.Text = "";
            if (purchase_invoice_combo.Items.Count != 0) purchase_invoice_combo.Items.Clear();
            purchase_invoice_field1.Text = "";
            purchase_invoice_data.SelectedDate = null;
            if (Product_purchase_combo1.Items.Count != 0) Product_purchase_combo1.Items.Clear();
            if (Product_purchase_combo2.Items.Count != 0) Product_purchase_combo2.Items.Clear();
            Product_purchase_field1.Text = "";
            Product_purchase_field3.Text = "";
            sales_invoice_field1.Text = "";
            sales_invoice_field2.Text = "";
            sales_invoice_data.SelectedDate = null;
            if (Product_sales_combo1.Items.Count != 0) Product_sales_combo1.Items.Clear();
            if (Product_sales_combo2.Items.Count != 0) Product_sales_combo2.Items.Clear();
            Product_sales_field1.Text = "";
            Product_sales_field2.Text = "";
            field_raw3.Text = "";
            field_contract2.Text = "";
            field_supp3.Text = "";
            product_order_field3.Text = "";
            purchase_invoice_field2.Text = "";
            Product_purchase_field4.Text = "";
            sales_invoice_field3.Text = "";
            Product_sales_field3.Text = "";
            field_raw4.Text = "";
            if (raw_combo.Items.Count != 0) raw_combo.Items.Clear();
            field_supp4.Text = "";
            if (supp_combo.Items.Count != 0) supp_combo.Items.Clear();
            if (contract_combo1.Items.Count != 0) contract_combo1.Items.Clear();
            contract_data.SelectedDate = null;
            if (contract_combo2.Items.Count != 0) contract_combo2.Items.Clear();
            if (product_order_combo3.Items.Count != 0) product_order_combo3.Items.Clear();
            if (product_order_combo4.Items.Count != 0) product_order_combo4.Items.Clear();
            if (product_order_combo5.Items.Count != 0) product_order_combo5.Items.Clear();
            product_order_field4.Text = "";
            if (purchase_invoice_combo1.Items.Count != 0) purchase_invoice_combo1.Items.Clear();
            if (purchase_invoice_combo2.Items.Count != 0) purchase_invoice_combo2.Items.Clear();
            purchase_invoice_data1.SelectedDate = null;
            if (product_purchase_combo3.Items.Count != 0) product_purchase_combo3.Items.Clear();
            if (product_purchase_combo4.Items.Count != 0) product_purchase_combo4.Items.Clear();
            if (product_purchase_combo5.Items.Count != 0) product_purchase_combo5.Items.Clear();
            product_purchase_field5.Text = "";
            if (sales_invoice_combo1.Items.Count != 0) sales_invoice_combo1.Items.Clear();
            sales_invoice_field4.Text = "";
            sales_invoice_data1.SelectedDate = null;
            if (product_sales_combo3.Items.Count != 0) product_sales_combo3.Items.Clear();
            if (product_sales_combo4.Items.Count != 0) product_sales_combo4.Items.Clear();
            if (product_sales_combo5.Items.Count != 0) product_sales_combo5.Items.Clear();
            product_sales_field4.Text = "";
            if (user_combo1.Items.Count != 0) user_combo1.Items.Clear();
            if (user_combo2.Items.Count != 0) user_combo2.Items.Clear();
            if (user_combo3.Items.Count != 0) user_combo3.Items.Clear();
            user_field1.Text = user_field2.Text = user_field3.Text = user_field4.Text = "";
        }

        private void Add_record_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ComboTables.SelectedItem == null)
            {
                MessageBox.Show("Выберить таблицу!!!");
                return;
            }
            Start_buttons.Visibility = System.Windows.Visibility.Hidden;
            switch ((string)ComboTables.SelectedItem)
            {
                case "Сырье":
                    Raw_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Договор":
                    Contract_insert.Visibility = System.Windows.Visibility.Visible;
                    var z = (from asd in model.supplier
                             select asd).ToList();
                    foreach (supplier t in z)
                        combo_contract.Items.Add(t.id_supp);
                    break;
                case "Поставщик":
                    Supp_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Продукция договоров":
                    var z1 = (from asd in model.contract
                              select asd).ToList();
                    foreach (contract t in z1)
                        product_order_combo1.Items.Add(t.id_contract);
                    var z2 = (from asd in model.raw
                              select asd).ToList();
                    foreach (raw t in z2)
                        product_order_combo2.Items.Add(t.id_raw);
                    Product_order_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Приходная накладная":
                    purchase_invoice_insert.Visibility = System.Windows.Visibility.Visible;
                    var z3 = (from asd in model.supplier
                              select asd).ToList();
                    foreach (supplier t in z3)
                        purchase_invoice_combo.Items.Add(t.id_supp);
                    break;
                case "Продукция приходной накладной":
                    var z4 = (from asd in model.purchase_invoice
                              select asd).ToList();
                    foreach (purchase_invoice t in z4)
                        Product_purchase_combo1.Items.Add(t.id_of_purchasing);
                    var z5 = (from asd in model.raw
                              select asd).ToList();
                    foreach (raw t in z5)
                        Product_purchase_combo2.Items.Add(t.id_raw);
                    Product_purchase_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Расходная накладная":
                    sales_invoice_invoice.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Продукция расходной накладной":
                    var z6 = (from asd in model.sales_invoice
                              select asd).ToList();
                    foreach (sales_invoice t in z6)
                        Product_sales_combo1.Items.Add(t.id_of_sailing);
                    var z7 = (from asd in model.raw
                              select asd).ToList();
                    foreach (raw t in z7)
                        Product_sales_combo2.Items.Add(t.id_raw);
                    Product_sales_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Пользователи":
                    user_combo1.Items.Add("Пользователь");
                    user_combo1.Items.Add("Администратор");
                    user_insert.Visibility = System.Windows.Visibility.Visible;
                    break;
            }
        }

        private void Add_record_raw_Click(object sender, RoutedEventArgs e)
        {
            int id_raw_;
            if (!Int32.TryParse(field_raw1.Text, out id_raw_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            string name_raw_ = field_raw2.Text;
            if (name_raw_ == "")
            {
                MessageBox.Show("Поле для ввода не заполнено!");
                return;
            }
            raw st = new raw() { id_raw = id_raw_, name_raw = name_raw_ };
            if ((from asd in model.raw
                 where asd.id_raw == id_raw_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.raw.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Add_record_supp_Click(object sender, RoutedEventArgs e)
        {
            int id_supp_;
            if (!Int32.TryParse(field_supp1.Text, out id_supp_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            string name_supp_ = field_supp2.Text;
            if (name_supp_ == "")
            {
                MessageBox.Show("Поле для ввода не заполнено!");
                return;
            }
            supplier st = new supplier() { id_supp = id_supp_, name_supp = name_supp_ };
            if ((from asd in model.supplier
                 where asd.id_supp == id_supp_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.supplier.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Add_record_contract_Click(object sender, RoutedEventArgs e)
        {
            int id_contract_;
            if (!Int32.TryParse(field_contract1.Text, out id_contract_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (data_contract.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            if (combo_contract.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int supp_id_ = (int)combo_contract.SelectedItem;
            contract st = new contract() { id_contract = id_contract_, id_supp = supp_id_, number_month = data_contract.SelectedDate };
            if ((from asd in model.contract
                 where asd.id_contract == id_contract_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.contract.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add_record_product_order_Click(object sender, RoutedEventArgs e)
        {
            int id_product_order_;
            if (!Int32.TryParse(product_order_field1.Text, out id_product_order_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (product_order_combo1.SelectedItem == null || product_order_combo2.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_contract_ = (int)product_order_combo1.SelectedItem;
            int id_raw_ = (int)product_order_combo2.SelectedItem;
            int amount_;
            if (!Int32.TryParse(product_order_field3.Text, out amount_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            product_order st = new product_order() { id_contaract = id_contract_, id = id_product_order_, amount = amount_, id_raw = id_raw_ };
            if ((from asd in model.product_order
                 where asd.id == id_product_order_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.product_order.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add_record_purchase_invoice_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(purchase_invoice_field1.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (purchase_invoice_combo.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            if (purchase_invoice_data.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            int id_supp_ = (int)purchase_invoice_combo.SelectedItem;
            purchase_invoice st = new purchase_invoice() { id_of_purchasing = id_, id_of_supp = id_supp_, date_of_purchasing = purchase_invoice_data.SelectedDate };
            if ((from asd in model.purchase_invoice
                 where asd.id_of_purchasing == id_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.purchase_invoice.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add_record_Product_purchase_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(Product_purchase_field1.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (Product_purchase_combo1.SelectedItem == null || Product_purchase_combo2.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_purchase_ = (int)Product_purchase_combo1.SelectedItem;
            int id_raw_ = (int)Product_purchase_combo2.SelectedItem;
            int amount_;
            if (!Int32.TryParse(Product_purchase_field3.Text, out amount_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            product_purchase st = new product_purchase() { id = id_, id_of_purchasing = id_purchase_, amount = amount_, id_raw = id_raw_ };
            if ((from asd in model.product_purchase
                 where asd.id == id_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.product_purchase.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add_record_sales_invoice_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(sales_invoice_field1.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            int id_workshop_;
            if (!Int32.TryParse(sales_invoice_field2.Text, out id_workshop_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (sales_invoice_data.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            sales_invoice st = new sales_invoice() { id_of_sailing = id_, id_workshop = id_workshop_, date_of_sale = Convert.ToDateTime(sales_invoice_data.SelectedDate) };
            if ((from asd in model.sales_invoice
                 where asd.id_of_sailing == id_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.sales_invoice.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add_record_Product_sales_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(Product_sales_field1.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            if (Product_sales_combo1.SelectedItem == null || Product_sales_combo2.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_sales_ = (int)Product_sales_combo1.SelectedItem;
            int id_raw_ = (int)Product_sales_combo2.SelectedItem;
            int amount_;
            if (!Int32.TryParse(Product_sales_field2.Text, out amount_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }
            product_sales st = new product_sales() { id = id_, id_of_sailing = id_sales_, amount = amount_, id_raw = id_raw_ };
            if ((from asd in model.product_sales
                 where asd.id == id_
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.product_sales.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void user_insert_butt_Click(object sender, RoutedEventArgs e)
        {
            if (user_combo1.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            Users st = new Users() { Password = user_field2.Text, Login = user_field1.Text, IsAdmin = (string)user_combo1.SelectedItem == "Пользователь" ? 0 : 1 };
            if ((from asd in model.Users
                 where asd.Login == user_field1.Text
                 select asd).LongCount() > 0 == true)
                MessageBox.Show("Запись уже существует!");
            else
            {
                model.Users.Add(st);
                try
                {
                    model.SaveChanges();
                    ShowTablesItems(null, null);
                    MessageBox.Show("Запись была успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Delete_record_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ComboTables.SelectedItem == null)
            {
                MessageBox.Show("Выберить таблицу!!!");
                return;
            }
            Start_buttons.Visibility = System.Windows.Visibility.Hidden;
            switch ((string)ComboTables.SelectedItem)
            {
                case "Сырье":
                    Raw_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Договор":
                    Contract_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Поставщик":
                    Supp_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Продукция договоров":
                    Product_order_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Приходная накладная":
                    purchase_invoice_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Продукция приходной накладной":
                    Product_purchase_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Расходная накладная":
                    sales_invoice_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Продукция расходной накладной":
                    Product_sales_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "Пользователи":
                    user_delete.Visibility = System.Windows.Visibility.Visible;
                    break;
            }
        }

        private void delete_record_raw_Click(object sender, RoutedEventArgs e)
        {
            int id_raw_;
            if (!Int32.TryParse(field_raw3.Text, out id_raw_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.raw
                 where asd.id_raw == id_raw_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            raw raw = (from asd in model.raw
                       where (asd.id_raw) == id_raw_
                       select asd).First();
            model.raw.Remove(raw);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_supp_Click(object sender, RoutedEventArgs e)
        {
            int id_supp_;
            if (!Int32.TryParse(field_supp3.Text, out id_supp_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.supplier
                 where asd.id_supp == id_supp_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            supplier supp = (from asd in model.supplier
                             where (asd.id_supp) == id_supp_
                             select asd).First();
            model.supplier.Remove(supp);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_contract_Click(object sender, RoutedEventArgs e)
        {
            int id_contract_;
            if (!Int32.TryParse(field_contract2.Text, out id_contract_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.contract
                 where asd.id_contract == id_contract_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            contract contr = (from asd in model.contract
                              where (asd.id_contract) == id_contract_
                              select asd).First();
            model.contract.Remove(contr);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_product_order_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(product_order_field2.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.product_order
                 where asd.id == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            product_order product_order = (from asd in model.product_order
                                           where (asd.id) == id_
                                           select asd).First();
            model.product_order.Remove(product_order);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_purchase_invoice_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(purchase_invoice_field2.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.purchase_invoice
                 where asd.id_of_purchasing == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            purchase_invoice purchase_invoice = (from asd in model.purchase_invoice
                                                 where asd.id_of_purchasing == id_
                                                 select asd).First();
            model.purchase_invoice.Remove(purchase_invoice);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_Product_purchase_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(Product_purchase_field4.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.product_purchase
                 where asd.id == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            product_purchase product_purchase = (from asd in model.product_purchase
                                                 where asd.id == id_
                                                 select asd).First();
            model.product_purchase.Remove(product_purchase);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_sales_invoice_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(sales_invoice_field3.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.sales_invoice
                 where asd.id_of_sailing == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            sales_invoice sales_invoice = (from asd in model.sales_invoice
                                           where asd.id_of_sailing == id_
                                           select asd).First();
            model.sales_invoice.Remove(sales_invoice);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void delete_record_Product_sales_Click(object sender, RoutedEventArgs e)
        {
            int id_;
            if (!Int32.TryParse(Product_sales_field3.Text, out id_))
            {
                MessageBox.Show("Номер должен состоять из цифр!");
                return;
            }

            if ((from asd in model.product_sales
                 where asd.id == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            product_sales product_sales = (from asd in model.product_sales
                                           where asd.id == id_
                                           select asd).First();
            model.product_sales.Remove(product_sales);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void user_delete_butt_Click(object sender, RoutedEventArgs e)
        {
            string id_ = user_field3.Text;

            if ((from asd in model.Users
                 where asd.Login == id_
                 select asd).LongCount() == 0 == true)
            {
                MessageBox.Show("Записи не существует!");
                return;
            }

            Users Users = (from asd in model.Users
                           where asd.Login == id_
                           select asd).First();
            model.Users.Remove(Users);
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно удалена!");
            }
            catch
            {
                MessageBox.Show("Убедитесь что все записи других таблиц связаных с этим ключем были удалены!");
            }
        }

        private void Update_record_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ComboTables.SelectedItem == null)
            {
                MessageBox.Show("Выберить таблицу!!!");
                return;
            }
            Start_buttons.Visibility = System.Windows.Visibility.Hidden;
            switch ((string)ComboTables.SelectedItem)
            {
                case "Сырье":
                    Raw_update.Visibility = System.Windows.Visibility.Visible;
                    var z1 = (from asd in model.raw
                              select asd).ToList();
                    foreach (raw t in z1)
                        raw_combo.Items.Add(t.id_raw);
                    break;
                case "Договор":
                    Contract_update.Visibility = System.Windows.Visibility.Visible;
                    var z3 = (from asd in model.contract
                              select asd).ToList();
                    foreach (contract t in z3)
                        contract_combo1.Items.Add(t.id_contract);
                    var z4 = (from asd in model.supplier
                              select asd).ToList();
                    foreach (supplier t in z4)
                        contract_combo2.Items.Add(t.id_supp);
                    break;
                case "Поставщик":
                    Supp_update.Visibility = System.Windows.Visibility.Visible;
                    var z2 = (from asd in model.supplier
                              select asd).ToList();
                    foreach (supplier t in z2)
                        supp_combo.Items.Add(t.id_supp);
                    break;
                case "Продукция договоров":
                    Product_order_update.Visibility = System.Windows.Visibility.Visible;
                    var z5 = (from asd in model.product_order
                              select asd).ToList();
                    foreach (product_order t in z5)
                        product_order_combo3.Items.Add(t.id);
                    var z6 = (from asd in model.raw
                              select asd).ToList();
                    foreach (raw t in z6)
                        product_order_combo4.Items.Add(t.id_raw);
                    var z7 = (from asd in model.contract
                              select asd).ToList();
                    foreach (contract t in z7)
                        product_order_combo5.Items.Add(t.id_contract);
                    break;
                case "Приходная накладная":
                    purchase_invoice_update.Visibility = System.Windows.Visibility.Visible;
                    var z8 = (from asd in model.purchase_invoice
                              select asd).ToList();
                    foreach (purchase_invoice t in z8)
                        purchase_invoice_combo1.Items.Add(t.id_of_purchasing);
                    var z9 = (from asd in model.supplier
                              select asd).ToList();
                    foreach (supplier t in z9)
                        purchase_invoice_combo2.Items.Add(t.id_supp);
                    break;
                case "Продукция приходной накладной":
                    Product_purchase_update.Visibility = System.Windows.Visibility.Visible;
                    var z10 = (from asd in model.product_purchase
                               select asd).ToList();
                    foreach (product_purchase t in z10)
                        product_purchase_combo3.Items.Add(t.id);
                    var z11 = (from asd in model.raw
                               select asd).ToList();
                    foreach (raw t in z11)
                        product_purchase_combo4.Items.Add(t.id_raw);
                    var z12 = (from asd in model.purchase_invoice
                               select asd).ToList();
                    foreach (purchase_invoice t in z12)
                        product_purchase_combo5.Items.Add(t.id_of_purchasing);
                    break;
                case "Расходная накладная":
                    sales_invoice_update.Visibility = System.Windows.Visibility.Visible;
                    var z13 = (from asd in model.sales_invoice
                               select asd).ToList();
                    foreach (sales_invoice t in z13)
                        sales_invoice_combo1.Items.Add(t.id_of_sailing);
                    break;
                case "Продукция расходной накладной":
                    Product_sales_update.Visibility = System.Windows.Visibility.Visible;
                    var z14 = (from asd in model.product_sales
                               select asd).ToList();
                    foreach (product_sales t in z14)
                        product_sales_combo3.Items.Add(t.id);
                    var z15 = (from asd in model.raw
                               select asd).ToList();
                    foreach (raw t in z15)
                        product_sales_combo4.Items.Add(t.id_raw);
                    var z16 = (from asd in model.sales_invoice
                               select asd).ToList();
                    foreach (sales_invoice t in z16)
                        product_sales_combo5.Items.Add(t.id_of_sailing);
                    break;
                case "Пользователи":
                    user_update.Visibility = System.Windows.Visibility.Visible;
                    var z17 = (from asd in model.Users
                               select asd).ToList();
                    foreach (Users t in z17)
                        user_combo2.Items.Add(t.Login);
                    user_combo3.Items.Add("Пользователь");
                    user_combo3.Items.Add("Администратор");
                    break;
            }
        }

        private void update_record_raw_Click(object sender, RoutedEventArgs e)
        {
            if (raw_combo.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)raw_combo.SelectedItem;
            if (field_raw4.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
                return;
            }
            int prav;
            if (Int32.TryParse(field_raw4.Text, out prav))
            {
                MessageBox.Show("Поле не должно состоять из цыфр!");
                return;
            }
            var st = (from asd in model.raw
                      where asd.id_raw == id_
                      select asd).First();
            if (st != null) st.name_raw = field_raw4.Text;
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_supp_Click(object sender, RoutedEventArgs e)
        {
            if (supp_combo.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)supp_combo.SelectedItem;
            if (field_supp4.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
                return;
            }
            int prav;
            if (Int32.TryParse(field_supp4.Text, out prav))
            {
                MessageBox.Show("Поле не должно состоять из цыфр!");
                return;
            }
            var st = (from asd in model.supplier
                      where asd.id_supp == id_
                      select asd).First();
            if (st != null) st.name_supp = field_supp4.Text;
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_contract_Click(object sender, RoutedEventArgs e)
        {
            if (contract_combo1.SelectedItem == null || contract_combo2.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)contract_combo1.SelectedItem;
            if (contract_data.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            var st = (from asd in model.contract
                      where asd.id_contract == id_
                      select asd).First();
            if (st != null)
            {
                st.id_supp = (int)contract_combo2.SelectedItem;
                st.number_month = contract_data.SelectedDate;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_product_order_Click(object sender, RoutedEventArgs e)
        {
            if (product_order_combo3.SelectedItem == null || product_order_combo4.SelectedItem == null || product_order_combo5.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)product_order_combo3.SelectedItem;
            int prav;
            if (!Int32.TryParse(product_order_field4.Text, out prav))
            {
                MessageBox.Show("Поле должно состоять из цыфр!");
                return;
            }
            var st = (from asd in model.product_order
                      where asd.id == id_
                      select asd).First();
            if (st != null)
            {
                st.id_raw = (int)product_order_combo4.SelectedItem;
                st.id_contaract = (int)product_order_combo5.SelectedItem;
                st.amount = prav;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_purchase_invoice_Click(object sender, RoutedEventArgs e)
        {
            if (purchase_invoice_combo1.SelectedItem == null || purchase_invoice_combo2.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)purchase_invoice_combo1.SelectedItem;
            if (purchase_invoice_data1.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            var st = (from asd in model.purchase_invoice
                      where asd.id_of_purchasing == id_
                      select asd).First();
            if (st != null)
            {
                st.id_of_supp = (int)purchase_invoice_combo2.SelectedItem;
                st.date_of_purchasing = purchase_invoice_data1.SelectedDate;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_product_purchase_Click(object sender, RoutedEventArgs e)
        {
            if (product_purchase_combo3.SelectedItem == null || product_purchase_combo4.SelectedItem == null || product_purchase_combo5.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)product_purchase_combo3.SelectedItem;
            int prav;
            if (!Int32.TryParse(product_purchase_field5.Text, out prav))
            {
                MessageBox.Show("Поле должно состоять из цыфр!");
                return;
            }
            var st = (from asd in model.product_purchase
                      where asd.id == id_
                      select asd).First();
            if (st != null)
            {
                st.id_raw = (int)product_purchase_combo4.SelectedItem;
                st.id_of_purchasing = (int)product_purchase_combo5.SelectedItem;
                st.amount = prav;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_sales_invoice_Click(object sender, RoutedEventArgs e)
        {
            if (sales_invoice_combo1.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int prav;
            if (!Int32.TryParse(sales_invoice_field4.Text, out prav))
            {
                MessageBox.Show("Поле должно состоять из цыфр!");
                return;
            }
            int id_ = (int)purchase_invoice_combo1.SelectedItem;
            if (sales_invoice_data1.SelectedDate == null)
            {
                MessageBox.Show("Выберить дату!");
                return;
            }
            var st = (from asd in model.sales_invoice
                      where asd.id_of_sailing == id_
                      select asd).First();
            if (st != null)
            {
                st.id_workshop = prav;
                st.date_of_sale = Convert.ToDateTime(sales_invoice_data1.SelectedDate);
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_record_product_sales_Click(object sender, RoutedEventArgs e)
        {
            if (product_sales_combo3.SelectedItem == null || product_sales_combo4.SelectedItem == null || product_sales_combo5.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            int id_ = (int)product_sales_combo3.SelectedItem;
            int prav;
            if (!Int32.TryParse(product_sales_field4.Text, out prav))
            {
                MessageBox.Show("Поле должно состоять из цыфр!");
                return;
            }
            var st = (from asd in model.product_sales
                      where asd.id == id_
                      select asd).First();
            if (st != null)
            {
                st.id_raw = (int)product_sales_combo4.SelectedItem;
                st.id_of_sailing = (int)product_sales_combo5.SelectedItem;
                st.amount = prav;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void user_update_butt_Click(object sender, RoutedEventArgs e)
        {
            if (user_combo2.SelectedItem == null || user_combo3.SelectedItem == null)
            {
                MessageBox.Show("Элемент в списке не выбран!");
                return;
            }
            string id_ = (string)user_combo2.SelectedItem;
            var st = (from asd in model.Users
                      where asd.Login == id_
                      select asd).First();
            if (st != null)
            {
                st.Password = user_field4.Text;
                st.IsAdmin = (string)user_combo3.SelectedItem == "Пользователь" ? 0 : 1;
            }
            else
            {
                MessageBox.Show("Записи не существует!");
                return;
            }
            try
            {
                model.SaveChanges();
                ShowTablesItems(null, null);
                MessageBox.Show("Запись была успешно отредактирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

