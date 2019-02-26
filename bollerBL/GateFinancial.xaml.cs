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
        string[] gates = { "1. kapu", "2. kapu", "3. kapu" };
        string[] shifts = { "6:00-10:00", "10:00-14:00", "14:00-18:00", "18:00-22:00" };
        public GateFinancial()
        {
            InitializeComponent();
            cbxGatge.ItemsSource = gates;
            cbxShift.ItemsSource = shifts;
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

                Grid g = new Grid();
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

                Button btnDelete = new Button();
                btnDelete.HorizontalAlignment = HorizontalAlignment.Left;
                btnDelete.VerticalAlignment = VerticalAlignment.Top;
                btnDelete.Margin = new Thickness(450, 10, 0, 0);
                btnDelete.Content = "Doboz törlése";
                btnDelete.Width = 100;
                btnDelete.Height = 25;
                btnDelete.Click += btnDelete_Click;

                g.Children.Add(label1);
                g.Children.Add(txtBegin);
                g.Children.Add(label2);
                g.Children.Add(txtEnd);
                g.Children.Add(btnDelete);
                gb.Content = g;
                ticketBoxes.Children.Add(gb);
            }
            else
                MessageBox.Show("Válassz ki doboz típust!");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ticketBoxes.Children.Remove((GroupBox)((Grid)(((Button)e.OriginalSource).Parent)).Parent);
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            decimal children = 0;
            decimal adult = 0;

            foreach (GroupBox gb in ticketBoxes.Children)
            {
                Grid g = (Grid)gb.Content;

                if (gb.Header.ToString() == "Felnőtt jegyek")
                    adult += decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text);
                else
                    children += decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text);
            }

            int money = 0;

            for (int i = 1; i < sMoney.Children.Count; i++)
            {
                money += int.Parse(((TextBox)((Grid)sMoney.Children[i]).Children[1]).Text) * int.Parse(((Label)((Grid)sMoney.Children[i]).Children[0]).Content.ToString());
            }

            if (MessageBox.Show(string.Format("Összes pénz: {0}{1}Hozott pénz: {2}{3}Készítsek nyugtát?", children * Misc.childrenPrice + adult * Misc.adultPrice, Environment.NewLine, money, Environment.NewLine), string.Format("{0}{1}", gates[cbxGatge.SelectedIndex], shifts[cbxShift.SelectedIndex]), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                createBill();
        }

        private void createBill()
        {
            Font yearFont = FontFactory.GetFont("Arial", 25);
            Font font = FontFactory.GetFont("Arial", 12);
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);

            Document doc = new Document();
            doc.SetPageSize(PageSize.A4);
            string filename = string.Format(@"{0}\{1}.pdf", Misc.PDFpath, string.Format("{0}_{1}", gates[cbxGatge.SelectedIndex], shifts[cbxShift.SelectedIndex].Replace(':','.')));
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

            PdfPTable ticketTable = new PdfPTable(6);

            PdfPCell ticketType = new PdfPCell(new Phrase("Felnőtt jegyek"));
            ticketType.Border = PdfPCell.NO_BORDER;
            ticketType.Colspan = 6;

            ticketTable.AddCell(ticketType);

            foreach (GroupBox gb in ticketBoxes.Children)
            {
                if (gb.Header.ToString() == "Felnőtt jegyek")
                {
                    Grid g = (Grid)gb.Content;

                    PdfPCell pdfPCell = new PdfPCell();
                    pdfPCell.Border = PdfPCell.NO_BORDER;

                    for (int i = 0; i < g.Children.Count; i++)
                    {
                        
                        if (g.Children[i] is Label)
                        {
                            pdfPCell.Phrase = new Phrase(((Label)g.Children[i]).Content.ToString());
                            ticketTable.AddCell(pdfPCell);
                        }

                        if (g.Children[i] is TextBox)
                        {
                            pdfPCell.Phrase = new Phrase(((TextBox)g.Children[i]).Text);
                            ticketTable.AddCell(pdfPCell);
                        }
                    }
                    pdfPCell.Phrase = new Phrase("Eladott jegyek száma:");
                    ticketTable.AddCell(pdfPCell);

                    pdfPCell.Phrase = new Phrase((decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text)).ToString());
                    ticketTable.AddCell(pdfPCell);
                }
            }

            doc.Add(ticketTable);

            ticketTable.DeleteBodyRows();

            

            ticketType.Phrase = new Phrase("Gyerek jegyek");
            ticketTable.AddCell(ticketType);

            foreach (GroupBox gb in ticketBoxes.Children)
            {
                if (gb.Header.ToString() == "Gyerek jegyek")
                {
                    Grid g = (Grid)gb.Content;

                    PdfPCell pdfPCell = new PdfPCell();
                    pdfPCell.Border = PdfPCell.NO_BORDER;

                    for (int i = 0; i < g.Children.Count; i++)
                    {
                        
                        if (g.Children[i] is Label)
                        {
                            pdfPCell.Phrase = new Phrase(((Label)g.Children[i]).Content.ToString());
                            ticketTable.AddCell(pdfPCell);
                        }

                        if (g.Children[i] is TextBox)
                        {
                            pdfPCell.Phrase = new Phrase(((TextBox)g.Children[i]).Text);
                            ticketTable.AddCell(pdfPCell);
                        }
                    }

                    pdfPCell.Phrase = new Phrase("Eladott jegyek száma:");
                    ticketTable.AddCell(pdfPCell);

                    pdfPCell.Phrase = new Phrase((decimal.Parse(((TextBox)g.Children[3]).Text) - decimal.Parse(((TextBox)g.Children[1]).Text)).ToString());
                    ticketTable.AddCell(pdfPCell);
                }
            }
            doc.Add(ticketTable);

            doc.Close();
            writer.Close();
            //MessageBox.Show("PDF készítése sikeres!");
            System.Diagnostics.Process.Start(filename);
        }
    }
}
