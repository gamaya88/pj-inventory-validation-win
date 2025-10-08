using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Report
{
    internal class ActaInventario : IDocument
    {
        private readonly string _titulo;
        private readonly string[] _columnas;
        private readonly List<string[]> _filas;

        public ActaInventario(string titulo, string[] columnas, List<string[]> filas)
        {
            _titulo = titulo;
            _columnas = columnas;
            _filas = filas;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(30);
                page.Header().Text(_titulo).AlignCenter().Bold().FontSize(18).FontColor(Colors.Black);
                page.Content()

            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Spacing(20);

                x.Item().Table(table =>
                {
                    // --- Definir las columnas de la tabla ---
                    table.ColumnsDefinition(columns =>
                    {
                        for (int i = 0; i < _columnas.Length; i++)
                        {
                            if (i == 0)
                            {
                                columns.ConstantColumn(20);
                            }
                            else if (i == 2)
                            {
                                columns.ConstantColumn(55);
                            }
                            else if (i == 3)
                            {
                                columns.ConstantColumn(40);
                            }
                            else if (i == 4)
                            {
                                columns.ConstantColumn(77);
                            }
                            else if (i == 5)
                            {
                                columns.ConstantColumn(112);
                            }
                            else if (i == 6)
                            {
                                columns.ConstantColumn(84);
                            }
                            else if (i == 7)
                            {
                                columns.ConstantColumn(70);
                            }
                            else
                            {
                                columns.RelativeColumn();
                            }                                
                        }
                    });

                    // --- Encabezados de la tabla ---
                    table.Header(header =>
                    {
                        foreach (var columna in _columnas)
                        {
                            header.Cell().Element(CellStyle).Text(columna).FontSize(8);
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold())
                                .PaddingVertical(5)
                                .BorderBottom(1)
                                .BorderColor(Colors.Black);
                        }
                    });

                    // --- Filas de la tabla ---
                    foreach (var fila in _filas)
                    {
                        foreach (var celda in fila)
                        {
                            table.Cell().Element(CellStyle).Text(celda).FontSize(8).FontFamily("Calibri");
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.Border(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                        }
                    }
                });
            });
            });
        }

        static IContainer CellStyle(IContainer container)
        {
            return container
                .PaddingVertical(5)
                .PaddingHorizontal(2)
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2);
        }
    }
}
