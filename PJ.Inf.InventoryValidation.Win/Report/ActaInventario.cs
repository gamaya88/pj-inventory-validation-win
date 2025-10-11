using PJ.Inf.InventoryValidation.Win.Model.Views;
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
        private readonly PersonaView _persona;

        public DateTime FechaGeneracion { get; private set; }

        public ActaInventario(string titulo, string[] columnas, List<string[]> filas, PersonaView persona)
        {
            _titulo = titulo;
            _columnas = columnas;
            _filas = filas;
            _persona = persona;
            FechaGeneracion = DateTime.Now;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(20);
                page.Header().Text(_titulo).AlignCenter().Bold().FontSize(18).FontColor(Colors.Black);
                page.Footer().Text(FechaGeneracion.ToString("dd/MM/yy HH:mm")).AlignLeft().Bold().FontSize(8).FontColor(Colors.Black);
                page.Content()

            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Item().Table(datosActa =>
                {
                    datosActa.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(100);
                        columns.ConstantColumn(200);
                        columns.ConstantColumn(100);
                        columns.ConstantColumn(200);
                    });

                    static IContainer CellStyle(IContainer container)
                    {
                        return container
                        .AlignMiddle()
                        .PaddingVertical(2)
                        .PaddingHorizontal(2)
                        .BorderColor(Colors.Black);
                    }

                    datosActa.Cell().Element(CellStyle).Text("CORTE:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.PerDescripcionCorte).FontSize(8).FontFamily("Calibri");
                    datosActa.Cell().Element(CellStyle).Text("LOCAL:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.SedDescripcion).FontSize(8).FontFamily("Calibri");

                    datosActa.Cell().Element(CellStyle).Text("DEPENDENCIA:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.DepParentDescripcion).FontSize(8).FontFamily("Calibri");
                    datosActa.Cell().Element(CellStyle).Text("DIRECCIÓN DEL LOCAL:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.SedDireccion).FontSize(8).FontFamily("Calibri");

                    datosActa.Cell().Element(CellStyle).Text("OFICINA:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.DepDescripcion).FontSize(8).FontFamily("Calibri");
                    datosActa.Cell().Element(CellStyle).Text("DEPARTAMENTO:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.SedDepartamento).FontSize(8).FontFamily("Calibri");

                    datosActa.Cell().Element(CellStyle).Text("PROVINCIA").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.SedProvincia).FontSize(8).FontFamily("Calibri");
                    datosActa.Cell().Element(CellStyle).Text("DISTRITO:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.SedDistrito).FontSize(8).FontFamily("Calibri");

                    datosActa.Cell().Element(CellStyle).Text("APELLIDOS Y NOMBRES):").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.PerNombreLargo).FontSize(8).FontFamily("Calibri");
                    datosActa.Cell().Element(CellStyle).Text("DNI:").FontSize(8).FontFamily("Calibri").Bold();
                    datosActa.Cell().Element(CellStyle).Text(_persona.PerNumeroDocumento).FontSize(8).FontFamily("Calibri");
                });

                x.Spacing(10);

                x.Item().Table(tDetalle =>
                {
                    // --- Definir las columnas de la tabla ---
                    tDetalle.ColumnsDefinition(columns =>
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
                    tDetalle.Header(header =>
                    {
                        foreach (var columna in _columnas)
                        {
                            header.Cell().Element(CellStyle).Text(columna).Bold().FontSize(8);
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container
                                .Background(Colors.Grey.Lighten2)
                                .Border((float)0.5)                                
                                .AlignMiddle()
                                .PaddingVertical(2)
                                .PaddingHorizontal(2)
                                .BorderColor(Colors.Black);
                        }
                    });

                    // --- Filas de la tabla ---
                    foreach (var fila in _filas)
                    {
                        foreach (var celda in fila)
                        {
                            tDetalle.Cell().Element(CellStyle).Text(celda).FontSize(8).FontFamily("Calibri");
                        }

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.Border((float)0.5)
                            .AlignMiddle()
                            .PaddingVertical(2)
                            .PaddingHorizontal(2)
                            .BorderColor(Colors.Black);
                        }
                    }
                });
            });
            });
        }

        static IContainer CellStyle(IContainer container)
        {
            return container
                .PaddingVertical(2)
                .PaddingHorizontal(2)
                .BorderBottom(1)
                .BorderColor(Colors.Black);
        }
    }
}
