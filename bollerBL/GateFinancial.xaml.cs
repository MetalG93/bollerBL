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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for GateFinancial.xaml
    /// </summary>
    public partial class GateFinancial : Window
    {
        string[] gates;
        string[] shifts;
        public GateFinancial()
        {
            InitializeComponent();
            loadGates();
            Misc.loadPrices();
            cbxGatge.ItemsSource = gates;
            cbxShift.ItemsSource = shifts;
        }

        private void loadGates()
        {
            StreamReader sr = new StreamReader("gates.csv");

            gates = sr.ReadLine().Split(';');
            shifts = sr.ReadLine().Split(';');

            sr.Close();
        }

        private void BtnNewBox_Click(object sender, RoutedEventArgs e)
        {
            if (cbxBoxType.SelectedIndex != -1)
            {
                GroupBox gb = new GroupBox();

                if (cbxBoxType.SelectedIndex == 0)
                {
                    gb.Header = "Felnőtt jegyek";
                }
                else
                {
                    gb.Header = "Gyerek jegyek";
                }

                StackPanel s = new StackPanel();

                Label handed = new Label();
                handed.Content = "Odaadott";

                Grid handedGrid = new Grid();
                createBoxes(handedGrid);

                Label broughtBack = new Label();
                handed.Content = "Visszahozott";

                Grid broughtBackGrid = new Grid();
                createBoxes(broughtBackGrid);

                s.Children.Add(handed);
                s.Children.Add(handedGrid);
                s.Children.Add(broughtBack);
                s.Children.Add(broughtBackGrid);

                Button btnDelete = new Button();
                btnDelete.Content = "Doboz törlése";
                btnDelete.Click += btnDelete_Click;

                s.Children.Add(btnDelete);

                gb.Content = s;
                ticketBoxes.Children.Add(gb);
            }
            else
                MessageBox.Show("Válassz ki doboz típust!");
        }

        private void createBoxes(Grid g)
        {
            Label label1 = new Label();
            label1.Content = "Kezdő sorszám";
            label1.Margin = new Thickness(10, 10, 0, 0);

            TextBox txtBegin = new TextBox();
            txtBegin.Margin = new Thickness(120, 10, 0, 0);

            Label label2 = new Label();
            label2.Content = "Vége sorszám";
            label2.Margin = new Thickness(230, 10, 0, 0);

            TextBox txtEnd = new TextBox();
            txtEnd.Margin = new Thickness(340, 10, 0, 0);

            g.Children.Add(label1);
            g.Children.Add(txtBegin);
            g.Children.Add(label2);
            g.Children.Add(txtEnd);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ticketBoxes.Children.Remove((GroupBox)((StackPanel)(((Button)e.OriginalSource).Parent)).Parent);
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {

            decimal children = 0;
            decimal adult = 0;
            int taste = int.Parse(txtTastingTicket.Text);
            int raffle = int.Parse(txtRaffle.Text);

            if (ticketBoxes.Children.Count > 0)
            {
                foreach (GroupBox gb in ticketBoxes.Children)
                {
                    StackPanel s = (StackPanel)gb.Content;

                    if (gb.Header.ToString() == "Felnőtt jegyek")
                        adult += (decimal.Parse(((TextBox)((Grid)s.Children[1]).Children[3]).Text) - decimal.Parse(((TextBox)((Grid)s.Children[1]).Children[1]).Text)) - (decimal.Parse(((TextBox)((Grid)s.Children[3]).Children[3]).Text) - decimal.Parse(((TextBox)((Grid)s.Children[3]).Children[1]).Text));
                    else
                        children += (decimal.Parse(((TextBox)((Grid)s.Children[1]).Children[3]).Text) - decimal.Parse(((TextBox)((Grid)s.Children[1]).Children[1]).Text)) - (decimal.Parse(((TextBox)((Grid)s.Children[3]).Children[3]).Text) - decimal.Parse(((TextBox)((Grid)s.Children[3]).Children[1]).Text));
                }
            }

            int money = 0;

            for (int i = 1; i < sMoney.Children.Count; i++)
            {
                money += int.Parse(((TextBox)((Grid)sMoney.Children[i]).Children[1]).Text) * int.Parse(((Label)((Grid)sMoney.Children[i]).Children[0]).Content.ToString());
            }

            try
            {
                if (MessageBox.Show(string.Format("Összes pénz: {0}{1}Hozott pénz: {2}{3}Készítsek nyugtát?", children * Misc.childrenPrice + adult * Misc.adultPrice + taste * Misc.taseTicketPrice + raffle * Misc.rafflePrice, Environment.NewLine, money, Environment.NewLine), string.Format("{0} {1}", gates[cbxGatge.SelectedIndex], shifts[cbxShift.SelectedIndex]), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    createBill(int.Parse(children.ToString()), int.Parse(adult.ToString()), taste, raffle);
            }
            catch (IndexOutOfRangeException)
            { MessageBox.Show("Jelöld ki az értékesítő helyet valamint az időpontot is!"); }

        }

        private void createBill(int children, int adult, int taste, int raffle)
        {
            Font yearFont = FontFactory.GetFont("Arial", 25);
            Font font = FontFactory.GetFont("Arial", 12);
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);

            Document doc = new Document();
            doc.SetPageSize(PageSize.A4);
            string filename = string.Format(@"{0}\{1}.pdf", Misc.PDFpath, string.Format("{0}_{1}", gates[cbxGatge.SelectedIndex], shifts[cbxShift.SelectedIndex].Replace(':', '.')));
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            writer.Open();
            doc.Open();

            PdfPTable icon = new PdfPTable(1);

            PdfPCell iconCell = new PdfPCell();
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("ikon.png");
            img.ScaleAbsolute(100, 100);
            iconCell.AddElement(img);
            iconCell.Border = PdfPCell.NO_BORDER;
            iconCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            icon.AddCell(iconCell);
            doc.Add(icon);

            PdfPTable yearTable = new PdfPTable(1);

            PdfPCell yerarNum = new PdfPCell(new Phrase(string.Format("BÖLLÉR BL {0}", DateTime.Today.Year), yearFont));
            yerarNum.Border = PdfPCell.NO_BORDER;
            yerarNum.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            yearTable.AddCell(yerarNum);
            doc.Add(yearTable);


            PdfPTable emptyTable = new PdfPTable(1);

            PdfPCell emptyCell = new PdfPCell(new Phrase(" ", font));
            emptyCell.Border = PdfPCell.NO_BORDER;

            emptyTable.AddCell(emptyCell);
            doc.Add(emptyTable);

            PdfPTable preTicekt = new PdfPTable(6);
            preTicekt.PaddingTop = PageSize.A4.Height / 3;
            /*preTicekt.AddCell(new PdfPCell(new Phrase("Kóstolójegy: ")));
            preTicekt.AddCell(new PdfPCell(new Phrase(taste)));
            preTicekt.AddCell(new PdfPCell(new Phrase("Tombola: ")));
            preTicekt.AddCell(new PdfPCell(new Phrase(raffle)));*/

            PdfPCell typeCell = new PdfPCell();
            typeCell.Border = PdfPCell.NO_BORDER;
            typeCell.Colspan = 5;

            PdfPCell numCell = new PdfPCell();
            numCell.Border = PdfPCell.NO_BORDER;

            typeCell.Phrase = new Phrase("Kóstolójegy");
            preTicekt.AddCell(typeCell);

            numCell.Phrase = new Phrase(taste.ToString());
            preTicekt.AddCell(numCell);

            typeCell.Phrase = new Phrase("Tombola");
            preTicekt.AddCell(typeCell);

            numCell.Phrase = new Phrase(raffle.ToString());
            preTicekt.AddCell(numCell);

            doc.Add(preTicekt);

            PdfPTable ticketTable = new PdfPTable(6);
            ticketTable.PaddingTop = PageSize.A4.Height * 2 / 3;

            PdfPCell ticketType = new PdfPCell(new Phrase("Felnőtt jegyek"));
            ticketType.Border = PdfPCell.NO_BORDER;
            ticketType.Colspan = 5;
            ticketTable.AddCell(ticketType);

            PdfPCell ticketNum = new PdfPCell(new Phrase(adult.ToString()));
            ticketNum.Border = PdfPCell.NO_BORDER;            
            ticketTable.AddCell(ticketNum);

            ticketType.Phrase = new Phrase("Gyerek jegyek");
            ticketTable.AddCell(ticketType);

            ticketNum.Phrase = new Phrase(children.ToString());
            ticketTable.AddCell(ticketNum);

            doc.Add(ticketTable);

            doc.Close();
            writer.Close();
            //MessageBox.Show("PDF készítése sikeres!");
            System.Diagnostics.Process.Start(filename);
        }
    }
}