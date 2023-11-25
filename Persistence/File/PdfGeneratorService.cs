using Application.Dtos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Persistence.File
{

    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task<bool> GeneratePdf(string fileName, string title, IEnumerable<SubjectTimeTableDto> data, List<string> columns)
        {
            bool downloaded = false;
            try
            {
                //Create a new document
                Document document = new Document();

                //Create a PDF writer
                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                FileStream file = new FileStream(downloadsFolder + @"\" + fileName, FileMode.Create);
                PdfWriter.GetInstance(document, file);

                //Open the document
                document.Open();

                //Add a title
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph titleParagraph = new Paragraph(title, titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(titleParagraph);

                //Add some text
                //Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                //Paragraph bodyParagraph = new Paragraph(body, bodyFont);
                var arial = FontFactory.GetFont("Arial", 8, BaseColor.Black);
                Table table = new Table(5, data.Count());
                table.Alignment = Element.ALIGN_CENTER;
                table.Cellpadding = 5;
                foreach (var column in columns)
                {
                    table.AddCell(new Phrase(column.ToString(), arial));
                }
                foreach (var item in data)
                {

                    table.AddCell(new Phrase(item.SubjectDto.Name.ToString(), arial));
                    table.AddCell(new Phrase(item.StartDate.ToString(), arial));
                    table.AddCell(new Phrase(item.StartTime.ToString(), arial));
                    table.AddCell(new Phrase(item.Duration.ToString(), arial));
                    table.AddCell(new Phrase(item.Location.ToString(), arial));
                }

                table.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(table);

                //Close the document
                document.Close();

                downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                var pdfPath = Path.Combine(downloadsFolder, fileName);
                downloaded = true;
                file.Close();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
             return downloaded;
            
        }
    }
}
